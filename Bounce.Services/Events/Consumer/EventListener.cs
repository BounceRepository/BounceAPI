using Bounce.DataTransferObject.DTO.Notification;
using Bounce.Services.Events.Args;
using Bounce_Application.DTO;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Notification;
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

namespace Bounce.Services.Events.Consumer
{
    public class EventListener
    {
        private readonly IEmalService _EmailService;
        public const string InterErrorMessage = "Internal server error occured";
        protected readonly BounceDbContext _context;
        private readonly INotificationService _notificationService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public string rootPath { get; set; }
        public EventListener(BounceDbContext context, IEmalService EmailService, INotificationService notificationService,
            IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _EmailService = EmailService;
            _notificationService = notificationService;
            _hostingEnvironment = hostingEnvironment;
            rootPath = _hostingEnvironment.ContentRootPath;
        }
    
        public  void HandleWalletEvent(object sender, WalletTopEventArgs e)
        {
            var request = e.Request;
            var transaction = new Transaction
            {
                RequestId = request.Id,
                TransactionType = TransactionType.TopUp,
                Decription = "Wallet Top Up",
                status = "00",
                CompletionTime = DateTime.Now,
                DateCreated = DateTime.Now,
                UserId = e.UserId

            };
            if (e.Status != StatusCodes.Status200OK)
            {
                request.IsCompleted = "FALSE";
                request.DateModified = DateTime.Now;
                transaction.status = "01";

                _context.Update(request);
                _context.Add(transaction);
                _context.SaveChanges();

            }
            else
            {
                var wallet = _context.Wallets.FirstOrDefault(x => x.UserId == e.UserId);
                wallet.Balance += request.Amount;
                wallet.LastModifiedBy = e.Email;
                wallet.DateModified = DateTime.Now;
                request.IsCompleted = "TRUE";
                request.DateModified = DateTime.Now;

                var paymentRequest = _context.PaymentRequests.FirstOrDefault(x => x.PaymentRequestId == request.Refxn);
                paymentRequest.Completed = true;
                paymentRequest.DateModified = DateTime.Now;

                var pushNotification = new PushNotificationDto
                {
                    Title = "Top-Up",
                    Topic = "Wallet transaction",
                    Message = "Your wallet top up was scuccessful",
                    TrxRef = e.TranxRef

                };
                var notification = new NotificationModel
                {
                    UserId = e.UserId,
                    Title = pushNotification.Title,
                    Message = pushNotification.Message,
                    NotificationRef = e.TranxRef

                };

                _context.Update(paymentRequest);
                _context.Update(request);
                _context.Add(transaction);
                _context.Add(notification);
                _context.Update(wallet);
                _context.SaveChanges();

                var mailBuilder = new StringBuilder();

                mailBuilder.AppendLine("Dear" + " " + e.Username + "," + "<br />");
                mailBuilder.AppendLine("<br />");
                mailBuilder.AppendLine($"Your wallet to up of {request.Amount} Naira was Successful.<br />");
                mailBuilder.AppendLine("<br />");
                mailBuilder.AppendLine("Regards:<br />");

                var emailRequest = new EmailRequest
                {
                    To = e.Email,
                    Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath),
                    Subject = "Wallet Top up"
                };
                 _notificationService.PushNotification(pushNotification).ConfigureAwait(true);
                 _EmailService.SendMail(emailRequest).ConfigureAwait(true);

                Console.WriteLine($"event completed");



            }



        }

        //public void HandleOtherEvent(object sender, MyOtherEventArgs e)
        //{
        //    Console.WriteLine($"MyOtherEvent handled: {e.Value}");
        //}
    }

}
