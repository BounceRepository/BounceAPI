using Bounce.DataTransferObject.DTO.Notification;
using Bounce_Application.DTO;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Bounce_Domain.Enum;
using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Notification.Wallet
{
    

    public class WalletMessageConsumer : IConsumer<WalletMessage>
    {
        private readonly ILogger<WalletMessageConsumer> _logger;

        private readonly SemaphoreSlim _semaphore;
        private bool _isProcessing;
        private readonly object _lock = new object();
        private readonly INotificationService _notificationService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmalService _EmailService;
        private readonly SessionManager _sessionManager;
        protected readonly BounceDbContext _context;
        private string rootPath { get; set; }

        //public WalletMessageConsumer(ILogger<WalletMessageConsumer> logger, SemaphoreSlim semaphore, bool isProcessing, object @lock, INotificationService notificationService, IHostingEnvironment hostingEnvironment, IEmalService emailService, SessionManager sessionManager, BounceDbContext context)
        //{
        //    _logger = logger;
        //    _semaphore = semaphore;
        //    _isProcessing = isProcessing;
        //    _lock = @lock;
        //    _notificationService = notificationService;
        //    _hostingEnvironment = hostingEnvironment;
        //    _EmailService = emailService;
        //    _sessionManager = sessionManager;
        //    _context = context;
        //    rootPath = _hostingEnvironment.ContentRootPath;
        //}
        //public WalletMessageConsumer()
        //{

        //}
        public Task Consume(ConsumeContext<WalletMessage> context)
        {
            var message = context.Message;

            //ProcessNewEvent(message.TrnxRef).ConfigureAwait(false);
            Console.WriteLine($"Received message: {message.TrnxRef}");
            return Task.CompletedTask;
        }

        //public async Task ProcessNewEvent(string trnRef)
        //{


        //    using (var db_transaction = await _context.Database.BeginTransactionAsync())
        //    {
        //        try
        //        {
        //            var user = _sessionManager.CurrentLogin;
        //            var request = _context.WalletRequests.Where(x => x.Refxn == trnRef).FirstOrDefault();

        //            var wallet = _context.Wallets.FirstOrDefault(x => x.UserId == user.Id);
        //            wallet.Balance += request.Amount;
        //            wallet.LastModifiedBy = user.Email;
        //            wallet.DateModified = DateTime.Now;
        //            _context.Update(wallet);
        //            await _context.SaveChangesAsync();


        //            request.IsCompleted = "TRUE";
        //            request.DateModified = DateTime.Now;
        //            _context.Update(request);
        //            await _context.SaveChangesAsync();


        //            var paymentRequest = _context.PaymentRequests.FirstOrDefault(x => x.PaymentRequestId == request.Refxn);
        //            paymentRequest.Completed = true;
        //            paymentRequest.DateModified = DateTime.Now;
        //            _context.Update(paymentRequest);
        //            await _context.SaveChangesAsync();

        //            var transaction = new Bounce_Domain.Entity.Transaction
        //            {
        //                RequestId = paymentRequest.Id,
        //                TransactionType = TransactionType.TopUp,
        //                Decription = "Wallet Top Up",
        //                status = "00",
        //                CompletionTime = DateTime.Now,
        //                DateCreated = DateTime.Now,
        //                UserId = user.Id,
        //                TransactionRef = trnRef,
        //                Amount = (decimal)request.Amount

        //            };
        //            _context.Add(transaction);
        //            _context.SaveChanges();

        //            var pushNotification = new PushNotificationDto
        //            {
        //                Title = "Top-Up",
        //                Topic = "Wallet transaction",
        //                Message = "Your wallet top up was scuccessful",
        //                TrxRef = trnRef

        //            };
        //            var notification = new NotificationModel
        //            {
        //                UserId = user.Id,
        //                Title = pushNotification.Title,
        //                Message = pushNotification.Message,
        //                NotificationRef = trnRef

        //            };

        //            _context.Add(notification);
        //            await _context.SaveChangesAsync(); ;

        //            //await db_transaction.CommitAsync();

        //            var mailBuilder = new StringBuilder();
        //            mailBuilder.AppendLine("Dear" + " " + user.UserName + "," + "<br />");
        //            mailBuilder.AppendLine("<br />");
        //            mailBuilder.AppendLine($"Your wallet to up of {request.Amount} Naira was Successful.<br />");
        //            mailBuilder.AppendLine("<br />");
        //            mailBuilder.AppendLine("Regards:<br />");

        //            var emailRequest = new EmailRequest
        //            {
        //                To = user.Email,
        //                Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath),
        //                Subject = "Wallet Top up"
        //            };

        //            await _EmailService.SendMail(emailRequest).ConfigureAwait(false);
        //            await _notificationService.PushNotification(pushNotification);

        //        }
        //        catch (Exception ex)
        //        {
        //            await db_transaction.RollbackAsync();


        //        }

        //    }


        //}


    }
}
