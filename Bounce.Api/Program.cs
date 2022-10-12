
using Bounce.Bounce_Application.Settings;
using Bounce.Services.Implementation.Cryptography;
using Bounce.Services.Implementation.Jwt;
using Bounce.Services.Implementation.Services;
using Bounce.Services.Implementation.Services.Admin;
using Bounce.Services.Implementation.Services.Articles;
using Bounce.Services.Implementation.Services.Auth;
using Bounce.Services.Implementation.Services.Hepler;
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
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.Persistence.Interfaces.Payment;
using Bounce_Application.Persistence.Interfaces.Therapist;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_Applucation.DTO.Auth;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
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

builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddXmlSerializerFormatters();
builder.Services.Configure<SmtpConfiguration>(configuration.GetSection("SmtpConfiguration"));
builder.Services.AddScoped<IAuthenticationServivce, AuthenticationServivce>();
builder.Services.AddScoped<IJwtFactory, JwtFactory>();
builder.Services.AddScoped<ICryptographyService, CryptographyService>();
builder.Services.AddScoped<IEmalService, EmailService>();
builder.Services.AddScoped<IPatientServices, PatientServices>();
builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddScoped<IBankAccountDetailServices, BankAccountDetailServices>();
builder.Services.AddScoped<ITherapistServices, TherapistServices>();
builder.Services.AddScoped<IArticleServices, ArticleServices>();
builder.Services.AddScoped<IPaymentServices, PaymentServices>();
builder.Services.AddScoped<SessionManager>();
builder.Services.AddScoped<BaseServices>();
builder.Services.AddSingleton<AdminLogger>();
builder.Services.AddSingleton<FileManager>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<FlutterWaveSetting>(flutterSettindSection);
builder.Services.AddSession();

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer( "Bearer", options =>
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
});
builder.Services.Configure<JwtIssuerOptions>(configuration.GetSection("JwtIssuerOptions"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


try
{
    using var scope = app.Services.CreateScope();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    var superAdminUser = new ApplicationUser
    {
        UserName = "SuperAdmin",
        Email = configuration["SuperAdminEmail"]
    };
    //var context = scope.ServiceProvider.GetRequiredService<BounceDbContext>();
    var superAdminExist = await userManager.FindByNameAsync(superAdminUser.UserName);
    if (superAdminExist == null)
    {
        if (!await roleManager.RoleExistsAsync(UserRoles.SuperAdministrator))
            await roleManager.CreateAsync(new ApplicationRole { Name = UserRoles.SuperAdministrator });

        var result = await userManager.CreateAsync(superAdminUser, "SuperAdminPassword");
        var role = await userManager.AddToRoleAsync(superAdminUser, UserRoles.SuperAdministrator);
    }
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
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
app.UseStaticFiles();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Bounce}/{action=Index}/{id?}");
});
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
//    RequestPath = new PathString("/Resources")
//});

app.MapControllers();
app.Run();