
using Bounce.Api.ChatHub;
using Bounce.Api.Filter;
using Bounce.Api.PipeLine;
using Bounce.Bounce_Application.Settings;
using Bounce.Job;
using Bounce.Services.Implementation.Cryptography;
using Bounce.Services.Implementation.Jwt;
using Bounce.Services.Implementation.Services;
using Bounce.Services.Implementation.Services.Admin;
using Bounce.Services.Implementation.Services.Articles;
using Bounce.Services.Implementation.Services.Auth;
using Bounce.Services.Implementation.Services.Communication;
using Bounce.Services.Implementation.Services.FilesManager;
using Bounce.Services.Implementation.Services.Hepler;
using Bounce.Services.Implementation.Services.Journal;
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
using Bounce_Application.Persistence.Interfaces.Communication;
using Bounce_Application.Persistence.Interfaces.FilesManager;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Journal;
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
namespace Microsoft.AspNetCore.Builder
{
    public static class IServiceExtension
    {

        public static void ApplicationServices(this WebApplicationBuilder builder)
        {
           
            builder.Services.AddScoped<IAuthenticationServivce, AuthenticationServivce>();
            builder.Services.AddScoped<IJwtFactory, JwtFactory>();
            builder.Services.AddScoped<ICryptographyService, CryptographyService>();
            builder.Services.AddScoped<IEmalService, EmailService>();
            builder.Services.AddScoped<IPatientServices, PatientServices>();
            builder.Services.AddScoped<IAdminServices, AdminServices>();
            builder.Services.AddScoped<ITherapistServices, TherapistServices>();
            builder.Services.AddScoped<IArticleServices, ArticleServices>();
            builder.Services.AddScoped<IPaymentServices, PaymentServices>();
            builder.Services.AddScoped<INotificationService, NotificationService>(); 
            builder.Services.AddScoped<IJournalServices, JournalServices>();
            builder.Services.AddScoped<IFileManagerServices, FileManagerServices>();
            builder.Services.AddScoped<ICommunicationServices, CommunicationServices>();
            builder.Services.AddDistributedMemoryCache();


            //Job JobScheduler
            builder.Services.AddScoped<IJobScheduler, JobScheduler>();
            builder.Services.AddScoped<BaseJobScheduler>();
            //builder.Services.AddSingleton<IHubContext<BounceChatHub>>();
            builder.Services.AddScoped<SessionManager>();
            builder.Services.AddScoped<BaseServices>();
            builder.Services.AddSingleton<AdminLogger>();
            builder.Services.AddSingleton<FileManager>();
            builder.Services.Configure<IPWhitelistOptions>(builder.Configuration.GetSection("IPWhitelistOptions"));
            builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    var responseObj = new
                    {
                        server = "ThrivX API",
                        path = context.HttpContext.Request.Path.ToString(),
                        method = context.HttpContext.Request.Method,
                        controller = (context.ActionDescriptor as ControllerActionDescriptor)?.ControllerName,
                        action = (context.ActionDescriptor as ControllerActionDescriptor)?.ActionName,
                        errors = context.ModelState.Keys.Select(k =>
                        {
                            return new
                            {
                                field = k,
                                Messages = context.ModelState[k]?.Errors.Select(e => e.ErrorMessage)
                            };
                        })
                    };

                    return new BadRequestObjectResult(responseObj);
                };
            });




        }
    }
}
