using AutoMapper;
using Bounce.Bounce_Application.Settings;
using Bounce.DataTransferObject.DTO.Notification;
using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Payment;
using Bounce.DataTransferObject.Helpers;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.DTO;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_Application.Persistence.Interfaces.Payment;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Bounce_Domain.Enum;
using Flutterwave.Ravepay.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Payment
{
    public class PaymentServices : BaseServices, IPaymentServices
    {
        private readonly FlutterWaveSetting _flutterWaveSettings;
        private readonly SessionManager _sessionManager;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmalService _EmailService;
          public string rootPath { get; set; }

        public PaymentServices(BounceDbContext context, IOptions<FlutterWaveSetting> flutterWave, SessionManager sessionManager, IMapper mapper, INotificationService notificationService, IHostingEnvironment hostingEnvironment, IEmalService emailService) : base(context)
        {
            _flutterWaveSettings = flutterWave.Value;
            _sessionManager = sessionManager;
            _mapper = mapper;
            _notificationService = notificationService;
            _hostingEnvironment = hostingEnvironment;
            _EmailService = emailService;
            rootPath = _hostingEnvironment.ContentRootPath;
        }


        public async Task<Response> InitailizePaymentAsync(PaymentRequestDto model)
        {
            try
            {
                LogInfo($"{"Started task to initialize payment }"}{" - "}{JsonConvert.SerializeObject(model)}{" - "}{DateTime.Now}");

                if (!Enum.TryParse<PaymentType>(model.PaymentType.ToLower(), out PaymentType paymentType))
                    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "Invalid payment type" };
               
                var payment = new PaymentRequest
                {
                    PaymentRequestId = "TRV" + DateTime.Now.Ticks.ToString(),
                    UserId = _sessionManager.CurrentLogin.Id,
                    PaymentType = paymentType,
                    Amount = model.Amount,
                    //PlanId = 1,                

                };
                await _context.AddAsync(payment);
                if (!await SaveAsync())
                    return FailedSaveResponse(payment);
                return SuccessResponse(data: new  PaymentResonseDto { TransactionRef = payment.PaymentRequestId });
            }
            catch (Exception ex) {
                return InternalErrorResponse(ex);
            }  


        }

        public async Task<Response> PayWithWallet(string TxRef)
        {
            
           LogInfo($"Started task to pay with wallet , TRxf: {TxRef}: Time: {DateTime.UtcNow}");
           using (var dbTransaction =await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = _sessionManager.CurrentLogin;
                    var transactionRequest = _context.PaymentRequests.FirstOrDefault(x => x.PaymentRequestId == TxRef && x.UserId == user.Id);

                    if (transactionRequest == null)
                        return AuxillaryResponse("invalid transactionRef", StatusCodes.Status404NotFound);

                    if (transactionRequest.Completed)
                        return AuxillaryResponse("Transaction has been completed", StatusCodes.Status400BadRequest);

                    var wallet = _context.Wallets.FirstOrDefault(x => x.UserId == user.Id);

                    if (transactionRequest.Amount > wallet.AvailableBalance)
                        return AuxillaryResponse("Your wallet balance is insufficient for this transaction", StatusCodes.Status400BadRequest);

                    var profile = _context.UserProfile.FirstOrDefault(x => x.UserId == user.Id);

                    wallet.Balance = wallet.Balance -= transactionRequest.Amount;
                    wallet.ModifiedTimeOffset = DateTimeOffset.UtcNow;
                    _context.Update(wallet);
                    if (!await AdminSaveChanges())
                        return FailedSaveResponse();

                    var transaction = new Transaction
                    {

                        RequestId = transactionRequest.Id,
                        TransactionType = TransactionType.Wallet,
                        Decription = "Wallet Transaction",
                        UserId = _sessionManager.CurrentLogin.Id,
                        CreatedTimeOffset = DateTimeOffset.UtcNow
                
                    };

                    _context.Transactions.Add(transaction);
                    if (!await AdminSaveChanges())
                        return FailedSaveResponse();

                    transactionRequest.PaymentType = PaymentType.wallet;
                    transactionRequest.Completed = true;
                    transactionRequest.CompletedTime = DateTime.UtcNow;
                    transactionRequest.ModifiedTimeOffset = DateTimeOffset.Now;
                    _context.Update(transactionRequest);
   
                    if (!await AdminSaveChanges())
                        return FailedSaveResponse();

                    await dbTransaction.CommitAsync();

                    
                    var mailBuilder = new StringBuilder();

                    mailBuilder.AppendLine($"Dear {profile?.FirstName}<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"Your wallet transaction of {transactionRequest.Amount} was successful.<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"Transaction RefreneceNumber: {transactionRequest.PaymentRequestId} <br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine("Date:" + "  " + DateTime.Now + "<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine("<br />");

                    var emailRequest = new EmailRequest
                    {
                        To = user.Email,
                        Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath),
                        Subject = "Payment Confirmation"
                    };

                    await _EmailService.SendMail(emailRequest);

                    LogInfo($"Started task to pay with wallet has been completed , TRxf: {TxRef}: Time: {DateTime.UtcNow}");

                    return SuccessResponse();

                }
                catch (Exception ex)
                {

                    await dbTransaction.RollbackAsync();
                    return InternalErrorResponse(ex);
                }
            }
        }
        public async Task<Response> Requery(string TxRef)
        {

            try
            {
                var transactionRequest = _context.PaymentRequests.FirstOrDefault(x => x.PaymentRequestId == TxRef);
                if (transactionRequest == null)
                    return AuxillaryResponse("invalid transactionRef", StatusCodes.Status404NotFound);

                if(transactionRequest.Completed)
                    return SuccessResponse("Success",
                     new FlutterWavePaymentResponse
                     {
                         status = "Success",
                         amount =(decimal)transactionRequest.Amount,
                         chargecode = "00",
                         TxRef = transactionRequest.PaymentRequestId
                     });

                var amount = (decimal)transactionRequest.Amount;

                var config = new RavePayConfig(_flutterWaveSettings.PublicKey, _flutterWaveSettings.SecreteKey);
                var trans = new RaveTransaction(config);
                var response = await trans.XqueryTransactionVeriication(new VerifyTransactoinParams(_flutterWaveSettings.SecreteKey, TxRef));
                if(response.Status != "success")
                    return AuxillaryResponse("Error occured while processing your request, try again later", StatusCodes.Status417ExpectationFailed);

                var respdata = response.Data.FirstOrDefault();
                if (/*respdata?.Status == "successful"*//* && respdata.Amount == amount && respdata.ChargeResponseCode == "00"*/ response.Status == "success")
                {
                    transactionRequest.Completed = true;
                    transactionRequest.IssuerTransRef = JsonConvert.SerializeObject(response.Data);
                    _context.Update(transactionRequest);
                    if (!await SaveAsync())
                        return FailedSaveResponse();

                    return SuccessResponse("Success",
                    new FlutterWavePaymentResponse
                    {
                        status = "Success",
                        amount = (decimal)transactionRequest.Amount,
                        chargecode = "00",
                        TxRef = transactionRequest.PaymentRequestId
                    });
                    
                }
                else
                {
                    return AuxillaryResponse("Incomplete transaction", StatusCodes.Status417ExpectationFailed);
                }


            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> Requery(string TxRef,double amount)
        {

            try
            {
     
                var config = new RavePayConfig(_flutterWaveSettings.PublicKey, _flutterWaveSettings.SecreteKey);
                var trans = new RaveTransaction(config);
                var response = await trans.XqueryTransactionVeriication(new VerifyTransactoinParams(_flutterWaveSettings.SecreteKey, TxRef));
                if (response.Status != "success")
                    return AuxillaryResponse("Error occured while processing your request, try again later", StatusCodes.Status417ExpectationFailed);

                var respdata = response.Data.FirstOrDefault();
                if (/*respdata?.Status == "successful"*//* && respdata.Amount == amount && respdata.ChargeResponseCode == "00"*/ response.Status == "success")
                {

                    return SuccessResponse("Success",
                    new FlutterWavePaymentResponse
                    {
                        status = "Success",
                        amount = (decimal)amount,
                        chargecode = "00",
                        TxRef = TxRef
                    });

                }
                else
                {
                    return AuxillaryResponse("Incomplete transaction", StatusCodes.Status417ExpectationFailed);
                }


            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

       
        public async Task<Response> ConfirmAppointment(string trxRef)
        {
            try
            {
                var paymentRequest = _context.PaymentRequests.FirstOrDefault(x => x.PaymentRequestId == trxRef);
                if (paymentRequest == null)
                    return AuxillaryResponse("payment not found", StatusCodes.Status404NotFound);

                var paymentStatus = await Requery(trxRef);
                if(paymentStatus.StatusCode != 200)
                    return AuxillaryResponse("Booking failed", StatusCodes.Status417ExpectationFailed);

                using(var _dbTransaction =  await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var appointmentRequest = _context.AppointmentRequest.FirstOrDefault(x => x.TrxRef == trxRef);
                        var existingAppointment = _context.Appointments.FirstOrDefault(x => x.AppointmentRequestId == appointmentRequest.Id);
                      if(existingAppointment != null)
                       {
                            return AuxillaryResponse("Appoinment has alreday been booked", StatusCodes.Status200OK);
                       }

                        var appointment = new Appointment
                        {
                            AppointmentRequestId = appointmentRequest.Id,
                            //SessionType = Enum.Parse<SessionType>(appointmentRequest.AppointmentType),
                            SessionType = SessionType.Chat,
                            Status = AppointStatus.UpComming,
                        };
                     
              
                        var transaction = new Transaction
                        {
                            RequestId = paymentRequest.Id,
                            TransactionType = TransactionType.Payment,
                            Decription = "Session Booking",
                            UserId = _sessionManager.CurrentLogin.Id,
                            status = "00",
                        };
                        _context.Appointments.Add(appointment);
                        _context.Add(transaction);

                        if (!await SaveAsync())
                            return FailedSaveResponse();

                       await  _dbTransaction.CommitAsync();
                        return SuccessResponse("Session booking was successful");

                    }
                    catch (Exception ex)
                    {
                        await _dbTransaction.RollbackAsync();
                        return InternalErrorResponse(ex);
                    }
                }

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
       
        public async Task<Response> WalletTop(WalletToUpDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var walletModel = new WalletRequest
                {
                    RequestType = WalletRequestType.TopUp,
                    Amount = model.Amount,
                    Refxn = "TP"+DateTime.Now.Ticks.ToString(),
                    UserId = user.Id,
                    DateCreated = DateTime.Now,
                    LastModifiedBy = user.Email,
                    DateModified = DateTime.Now,
                    Time = DateTime.UtcNow,
                };

                var paymentRequest = new PaymentRequest
                {
                    UserId = user.Id,
                    Amount = model.Amount,
                    PaymentRequestId = walletModel.Refxn,
                    CreatedTimeOffset = DateTimeOffset.UtcNow,
                    PaymentDecription = "Top Up",
                    PaymentType = PaymentType.card,
                    //SubPlanId = 7
                };
                 _context.Add(paymentRequest);
                _context.Add(walletModel);

                if (!await SaveAsync())
                    return FailedSaveResponse();
                return SuccessResponse(data: new { TrxRef = walletModel.Refxn });

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> ComfirmWalletTop(string TrxRef)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var request = _context.WalletRequests.Where(x=> x.Refxn == TrxRef).FirstOrDefault();

                if (request == null)
                    return AuxillaryResponse("transaction not found", StatusCodes.Status400BadRequest);

                if (request.IsCompleted == "TRUE")
                    return AuxillaryResponse("this transaction has been completed", StatusCodes.Status400BadRequest);

                var transactionStatus =  await Requery(TrxRef, request.Amount);

                var transaction = new Transaction
                {
                    RequestId = request.Id,
                    TransactionType = TransactionType.TopUp,
                    Decription = "Wallet Top Up",
                    status = "00",
                    CompletionTime = DateTime.Now,
                    DateCreated = DateTime.Now,
                    UserId = user.Id

                };
                if (transactionStatus.StatusCode != StatusCodes.Status200OK)
                {
                    request.IsCompleted = "FALSE";
                    request.DateModified = DateTime.Now;
                    transaction.status = "01";

                    _context.Update(request);
                    _context.Add(transaction);
                    _context.SaveChanges();
                    return AuxillaryResponse("Transaction failed,", StatusCodes.Status412PreconditionFailed);
                }
                   

                var wallet = _context.Wallets.FirstOrDefault(x => x.UserId == user.Id);
                wallet.Balance += request.Amount;
                wallet.LastModifiedBy = user.Email;
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
                    TrxRef = TrxRef

                };
                var notification = new NotificationModel
                {
                    UserId = user.Id,
                    Title = pushNotification.Title,
                    Message = pushNotification.Message,
                    NotificationRef = TrxRef

                };

                _context.Update(paymentRequest);
                _context.Update(request);
                _context.Add(transaction);
                _context.Add(notification);
                _context.Update(wallet);

                if (!await SaveAsync())
                    return FailedSaveResponse();         

                var mailBuilder = new StringBuilder();

                mailBuilder.AppendLine("Dear" + " " + user.UserName + "," + "<br />");
                mailBuilder.AppendLine("<br />");
                mailBuilder.AppendLine($"Your wallet to up of {request.Amount} Naira was sunccessful.<br />");
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

                return SuccessResponse("Top confirmation was successful");

             
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> TransactionHistory()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var transactions = _context.Transactions.Where(x => x.UserId == user.Id).ToList();

              
#pragma warning disable CS8601 // Possible null reference assignment.
                var query =  (from t in transactions where t.status == AdminStatus.Success
                              join requet in _context.WalletRequests on t.RequestId equals requet.Id
                                          join notifcation in _context.Notification on requet.Refxn equals notifcation.NotificationRef
                                          select new TransactionHistoryDto
                                          {
                                              TransactionId = requet.Refxn,
                                              Amount = Convert.ToDecimal(requet.Amount),
                                              Message = notifcation.Message,
                                              Title = notifcation.Title,
                                              TimeToString = t.CompletionTime.ToString(AdminConstants.FullDateTime),
                                              Time = t.CompletionTime/*.ToString(AdminConstants.FullDateTime)*/,
                                              TransactionType = requet.RequestType == WalletRequestType.TopUp ? 
                                              AdminConstants.WalletTopUp : AdminConstants.WalletPayment
                                          }).OrderByDescending(x=> x.Time).ToList();
#pragma warning restore CS8601 // Possible null reference assignment.

                return SuccessResponse(data: query);                 

            }
            catch(Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> TransactionByFilter( string filter)
        {
            try
            {
                var filters = new List<string> { "all", "topup", "payment" };
                var val = filter.ToLower();
                if (!filters.Contains(filter))
                    return AuxillaryResponse("Invalid filter value, kindly use 'topup', 'all' or 'topup' ", StatusCodes.Status400BadRequest);

                var user = _sessionManager.CurrentLogin;
                var transactions = (from transaction in _context.Transactions.Where(x => !x.IsDeleted).Where(x => x.UserId == user.Id && x.status == "00")
                            join request in _context.PaymentRequests on transaction.RequestId equals request.Id
                            select new
                            {
                                TransactionId = request.PaymentRequestId,
                                Amount = Convert.ToDecimal(request.Amount),
                                PaymentDescription = transaction.Decription,
                                Time = transaction.DateCreated,
                                Type = transaction.TransactionType,
                                TransactionType = transaction.TransactionType == TransactionType.TopUp ?
                                AdminConstants.WalletTopUp : AdminConstants.WalletPayment
                            }).OrderByDescending(x => x.Time).ToList();


                //var transactions = await _context.Transactions.Where(x => x.UserId == user.Id && x.status == "00").ToListAsync();

                if (val == "topup")
                    transactions = transactions.Where(x => x.Type == TransactionType.TopUp).ToList();

                if (val == "payment" )
                    transactions = transactions.Where(x => x.Type != TransactionType.TopUp).ToList();
      


                return SuccessResponse(data: transactions);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> GetWalletBallance()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var wallet = await _context.Wallets.FirstOrDefaultAsync(x => x.UserId == user.Id);
                var data = new
                {
                    Balance = wallet.Balance,
                    AvaialbaleBalance = wallet.Balance + wallet.ReferalBonus,
                    ReferalBonus = wallet.ReferalBonus
                };


                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
