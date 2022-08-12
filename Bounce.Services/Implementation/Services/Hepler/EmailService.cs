using Bounce_Application.DTO;
using Bounce_Application.DTO.ServiceModel;
using Bounce_Application.Persistence.Interfaces.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private SmtpConfiguration smtpConfiguration;
        private IHttpContextAccessor contextAccessor;

        public EmailService(IConfiguration configuration, IOptions<SmtpConfiguration> smtpConfiguration, IHttpContextAccessor contextAccessor)
        {
            this.configuration = configuration;
            this.smtpConfiguration = smtpConfiguration.Value;
            this.contextAccessor = contextAccessor;
        }

        public async Task SendMail(EmailRequest emailRequest)
        {
            try
            {
                using (MailMessage mm = new MailMessage())
                {
                    mm.Subject = emailRequest.Subject;
                    mm.Body = emailRequest.Body;
                    mm.From = new MailAddress(smtpConfiguration.EmailAddress);
                    mm.Sender = new MailAddress(smtpConfiguration.EmailAddress);
                    mm.To.Add(emailRequest.To);
                    if (emailRequest.Attachments.Count > 0)
                    {
                        foreach (var attachment in emailRequest.Attachments)
                        {
                            string fileName = Path.GetFileName(attachment.FileName);
                            mm.Attachments.Add(new Attachment(attachment.OpenReadStream(), fileName));
                        }
                    }
                    mm.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient(smtpConfiguration.Host,smtpConfiguration.Post))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(smtpConfiguration.EmailAddress, smtpConfiguration.Password);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = smtpConfiguration.EnableSSl;
                        smtp.Timeout = 30000;
                        smtp.Send(mm);
                        
                    }
                   

                }
            }
            catch (Exception ex)
            {

                ;
            }
        }
    }
}
