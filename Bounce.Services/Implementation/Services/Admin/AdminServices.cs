using Bounce.DataTransferObject.DTO.Admin;
using Bounce.DataTransferObject.DTO.Therapist;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Admin;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_Applucation.DTO.Auth;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Bounce_Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Admin
{
    public class AdminServices : BaseServices, IAdminServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SessionManager _sessionManager;

        public AdminServices(BounceDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SessionManager sessionManager) : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _sessionManager = sessionManager;
        }

        public async Task<Response> GetUsersAsync(string role)
        {
  
            try
            {

                var users = await _userManager.GetUsersInRoleAsync(role);
                if(role == UserRoles.Administrator)
                {
                    var superAdmin = await _userManager.GetUsersInRoleAsync(UserRoles.SuperAdministrator);
                    users = users.Concat(superAdmin).ToList();
                }

                //var data = (from user in users
                //            join profile in _context.BioDatas on user.Id equals profile.UserId
                //            select new AllTherapistDto
                //            {
                //                UserId = user.Id,
                //                FirstName = profile.FirstName,
                //                LastName = profile.LastName,
                //                Email = user.Email,
                //                PicturePath = profile.FilePath

                //            }).ToList();

                return new Response { StatusCode = StatusCodes.Status200OK, Data = null };
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }


        public async Task<Response> GetUsersByIdAsync(long Id)
        {

            try
            {
               
                var data = (from user in _userManager.Users
                            where user.Id == Id
                            join profile in _context.UserProfile on user.Id equals profile.UserId
                            select new AllTherapistDto
                            {
                                UserId = user.Id,
                                FirstName = profile.FirstName,
                                LastName = profile.LastName,
                                Email = user.Email,
                                PicturePath = profile.FilePath

                            }).FirstOrDefault();

                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }

        }

        public async Task<Response> CreateQuestion(TherapistQuestionDTO model)
        {
            try
            {
                var user = _sessionManager.CurrentLogin;
                var question = new TherapistAccesmentQuestion
                {
                    Question = model.Question,
                    CorrectAnswer = model.CorrectAnswer,
                    OptionA = model.A,
                    OptionB = model.B,
                    OptionC = model.C,
                    OptionD = model.D,
                    CreatedById = user.Id
                };

              await  _context.AddAsync(question);

                if (!await SaveAsync())
                    return FailedSaveResponse(question);
                return SuccessResponse("Question was created successfuly");

            }
            catch(Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


        //public async Task<Response> DashBoardStatistics()
        //{

        //    try
        //    {   var userRecords = _userManager.Users.ToList();
        //        var therapists = userRecords.Where(x => x.Discriminator == UserType.Therapist);
        //        var patients = userRecords.Where(x => x.Discriminator == UserType.Patient);
        //        var consultaions = _context.InteractiveSessions.Where(x=> !x.IsDeleted).ToList();
             

        //        var dashboard = new DashBoardStatisticsDto
        //        {
        //            Patients = patients.Count(),
        //            Therapist = therapists.Count(),
        //            AllConsultaions = consultaions.Count(),
        //        }
        //        var therapists = userRecords.Where(x => x.Discriminator == UserType.Therapist);
        //        var data = (from user in _userManager.Users
        //                    where user.Id == Id
        //                    join profile in _context.BioDatas on user.Id equals profile.UserId
        //                    select new AllTherapistDto
        //                    {
        //                        UserId = user.Id,
        //                        FirstName = profile.FirstName,
        //                        LastName = profile.LastName,
        //                        Email = user.Email,
        //                        PicturePath = profile.FilePath

        //                    }).FirstOrDefault();

        //        return new Response { StatusCode = StatusCodes.Status200OK, Data = data, Message = "user found" };
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalErrorResponse(ex);
        //    }

        //}

    }
}
