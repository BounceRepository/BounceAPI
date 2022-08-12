using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.SeriLog
{
    public  class AdminLogger
    {
        public IConfiguration Configuration { get; }
        public AdminLogger(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void LogRequest(string message, bool isError)
        {
            var options = Configuration.GetSection(nameof(SerilogConfiguration)).Get<SerilogConfiguration>();

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .Enrich.FromLogContext()
           // Add this line:
           .WriteTo.File(
              options.Adminlogger,
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
