using Bounce.DataTransferObject.DTO.Therapist;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Admin;
using Bounce_Application.SeriLog;
using Bounce_Applucation.DTO.Auth;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
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
    public class AdminServices : IAdminServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly BounceDbContext _context;
        private readonly AdminLogger _adminLogger;

        public AdminServices(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, BounceDbContext context, AdminLogger adminLogger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _adminLogger = adminLogger;
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

                var data = (from user in users
                            join profile in _context.BioDatas on user.Id equals profile.UserId
                            select new AllTherapistDto
                            {
                                UserId = user.Id,
                                FirstName = profile.FirstName,
                                LastName = profile.LastName,
                                Email = user.Email,
                                PicturePath = profile.FilePath

                            }).ToList();

                return new Response { StatusCode = StatusCodes.Status200OK, Data = data };
            }
            catch (Exception ex)
            {
                _adminLogger.LogRequest($"{"Internal server error occured}"}{" - "}{ex}{" - "}{DateTime.Now}", true);
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


        public async Task<Response> GetUsersByIdAsync(long Id)
        {

            try
            {
               
                var data = (from user in _userManager.Users
                            where user.Id == Id
                            join profile in _context.BioDatas on user.Id equals profile.UserId
                            select new AllTherapistDto
                            {
                                UserId = user.Id,
                                FirstName = profile.FirstName,
                                LastName = profile.LastName,
                                Email = user.Email,
                                PicturePath = profile.FilePath

                            }).FirstOrDefault();

                return new Response { StatusCode = StatusCodes.Status200OK, Data = data , Message ="user found"};
            }
            catch (Exception ex)
            {
                _adminLogger.LogRequest($"{"Internal server error occured}"}{" - "}{ex}{" - "}{DateTime.Now}", true);
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
