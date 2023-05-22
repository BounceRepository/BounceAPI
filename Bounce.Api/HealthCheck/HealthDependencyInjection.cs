using Bounce.Api.HealthCheck;

namespace  Microsoft.AspNetCore.Builder
{
    public  static class HealthDependencyInjection
    {
        public static void HealthServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("BounceDatabase")).
                AddCheck<AppHealthCheckServices>("ApplicationHealthCheckServices")
                .AddCheck<CloudinaryHealthCheck>("CloudinaryHealthCheckServices");
            builder.Services.AddHealthChecksUI().AddInMemoryStorage();
        }
    }
}
