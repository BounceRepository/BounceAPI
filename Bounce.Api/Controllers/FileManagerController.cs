using Bounce_Application.Persistence.Interfaces.FilesManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bounce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileManagerController : BaseController
    {
        private readonly IFileManagerServices _fileManager;
        public FileManagerController(IHttpContextAccessor httpContext, IFileManagerServices fileManager) : base(httpContext)
        {
            _fileManager = fileManager;
        }

        [HttpPost("UploadFile")]
        public IActionResult UploadFile(IFormFile formFile) => Response(_fileManager.UploadFile(formFile));

        [HttpPost("UploadFiles")]
        public IActionResult UploadFiles(List<IFormFile> formFiles) => Response(_fileManager.UploadFiles(formFiles));
    }

}
