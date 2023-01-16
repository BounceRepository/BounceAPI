using Bounce_Application.Persistence.Interfaces.Communication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CommunicationController : BaseController
    {
        private readonly ICommunicationServices _communicationServices;
        public CommunicationController(IHttpContextAccessor httpContext, ICommunicationServices communicationServices) : base(httpContext)
        {
            _communicationServices = communicationServices;
        }


        [HttpPatch("StartConsultaion")]
        public async Task<IActionResult> StartConsultation([FromQuery] long appointRequestId) => Response(await _communicationServices.StartConsulation(appointRequestId));


        [HttpPatch("EndConsultaion")]
        public async Task<IActionResult> EndConsultation([FromQuery] long appointRequestId) => Response(await _communicationServices.StopConsulation(appointRequestId));



        [HttpPatch("GetChannelKey")]
        public async Task<IActionResult> Key([FromQuery] long appointRequestId) => Response( _communicationServices.GetChannelDetail(appointRequestId));
    }
}
