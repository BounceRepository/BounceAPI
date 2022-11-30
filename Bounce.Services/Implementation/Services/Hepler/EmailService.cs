using Bounce_Application.Cryptography.Hash;
using Bounce_Application.DTO;
using Bounce_Application.DTO.ServiceModel;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.SeriLog;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Hepler
{
    public class EmailService : IEmalService
    {
        private readonly IConfiguration configuration;
        private readonly ICryptographyService _cryptographyService;
        private readonly SmtpConfiguration _smtpConfiguration;
        private IHttpContextAccessor contextAccessor;
        private readonly AdminLogger _adminLogger;
        private readonly BounceDbContext _bounceDbContext;

        public EmailService(IConfiguration configuration, IOptions<SmtpConfiguration> smtpConfiguration, IHttpContextAccessor contextAccessor, AdminLogger adminLogger, ICryptographyService cryptographyService, BounceDbContext bounceDbContext)
        {
            this.configuration = configuration;
            _smtpConfiguration = smtpConfiguration.Value;
            this.contextAccessor = contextAccessor;
            _adminLogger = adminLogger;
            _cryptographyService = cryptographyService;
            _bounceDbContext = bounceDbContext;
        }




        public async Task<bool> SendMail(EmailRequest emailRequest)
        {
            try
            {
                //var key1 = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
                var sender = _cryptographyService.Base64Decode(_smtpConfiguration.sendgridSender);
                var key = _cryptographyService.Base64Decode(_smtpConfiguration.sendgridKey);
                using var message = new MailMessage();
                message.From = new MailAddress(sender, _smtpConfiguration.sendgridName);

                message.IsBodyHtml = true;
                message.To.Add(new MailAddress(emailRequest.To, "Bounce Online"));
                message.Body = emailRequest.Body;

                message.Subject = emailRequest.Subject;
                if (emailRequest.Attachments.Count > 0)
                {
                    foreach (var attachment in emailRequest.Attachments)
                    {
                        string fileName = Path.GetFileName(attachment.FileName);
                        message.Attachments.Add(new System.Net.Mail.Attachment(attachment.OpenReadStream(), fileName));
                    }
                }

                using var client = new SmtpClient(host: "smtp.sendgrid.net", port: 587);
                client.Credentials = new NetworkCredential(
                    userName: "apikey",
                    password: key
                    );


                await client.SendMailAsync(message);
                return true;
            }
            catch(Exception ex)
            {

                var model = $"{JsonConvert.SerializeObject(emailRequest)}";
                var message = $"{"internal server occured while sending email"}{" - "}{ex}{" - "}{model}{DateTime.Now}";
                var fialedMessage = new FailedEmailRequest
                {
                    To = emailRequest.To,
                    Body = emailRequest.Body,
                    Subject = emailRequest.Subject
                };
                try
                {
                   
                   await  _bounceDbContext.AddAsync(fialedMessage);
                    await _bounceDbContext.SaveChangesAsync();


                }
                catch(Exception exp)
                {
                    var failedMessageModel = $"{JsonConvert.SerializeObject(fialedMessage)}";
                    var Failedmessage = $"{"internal server occured while Saving FailedEmailRequest data "}{" - "}{exp}{" - "}{model}{DateTime.Now}";
                    _adminLogger.LogRequest(Failedmessage, true);
                }
                _adminLogger.LogRequest(message, true);
                return false;
            }
        }

    }
}
