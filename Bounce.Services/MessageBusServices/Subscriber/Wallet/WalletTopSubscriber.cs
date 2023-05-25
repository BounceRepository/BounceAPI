using Bounce.DataTransferObject.DTO.Notification;
using Bounce.Services.Implementation.Services;
using Bounce_Application.DTO;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Bounce_Domain.Enum;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bounce.Services.MessageBusServices.Subscriber.Wallet
{
  
    public class WalletTopSubscriber : BaseServices
    {

        private readonly INotificationService _notificationService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmalService _EmailService;
        private readonly SessionManager _sessionManager;
        private string rootPath { get; set; }

        public WalletTopSubscriber(INotificationService notificationService, IHostingEnvironment hostingEnvironment, IEmalService emailService, BounceDbContext context, SessionManager sessionManager) : base(context)
        {

            _notificationService = notificationService;
            _hostingEnvironment = hostingEnvironment;
            _EmailService = emailService;
            _sessionManager = sessionManager;
            rootPath = _hostingEnvironment.ContentRootPath;
        }

        public async Task<Task> ConfirmWalletTopUpEvent(WalletEvent message)
        {



            using (var db_transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = _sessionManager.CurrentLogin;
                    var request = _context.WalletRequests.Where(x => x.Refxn == message.Message).FirstOrDefault();




                    var wallet = _context.Wallets.FirstOrDefault(x => x.UserId == user.Id);
                    wallet.Balance += request.Amount;
                    wallet.LastModifiedBy = user.Email;
                    wallet.DateModified = DateTime.Now;
                    _context.Update(wallet);
                    await SaveAsync();


                    request.IsCompleted = "TRUE";
                    request.DateModified = DateTime.Now;
                    _context.Update(request);
                    await SaveAsync();


                    var paymentRequest = _context.PaymentRequests.FirstOrDefault(x => x.PaymentRequestId == request.Refxn);
                    paymentRequest.Completed = true;
                    paymentRequest.DateModified = DateTime.Now;
                    _context.Update(paymentRequest);
                    await SaveAsync();

                    var transaction = new Bounce_Domain.Entity.Transaction
                    {
                        RequestId = paymentRequest.Id,
                        TransactionType = TransactionType.TopUp,
                        Decription = "Wallet Top Up",
                        status = "00",
                        CompletionTime = DateTime.Now,
                        DateCreated = DateTime.Now,
                        UserId = user.Id,
                        TransactionRef = message.Message,
                        Amount = (decimal)request.Amount

                    };
                    _context.Add(transaction);
                    _context.SaveChanges();

                    var pushNotification = new PushNotificationDto
                    {
                        Title = "Top-Up",
                        Topic = "Wallet transaction",
                        Message = "Your wallet top up was scuccessful",
                        TrxRef = message.Message

                    };
                    var notification = new NotificationModel
                    {
                        UserId = user.Id,
                        Title = pushNotification.Title,
                        Message = pushNotification.Message,
                        NotificationRef = message.Message

                    };

                    _context.Add(notification);
                    await SaveAsync();

                    //await db_transaction.CommitAsync();

                    var mailBuilder = new StringBuilder();
                    mailBuilder.AppendLine("Dear" + " " + user.UserName + "," + "<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"Your wallet to up of {request.Amount} Naira was Successful.<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine("Regards:<br />");

                    var emailRequest = new EmailRequest
                    {
                        To = user.Email,
                        Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath),
                        Subject = "Wallet Top up"
                    };

                    await _EmailService.SendMail(emailRequest).ConfigureAwait(false);
                    await _notificationService.PushNotification(pushNotification);

                    return Task.CompletedTask;


                }
                catch (Exception ex)
                {
                    await db_transaction.RollbackAsync();
                    return Task.CompletedTask;

                }
            }

        
        }
    }


}
