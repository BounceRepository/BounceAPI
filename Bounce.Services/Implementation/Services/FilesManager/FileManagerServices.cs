using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.FilesManager;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.FilesManager
{
    public class FileManagerServices : BaseServices, IFileManagerServices
    {
        private readonly FileManager _fileManager;
        private readonly AdminLogger _adminLogger;

        public FileManagerServices(BounceDbContext context, FileManager fileManager, AdminLogger adminLogger) : base(context)
        {
            _fileManager = fileManager;
            _adminLogger = adminLogger;
        }

        public  Response UploadFile(IFormFile file)
        {
            try
            {
                var filePath = file != null ? _fileManager.FileUpload(file) : "";
                return SuccessResponse(data: new { filePath = filePath });
            }
            catch(Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public Response UploadFiles(List<IFormFile> files)
        {
            try
            {
                var filePaths = new List<string>();
                foreach (var file in files)
                {
                    var filePath = _fileManager.FileUpload(file);
                    filePaths.Add(filePath);
                }
              
                return SuccessResponse(data: new { filePath = filePaths });
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
    }
}
