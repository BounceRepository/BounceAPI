
using Bounce.Api.ChatHub;
using Bounce.Api.Filter;
using Bounce.Bounce_Application.Settings;
using Bounce.Job;
using Bounce.Services.Implementation.Cryptography;
using Bounce.Services.Implementation.Jwt;
using Bounce.Services.Implementation.Services;
using Bounce.Services.Implementation.Services.Admin;
using Bounce.Services.Implementation.Services.Articles;
using Bounce.Services.Implementation.Services.Auth;
using Bounce.Services.Implementation.Services.Hepler;
using Bounce.Services.Implementation.Services.Notification;
using Bounce.Services.Implementation.Services.Patient;
using Bounce.Services.Implementation.Services.Payment;
using Bounce.Services.Implementation.Services.Therapist;
using Bounce_Application.Cryptography.Hash;
using Bounce_Application.DTO.ServiceModel;
using Bounce_Application.Persistence.Interfaces.Admin;
using Bounce_Application.Persistence.Interfaces.Articles;
using Bounce_Application.Persistence.Interfaces.Auth;
using Bounce_Application.Persistence.Interfaces.Auth.Jwt;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.Persistence.Interfaces.Payment;
using Bounce_Application.Persistence.Interfaces.Therapist;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_Applucation.DTO.Auth;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Hangfire;
using MessagePack;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var flutterSettindSection = configuration.GetSection("FlutterWaveSetting");


builder.Services.AddDbContext<BounceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BounceDatabase")));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<BounceDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<FlutterWaveSetting>(flutterSettindSection);
builder.Services.AddSession();
/*AddMessagePackProtocol();*/
//builder.Services.AddSignalR();
    //.AddMessagePackProtocol(options =>
    //{
    //    options.SerializerOptions = MessagePackSerializerOptions.Standard
    //        .WithResolver(MessagePack.Resolvers.StandardResolver.Instance)
    //        .WithSecurity(MessagePackSecurity.UntrustedData);
    //});

builder.ApplicationServices();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bounce", Version = "v1" });
});
builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(configuration.GetConnectionString("BounceDatabase"));
});
builder.Services.AddHangfireServer();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer("Bearer", options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        //ValidAudience = configuration["JWT:ValidAudience"],
        //ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Secret"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            // If the request is for our hub...
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/hubs/chat")))
            {
                // Read the token out of the query string
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});
builder.Services.Configure<JwtIssuerOptions>(configuration.GetSection("JwtIssuerOptions"));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddXmlSerializerFormatters();
builder.Services.Configure<SmtpConfiguration>(configuration.GetSection("SmtpConfiguration"));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
            //.WithOrigins("https://localhost:44362/")
                .AllowAnyHeader()
               
                .AllowAnyMethod();

                //.WithMethods("GET", "POST")
             
        });
});
builder.Services.AddSignalR();

var app = builder.Build();
using var scope = app.Services.CreateScope();



try
{
   

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    var superAdminUser = new ApplicationUser
    {
        UserName = "Admin",
        Email = configuration["Devsbounce@gmail.com"]
    };
    var superAdminExist = await userManager.FindByNameAsync(superAdminUser.UserName);
    if (superAdminExist == null)
    {
        if (!await roleManager.RoleExistsAsync(UserRoles.SuperAdministrator))
            await roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.SuperAdministrator });

        var result = await userManager.CreateAsync(superAdminUser, "Admin160@");
        var role = await userManager.AddToRoleAsync(superAdminUser, UserRoles.SuperAdministrator);
        
    }
}
catch (Exception ex)
{
    throw new ArgumentOutOfRangeException(ex.Message);
    Console.WriteLine("Error from startUp class: " + ex.Message);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
 
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
//app.UseStaticFiles();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Bounce}/{action=Index}/{id?}");

    endpoints.MapHangfireDashboard();
    endpoints.MapHub<BounceChatHub>("/chat");
});



var options = new BackgroundJobServerOptions
{
    ServerName = String.Format(
        "{0}.{1}",
        Environment.MachineName,
        Guid.NewGuid().ToString())
};

var server = new BackgroundJobServer(options);
app.UseHangfireServer(/*options*/);
app.UseCors();
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
//    RequestPath = new PathString("/Resources")
//});
//app.UseMiddleware<EncryptionMiddleware>();
app.MapControllers();
var _jobScheduler = scope.ServiceProvider.GetRequiredService<IJobScheduler>();
app.AddCronJob(_jobScheduler);
//app.MapHub<BounceChatHub>("/chat");


app.Run();