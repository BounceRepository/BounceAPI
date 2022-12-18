using Bounce.DataTransferObject.DTO.Auth;
using Bounce_Application.DTO;
using Bounce_Application.DTO.Auth;
using Bounce_Application.Persistence.Interfaces.Auth;
using Bounce_Applucation.DTO.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationServivce registrationServivce;
        public AuthenticationController(IHttpContextAccessor httpContext, IAuthenticationServivce registrationServivce) : base(httpContext)
        {
	        this.registrationServivce = registrationServivce;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.SuperAdministrator)]
        [HttpPost("register/admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterModel registerModel) =>
                 Response(await registrationServivce.RegisterAdminUser(registerModel));

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.SuperAdministrator)]
        [HttpPost("register/superAdmin")]
        public async Task<IActionResult> RegisterSuperAdminAdmin(RegisterModel registerModel) =>
                Response(await registrationServivce.RegisterSuperAdminUser(registerModel));


        [HttpPost("register/therapist")]
        public async Task<IActionResult> RegisterTherapist([FromBody] RegisterModel registerModel) =>
             Response(await registrationServivce.RegisterTherapist(registerModel));


        [HttpPost("register/user")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel registerModel)
        {
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

            return Response(await registrationServivce.RegisterUser(registerModel));
			
		}

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel) => Response(await registrationServivce.Login(loginModel));

        [HttpPost("PatientLogin")]
        public async Task<IActionResult> PatientLogin([FromBody] LoginModel loginModel) => Response(await registrationServivce.PatientLogin(loginModel));

        [HttpPost("TherapistLogin")]
        public async Task<IActionResult> TherapistLogin([FromBody] LoginModel loginModel) => Response(await registrationServivce.TherapistLogin(loginModel));



        [HttpPost("ConfirmLogin")]
        public async Task<IActionResult> ConfirmLogin([FromBody] LoginModel loginModel) => Response(await registrationServivce.Login(loginModel));

        //[HttpPost("ConfirmEmail")]
        //public async Task<IActionResult> EmailConfirmation([FromBody]  ConfirmEmailDto model) =>   Response(await registrationServivce.ConfirmEmail(model));

        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string email) => Response(await registrationServivce.SendEmailConfrimationLink(email));

        [HttpGet("EmailConfirmationStatus")]
        public async Task<IActionResult> EmailStatus([FromQuery] string email) => Response(await registrationServivce.EmailConfirmationStatus(email));
    


        [HttpPost("ResetPassword")]
        public async Task<IActionResult> RessetPassword([FromQuery] string email) => Response(await registrationServivce.ResetPassword(email));

        [HttpPost("ValidateToken")]
        public async Task<IActionResult> ValidateToken([FromQuery] string token) => Response(await registrationServivce.ValidateToken(token));

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ValidateToken([FromBody] ChangePasswordDto model) => Response(await registrationServivce.ChangePassword(model));


    }
}
