using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bounce_Application.Utilies
{
    public class FileManager
    {
        public IServiceProvider Services { get; }
        private readonly IHttpContextAccessor contextAccessor;

        public FileManager(IServiceProvider services, IHttpContextAccessor contextAccessor)
        {
            Services = services;
            this.contextAccessor = contextAccessor;
        }


        public string GetHost()
        {
            var scheme = contextAccessor.HttpContext.Request.Scheme;
            var host = contextAccessor.HttpContext.Request.Host.Value;
            return $"{scheme}://{host}/";
        }
        public string FileUploadToCloudinary(IFormFile file, string path)
        {
            try
            {

 

                var folderName = "Resources";
                folderName = $"{folderName}/{path}";
                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + Regex.Replace(fileName, @"\s", "");
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var scheme = contextAccessor.HttpContext.Request.Scheme;
                    var host = contextAccessor.HttpContext.Request.Host.Value;

                    ////var fileurl = $"{scheme}://{host}/{folderName}/{fileName}";
                    var fileurl = $"{folderName}/{fileName}";



                    return fileurl;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public string FileUpload(IFormFile file, string path = "images")
        {
            try
            { 

                var folderName = "Resources";
                folderName = $"{folderName}/{path}";
                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + Regex.Replace(fileName, @"\s", "");
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var uploadParams = new VideoUploadParams()
                    {
                        File = new FileDescription(fullPath),
                        Folder = $"Resources/{path}/",
                        //Folder = "footballbuzz/stories/", 
                        Overwrite = false
                    };

                    Account account = new Account(
                    "dukd0jnep",
                     "218328548349527",
                     "pHHXluwid33h4jA-82-7rzBCMJA");
                    Cloudinary cloudinary = new Cloudinary(account);


                    var uploadResult = cloudinary.UploadLarge(uploadParams);
                    var uploadedFilePath = uploadResult.SecureUrl.AbsoluteUri;
                    File.Delete(fullPath);

                    return uploadedFilePath;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        //public async Task<List<string>> UploadMediaType2([FromBody] MediaTypeDTO media)
        //{
        //    if (media.Media != null)
        //    {

        //        if (!Directory.Exists(_webHost.WebRootPath + "\\mediaUri\\"))
        //        {
        //            Directory.CreateDirectory(_webHost.WebRootPath + "\\mediaUri\\");
        //        }
        //        var paths = new List<string>();
        //        var mp4Error = new List<string>() { "Video cannot be more than one" };

        //        var mp4 = new List<string>();
        //        //var images = new List<string>();

        //        foreach (var item in media.Media)
        //        {
        //            var date = DateTime.Now.Ticks;
        //            var uniqueName = $"{date}{item.FileName}";
        //            var uploads = Path.Combine(_webHost.WebRootPath, "mediaUri");
        //            var filePath = Path.Combine(uploads, uniqueName);
        //            FileInfo ext = new FileInfo(filePath);
        //            var extension = ext.Extension;
        //            string fileName = Path.GetFileNameWithoutExtension(filePath);
        //            if (extension == ".mp4")
        //            {
        //                mp4.Add(extension);

        //                if (mp4.Count > 1)
        //                {
        //                    return mp4Error;
        //                }
        //                else
        //                {
        //                    using (FileStream fileStream = System.IO.File.Create(filePath))
        //                    {
        //                        await item.CopyToAsync(fileStream);
        //                        fileStream.Flush();
        //                        fileStream.Close();
        //                    }

        //                    var uploadParams = new VideoUploadParams()
        //                    {
        //                        File = new FileDescription(filePath),
        //                        Folder = "footballbuzz/posts/",
        //                        //Folder = "footballbuzz/stories/", 
        //                        Overwrite = false
        //                    };
        //                    var uploadResult = cloudinary.UploadLarge(uploadParams);
        //                    var path = uploadResult.SecureUrl.AbsoluteUri;
        //                    paths.Add(path);

        //                    System.IO.File.Delete(filePath);

        //                }
        //            }
        //            else
        //            {
        //                using (FileStream fileStream = System.IO.File.Create(filePath))
        //                {
        //                    await item.CopyToAsync(fileStream);
        //                    fileStream.Flush();
        //                    fileStream.Close();
        //                }

        //                ImageUploadParams uploadParams = new ImageUploadParams()
        //                {
        //                    File = new FileDescription(filePath),
        //                    Folder = "footballbuzz/posts/",
        //                    Overwrite = false
        //                };

        //                ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
        //                var path = uploadResult.SecureUrl.AbsoluteUri;
        //                paths.Add(path);

        //                System.IO.File.Delete(filePath);
        //            }
        //        }
        //        return paths;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


    }
}
