using Bounce.DataTransferObject.DTO.Patient;
using Bounce_Application.Persistence.Interfaces.Patient;
using Bounce_Application.Persistence.Interfaces.Payment;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class PatientController : BaseController
    {
        private readonly IPatientServices _patientServices;
        private readonly IPaymentServices _paymentServices;
        public PatientController(IHttpContextAccessor httpContext, IPatientServices patientServices, IPaymentServices paymentServices) : base(httpContext)
        {
            _patientServices = patientServices;
            _paymentServices = paymentServices;
        }


        [HttpPatch("UpdateBioData")]
        public async Task<IActionResult> UdateProfile([FromForm] UpdateProfileDto model) => Response(await _patientServices.UpdateProfileAsync(model));

        [AllowAnonymous]
        [HttpGet("GetAllTherapists")]
        public async Task<IActionResult> GetAllTherapists() => Response(await _patientServices.GetTherapist());


        [HttpPost("BookAppointment")]
        public async Task<IActionResult> BookAppointment([FromBody] AppointmentDto model) => Response(await _paymentServices.BookAppointment(model));

        [HttpPost("ComfirmAppointment")]
        public async Task<IActionResult> ComfirmAppointment([FromQuery] string TxRef) => Response(await _paymentServices.ConfirmAppointment(TxRef));


    }
}
