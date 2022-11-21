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

   
        [HttpGet("GetAllTherapists")]
        public async Task<IActionResult> GetAllTherapists() => Response(await _patientServices.GetTherapist());


        [AllowAnonymous]
        [HttpGet("GetPlans")]
        public IActionResult GetAllPlans() => Response( _patientServices.GetAllPlans());

  
        [HttpPost("BookAppointment")]
        public async Task<IActionResult> Appointment([FromBody] AppointmentDto model) => Response(await _patientServices.BookAppointment(model));

        [HttpPost("ComfirmAppointment")]
        public async Task<IActionResult> ComfirmAppointment([FromQuery] string TxRef) => Response(await _paymentServices.ConfirmAppointment(TxRef));
        [HttpGet("UpComingSessions")]
        public async  Task<IActionResult> UpcomingSessions() => Response( await _patientServices.UpcomingAppointment());

        [HttpPost("LogUserfeelings")]
        public IActionResult LogUserFeelings([FromBody] List<string> feelings) => Response( _patientServices.LogUserFeeling(feelings));

        [HttpGet("GetAllFeelings")]
        public IActionResult Allfellings() => Response(_patientServices.GetAllFeelings());
        [HttpGet("GetUserFeelings")]
        public IActionResult UserFeelings() => Response(_patientServices.GetUserFeelings());


        [HttpPost("CreateReview")]
        public async Task<IActionResult> Review([FromBody] CreateReviewDto model) => Response(await _patientServices.CreateReview(model));

        [HttpGet("GetReviewsByTherapistId")]
        public IActionResult GetAllReview([FromQuery] long therapistId) => Response(_patientServices.GetReviewByTherapistId(therapistId));

    }
}
