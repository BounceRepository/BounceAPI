using Bounce_Application.DTO;
using Bounce_Application.DTO.ServiceModel;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.SeriLog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly SmtpConfiguration _smtpConfiguration;
        private IHttpContextAccessor contextAccessor;
        private readonly AdminLogger _adminLogger;

        public EmailService(IConfiguration configuration, IOptions<SmtpConfiguration> smtpConfiguration, IHttpContextAccessor contextAccessor, AdminLogger adminLogger)
        {
            this.configuration = configuration;
            _smtpConfiguration = smtpConfiguration.Value;
            this.contextAccessor = contextAccessor;
            _adminLogger = adminLogger;
        }


       

        public async Task SendMail(EmailRequest emailRequest)
        {
            using var message = new MailMessage();
            message.From = new MailAddress(_smtpConfiguration.sendgridSender, _smtpConfiguration.sendgridName);

            message.IsBodyHtml = true;
            message.To.Add(new MailAddress(emailRequest.To, "Bounce Online"));
            message.Body = emailRequest.Body;

            message.Subject = message.Subject;
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
                password: _smtpConfiguration.sendgridKey
            );


            await client.SendMailAsync(message);
        }

    }
}
