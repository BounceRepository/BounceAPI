using AutoMapper;
using Bounce.DataTransferObject.DTO.Patient;
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
    public class TherapistServices: ITherapistServices
    {
        private readonly BounceDbContext _context;
        private readonly FileManager _fileManager;
        private readonly AdminLogger _adminLogger;
        private readonly IMapper _mapper;

        public TherapistServices(BounceDbContext context, FileManager fileManager, AdminLogger adminLogger, IMapper mapper)
        {
            _context = context;
            _fileManager = fileManager;
            _adminLogger = adminLogger;
            _mapper = mapper;
        }
        public async Task<Response> BankDetailsUpsert(BankAccountDetailDto model)
        {
            try
            {
                var bankProfile = _context.BankAccountDetails.FirstOrDefault(x => x.TherapistId == model.TherapistId);

                var entity = _mapper.Map<BankAccountDetails>(model);
                //entity.LastModifiedBy = ".";
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
               


                if (await SaveAsync()) return new Response { StatusCode = StatusCodes.Status200OK, Message = "Bank Detail Updated" };
               
                return new Response
                        {
                                StatusCode = StatusCodes.Status500InternalServerError,
                                Message = "Sorry we can not complete your request at this time, please try again later"
                        };
               

            }
            catch (Exception ex)
            {

                _adminLogger.LogRequest($"{"internal server error }"}{ex}{" - "}{JsonConvert.SerializeObject(model)}{" - "}{DateTime.Now}", true);

                return new Response
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Internal server error occured"
                };
            }
        }
        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;
    }
}
