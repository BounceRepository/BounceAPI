using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Bounce.Api.HealthCheck
{
   

    public class CloudinaryHealthCheck : IHealthCheck
    {
        private readonly HttpClient _httpClient;

        public CloudinaryHealthCheck(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _httpClient.GetAsync("http://res.cloudinary.com");

                if (response.IsSuccessStatusCode)
                {
                    return HealthCheckResult.Healthy("Cloudinary service is healthy.");
                }
                else
                {
                    return HealthCheckResult.Unhealthy("Cloudinary service is unhealthy.");
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy($"Cloudinary service is unhealthy. Exception: {ex.Message}");
            }
        }
    }

}
