using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AspNetCoreHealthChecks
{
    public class BrokenHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
