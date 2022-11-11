using Bounce.DataTransferObject.DTO.Patient;
using Bounce_Application.Persistence.Interfaces.Therapist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TherapistController : BaseController
    {
        private readonly ITherapistServices _therapistServices;

        public TherapistController(IHttpContextAccessor httpContext, ITherapistServices therapistServices) : base(httpContext)
        {
            _therapistServices = therapistServices;
        }

        [HttpPost("UpsertBankAccountDetails")]
        public async Task<IActionResult> Subscription([FromBody] BankAccountDetailDto model) => Response(await _therapistServices.BankDetailsUpsert(model));
    }
}
