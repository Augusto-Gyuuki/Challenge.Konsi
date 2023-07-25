using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Challenge.Konsi.Application.Common.Interfaces.HealthCheck;

public interface IHealthChecker : IHealthCheck
{
    public string Name { get; }
}
