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
                    EatingHabit = model.EatingHabit,
                    PhysicalHealthRate = model.PhysicalHealthRate,
                    MentalHealthRate = model.MentalHealthRate,
                    EmotionalHealthRate = model.EmotionalHealthRate,
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
                        Image = profile.FilePath,
                        EatingHabit = model.EatingHabit,
                        PhysicalHealthRate = model.PhysicalHealthRate,
                        MentalHealthRate = model.MentalHealthRate,
                        EmotionalHealthRate = model.EmotionalHealthRate,

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
            LogInfo($"{"Started task to initialize plan subscription }"}{" - "}{subplanId}{" - "}{DateTime.Now}");
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = _sessionManager.CurrentLogin;

                    var plan = _context.SubPlan.Include(x=> x.Plan).FirstOrDefault(x => x.Id == subplanId);
                    var wallet = _context.Wallets.FirstOrDefault(x => x.UserId == user.Id);
                    if (wallet?.Balance < plan.Cost)
                        return AuxillaryResponse("Insufficient balance", StatusCodes.Status402PaymentRequired);

                    wallet.Balance = wallet.Balance - plan.Cost;
                    _context.Update(wallet);

                    var payment = new PaymentRequest
                    {
                        PaymentRequestId = DateTime.Now.Ticks.ToString(),
                        PaymentType = PaymentType.wallet,
                        UserId = _sessionManager.CurrentLogin.Id,
                        Amount = plan.Cost,
                        SubPlanId = subplanId,
                        PaymentDecription = "Plan Subscription",
                        CreatedTimeOffset = DateTimeOffset.Now

                    };
                    await _context.AddAsync(payment);

                    var subscription = new Subscription
                    {
                        UserId = user.Id,
                        SubPlanId = subplanId,
                        IsActive = true
                    };
                    await _context.AddAsync(subscription);

                   

                    if (!await SaveAsync())
                        return FailedSaveResponse();

                    var trans = new Transaction
                    {
                        RequestId = payment.Id,
                        TransactionType = TransactionType.Wallet,
                        Decription = "Plan Subscription",
                        UserId = user.Id,
                        status = "00",
                        CreatedTimeOffset = DateTimeOffset.UtcNow,
                        TransactionRef = payment.PaymentRequestId,
                        Amount = (decimal)plan.Cost
 
                    };

                    await _context.AddAsync(trans);
                    if (!await SaveAsync())
                        return FailedSaveResponse();

                    await transaction.CommitAsync();

                    var userProfile = _context.UserProfile.FirstOrDefault(x => x.UserId == user.Id);
                    var mailBuilder = new StringBuilder();

                    mailBuilder.AppendLine("Dear" + " " + userProfile.FirstName + "," + "<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine($"Your {plan.Title} plan subscription was successful<br />");
                    mailBuilder.AppendLine("<br />");
                    mailBuilder.AppendLine("Regards:<br />");

                    var emailRequest = new EmailRequest
                    {
                        To = user.Email,
                        Body = EmailFormatter.FormatGenericEmail(mailBuilder.ToString(), rootPath),
                        Subject = "Plan Subscription"
                    };

                    await _EmailService.SendMail(emailRequest).ConfigureAwait(false);

                    var pushNotifications = new List<PushNotificationDto>();
                    var patientPushNotification = new PushNotificationDto
                    {
                        Title = "Plan Subscription",
                        Topic = "Plan Subscription",
                        Message = $"Your {plan.Title} plan subscription was successful",
                        TrxRef = payment.PaymentRequestId,
                        userId = userProfile.UserId,

                    };
                    pushNotifications.Add(patientPushNotification);
                  
                    await _notificationService.PushMultipleNotificationAsyn(pushNotifications);

                    LogInfo($"{"task to subscribe to plan was successful "} transactionRef: {payment.PaymentRequestId}{" - "} Amount: {payment.Amount}{" - "}{DateTime.Now}");
                    return SuccessResponse("Your subscription was successful");
                }
                catch (Exception ex)
                {
                   await  transaction.RollbackAsync();
                    return InternalErrorResponse(ex);
                }
            }
        }

        public async Task<Response> GetAvialableTimeByTherapistId(long therapistid, DateTime date)
        {
            try
            {
                var therapist = _context.TherapistProfiles.FirstOrDefault(x => x.UserId == therapistid);
                if (therapist == null)
                    return AuxillaryResponse("user not found", StatusCodes.Status400BadRequest);

                var validTimes = new List<string>();
                var startTime = therapist.ConsultationStartTime.ConvertToHourLocal(DateTime.Now);
                var endTime = therapist.ConsultationEndTime.ConvertToHourLocal(DateTime.Now);

                var availableHours = GetAvailableSingleTime(startTime, endTime);
                var consultaionsTimes = _context.AppointmentRequest.Where(x=> x.Date.Value.Date == date.Date)
                    .Where(x => x.TherapistId == therapistid).Select(x => x.StartTimeToString).ToList();
                foreach (var time in availableHours)
                {
                    if (!consultaionsTimes.Contains(time))
                    {
                        if(date.Date == DateTime.Now.Date)
                        {
                            if(time.ValidTime())
                            {
                                validTimes.Add(time);
                            }
                          
                        }
                        else
                        {
                            validTimes.Add(time);
                        }
                       
                    }
                }
        

                return SuccessResponse(data: validTimes);

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
                    var time = model.StartTime.ConvertToHourLocal((DateTime)model.Date);
                    if (time <= DateTime.Now)
                    {
                        return AuxillaryResponse("Your booking time must be greater than current time", StatusCodes.Status400BadRequest);
                    }

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

                    //var time = model.StartTime.ConvertToHour((DateTimeOffset)model.Date);
                    var appointement = _mapper.Map<AppointmentRequest>(model);
                    appointement.StartTime = time;
                    appointement.StartTimeToString = model.StartTime;
                    appointement.Status = AppointmentStatus.Upcomming;
                    appointement.EndTime = time.AddHours(1);
                    appointement.AvailableTime = time;
                    appointement.TrxRef = payment.PaymentRequestId;
                    appointement.PatientId = user.Id;
                    appointement.ReasonForTherapy = model.ReasonForTherapy;
                    appointement.IsPaymentCompleted = true;
                    
                    await _context.AddAsync(appointement);


                    if (!await SaveAsync())
                        return FailedSaveResponse();

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


        public async Task<Response> UpcomingAppointment(string filter)
        {
            try
            {
                filter = filter.ToLower();
                if (filter != "completed" && filter != "upcoming")
                    return AuxillaryResponse("invalid filter value, use can use 'upcoming' or 'completed' as filter value", StatusCodes.Status400BadRequest);

                var user = _sessionManager.CurrentLogin;
                var request = _context.AppointmentRequest.Where(x => x.PatientId == user.Id);
                if (filter.Equals("completed"))
                    request = request.Where(x => x.Status == AppointmentStatus.Completed);
                else
                    request = request.Where(x => x.Status != AppointmentStatus.Completed);

                var ssss = request.ToList();

                var query = await (from r in request
                                   join t in _context.Users on r.TherapistId equals t.Id
                                   join p in _context.TherapistProfiles on t.Id equals p.UserId

                                   select new
                                   {
                                       SessionId = r.Id,
                                       StartTime = r.StartTimeToString,
                                       EndTime = r.EndTime,
                                       Date = r.StartTime,
                                       Time = r.StartTime.HasValue ? r.StartTime.Value.ToString("D") + " " + "at " + r.StartTime.Value.ToString("t") : "",
                                       TherapistFirstName = p.FirstName + " " + p.LastName,
                                       TherapistTitle = p.Title,
                                       Discipline = p.Specialization,
                                       Therapist = t.Email,
                                       TherapistId = t.Id,
                                       ReasonForTherapy = r.ReasonForTherapy,
                                       AdditionalNote = r.ProblemDecription,
                                       Amount = r.TotalAMount,
                                       ProblemDecription = r.ProblemDecription,
                                       Status = r.Status.ToString(),
                                       IsCompleted = false,
                                       IsDue = r.Status == AppointmentStatus.Due ? true : false,
                                       IsOverdue = r.Status == AppointmentStatus.Overdue ? true : false,
                                   


                                   }).OrderByDescending(x => x.Date).ToListAsync();

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


                if (session.Status == AppointmentStatus.Completed)
                    return AuxillaryResponse("session has been completed", StatusCodes.Status400BadRequest);


                if (session.StartTime.Value.LocalDateTime <= DateTime.Now)
                    return AuxillaryResponse("you can not re-schedule session at this moment try again later", StatusCodes.Status400BadRequest);



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
        public async Task<Response> UpdateUserFellings(UpdateUserModeDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var profile = _context.UserProfile.FirstOrDefault(x => x.UserId == user.Id);

                if (profile != null)
                {
                    profile.Feelings = String.Join('|', model.Mood);
                    _context.Update(profile);

                    if (!await SaveAsync())
                        return FailedSaveResponse(model);
                    return SuccessResponse();
                }
                else
                {
                    return AuxillaryResponse("mood can not be null", StatusCodes.Status400BadRequest);
                }


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


        public Response GetAllPatient()
        {
            try
            {
                var data = (from user in _context.Users.Where(x => x.Discriminator == UserType.Patient)
                            join patientProfile in _context.UserProfile on user.Id equals patientProfile.UserId
                            select new
                            {

                                Id = user.Id,
                                UserName = user.UserName,
                                FirstName = patientProfile.FirstName,
                                LastName = patientProfile.LastName,
                                Email = user.Email,
                                ProfilePicture = patientProfile.FilePath,
                                Gender = patientProfile.Gender,
                                PhoneNumber = patientProfile.Phone,
                                DateOfBirth = patientProfile.DateOfBirth.ToShortDateString(),
                            }).ToList();

                
                return SuccessResponse(data: data);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response SearchPatient(string query)
        {
            try
            {
                var data = (from user in _context.Users.Where(x => x.Discriminator == UserType.Patient)
                            join patientProfile in _context.UserProfile.Where(x=> x.FirstName.Contains(query) || x.LastName.Contains(query) || x.Gender.Contains(query)
                            || x.EatingHabit.Contains(query) || x.Feelings.Contains(query) || x.PhysicalHealthRate.Contains(query))
                            
                            on user.Id equals patientProfile.UserId
                            select new
                            {

                                Id = user.Id,
                                UserName = user.UserName,
                                FirstName = patientProfile.FirstName,
                                LastName = patientProfile.LastName,
                                Email = user.Email,
                                ProfilePicture = patientProfile.FilePath,
                                Gender = patientProfile.Gender,
                                PhoneNumber = patientProfile.Phone,
                                DateOfBirth = patientProfile.DateOfBirth.ToShortDateString(),
                            }).ToList();


                return SuccessResponse(data: data);
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }



        public Response GetPatienceById (long id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id && x.Discriminator == UserType.Patient);
                if (user == null)
                    return AuxillaryResponse("User does not exist", StatusCodes.Status404NotFound);

                var patientProfile = _context.UserProfile.FirstOrDefault(x=> x.UserId == id);
                if (patientProfile == null)
                    return AuxillaryResponse("User does not have not profile", StatusCodes.Status404NotFound);


                var data = new
                {
                    Id = id,
                    UserName = user.UserName,
                    FirstName = patientProfile?.FirstName,
                    LastName = patientProfile?.LastName,
                    Email = user.Email,
                    ProfilePicture = patientProfile?.FilePath,
                    Gender = patientProfile?.Gender,
                    PhoneNumber = patientProfile?.Phone,
                    DateOfBirth = patientProfile?.DateOfBirth.ToShortDateString(),

                };
                return SuccessResponse(data: data);
            }
            catch(Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetPatienceProfileHistory(long id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id && x.Discriminator == UserType.Patient);
                if (user == null)
                    return AuxillaryResponse("User does not exist", StatusCodes.Status404NotFound);

                var patientProfile = _context.UserProfile.FirstOrDefault(x => x.UserId == id);
                if (patientProfile == null)
                    return AuxillaryResponse("User does not have not profile", StatusCodes.Status404NotFound);

                var consultaions = _context.AppointmentRequest.Where(x => x.PatientId == id).ToList();
                var prescription = (from t in consultaions
                                    join p in _context.Prescriptions on t.Id equals
                                    p.AppointmentRequestId 
                                    join therapist in _context.TherapistProfiles on t.TherapistId equals therapist.UserId
                                    select new
                                    {
                                        Title = t.ReasonForTherapy,
                                        Medication = p.PrescriptionText,
                                        Time = p.DateCreated,
                                        Therapist = therapist.Title + " " + therapist.FirstName + " " + therapist.LastName,
                                        Dosage = p.Dosage,
                                        Drug = p.Drug


                                    });
                var data = new
                {
                    Id = id,
                    UserName = user.UserName,
                    FirstName = patientProfile?.FirstName,
                    LastName = patientProfile?.LastName,
                    Email = user.Email,
                    ProfilePicture = patientProfile?.FilePath,
                    Gender = patientProfile?.Gender,
                    PhoneNumber = patientProfile?.Phone,
                    DateOfBirth = patientProfile?.DateOfBirth.ToString("M"),
                    PhysicalHealth = patientProfile.PhysicalHealthRate,
                    MentalHealth = patientProfile?.MentalHealthRate,
                    EmotionalHealth = patientProfile.EmotionalHealthRate,
                    EatenHabit = patientProfile.EatingHabit,
                    Complains = consultaions.Select(x=> new
                    {
                        ReasonForTherapy = x.ReasonForTherapy,
                        ProblemDecription = x.ProblemDecription,
                        Date = x.DateCreated,
                    }),
                    Prescriptions = prescription.Select(x=> new 
                    {
                        Title = x.Title,
                        Drug = x.Drug,
                        Dosage = x.Dosage,
                        Medication = x.Medication,
                        Date = x.Time,
                        Therapist = x.Therapist
                    })

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

        private List<string> GetAvailableSingleTime(DateTime startDate, DateTime endDate)
        {
            var availabeleTimes = new List<string>();
            var count = 0;

            while (count != -1)
            {
                var time2 = startDate.AddHours(count).ToString("hh:00 t");
                var time3 = startDate.AddHours(count + 1).ToString("hh:00 t");
                var formatedStartDate = Uri.UnescapeDataString(time2);

                if (formatedStartDate.Contains("P"))
                    formatedStartDate = formatedStartDate.Replace("P", "PM");
                if (formatedStartDate.Contains("A"))
                    formatedStartDate = formatedStartDate.Replace("A", "AM");


                var realTime = $"{formatedStartDate}";
                availabeleTimes.Add(realTime);

                count++;
                if (endDate.Hour == startDate.AddHours(count).Hour)
                {
                    count = -1;
                }
            }
            return availabeleTimes;
        }

        private List<string> GetAvailableTime(DateTime startDate, DateTime endDate)
        {
            var availabeleTimes = new List<string>();
            var count = 0;

            while (count != -1)
            {
                var time2 = startDate.AddHours(count).ToString("hh:00 t");
                var time3 = startDate.AddHours(count + 1).ToString("hh:00 t");
                var formatedStartDate = Uri.UnescapeDataString(time2);
                var formatedEndDate= Uri.UnescapeDataString(time3);

                if (formatedStartDate.Contains("P"))
                    formatedStartDate = formatedStartDate.Replace("P", "PM");
                if (formatedStartDate.Contains("A"))
                    formatedStartDate = formatedStartDate.Replace("A", "AM");

                if (formatedEndDate.Contains("P"))
                    formatedEndDate = formatedEndDate.Replace("P", "PM");
                if (formatedEndDate.Contains("A"))
                    formatedEndDate = formatedEndDate.Replace("A", "AM");


                var realTime = $"{formatedStartDate} - {formatedEndDate}";
                availabeleTimes.Add(realTime);

                count++;
                if (endDate.Hour == startDate.AddHours(count).Hour)
                {
                    count = -1;
                }
            }
            return availabeleTimes;
        }


    }
}
