﻿using AutoMapper;
using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Therapist;
using Bounce.DataTransferObject.Helpers.BaseResponse;
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

        public TherapistServices(BounceDbContext context, FileManager fileManager, AdminLogger adminLogger, IMapper mapper, SessionManager sessionManager, UserManager<ApplicationUser> userManager) : base(context)
        {
            _fileManager = fileManager ?? throw new ArgumentNullException(nameof(fileManager));
            _adminLogger = adminLogger ?? throw new ArgumentNullException(nameof(adminLogger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _sessionManager = sessionManager;
            _userManager = userManager;
        }

        public async Task<Response> CreateTherapistProfile(TherapistProfileDto model)
        {
           using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var user = _sessionManager.CurrentLogin;
                    var profile = _mapper.Map<TherapistProfile>(model);
                    profile.ProfilePicture = _fileManager.FileUpload(model.ProfilePicture);
                    profile.UserId = user.Id;

                    var entity = _context.Set<TherapistProfile>().Add(profile);
                    if (!await SaveAsync())
                        return FailedSaveResponse(model);

                    user.TherapistUserProfileId = entity.Entity.Id;
                    user.HasProfile = true;
                    await _userManager.UpdateAsync(user);
                   await transaction.CommitAsync();
                    return SuccessResponse();

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
                var bankProfile = _context.BankAccountDetails.FirstOrDefault(x => x.TherapistId == model.TherapistId);

                var entity = _mapper.Map<BankAccountDetails>(model);
                if (bankProfile == null)
                    _context.Add(entity);
                else
                {
                    bankProfile.AccountName = model.AccountName;
                    bankProfile.AccountNumber = model.AccountNumber;
                    bankProfile.BankName = model.BankName;
                    bankProfile.AccountType = model.AccountType;
                    bankProfile.LastModifiedBy = model.TherapistId.ToString();
   
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

                };
                return SuccessResponse(data: data);

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
                            && consultation.IsPaymentCompleted
                            join patient in _context.UserProfile on consultation.PatientId equals patient.Id
                            select new
                            {
                                PatientName = patient.FirstName + " " + patient.LastName,
                                ProfilePicure = patient.FilePath,
                                Date = consultation.Date,
                                Time = consultation.StartTime,
                                EndTime = consultation.EndTime

                            });
                            
                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }


        }
    }
}
