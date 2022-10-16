using Bounce_Application.Persistence.Interfaces.Admin;
using Bounce_Applucation.DTO.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseController
    {
        private readonly IAdminServices adminServices;
        public AdminController(IHttpContextAccessor httpContext, IAdminServices adminServices) : base(httpContext)
        {
            this.adminServices = adminServices;
        }


        [HttpGet]
        [Route("GetAllTherapists")]
        public async Task<IActionResult> GetAllTherapist() => Response(await adminServices.GetUsersAsync(UserRoles.Therapist));

        [AllowAnonymous]
        [HttpGet("GetAllAdminUsers")]

        public async Task<IActionResult> GetAllAdmin() => Response(await adminServices.GetUsersAsync(UserRoles.Administrator));

        [AllowAnonymous]
        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients() => Response(await adminServices.GetUsersAsync(UserRoles.User));

        [AllowAnonymous]
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] long Id) => Response(await adminServices.GetUsersByIdAsync(Id));



    }
}
