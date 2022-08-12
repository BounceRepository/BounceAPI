using Bounce.DataTransferObject.DTO.Auth;
using Bounce_Application.DTO;
using Bounce_Application.DTO.Auth;
using Bounce_Application.Persistence.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationServivce registrationServivce;
        public AuthenticationController(IHttpContextAccessor httpContext, IAuthenticationServivce registrationServivce) : base(httpContext)
        {
	        this.registrationServivce = registrationServivce;
        }

        [HttpPost("register/admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterModel registerModel) =>
                 Response(await registrationServivce.RegisterAdminUser(registerModel));


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

        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> EmailConfirmation([FromBody]  ConfirmEmailDto model) =>   Response(await registrationServivce.ConfirmEmail(model));


        [HttpPost("RessetPassword")]
        public async Task<IActionResult> RessetPassword([FromQuery] string email) => Response(await registrationServivce.RessetPassword(email));

        [HttpPost("ValidateToken")]
        public async Task<IActionResult> ValidateToken([FromQuery] string token) => Response(await registrationServivce.ValidateToken(token));

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ValidateToken([FromBody] ChangePasswordDto model) => Response(await registrationServivce.ChangePassword(model));


    }
}
