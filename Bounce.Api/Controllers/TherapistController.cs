using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Therapist;
using Bounce_Application.Persistence.Interfaces.Therapist;
using Bounce_Applucation.DTO.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.Therapist)]
    public class TherapistController : BaseController
    {
        private readonly ITherapistServices _therapistServices;

        public TherapistController(IHttpContextAccessor httpContext, ITherapistServices therapistServices) : base(httpContext)
        {
            _therapistServices = therapistServices;
        }



        [HttpPost("CreateProfile")]
        public async Task<IActionResult> Profile([FromForm] TherapistProfileDto model) => Response(await _therapistServices.CreateTherapistProfile(model));

        [HttpGet("GetTherpaistDashboard")]
        public  IActionResult GetDashboard() => Response( _therapistServices.GetTherapistDashBoard());

        [HttpGet("GetTherpaistById")]
        public IActionResult GetTherpaistById([FromQuery] long id) => Response(_therapistServices.GetTherapisById(id));

        [HttpGet("GetConsultaions")]
        public IActionResult Consultaions() => Response(_therapistServices.GetTherapistConsultaion());

        [HttpPut("UpdateBankAccountDetails")]
        public async Task<IActionResult> Subscription([FromBody] TherapistAccountDetailsDto model) => Response(await _therapistServices.CreateUpdateUpdateTherapistAccountDetails(model));

        
        [HttpGet("GetQuestions")]
        public async Task<IActionResult> Questions() => Response( await _therapistServices.GetQuestions());

   
        [HttpPost("TakeAssesement")]
        public async Task<IActionResult> Assesement([FromBody] AssesmentDto model) => Response(await _therapistServices.ValidateAssement(model));
        

    }
}
