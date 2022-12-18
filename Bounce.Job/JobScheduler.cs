using Bounce_Application.DTO;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Bounce_Domain.Enum;
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
        //private readonly INotification

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

        public async Task<bool> CheckDueAppointments()
        {
            var appoinments = (from app in _context.AppointmentRequest where app.IsPaymentCompleted && app.Status == AppointmentStatus.Upcomming
                               join therapistProfile in _context.TherapistProfiles on app.TherapistId equals therapistProfile.UserId
                               join patientProfile in _context.UserProfile on app.PatientId equals patientProfile.UserId
                               join therapistUser in _context.Users on app.TherapistId equals therapistUser.Id
                               join patientUser in _context.Users on app.PatientId equals patientUser.Id
                               select new
                               {
                                   AppointMent = app,
                                   TherapistEmail = therapistUser.Email,
                                   TherapistName = therapistProfile.Title + " " + therapistProfile.FirstName,
                                   PatientEmail = patientUser.Email,
                                   PatientName =    patientProfile.FirstName,
                                   SectionTime = app.AvailableTime
                               }).ToList();

            foreach (var appointment in appoinments)
            {
                if(appointment.SectionTime < DateTime.Now.AddMinutes(20))
                {
                    appointment.AppointMent.Status = AppointmentStatus.Overdue;
                    appointment.AppointMent.DateModified = DateTime.Now;
                    _context.Update(appointment.AppointMent);
                    await _context.SaveChangesAsync();
                    var mailBuilder = new StringBuilder();

                    mailBuilder.AppendLine("Dear" + " " + appointment.PatientName + "," + "<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"Kindly note that your session with {appointment.TherapistName} has expired.<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"You can reshedule the session.<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine("Regards:<br />");

                    var patientEmailRequest = new EmailRequest
                    {
                        To = appointment.PatientEmail,
                        Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath, "Session Expiry"),
                        Subject = "Email Confirmation"
                    };
                    await _EmailService.SendMail(patientEmailRequest);

                    mailBuilder.Clear();

                    mailBuilder.AppendLine("Dear" + " " + appointment.TherapistName + "," + "<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"Kindly note that your session with {appointment.PatientName} has expired.<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"KIndly state the reason why the session did not hold.<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine("Regards:<br />");

                    var therapisEmailRequest = new EmailRequest
                    {
                        To = appointment.TherapistEmail,
                        Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath, "Session Expiry"),
                        Subject = "Email Confirmation"
                    };

                }
                if ((appointment.SectionTime - DateTime.Now).TotalMinutes < 15 && (appointment.SectionTime - DateTime.Now).TotalMinutes  > 1)
                {
                    var timeRemaining = (appointment.SectionTime - DateTime.Now).TotalMinutes;
                    
                    var mailBuilder = new StringBuilder();

                    mailBuilder.AppendLine("Dear" + " " + appointment.PatientName + "," + "<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"Kindly note that your session with {appointment.TherapistName} will start in {timeRemaining} munites time.<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"KIndly get your self ready .<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine("Regards:<br />");

                    var patientEmailRequest = new EmailRequest
                    {
                        To = appointment.PatientEmail,
                        Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath, "Session Notification"),
                        Subject = "Email Confirmation"
                    };
                    await _EmailService.SendMail(patientEmailRequest);

                    mailBuilder.Clear();

                    mailBuilder.AppendLine("Dear" + " " + appointment.TherapistName + "," + "<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"Kindly note that your session with {appointment.PatientName} will start in {timeRemaining} munites time.<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"KIndly get your self ready .<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine("Regards:<br />");

                    var therapisEmailRequest = new EmailRequest
                    {
                        To = appointment.TherapistEmail,
                        Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath, "Session Notification"),
                        Subject = "Email Confirmation"
                    };


                }

               
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
