using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Patient
{
    public class PatientServices : IPatientServices
    {
        private readonly BounceDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FileManager _fileManager;
        public PatientServices(BounceDbContext context, UserManager<ApplicationUser> userManager, FileManager fileManager)
        {
            this._context = context;
            _userManager = userManager;
            _fileManager = fileManager;
        }
        public async Task<Response> UpdateProfileAsync (UpdateProfileDto model)
        {
            try
            {
                //var userId = long.Parse(model.UserId);
                var userId = model.UserId;
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
                    LastModifiedBy = DateTime.Now.ToShortDateString(),
                    FilePath = _fileManager.FileUpload(model.File)
                };

                
             
              var record =  _context.Add(profile);
                var isSaved = await _context.SaveChangesAsync() > 0;
                if(isSaved)
                {
                    var id = record.Member("Id").CurrentValue;
                    user.ProfileId = (long?)id;
                    user.HasProfile = true;
                    await _userManager.UpdateAsync(user);
                    return new Response { StatusCode = StatusCodes.Status200OK, Message = "Profile Updated" };
                }
                    
                else
                return new Response
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null,
                    Error = new ErrorResponse
                    {
                        ErrorMesaage = "Sorry we can not complete your request at this time, please try again later"
                    }
                };

              
            }
            catch(Exception ex)
            {
                //throw ex;
                return new Response
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null,
                    Error = new ErrorResponse
                    {
                        ErrorMesaage = "Internal server error occured"
                    }
                };
            }

        }
    }
}
