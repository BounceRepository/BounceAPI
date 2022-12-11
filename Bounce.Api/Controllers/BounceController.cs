using Bounce_Application.Cryptography.Hash;
using Bounce_Application.DTO;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bounce.Api.Controllers
{
    public class BounceController : Controller
    {
        private readonly ICryptographyService _cryptographyService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AdminLogger _adminLogger;
        private readonly IHttpContextAccessor contextAccessor;
        private static string EmailConfrimationUrl = "Bounce/ConfirmEmail";
        private readonly IEmalService _EmailService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        protected readonly BounceDbContext _context;

        public string rootPath { get; set; }
        public BounceController(ICryptographyService cryptographyService, UserManager<ApplicationUser> userManager, AdminLogger adminLogger, IHttpContextAccessor contextAccessor, IEmalService emailService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, BounceDbContext context)
        {
            _cryptographyService = cryptographyService;
            _userManager = userManager;
            _adminLogger = adminLogger;
            this.contextAccessor = contextAccessor;
            _EmailService = emailService;
            _hostingEnvironment = hostingEnvironment;
            rootPath = _hostingEnvironment.ContentRootPath;
            _context = context;
        }

        //public IActionResult ConfirmEmail()
        //{
        //    return View();
        //}


        public async Task< IActionResult> ConfirmEmail(string token, string email)
        {
            var emailValue = "";
            var model = new EmailLinkViewModel();
            try
            {
                
                    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
                    {
                        model.Status = ConfrimationStatus.InvalidLink;
                        return View(model);
                    }

                _adminLogger.LogRequest($"{"Task started for email confirmation}"}{" - "}{email}{" - "}{DateTime.Now}", false);

                var message = "";
                var decryptedValue = _cryptographyService.Base64Decode(email);

          
                if (string.IsNullOrEmpty(decryptedValue))
                {
                    model.Status = ConfrimationStatus.InvalidLink;
                    return View(model);
                }
                 emailValue = decryptedValue.Split('^')[0];
                var timeValue = decryptedValue.Split('^')[1];
                var absoluteTime = DateTime.Parse(timeValue);

                var respnseValue = Uri.UnescapeDataString(token);
                if (respnseValue.Contains(" "))
                    token = respnseValue.Replace(" ", "+");


                if ((DateTime.Now - absoluteTime).TotalHours > 1)
                {
                    model.Status = ConfrimationStatus.LinkExpired;
                    return View(model);
                }

                var user = await _userManager.FindByEmailAsync(emailValue);

                if(user.EmailConfirmed)
                {
                    model.Status = ConfrimationStatus.EmailConfirmedlreday;
                    return View(model);
                }
                //token = "CfDJ8AADAIgM2BxMoVE/94jBvoc2abMG+lx5+TL/emYOgSu0lYe4j/AYNXRKv9AU+t0hCiQb7zmDqTEEGLRUx7dBiJIz0Vk+ZjXykE/GI2h6iJJT8aXbfJ3brqp3uq689urh+AX0K8VVJL0sR55PsILMbT94Ro10yJRetmng+bQGanY53iSDXsWtuwHDp9JzK3b9zA==";
                IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
                
                if (result.Succeeded)
                {
                    var wallet = new Wallet
                    {
                        UserId = user.Id,
                        Balance = 0,
                        ReferalBonus = 0,
                        DateCreated = DateTime.Now
                    };
                    _context.Add(wallet);
                    _context.SaveChanges();
                    var emailRequest = new EmailRequest
                    {
                        To = model.Key,
                        Body = EmailFormatter.FormatEmailResponse("", rootPath),
                        Subject = "Email Confirmation"
                    };

                    await _EmailService.SendMail(emailRequest);

                    model.Status = ConfrimationStatus.Confirmed;
                    return View(model);
                }

                model.Status = ConfrimationStatus.Failed;
                return View(model);
            }
            catch(Exception ex)
            {
                _adminLogger.LogRequest($"{"internal server error occured while confirming the email}"}{ex}{" - "}{emailValue}{" - "}{DateTime.Now}", false);
                model.Status = ConfrimationStatus.Exception;
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(EmailLinkViewModel model)
        {
            try
            {
                var emailModel = new EmailLinkViewModel();
                var user = await _userManager.FindByEmailAsync(model.Key);
                if (user == null)
                {
                    model.Status = ConfrimationStatus.InvaidUser;

                    return View(model);
                }

                if (user.EmailConfirmed)
                {
                    model.Status = ConfrimationStatus.EmailConfirmedlreday;
                    return View(model);
                }

                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var time = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                var delimiter = $"{model.Key}^{time}";
                var email = _cryptographyService.Base64Encode(delimiter);


                var scheme = contextAccessor.HttpContext.Request.Scheme;
                var host = contextAccessor.HttpContext.Request.Host.Value;

                var fileurl = $"{scheme}://{host}/{EmailConfrimationUrl}";
                var baseUrl = $"{fileurl}?token={confirmationToken}&email={email}";

                var emailRequest = new EmailRequest
                {

                    To = model.Key,
                    Body = EmailFormatter.FormatEmaiConfimation(baseUrl, rootPath),
                    Subject = "Email Confirmation"
                };

                await _EmailService.SendMail(emailRequest);

                return RedirectToAction(nameof(EmailResponse));

            }
            catch (Exception ex)
            {
                _adminLogger.LogRequest($"{"internal server error occured while generating email confrimation link}"}{ex}{" - "}{JsonConvert.SerializeObject(model)}{" - "}{DateTime.Now}", false);
                model.Status = ConfrimationStatus.Exception;
                return View();
            }
        }

        public IActionResult EmailResponse()
        {
            return View();
        }
    }
}
