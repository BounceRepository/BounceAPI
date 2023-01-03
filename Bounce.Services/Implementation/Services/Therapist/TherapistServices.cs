using AutoMapper;
using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Therapist;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.Persistence.Interfaces.Therapist;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Therapist
{
    public class TherapistServices: BaseServices, ITherapistServices
    {
     
        private readonly FileManager _fileManager;
        private readonly AdminLogger _adminLogger;
        private readonly IMapper _mapper;
        private readonly SessionManager _sessionManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientServices _patientServices;

        public TherapistServices(BounceDbContext context, FileManager fileManager, AdminLogger adminLogger, IMapper mapper, SessionManager sessionManager, UserManager<ApplicationUser> userManager, IPatientServices patientServices) : base(context)
        {
            _fileManager = fileManager ?? throw new ArgumentNullException(nameof(fileManager));
            _adminLogger = adminLogger ?? throw new ArgumentNullException(nameof(adminLogger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _sessionManager = sessionManager;
            _userManager = userManager;
            _patientServices = patientServices;
        }

        public async Task<Response> CreateTherapistProfile(TherapistProfileDto model)
        {
           using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = _sessionManager.CurrentLogin;
                    var existingProfile = _context.TherapistProfiles.FirstOrDefault(x => x.UserId == user.Id);
                    if(existingProfile != null)
                    {
                        var profile = _mapper.Map<TherapistProfile>(model);
                        if(model.ProfilePicture != null)
                        {
                            existingProfile.ProfilePicture = _fileManager.FileUpload(model.ProfilePicture);
                        }
            
                        var entity = _context.Set<TherapistProfile>().Add(profile);
                        var response = _mapper.Map<TherapistProfileResponseDto>(model);

                        response.ProfilePicture = profile.ProfilePicture;
                        response.EmailAddress = user.Email;

                        if (!await SaveAsync())
                            return FailedSaveResponse(model);
                        await transaction.CommitAsync();

                        return SuccessResponse(data: response);
                    }
                    else
                    {
                        var profile = _mapper.Map<TherapistProfile>(model);
                        profile.ProfilePicture = _fileManager.FileUpload(model.ProfilePicture);
                        profile.UserId = user.Id;

                        var entity = _context.Set<TherapistProfile>().Add(profile);
                        var response = _mapper.Map<TherapistProfileResponseDto>(model);

                        response.ProfilePicture = profile.ProfilePicture;
                        response.EmailAddress = user.Email;
                        var wallet = new Wallet
                        {
                            UserId = user.Id
                        };
                        _context.Add(wallet);

                        if (!await SaveAsync())
                            return FailedSaveResponse(model);

                        user.TherapistUserProfileId = entity.Entity.Id;
                        user.HasProfile = true;
                        await _userManager.UpdateAsync(user);
                        await transaction.CommitAsync();

                        return SuccessResponse(data: response);
                    }
                   

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return InternalErrorResponse(ex);
                }

            }
        }
        public async Task<Response> BankDetailsUpsert(BankAccountDetailDto model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var bankProfile = _context.BankAccountDetails.FirstOrDefault(x => x.TherapistId == user.Id);

                var entity = _mapper.Map<BankAccountDetails>(model);
                if (bankProfile == null)
                {
                    entity.TherapistId = user.Id;
                    _context.Add(entity);
                }               
                else
                {
                    bankProfile.AccountName = model.AccountName;
                    bankProfile.AccountNumber = model.AccountNumber;
                    bankProfile.BankName = model.BankName;
                    _context.Update(bankProfile);
                }
                if (!await SaveAsync())
                    return FailedSaveResponse(bankProfile);
                return SuccessResponse();
            }
            catch (Exception ex)
            {

                return InternalErrorResponse(ex);
            }
        }

        public Response GetTherapistDashBoard()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var consulations = _context.AppointmentRequest.Where(x => !x.IsDeleted).Where(x => x.TherapistId == user.Id && x.IsPaymentCompleted).ToList();
                var data = new
                {
                    TherapistId = user.Id,
                    Title = user.TherapistProfile.Title,
                    FirstName = user.TherapistProfile.FirstName,
                    LastName = user.TherapistProfile.LastName,
                    PhoneNumber = user.TherapistProfile.PhoneNumber,
                    ProfilePicture = user.TherapistProfile.ProfilePicture,
                    MonthlyConsultationCount = consulations.Count(),
                    TotalPatient = consulations.DistinctBy(x=> x.PatientId).Count()

                };
                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }


        public Response GetPatientProfileHistory(long patientId)
        {
            try
            {
                var profile = _context.UserProfile.FirstOrDefault(x => x.UserId == patientId);
                if (profile == null)
                    return AuxillaryResponse("user does not exist", StatusCodes.Status400BadRequest);


                var data = new
                {
                    PatientName = profile.FirstName + " " + profile.LastName,
                    PatientId = patientId,
                    PatientNamePicure = profile.FilePath,
                    Gender = profile.Gender,
                    DateOfBirth = profile.DateOfBirth.Date.ToString("MMM dd"),
                    PhoneNumber = profile.Phone,
                    PhysicalHealth = profile.PhysicalHealthRate,
                    MentalHealth = profile.MentalHealthRate,
                    EmotionalHealth = profile.EmotionalHealthRate,
                    EatingHabit = profile.EatingHabit

                };

                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }

        public Response GetTherapistConsultaionById(long id)
        {
            try
            {

                var data = (from consultation in _context.AppointmentRequest
                            where consultation.Id == id && !consultation.IsDeleted
                            join patient in _context.UserProfile on consultation.PatientId equals patient.UserId
                            select new
                            {
                                PatientName = patient.FirstName + " " + patient.LastName,
                                PatientId = patient.Id,
                                PatientNamePicure = patient.FilePath,
                                PrefaredDate = consultation.Date,
                                ReasonForTherapy = consultation.ReasonForTherapy,
                                AvailableTime = consultation.StartTimeToString,
                                AdditionalNote = consultation.ProblemDecription,
                                IsDue = consultation.Status == Bounce_Domain.Enum.AppointmentStatus.Due ? true : false,
                                IsOverdue = consultation.Status == Bounce_Domain.Enum.AppointmentStatus.Overdue ? true : false,

                            }).FirstOrDefault();

                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }

        public Response GetTherapistSchedules()
        {
            try
            {

                var schelues = new List<SchedulersDto>();
                var user = _sessionManager.CurrentLogin;
                var appointments = _context.AppointmentRequest.Where(x => x.TherapistId == user.Id).OrderByDescending(x => x.StartTime).ToList();
                var patients = _context.UserProfile.ToList();
                var groupeDate = appointments
                    .GroupBy(key => key.StartTime.GetValueOrDefault().Date).Select(x=> x.Key.Date);
                foreach (var item in groupeDate)
                {
                    var appointmentRequests = appointments.Where(x => x.StartTime.GetValueOrDefault().Date == item.Date).ToList();
                    var sheduleItems = (from req in appointmentRequests join pat in patients on req.PatientId equals pat.UserId
                                select new SchedulersItmesDto
                                {
                                    PatientName = pat.FirstName + " " + pat.LastName,
                                    StartTime = req.StartTimeToString,
                                    Status = req.Status.ToString(),
                                    Time = req.StartTime.GetValueOrDefault().DateTime,
                                }).ToList();


                    var sche = new SchedulersDto
                    {
                        Date = item.Date,
                        Appointments = sheduleItems
                    };
                    schelues.Add(sche);

                }
                    
                return SuccessResponse(data: schelues);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }
        public Response GetTherapistCommision()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var wallet = _context.Wallets.FirstOrDefault(x => x.UserId == user.Id);

                var data = new
                {
                    Commission = wallet.Commission,
                    Rate = wallet.Rate > 0 ? wallet.Rate : 2,
                };

                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }


        public Response GetTherapistBankDetail()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var detail = _context.BankAccountDetails.FirstOrDefault(x => x.TherapistId == user.Id);
                if(detail == null)
                {
                    return AuxillaryResponse("record not found", StatusCodes.Status404NotFound);
                }
                var data = new
                {
                    AccountName = detail.AccountName,
                    AccountNumber = detail.AccountNumber,
                    BankName = detail.BankName,

                };
                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }


        public Response GetCommissions()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var commission = _context.Commisions.Where(x => x.TherapistId == user.Id)
                    .Select(x => new
                    {
                        PaymentId = x.TransactionRef,
                        Amount = x.Amount,
                        Description = x.Decription,
                        Date = x.DateCreated.ToString("f")
                    });
                
                return SuccessResponse(data: commission);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }

        public Response GetTherapistConsultaion()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var data = (from consultation in _context.AppointmentRequest
                            where consultation.TherapistId == user.Id && !consultation.IsDeleted
                            //&& consultation.IsPaymentCompleted
                            join patient in _context.UserProfile on consultation.PatientId equals patient.UserId
                            select new
                            {
                                AppointmentRequestId = consultation.Id,
                                PatientName = patient.FirstName + " " + patient.LastName,
                                PatientId = patient.UserId,
                                PatientNamePicure = patient.FilePath,
                                Date = consultation.Date,
                                Time = consultation.StartTime.HasValue ? consultation.StartTime.Value.ToString("D") +" " + "at " + consultation.StartTime.Value.ToString("t") : "",
                                SatrtTime = consultation.StartTimeToString,
                                EndTime = consultation.EndTime.HasValue ? GetEndDate(consultation.EndTime.Value) : "",
                                ReasonForTherapy = consultation.ReasonForTherapy,
                                AdditionalNote = consultation.ProblemDecription,
                                AvailableTime = consultation.StartTimeToString,
                                //EndTime = consultation.EndTime.Value.DateTime,
                                Status = consultation.Status.ToString(),
                                IsDue = consultation.Status == Bounce_Domain.Enum.AppointmentStatus.Due ? true : false,
                                IsOverdue = consultation.Status == Bounce_Domain.Enum.AppointmentStatus.Overdue ? true : false,
                                OrderBy = consultation.StartTime


                            }).ToList().OrderByDescending(x=> x.OrderBy);
                            
                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }
        public  Response GetTherapisById(long id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                    return AuxillaryResponse("Therapist not found", 404);

                var profile = _context.TherapistProfiles.FirstOrDefault(x => x.UserId == id);
                if (profile == null)
                    return AuxillaryResponse("There is no profile for this therapist, kindly update the therapist profile", 404);

                var ratings = _context.Reviews.Where(x => !x.IsDeleted && x.TherapistUserId == id && x.RateCount > 0).OrderByDescending(x => x.DateCreated).ToList();
                var patientCount = _context.AppointmentRequest.Where(m => m.TherapistId == id && m.IsPaymentCompleted).DistinctByProperty(x => x.PatientId).Count();
                var wallet =   _context.Wallets.FirstOrDefault(x => x.UserId == id);
                var response = _mapper.Map<TherapistProfileDetailDto>(profile);
                response.ReviewCount = ratings.Where(x => x.TherapistUserId == user.Id && x.RateCount > 0).Count();
                response.ReviewRatio = _patientServices.CalculateTherapisRating(user.Id).Ratio;
                response.ServiceChargePerHoure = 50000;
                response.NumberOfPatient = patientCount;
                response.EmailAddress = user.Email;
                response.Commission = wallet.Commission;

                return SuccessResponse(data: response);


            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }
        public async Task<Response> CreateUpdateUpdateTherapistAccountDetails(TherapistAccountDetailsDto model)
        {
            _adminLogger.LogRequest($"Task to create a bank profile for Therapist userhas started: {DateTime.Now} : {JsonConvert.SerializeObject(model)}");

            try
            {
                var user = _sessionManager.CurrentLogin;
                var bankProfile = _context.BankAccountDetails.FirstOrDefault(x => x.TherapistId == user.Id);
                if(bankProfile != null)
                {
                    bankProfile.BankName = model.BankName.EncryptString();
                    bankProfile.AccountNumber = model.AccountNumber.EncryptString();
                    bankProfile.AccountName = model.AccountName.EncryptString();
                    _context.Update(bankProfile);

                }
                else
                {
                     bankProfile = _mapper.Map<BankAccountDetails>(model);
                    bankProfile.TherapistId = user.Id;
                    _context.Add(bankProfile);
                }
                    
                if (!await SaveAsync())
                    return FailedSaveResponse(model);

                _adminLogger.LogRequest($"Task to update  bank profile for Therapist user {user.Email} has been  successful completed: {DateTime.Now} : {JsonConvert.SerializeObject(model)}");

                return SuccessResponse("Bank profile has been updated");


            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public async Task<Response>  GetQuestions()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var questions = new List<TherapistAccesmentQuestion>();
                var existingQuestionIds = _context.TherapistAccessments.Where( x=> !x.IsDeleted && x.TherapistId == user.Id).Select(x=> x.AnsweredQuestionIds).ToList();
                if(existingQuestionIds.Any())
                {   
                    if(existingQuestionIds.Count() == 3)
                    {
                        return AuxillaryResponse("You have exceeded your assessment limit", StatusCodes.Status400BadRequest);
                    }
                    var ids = new List<long>();
                    foreach (var item in existingQuestionIds)
                    {
                        ids.AddRange(item.Split('|').Select(long.Parse).ToList());
                    };
                     questions = await _context.TherapistAccesmentQuestions.Where(x => !x.IsDeleted).Where(m=> ids.Contains(m.Id)).ToListAsync();

                }
                else
                {
                    questions = await _context.TherapistAccesmentQuestions.Where(x => !x.IsDeleted).ToListAsync();
                }
             
                var newQuestion = new List<QuestionDTO>();
                if (questions.Any())
                {
                   
                    var indexers = new List<int>();
                    var counter = 1;
                    var questionCount = 2;
                    while (counter > 0)
                    {
                        Random rnd = new Random();
                        int randIndex = rnd.Next(questions.Count);
                        var question = questions[randIndex];

                        if (!indexers.Contains(randIndex))
                        {
                            indexers.Add(randIndex);
                            newQuestion.Add(new QuestionDTO
                            {
                                QuestionId = question.Id,
                                Question = question.Question,                         
                                A = question.OptionA,
                                B = question.OptionB,
                                C = question.OptionC,
                                D = question.OptionD
                            });
                            if (newQuestion.Count == questionCount)
                            {
                                counter = 0;
                            }
                        }


                    }
                }

                
                return SuccessResponse(data: newQuestion);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }
        public async Task<Response> ValidateAssement(AssesmentDto model)
        {
            _adminLogger.LogRequest($"Task to create validate therapist accessment started: {DateTime.Now} : {JsonConvert.SerializeObject(model)}");

            try
            {
             
                if (model.Result == null || !model.Result.Any())
                    return AuxillaryResponse("accessment is empty", StatusCodes.Status400BadRequest);

                var user = _sessionManager.CurrentLogin;
                var questions = _context.TherapistAccesmentQuestions.Where(x => !x.IsDeleted).ToList();

                var correctAnswer = 0;
                var wrongAnswer = 0;
                
                foreach (var resut in model.Result)
                {
                    var question = questions.FirstOrDefault(x => x.Id == resut.QuestionId);
                    if (question != null)
                    {
                        if (resut.Answer == question.CorrectAnswer)
                            correctAnswer++;
                        else
                            wrongAnswer++;
                    }
                }
                var questionIds = model.Result.Select(x => x.QuestionId).ToList();
                var assesment = new TherapistAccessment
                {
                    TherapistId = user.Id,
                    TotalFailed = wrongAnswer,
                    TotalPassed = correctAnswer,
                    TotalScore = correctAnswer,
                    TotalQuestion = correctAnswer + wrongAnswer,
                    AnsweredQuestionIds = String.Join('|', questionIds)
                };

                var percentage = (assesment.TotalPassed * assesment.TotalScore) / 100;

                if(percentage > 59)
                {
                    var userProfile = _context.TherapistProfiles.FirstOrDefault(x => x.UserId == user.Id);

                    userProfile.PassedAccessment = true;
                    _context.Update(userProfile);
                    await _context.AddAsync(assesment);
                    if (!await SaveAsync())
                        return FailedSaveResponse(model);


                    return SuccessResponse("Text completed", new { Passed = true });

                }

                return SuccessResponse("Text completed", new { Passed = false });



            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public static string GetEndDate(DateTimeOffset statrtTme)
        {
            if (statrtTme == null)
                return "";

            var time3 = statrtTme.ToString("hh:00 t");
            var decodeMessage2 = Uri.UnescapeDataString(time3);
            if (decodeMessage2.Contains("A"))
                decodeMessage2 = decodeMessage2.Replace("A", "AM");

            if (decodeMessage2.Contains("P"))
                decodeMessage2 = decodeMessage2.Replace("P", "PM");

            return decodeMessage2;
        }

    }
}
