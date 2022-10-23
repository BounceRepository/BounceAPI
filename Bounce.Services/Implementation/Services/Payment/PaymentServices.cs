using AutoMapper;
using Bounce.Bounce_Application.Settings;
using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Payment;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Payment;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Bounce_Domain.Enum;
using Flutterwave.Ravepay.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public PaymentServices(BounceDbContext context, IOptions<FlutterWaveSetting> flutterWave, SessionManager sessionManager, IMapper mapper) : base(context)
        {
            _flutterWaveSettings = flutterWave.Value;
            _sessionManager = sessionManager;
            _mapper = mapper;
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
                    PaymentRequestId = DateTime.Now.Ticks.ToString(),
                    UserId = _sessionManager.CurrentLogin.Id,
                    PaymentType = paymentType,
                    Amount = model.Amount,
                    PlanId = 1,                

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
                    //return SuccessResponse(response.Message, 
                    //new FlutterWavePaymentResponse
                    //{
                    //    status = respdata.Status,
                    //    amount = respdata.Amount,
                    //    chargecode = respdata.ChargeResponseCode,
                    //    TxRef = respdata.TxRef
                    //});
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

        public async Task<Response> BookAppointment(AppointmentDto model)
        {
            try
            {

                var paymentModel = new PaymentRequestDto
                {
                    PaymentType = model.PaymentType,
                    Amount = model.TotalAMount

                };
                var response = await InitailizePaymentAsync(paymentModel);
                if (response.StatusCode != 200)
                    return AuxillaryResponse("Error occured while booking your appointement", response.StatusCode);

                var responseData = (PaymentResonseDto)response.Data;
                var appointement = _mapper.Map<AppointmentRequest>(model);
                appointement.TrxRef = responseData.TransactionRef;
                _context.Add(appointement);

                if (!await SaveAsync())
                    return FailedSaveResponse();
                return SuccessResponse(data: new { TrxRef = appointement.TrxRef });


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
                        var existingAppointment = _context.Appointments.Any(x => x.AppointmentRequestId == appointmentRequest.Id);
                        return AuxillaryResponse("Appoinment has alreday been booked", StatusCodes.Status200OK);

                        var appointment = new Appointment
                        {
                            AppointmentRequestId = appointmentRequest.Id,
                            //SessionType = Enum.Parse<SessionType>(appointmentRequest.AppointmentType),
                            SessionType = SessionType.Chat,
                            Status = AppointStatus.UpComming,
                        };
                        _context.Add(appointment);
              
                        var transaction = new Transaction
                        {
                            RequestId = paymentRequest.Id,
                            TransactionType = TransactionType.Other,
                            Decription = "Session Booking"
                        };
                        _context.Add(transaction);

                        if (!await SaveAsync())
                            return FailedSaveResponse();
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
                    Refxn = DateTime.Now.Ticks.ToString(),
                    UserId = user.Id,
                    DateCreated = DateTime.Now,
                    LastModifiedBy = user.Email,
                    DateModified = DateTime.Now,
                    Time = DateTime.UtcNow,
                };
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
    }
}
