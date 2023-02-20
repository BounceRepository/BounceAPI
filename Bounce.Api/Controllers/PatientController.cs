using Bounce.DataTransferObject.DTO.Patient;
using Bounce.DataTransferObject.DTO.Payment;
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

    
        [HttpGet("GetPatientById")]
        public IActionResult GetPatientById([FromQuery] long patientId) => Response(_patientServices.GetPatienceById(patientId));

       
        [HttpGet("GetAllPatient")]
        public IActionResult GetlAlPatient() => Response(_patientServices.GetAllPatient());
        [AllowAnonymous]

        [HttpGet("GetPatientProfileHistory")]
        public IActionResult GetPatientProfileHistory([FromQuery] long patientId) => Response(_patientServices.GetPatienceProfileHistory(patientId));


        [HttpGet("SearchPatient")]
        public IActionResult SearchPatient([FromQuery] string search) => Response(_patientServices.SearchPatient(search));


        [HttpPatch("UpdateBioData")]
        public async Task<IActionResult> UdateProfile([FromForm] UpdateProfileDto model) => Response(await _patientServices.UpdateProfileAsync(model));


 
        [HttpGet("GetAllTherapists")]
        public async Task<IActionResult> GetAllTherapists() => Response(await _patientServices.GetTherapist());



        [HttpGet("GetPlans")]
        public IActionResult GetAllPlans() => Response( _patientServices.GetAllPlans());

        [HttpPost("SubscribeToPlan")]
        public async Task<IActionResult> PlanSub([FromBody] PlanScubscriptionDto model) => Response(await _patientServices.SubscribeToPlan(model.PlanId, model.SubPlanId));


        [HttpGet("GetAvaialbleBookingTime")]
        public async Task<IActionResult> GetAvaialbleBookingTime([FromQuery] long therapistId, DateTime date) => Response(await _patientServices.GetAvialableTimeByTherapistId(therapistId, date));

        [HttpPost("BookAppointment")]
        public async Task<IActionResult> Appointment([FromBody] AppointmentDto model) => Response(await _patientServices.BookAppointment(model));

        [HttpPost("ComfirmAppointment")]
        public async Task<IActionResult> ComfirmAppointment([FromQuery] string TxRef) => Response(await _paymentServices.ConfirmAppointment(TxRef));
        [HttpGet("UpComingSessions")]
        public async  Task<IActionResult> UpcomingSessions([FromQuery] string filter) => Response( await _patientServices.UpcomingAppointment(filter));

       
        [HttpPost("CreateReview")]
        public async Task<IActionResult> Review([FromBody] CreateReviewDto model) => Response(await _patientServices.CreateReview(model));

        [HttpGet("GetReviewsByTherapistId")]
        public IActionResult GetAllReview([FromQuery] long therapistId) => Response(_patientServices.GetReviewByTherapistId(therapistId));


        [HttpPost("ReScheduleAppointment")]
        public async Task<IActionResult> RescheduleAppointemnt([FromBody] ReScheduleAppointmentDto model) => Response(await _patientServices.ReScheduleAppointtment(model));


        [HttpPatch("UpdatePatientMood")]
        public async Task<IActionResult> UpdateMood([FromBody] UpdateUserModeDto model) => Response(await _patientServices.UpdateUserFellings(model));

        [HttpGet("GetUserMood")]
        public IActionResult UserFeelings() => Response(_patientServices.GetUserFeelings());

       
        public class GetTransaction
        {
            public string Referenceid { get; set; }
            public int RequestType { get; set; }
            public string Translocation { get; set; }
            public string NUBAN { get; set; }
            public DateTime StartDate { get; set; }
            public string EndDate { get; set; }
        }


    }
}
