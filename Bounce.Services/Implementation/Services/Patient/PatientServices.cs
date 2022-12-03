using AutoMapper;
using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Payment;
using Bounce.DataTransferObject.Helpers;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.Persistence.Interfaces.Payment;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_Applucation.DTO.Auth;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Bounce_Domain.Enum;
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
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor contextAccessor;
        private string root = "";
        private readonly SessionManager _sessionManager;
        public PatientServices(BounceDbContext context, UserManager<ApplicationUser> userManager, FileManager fileManager, AdminLogger adminLogger, IPaymentServices paymentServices, IMapper mapper, IHttpContextAccessor contextAccessor, SessionManager sessionManager) : base(context)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _fileManager = fileManager;
            _adminLogger = adminLogger;
            _paymentServices = paymentServices;
            _mapper = mapper;
            this.contextAccessor = contextAccessor;
            var scheme = contextAccessor?.HttpContext?.Request.Scheme;
            var host = contextAccessor?.HttpContext?.Request.Host.Value;
            root = $"{scheme}://{host}/";
            _sessionManager = sessionManager;
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
                    return new Response { StatusCode = StatusCodes.Status200OK, Message = "Profile Updated" };
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

        public async Task<Response> BookAppointment(AppointmentDto model)
        {
            var user = _sessionManager.CurrentLogin;
            using (var _transaction = await  _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var paymentModel = new PaymentRequestDto
                    {
                        PaymentType = model.PaymentType,
                        Amount = model.TotalAMount

                    };
                    LogInfo($"{"Started task to initialize payment }"}{" - "}{JsonConvert.SerializeObject(model)}{" - "}{DateTime.Now}");

                    if (!Enum.TryParse<PaymentType>(model.PaymentType.ToLower(), out PaymentType paymentType))
                        return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "Invalid payment type" };

                    var payment = new PaymentRequest
                    {
                        PaymentRequestId = DateTime.Now.Ticks.ToString(),
                        UserId = _sessionManager.CurrentLogin.Id,
                        PaymentType = paymentType,
                        Amount = paymentModel.Amount,
                        PlanId = 1,


                    };
                    await _context.AddAsync(payment);
         
                    var appointement = _mapper.Map<AppointmentRequest>(model);
                    appointement.TrxRef = payment.PaymentRequestId;
                    appointement.PatientId = user.Id;
                    appointement.AgeRange = "";
                    _context.Add(appointement);

                   await  _context.SaveChangesAsync();
                    await _transaction.CommitAsync();

   
                    return SuccessResponse(data: new { TrxRef = appointement.TrxRef });
                }
                catch (Exception ex)
                {
                    await _transaction.RollbackAsync();
                    return InternalErrorResponse(ex);
                }
            }
        }

        public async Task<Response> ReScheduleAppointtment(ReScheduleAppointmentDto model)
        {
            try
            {
                _adminLogger.LogRequest($"{"Task to Reschedule appointment session has started"}{" - "}{JsonConvert.SerializeObject(model)}{" - "}{DateTime.Now}");
                var user = _sessionManager.CurrentLogin;
                var session = _context.AppointmentRequest.FirstOrDefault(/*x => x.Id == model.SessionId*/ /*&& x.PatientId == user.Id*/);
                if (session == null)
                    return AuxillaryResponse("session not found", StatusCodes.Status404NotFound);

                var time = model.StartTime.ConvertToHour(model.Date);
                session.DateModified = DateTime.Now;
                session.StartTime = time;
                session.EndTime = time.AddHours(2);
                session.AvailableTime = time.DateTime;
                //session.AvailableTime = model.StartTime;
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

                var data = (from user in users where user.HasProfile == true
                            join profile in _context.TherapistProfiles on user.TherapistUserProfileId equals profile.Id                    
                            select new 
                            {
                                TherapistId = user.Id,
                                Title = profile.Title,
                                FirstName = profile.FirstName,
                                LastName = profile.LastName,
                                YearsExperience = profile.YearsOfExperience ,
                                Ratings = 5,
                                About = profile.Email,
                                PhoneNUmber = profile.PhoneNumber,
                                Specialization = profile.Specialization,
                                ConsultaionDays = profile?.ConsultationDays?.ToSplit('|'),
                                StartTime = profile.ConsultationStartTime,
                                EndTime = profile.ConsultationEndTime,
                                PicturePath = profile.ProfilePicture,
                                ServiceChargePerHoure = 50000,
                                NumberOfPatient = 50,
                                Rating = 5

                            }).ToList();

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
                _context.SaveChanges();
                return SuccessResponse();

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

            #region Subplans
            var subplans = new List<SubPlan>
            {
                new SubPlan
                {
                    Title = "Annual",
                    PLanId = 3,
                    NumberOfMeditation = 100,
                    Cost = 100000,
                    TherapistCount = 50,
                    FreeTrialCount = 50,

                },
                 new SubPlan
                {
                    Title = "Quarter",
                    PLanId = 3,
                    NumberOfMeditation = 50,
                    Cost = 80000,
                    TherapistCount = 36,
                    FreeTrialCount = 30,

                },
                new SubPlan
                {
                    Title = "Month",
                    PLanId = 3,
                    NumberOfMeditation = 30,
                    Cost = 500000,
                    TherapistCount = 30,
                    FreeTrialCount = 20,

                },////////////////

                 new SubPlan
                {
                    Title = "Annual",
                    PLanId = 2,
                    NumberOfMeditation = 50,
                    Cost = 50000,
                    TherapistCount = 30,
                    FreeTrialCount = 20,

                },
                 new SubPlan
                {
                    Title = "Quarter",
                    PLanId = 2,
                    NumberOfMeditation = 40,
                    Cost = 420000,
                    TherapistCount = 30,
                    FreeTrialCount = 30,

                },
                new SubPlan
                {
                    Title = "Month",
                    PLanId = 2,
                    NumberOfMeditation = 30,
                    Cost = 350000,
                    TherapistCount = 29,
                    FreeTrialCount = 18,

                },////////
                 new SubPlan
                {
                    Title = "Annual",
                    PLanId = 1,
                    NumberOfMeditation = 30,
                    Cost = 20000,
                    TherapistCount = 20,
                    FreeTrialCount = 10,

                },
                 new SubPlan
                {
                    Title = "Quarter",
                    PLanId = 1,
                    NumberOfMeditation = 20,
                    Cost = 10000,
                    TherapistCount = 15,
                    FreeTrialCount = 5,

                },
                new SubPlan
                {
                    Title = "Month",
                    PLanId = 2,
                    NumberOfMeditation = 10,
                    Cost = 5000,
                    TherapistCount = 10,
                    FreeTrialCount = 2,

                },
            };
            #endregion

            try
            {
                var plans = _context.Plan.ToList().Select(x => new
                GetAllPlansDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    SubPlans = subplans.Where(s=> s.PLanId == x.Id).ToList()
      
                });

                return SuccessResponse(data: plans);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> UpcomingAppointment()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;

                var query = await (from r in _context.AppointmentRequest
                                   where r.PatientId == user.Id
                                   join a in _context.Appointments on r.Id equals a.AppointmentRequestId
                                   where a.Status == AppointStatus.UpComming
                                   join t in _context.Users on r.TherapistId equals t.Id
                                   join p in _context.TherapistProfiles on t.Id equals p.UserId

                                   select new
                                   {    
                                       SessionId = r.Id,
                                       StartTime = r.StartTime,
                                       EndTime = r.EndTime,
                                       Time = r.StartTime/*.ToString(AdminConstants.FullTime)*/,
                                       Date = r.StartTime/*.ToString(AdminConstants.FullDate)*/,
                                       TherapistFirstName = p.FirstName + " " + p.LastName,
                                       TherapistTitle = p.Title,
                                       Discipline = p.Specialization,
                                       Therapist = t.Email,
                                       TherapistId = t.Id,
                                       Amount = r.TotalAMount,
                                 
                                   }).OrderByDescending(x=> x.Time).ToListAsync();

                return SuccessResponse(data: query);

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
                var oneStarPercent = (100 * oneStarRating) / total;
                var twoStarPercent = (100 * twoStarRating) / total;
                var threeStarPercent = (100 * threeStarRating) / total;
                var fourStarPercent = (100 * fourStarRating) / total;
                var fiveStarPercent = (100 * fiveStarRating) / total;

                var reviewRatio = (decimal.Parse(total.ToString()) / decimal.Parse(revews.Count().ToString()));

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
    }
}
