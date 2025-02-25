using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AspNetCoreHealthChecks
{
    public class FakerHealthCheck(ILogger<FakerHealthCheck> logger, IFakerClient client) : IHealthCheck
    {
        private readonly IFakerClient _client = client;
        private readonly ILogger<FakerHealthCheck> _logger = logger;

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _client.AddressesAsync();
                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FakerHealthCheck failed");
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
