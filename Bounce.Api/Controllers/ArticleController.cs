using Bounce.DataTransferObject.DTO.Auth.Articles;
using Bounce_Application.Persistence.Interfaces.Articles;
using Bounce_Applucation.DTO.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ArticleController : BaseController
    {
        private readonly IArticleServices _services;

        public ArticleController(IHttpContextAccessor httpContext, IArticleServices services) : base(httpContext)
        {
            _services = services;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = UserRoles.SuperAdministrator)]
        [HttpPost("CreateArticle")]
        public async Task<IActionResult> Create([FromForm] ArticleCreateDto model) => Response(await _services.CreateArticle(model));
        [HttpGet("GetArticles")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get() => Response(await _services.GetArticles());
    }
}
