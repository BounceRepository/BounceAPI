using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_DbOps.EF;
using Flutterwave.Ravepay.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services
{
    public class BaseServices
    {
        public const string InterErrorMessage = "Internal server error occured";
        protected readonly BounceDbContext _context;
       

        public BaseServices(BounceDbContext context)
        {
            _context = context;
        }

        public async Task<Response> InternalErrorResponseAsync(Exception ex)
        {
            LogRequest(ex);
            return new Response
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = InterErrorMessage
            };
        }
        /// <summary>
        /// this method logs success informations
        /// </summary>
        /// <param name="message">takes the log messages to the logger</param>
        public void LogInfo(string message)
        {
            LogRequest(message: message, isError: false);
            
        }
        public Response FailedSaveResponse(object? model = null)
        {
            var message = "Sorry your transaction can not completed at the moment, try again later";
            LogRequest(message: message, model: model);
            return new Response
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = message

            };
        }
        public Response SuccessResponse(string message = "Success", object? data = null)
        {
            return new Response
            {
                StatusCode = StatusCodes.Status200OK,
                Message = message,
                Data = data

            };
        }
        public Response AuxillaryResponse(string message, int statusCode)
        {
            return new Response
            {
                StatusCode = statusCode,
                Message = message,
   
            };
        }

        public Response InternalErrorResponse(Exception ex)
        {
            LogRequest(ex);
            return new Response
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = InterErrorMessage,

            };
        }

        /// <summary>
        /// this method logs infromations and error into the file 
        /// system using serilog. If the isError is set to true means the system will log the 
        /// information as error else the other wise
        /// </summary>
        /// <param name="ex"> exceptions</param>
        /// <param name="message">log messages</param>
        /// <param name="isError">error status which indicates the log type, when set to true logs error otherwise logs information</param>
        /// <param name="model">entity model</param>
        public void LogRequest(Exception? ex = null, string message = "", bool isError = true, object? model = null)
        {
        
            if(isError)
            {
                var prefix = model != null ? $"{JsonConvert.SerializeObject(model)}" : "";
                message = $"{InterErrorMessage}{" - "}{ex.Message}{" - "}{prefix}{DateTime.Now}";
            }

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .Enrich.FromLogContext()
           // Add this line:
           .WriteTo.File(
              "ApiLogs\\AdminLogs\\events.log",
               outputTemplate: "{Timestamp:o} [{Level:u3}] ({SourceContext}) {Message}{NewLine}{Exception}",
               fileSizeLimitBytes: 1_000_000,
               rollingInterval: RollingInterval.Day,
               rollOnFileSizeLimit: true,
               shared: true,
               flushToDiskInterval: TimeSpan.FromSeconds(1))
           .CreateLogger();

            if (isError)
            {
                Log.Logger.Error(message);
            }
            else
            {
                Log.Logger.Information(message);
            }
        }
        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;


    


    }
}
