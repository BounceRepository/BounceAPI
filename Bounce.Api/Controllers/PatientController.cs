using Bounce.DataTransferObject.DTO.Patient;
using Bounce_Application.Persistence.Interfaces.Patient;
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
        public PatientController(IHttpContextAccessor httpContext, IPatientServices patientServices) : base(httpContext)
        {
            _patientServices = patientServices;
        }


        [HttpPatch("UpdateBioData")]
        public async Task<IActionResult> UdateProfile([FromForm] UpdateProfileDto model) => Response(await _patientServices.UpdateProfileAsync(model));


    }
}
