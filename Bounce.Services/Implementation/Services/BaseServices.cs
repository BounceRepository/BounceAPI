using Bounce.DataTransferObject.Helpers.BaseResponse;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services
{
    public class BaseServices
    {
        public const string InterErrorMessage = "Internal server error occured";
        public async Task<Response> InternalErrorResponseAsync(Exception ex)
        {
            LogRequest(ex);
            return new Response
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = InterErrorMessage
            };
        }

        public Response InternalErrorResponse(Exception ex)
        {
            LogRequest(ex);
            return new Response
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = InterErrorMessage,
                Data = new {ErrorMessage = ex.Message}
            };
        }

        public void LogRequest(Exception ex, bool isError = true)
        {
           
            var message = $"{InterErrorMessage}{" - "}{ex}{" - "}{DateTime.Now}";

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

    }
}
