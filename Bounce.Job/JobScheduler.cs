using Bounce_Application.DTO;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Job
{
    public class JobScheduler : BaseJobScheduler, IJobScheduler
    {
        private string rootPath = string.Empty;

        public JobScheduler(IEmalService emailService, IHttpContextAccessor contextAccessor, IHostingEnvironment hostingEnvironment, BounceDbContext context) : base(emailService, contextAccessor, hostingEnvironment, context)
        {
            rootPath = hostingEnvironment.ContentRootPath;
        }

        public async Task<bool> ResendFaileMessages()
        {
            var failedMessages = _context.FailedEmailRequests.Where(x => !x.IsCompleted).ToList();
            foreach (var message in failedMessages)
            {
                var email = new EmailRequest
                {
                    To = message.To,
                    Body = message.Body,
                    Subject = message.Subject,
                };
                if(await _EmailService.SendMail(email))
                {
                   message.IsCompleted = true;                
                }
                message.DateModified = DateTime.Now;
                _context.Update(message);
                _context.SaveChanges();
            }
            return Task.FromResult(true).Result;
        }



        public async Task<bool> CheckFreeTrialAsync()
        {
           ////using (var context = new BounceDbContext())
           //// {
      
           ////     var review = new TherapistReview
           ////     {
           ////         Time = DateTimeOffset.Now,
           ////         TherapistUserId = 2,
           ////         ReviewComment = "Comment from local server"

           ////     };
           ////     _context.AddAsync(review);
           ////     await _context.SaveChangesAsync();
           // }
 

            return Task.FromResult(true).Result;
        }
    }
}
