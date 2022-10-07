using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
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
        private readonly BounceDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FileManager _fileManager;
        private readonly AdminLogger _adminLogger;
        public PatientServices(BounceDbContext context, UserManager<ApplicationUser> userManager, FileManager fileManager, AdminLogger adminLogger)
        {
            this._context = context;
            _userManager = userManager;
            _fileManager = fileManager;
            _adminLogger = adminLogger;
        }
        public async Task<Response> UpdateProfileAsync (UpdateProfileDto model)
        {
            try
            {
                //var userId = long.Parse(model.UserId);
                var userId = long.Parse(model.UserId);
                var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
                if (user == null)
                    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "user does not exist" };

                //if (user.HasProfile)
                //    return new Response { StatusCode = StatusCodes.Status400BadRequest, Message = "profile has been updated for this user" };

                var profile = new BioData
                {
                    UserId = userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    Phone = model.Phone,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    MeansOfIdentification  = _fileManager.FileUpload(model.MeansOfIdentification),
                    LastModifiedBy = DateTime.Now.ToShortDateString(),
                    FilePath = _fileManager.FileUpload(model.ImageFile)
                };



                var record = /*_context.Set<BioData>().Add(profile);*/  await _context.AddAsync(profile);

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
    }
}
