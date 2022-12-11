using Bounce.DataTransferObject.DTO.Auth.Articles;
using Bounce.DataTransferObject.DTO.Journal;
using Bounce_Application.Persistence.Interfaces.Articles;
using Bounce_Application.Persistence.Interfaces.Journal;
using Bounce_Applucation.DTO.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class JournalController : BaseController
    {
        private readonly IJournalServices _journalServices;
        public JournalController(IHttpContextAccessor httpContext, IJournalServices journalServices) : base(httpContext)
        {
            _journalServices = journalServices;
        }

        [HttpPost("CreateJournal")]
        public async Task<IActionResult> CreateJournal([FromBody] CreateJournalDto model) => Response( await _journalServices.Create(model));

        [HttpPatch("UpdateJournal")]
        public async Task<IActionResult> UpdateJournal([FromBody] UpdateJournalDto model) => Response(await _journalServices.Edit(model));

        [HttpGet("GetJournalById")]
        public IActionResult GetJurnalById([FromQuery] long  id) => Response( _journalServices.GetById(id));


        [HttpGet("GetAllJournals")]
        public IActionResult GetJournals() => Response(_journalServices.GetAll());

        [HttpDelete("DeleteJournal")]
        public async Task<IActionResult> GetJournals([FromQuery] long id) => Response( await _journalServices.Delete(id));
    }
}
