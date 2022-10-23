using AutoMapper;
using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Payment;
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
            _userManager = userManager;
            _fileManager = fileManager;
            _adminLogger = adminLogger;
            _paymentServices = paymentServices;
            _mapper = mapper;
            this.contextAccessor = contextAccessor;
            var scheme = contextAccessor?.HttpContext?.Request.Scheme;
            var host = contextAccessor?.HttpContext?.Request.Host.Value;
            root = $"{scheme}://{host}/";
            _sessionManager = sessionManager;
        }

        public async Task<Response> UpdateProfileAsync (UpdateProfileDto model)
        {
            try
            {

                var userId = _sessionManager.CurrentLogin.Id;
                var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
                if (user == null)
                    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "user does not exist" };

                if (user.HasProfile)
                    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "profile has been updated for this user" };


                var profile = new UserProfile
                {
                    UserId = userId,
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

                var isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                {
                    var id = record.Member("Id").CurrentValue;
                    //var id = long.Parse(id);
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

        public async Task<Response> GetTherapist()
        {
            try
            {

                var users = await _userManager.GetUsersInRoleAsync(UserRoles.SuperAdministrator);

                var data = (from user in users where user.HasProfile == true
                            join profile in _context.UserProfile on user.Id equals profile.UserId
                            join profile2 in _context.TherapistHospitalInformations on user.Id equals profile2.TherapistId
                            join profile3 in _context.TherapistmedicalRegistrations on user.Id equals profile3.TherapistId
                           
                            select new GetTherapistDto
                            {
                                Id = user.Id,
                                FirstName = profile.FirstName,
                                LastName = profile.LastName,
                                YearsExperience = "10",
                                Ratings = 12,
                                About = "lorem",
                                //HoursWorking = "Mondya-Saturday (08:30 AM - 09: PM)",
                                PhoneNUmber = "08037620380",
                                PicturePath = profile?.FilePath,

                            }).ToList();

                data.Add(new GetTherapistDto
                {
                    Id = 6,
                    Descipline = "Psychology",
                    FirstName = "Ifeanyi",
                    LastName =  "Ozougwu",
                    Ratings = 12,
                    Specialization =  new List<string> { "Bsc", "LBS" },
                    YearsExperience = "4",
                    About = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Qui adipisci dolor odit architecto, cupiditate totam blanditiis veritatis" +
                    " ducimus unde consequuntur impedit fugiat voluptate amet in non beatae saepe corrupti laboriosam.",
                    ListofDays = "5",
                    StartTime = "9Am",
                    EndTime = "5pm",
                    PhoneNUmber = "08037620380",
                    PicturePath = root +"Resources/files/" + "usman-yousaf-pTrhfmj2jDA-unsplash.jpg"
                });
                data.Add(new GetTherapistDto
                {
                    Id = 6,
                    FirstName = "Chinedu",
                    LastName = "Eze",
                    Descipline = "Therapist",
                    Ratings = 12,
                    Specialization = new List<string> { "Bsc", "LBS" },
                    YearsExperience = "4",
                    About = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Qui adipisci dolor odit architecto, cupiditate totam blanditiis veritatis" +
                    " ducimus unde consequuntur impedit fugiat voluptate amet in non beatae saepe corrupti laboriosam.",
                    ListofDays = "5",
                    StartTime = "10Am",
                    EndTime = "5pm",
                    PhoneNUmber = "08037623425243",
                    PicturePath = root + "Resources/files/" + "usman-yousaf-pTrhfmj2jDA-unsplash.jpg"
                });
                return SuccessResponse(data: data);

            }
            catch(Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetAllPlans()
        {
            try
            {
                var plans = _context.Plan.ToList().Select(x => new
                GetAllPlansDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Cost = x.Cost,
                    Therapist = x.TherapistCount,
                    DailyMeditation = x.DailyMeditationCount,
                    FreeDaysTrialCount = x.FreeTrialCount,
                });

                return SuccessResponse(data: plans);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
