using AutoMapper;
using Bounce.DataTransferObject.DTO;
using Bounce.DataTransferObject.DTO.Notification;
using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Payment;
using Bounce.DataTransferObject.Helpers;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.DTO;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Notification;
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.Persistence.Interfaces.Payment;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_Applucation.DTO.Auth;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Bounce_Domain.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Patient
{
    public class PatientServices : BaseServices, IPatientServices
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FileManager _fileManager;
        private readonly AdminLogger _adminLogger;
        private readonly IPaymentServices _paymentServices;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor contextAccessor;
        private string rootPath = "";
        private string root = "";
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly SessionManager _sessionManager;
        private readonly IEmalService _EmailService;
        public PatientServices(BounceDbContext context, UserManager<ApplicationUser> userManager, FileManager fileManager, AdminLogger adminLogger, IPaymentServices paymentServices, IMapper mapper, IHttpContextAccessor contextAccessor, SessionManager sessionManager, INotificationService notificationService, IEmalService emailService, IHostingEnvironment hostingEnvironment) : base(context)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _fileManager = fileManager ?? throw new ArgumentNullException(nameof(fileManager));
            _adminLogger = adminLogger ?? throw new ArgumentNullException(nameof(paymentServices));
            _paymentServices = paymentServices ?? throw new ArgumentNullException(nameof(fileManager));
            _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
            _sessionManager = sessionManager ?? throw new ArgumentNullException(nameof(sessionManager));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _EmailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            var scheme = contextAccessor?.HttpContext?.Request.Scheme;
            var host = contextAccessor?.HttpContext?.Request.Host.Value;
            root = $"{scheme}://{host}/";
            rootPath = _hostingEnvironment.ContentRootPath;
           
            //contextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();

        }

        public async Task<Response> UpdateProfileAsync (UpdateProfileDto model)
        {
            try
            {

                var user = _context.Users.FirstOrDefault(x=> x.Email == model.Email);
                if (user == null)
                    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "user does not exist" };

                if (user.HasProfile)
                    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "profile has been updated for this user" };


                var profile = new UserProfile
                {
                    UserId = user.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    Phone = model.Phone,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    MeansOfIdentification = model.MeansOfIdentification != null ? _fileManager.FileUpload(model.MeansOfIdentification) : "",
                    LastModifiedBy = DateTime.Now.ToShortDateString(),
                    FilePath = model.ImageFile != null ? _fileManager.FileUpload(model.ImageFile) : ""
                };

                var record = await _context.AddAsync(profile);
                if (await SaveAsync())
                {
                    var id = record.Member("Id").CurrentValue;
                    user.ProfileId = (long)(id);
                    user.HasProfile = true;
                    await _userManager.UpdateAsync(user);

                    var data = new
                    {
                        UserId = user.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateOfBirth = model.DateOfBirth,
                        Gender = model.Gender,
                        Phone = model.Phone,
                        MeansOfIdentification = profile.MeansOfIdentification,
                        Image = profile.FilePath

                    };
                    return SuccessResponse("Profile Updated", data: data);
                }

                else
                {
                    _adminLogger.LogRequest($"{"Internal server error occured while saving a record}"}{" - "}{JsonConvert.SerializeObject(profile)}{" - "}{DateTime.Now}", true);
                    return new Response { StatusCode = StatusCodes.Status500InternalServerError, Message = InterErrorMessage };
                }
                  
            }
            catch(Exception ex)
            {
               return InternalErrorResponse(ex);
            }




        }
        public async Task<Response> SubscribeToPlan(long planId, long subplanId)
        {

            try
            {
                LogInfo($"{"Started task to initialize plan subscription }"}{" - "}{planId}{" - "}{DateTime.Now}");

                var plan = _context.SubPlan.FirstOrDefault(x => x.Id == subplanId);

                var payment = new PaymentRequest
                {
                    PaymentRequestId = DateTime.Now.Ticks.ToString(),
                    UserId = _sessionManager.CurrentLogin.Id,
                    Amount = plan.Cost,
                    SubPlanId = subplanId,
                    PaymentDecription = "Plan Subscription",
                    CreatedTimeOffset = DateTimeOffset.Now

                };
                await _context.AddAsync(payment);
                if (!await SaveAsync())
                    return FailedSaveResponse();
                 
                LogInfo($"{"task to subscribe to plan was successful "} transactionRef: {payment.PaymentRequestId}{" - "} Amount: {payment.Amount}{" - "}{DateTime.Now}");
                return SuccessResponse(data: new { TrxRef = payment.PaymentRequestId });
            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }
        }


        public async Task<Response> BookAppointment(AppointmentDto model)
        {
            LogInfo($"{"Started task to initialize wallert payment for session Booking  }"}{" - "}{JsonConvert.SerializeObject(model)}{" - "}{DateTime.Now}");

            var user = _sessionManager.CurrentLogin;
            using (var _transaction = await  _context.Database.BeginTransactionAsync())
            {
                try
                {
                  
                    var wallet = _context.Wallets.FirstOrDefault(x => x.UserId == user.Id);
                    if (wallet?.Balance < model.TotalAMount)
                        return AuxillaryResponse("Insufficient balance", StatusCodes.Status402PaymentRequired);

                    wallet.Balance =  wallet.Balance - model.TotalAMount;
                    _context.Update(wallet);

                    var payment = new PaymentRequest
                    {
                        PaymentRequestId = DateTime.Now.Ticks.ToString(),
                        UserId = _sessionManager.CurrentLogin.Id,
                        PaymentType = PaymentType.wallet,
                        Amount = model.TotalAMount,
                        Completed = true,
                        CompletedTime = DateTime.UtcNow
                        
                    };
                    await _context.AddAsync(payment);

                    var time = model.StartTime.ConvertToHour((DateTimeOffset)model.Date);
                    var appointement = _mapper.Map<AppointmentRequest>(model);
                    appointement.StartTime = time;
                    appointement.StartTimeToString = model.StartTime;
                    appointement.Status = AppointmentStatus.Upcomming;
                    appointement.EndTime = time.AddHours(1);
                    appointement.AvailableTime = time.DateTime;
                    appointement.TrxRef = payment.PaymentRequestId;
                    appointement.PatientId = user.Id;
                    appointement.ReasonForTherapy = model.ReasonForTherapy;
                    await _context.AddAsync(appointement);

                    var transaction = new Transaction
                    {
                        RequestId = payment.Id,
                        TransactionType = TransactionType.Payment,
                        Decription = "Session Booking",
                        UserId = _sessionManager.CurrentLogin.Id,
                        status = "00",
                        CreatedTimeOffset = DateTimeOffset.UtcNow,
                    };

                   await  _context.AddAsync(transaction);

                    if (!await SaveAsync())
                        return FailedSaveResponse();

                    await _transaction.CommitAsync();

                    var userProfile = _context.UserProfile.FirstOrDefault(x=> x.UserId == user.Id);
                    var therapist = _context.TherapistProfiles.FirstOrDefault(x => x.UserId == model.TherapistId);
                    var therapistUser = _context.Users.FirstOrDefault(x => x.Id == model.TherapistId);
                    var mailBuilder = new StringBuilder();

                    mailBuilder.AppendLine("Dear" + " " + userProfile.FirstName + "," + "<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"Your session booking with { therapist?.Title + " " + therapist.FirstName + " " + therapist.LastName } was was scuccessful with .<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine("Regards:<br />");

                    var emailRequest = new EmailRequest
                    {
                        To = user.Email,
                        Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath),
                        Subject = "Consultaion Session Booking"
                    };

                    await _EmailService.SendMail(emailRequest).ConfigureAwait(false);

                    mailBuilder.Clear();

                    mailBuilder.AppendLine("Dear" + " " + therapist.Title + " " + therapist.FirstName + "," + "<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"Your have an active session with { userProfile.FirstName + " " + userProfile.LastName} by {appointement.StartTime} .<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine("Regards:<br />");

                    var emailRequest2 = new EmailRequest
                    {
                        To = therapistUser?.Email,
                        Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath),
                        Subject = "Consultaion Session Booking"
                    };
                    await _EmailService.SendMail(emailRequest2).ConfigureAwait(false);

                    var pushNotifications = new List<PushNotificationDto>();
                    var patientPushNotification = new PushNotificationDto
                    {
                        Title = "Session Booking",
                        Topic = "Wallet transaction",
                        Message = $"Your have an active session {userProfile.FirstName + " " + userProfile.LastName} by {appointement.StartTime} ",
                        TrxRef = appointement.TrxRef,
                        userId = userProfile.UserId,

                    };
                    pushNotifications.Add(patientPushNotification);
                    var TherapistPushNotification = new PushNotificationDto
                    {
                        Title = "Session Booking",
                        Topic = "Apponitment Notification",
                        Message = $"Your session booking with {therapist?.Title + " " + therapist.FirstName + " " + therapist.LastName} was was scuccessful with ",
                        TrxRef = appointement.TrxRef,
                        userId = therapistUser.Id

                    };
                    pushNotifications.Add(TherapistPushNotification);
                  
             
                    await _notificationService.PushMultipleNotificationAsyn(pushNotifications);
                    LogInfo($"{"Started task to initialize wallet payment for session Booking was successful }"}{" - "}{JsonConvert.SerializeObject(model)}{" - "}{DateTime.Now}");

                    return SuccessResponse("your booking was successful");

                    //return SuccessResponse(data: new { TrxRef = appointement.TrxRef });
                }
                catch (Exception ex)
                {
                    await _transaction.RollbackAsync();
                    return InternalErrorResponse(ex);
                }
            }
        }

        public async Task<Response> UpcomingAppointment()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;

                var query = await (from r in _context.AppointmentRequest
                                   where r.PatientId == user.Id
                                   //join a in _context.Appointments on r.Id equals a.AppointmentRequestId
                                   //where a.Status == AppointStatus.UpComming
                                   join t in _context.Users on r.TherapistId equals t.Id
                                   join p in _context.TherapistProfiles on t.Id equals p.UserId

                                   select new
                                   {
                                       SessionId = r.Id,
                                       StartTime = r.StartTimeToString,
                                       EndTime = r.EndTime,
                                       Date = r.StartTime,
                                       TherapistFirstName = p.FirstName + " " + p.LastName,
                                       TherapistTitle = p.Title,
                                       Discipline = p.Specialization,
                                       Therapist = t.Email,
                                       TherapistId = t.Id,
                                       Amount = r.TotalAMount,
                                       ProblemDecription = r.ProblemDecription,
                                       Status = r.Status.ToString(),
                                       IsCompleted = false,
                                       IsDue = r.Status == AppointmentStatus.Due ? true : false,
                                       IsOverdue = r.Status == AppointmentStatus.Overdue ? true : false,


                                   }).OrderByDescending(x => x.EndTime).ToListAsync();

                return SuccessResponse(data: query);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> ReScheduleAppointtment(ReScheduleAppointmentDto model)
        {
            try
            {
                _adminLogger.LogRequest($"{"Task to Reschedule appointment session has started"}{" - "}{JsonConvert.SerializeObject(model)}{" - "}{DateTime.Now}");
                var user = _sessionManager.CurrentLogin;
                var session = _context.AppointmentRequest.FirstOrDefault(x => x.Id == model.SessionId && x.PatientId == user.Id);
                if (session == null)
                    return AuxillaryResponse("session not found", StatusCodes.Status404NotFound);



                var time = model.StartTime.ConvertToHour(model.Date);
                session.DateModified = DateTime.Now;
                session.StartTimeToString = model.StartTime;
                session.Status = AppointmentStatus.Upcomming;
                session.StartTime = time;
                session.EndTime = time.AddHours(2);
                session.AvailableTime = time.DateTime;

                _context.Update(session);
                if(!await SaveAsync())
                    return FailedSaveResponse();
                
                return SuccessResponse("Appointment has been re-scheduled successfully");
                
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response> GetTherapist()
        {
            try
            {
               
                var users = _userManager.Users.Where(x=> x.Discriminator == UserType.Therapist).ToList();
                if (users == null)
                    return SuccessResponse(data: null);
                var ratings = _context.Reviews.Where(x=> !x.IsDeleted).ToList();
                var data = (from user in users where user.HasProfile == true
                            join profile in _context.TherapistProfiles on user.TherapistUserProfileId equals profile.Id                    
                            select new 
                            {
                                TherapistId = user.Id,
                                Title = profile.Title,
                                FirstName = profile.FirstName,
                                LastName = profile.LastName,
                                YearsExperience = profile.YearsOfExperience ,
                                About = profile.Email,
                                PhoneNUmber = profile.PhoneNumber,
                                Specialization = profile.Specialization,
                                ConsultaionDays = profile?.ConsultationDays?.ToSplit('|'),
                                StartTime = profile.ConsultationStartTime,
                                EndTime = profile.ConsultationEndTime,
                                PicturePath = profile.ProfilePicture,
                                ServiceChargePerHoure = 50000,
                                NumberOfPatient = 50,
                                ReviewCount = ratings.Where(x => x.TherapistUserId == user.Id && x.RateCount > 0).Count(),
                                ReviewRatio = CalculateTherapisRating(user.Id).Ratio

                            }).OrderByDescending(x=> x.ReviewRatio).ToList();

                return SuccessResponse(data: data);

            }
            catch(Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public Response LogUserFeeling(List<string> feelings)
        {
            try
            {
                if(feelings == null)
                    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "feelings can not ne null" };

                var user = _sessionManager.CurrentLogin;

                if (!user.HasProfile)
                    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "profile has not been updated" };
                var userProfile = _context.UserProfile.FirstOrDefault(x => x.Id == user.ProfileId);
                userProfile.Feelings = String.Join("|", feelings);
                _context.Update(userProfile);  
                _context.Update(user);
                if(_context.SaveChanges() > 0)
                {
                    return SuccessResponse();
                }
                else
                {
                    return FailedSaveResponse();
                }
           

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public Response GetAllFeelings()
        {
            try
            {
                var fellings = new List<string> { "Sad","Depressed","Nocotogis", "Lonly","Relief", "Guilt", "Angry", "Empty",
                "Happy","Satisfied","Scared", "Anxios","Disgust","Love","Content"};
                return SuccessResponse(data: fellings);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public Response GetUserFeelings()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                if (!user.HasProfile)
                    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "profile has not been updated" };
                var profile = _context.UserProfile.FirstOrDefault(x => x.UserId == user.Id);
                var feelings = profile?.Feelings?.Split("|");
                return SuccessResponse(data: feelings);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetAllPlans()
        {


            try
            {
                var plans = _context.Plan.Select(x => new
                GetAllPlansDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    SubPlans = x.SubPlans.Select(s=> new
                    {
                        SubPlanId = s.Id,
                        Title = s.Title,
                        PLanId = s.PLanId,
                        NumberOfMeditation =s.NumberOfMeditation,
                        Cost = s.Cost,
                        TherapistCount = s.TherapistCount,
                        FreeTrialCount = s.FreeTrialCount

                    })
      
                });

                return SuccessResponse(data: plans);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetMessages()
        {

            try
            {
                var user = _sessionManager.CurrentLogin;
                var sendMessages = _context.Chats.Where(x=> x.SenderId == user.Id).Select(x => new
                {
                    ChatId = x.Id,
                    Message = x.Message,
                    Time = x.DateCreated,
                    MessageType = "Send",
                    ReceieverId = x.ReceieverId,
                    ReceieverUserName = x.Receiever.UserName

                });
                var receivedMessages = _context.Chats.Where(x => x.ReceieverId == user.Id).Select(x => new
                {
                    ChatId = x.Id,
                    Message = x.Message,
                    Time = x.DateCreated,
                    MessageType = "Recieved",
                    SenderId = x.SenderId,
                    SenderUserName = x.Sender.UserName

                });
                var message = sendMessages.Concat(sendMessages).OrderByDescending(x => x.Time).ToList();
                return SuccessResponse(data: message);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> CreateReview(CreateReviewDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var reveiew = new TherapistReview
                {
                    Time = model.Time,
                    ReviewComment = model.ReviewComment,
                    TherapistUserId = model.TherapistUserId,
                    PatientUserId = user.Id,
                    RateCount = model.ReviewStarCount
                    
                };

                await _context.Reviews.AddAsync(reveiew);
                if (!await SaveAsync())
                    return FailedSaveResponse(reveiew);
                return SuccessResponse();

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }




        }
        public Response GetReviewByTherapistId(long id)
        {
            try
            {


                var revews = _context.Reviews.Where(x=> !x.IsDeleted && x.TherapistUserId == id && x.RateCount > 0).OrderByDescending(x => x.DateCreated).ToList();
                var oneStarRating = revews.Where(x => x.RateCount == 1).Sum(x => x.RateCount);
                var twoStarRating = revews.Where(x => x.RateCount == 2).Sum(x => x.RateCount);
                var threeStarRating = revews.Where(x => x.RateCount == 3).Sum(x => x.RateCount);
                var fourStarRating = revews.Where(x => x.RateCount == 4).Sum(x => x.RateCount);
                var fiveStarRating = revews.Where(x => x.RateCount == 5).Sum(x => x.RateCount);

                var total = oneStarRating + twoStarRating + threeStarRating + fourStarRating + fiveStarRating;
                var oneStarPercent = oneStarRating > 0 ? (100 * oneStarRating) / total : 0;
                var twoStarPercent = twoStarRating > 0 ? (100 * twoStarRating) / total : 0;
                var threeStarPercent = threeStarRating > 0 ? (100 * threeStarRating) / total : 0;
                var fourStarPercent = fourStarRating > 0 ? (100 * fourStarRating) / total : 0;
                var fiveStarPercent = fiveStarRating > 0 ? (100 * fiveStarRating) / total : 0;

                var reviewRatio = (decimal.Parse(total.ToString()) > 0 ? decimal.Parse(total.ToString()) / decimal.Parse(revews.Count().ToString()) : 0);

                var query = (from review in revews
                            join profile in _context.UserProfile on review.PatientUserId equals profile.UserId
                            select new
                            {
                                ReviewId = review.Id,
                                ReviewStar =  review.RateCount,
                                ReviewComment = review.ReviewComment,
                                ReviewName = $"{profile.FirstName} {profile.LastName}",
                                Picture = profile.FilePath,
                                Time = review.Time,
                                
                            }).ToList();

                var data = new
                {
                    TotalReviewCount = revews.Count(),
                    ReviewRation = Math.Round(reviewRatio, 1),
                    OneStarPercentage = oneStarPercent,
                    TwoStarPercentage = twoStarPercent,
                    ThreeStarPercentage = threeStarPercent,
                    FourStarPercentage = fourStarPercent,
                    FiveStarPercentage = fiveStarPercent,
                    Reviews = query,


                };

                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
          
            }
        }


        public ReviewCalculationDto CalculateTherapisRating(long id)
        {
            var revews = _context.Reviews.Where(x => !x.IsDeleted && x.TherapistUserId == id && x.RateCount > 0)
                .OrderByDescending(x => x.DateCreated).ToList();

            var oneStarRating = revews.Where(x => x.RateCount == 1).Sum(x => x.RateCount);
            var twoStarRating = revews.Where(x => x.RateCount == 2).Sum(x => x.RateCount);
            var threeStarRating = revews.Where(x => x.RateCount == 3).Sum(x => x.RateCount);
            var fourStarRating = revews.Where(x => x.RateCount == 4).Sum(x => x.RateCount);
            var fiveStarRating = revews.Where(x => x.RateCount == 5).Sum(x => x.RateCount);

            var total = oneStarRating + twoStarRating + threeStarRating + fourStarRating + fiveStarRating;
            var oneStarPercent = oneStarRating > 0 ? (100 * oneStarRating) / total : 0;
            var twoStarPercent = twoStarRating > 0 ? (100 * twoStarRating) / total : 0;
            var threeStarPercent = threeStarRating > 0 ?(100 * threeStarRating) / total : 0;
            var fourStarPercent = fourStarRating > 0 ? (100 * fourStarRating) / total : 0;
            var fiveStarPercent = fiveStarRating > 0  ? (100 * fiveStarRating) / total : 0;

            var reviewRatio = (decimal.Parse(total.ToString()) > 0 ? decimal.Parse(total.ToString()) / decimal.Parse(revews.Count().ToString()) : 0);

            return new ReviewCalculationDto
            {
                Reviews =  revews,
                TotalRating = total,
                OneStarPercent = oneStarPercent,
                TwoStarPercent = twoStarPercent,
                ThreeStarPercent = threeStarPercent,
                FourStarPercent = fourStarPercent,
                Ratio = Math.Round(reviewRatio, 1),

            };
        }

    }
}
