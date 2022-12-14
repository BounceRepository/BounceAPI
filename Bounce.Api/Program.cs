using Bounce.Services.Implementation.Cryptography;
using Bounce.Services.Implementation.Jwt;
using Bounce.Services.Implementation.Services.Admin;
using Bounce.Services.Implementation.Services.Auth;
using Bounce.Services.Implementation.Services.Hepler;
using Bounce.Services.Implementation.Services.Patient;
using Bounce_Application.Cryptography.Hash;
using Bounce_Application.DTO.ServiceModel;
using Bounce_Application.Persistence.Interfaces.Admin;
using Bounce_Application.Persistence.Interfaces.Auth;
using Bounce_Application.Persistence.Interfaces.Auth.Jwt;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Patient;
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
builder.Services.AddSingleton<AdminLogger>(); 
builder.Services.AddSingleton<FileManager>();

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
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
    var superAdminExist =await userManager.FindByNameAsync(superAdminUser.UserName);
    if(superAdminExist == null)
    {
        if (! await roleManager.RoleExistsAsync(UserRoles.SuperAdministrator))
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
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

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
