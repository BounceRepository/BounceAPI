using Bounce.DataTransferObject.Helpers.BaseResponse;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.FilesManager
{
    public interface IFileManagerServices
    {
        Response UploadFile(IFormFile file);
        Response UploadFiles(List<IFormFile> files);
    }
}
