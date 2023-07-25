using Challenge.Konsi.Infrastructure;
using Challenge.Konsi.Tests.Unit.Common.Fixtures;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;

namespace Challenge.Konsi.Tests.Unit.InfrastructureLayer;

[Collection(nameof(InfrastructureSettingsFixture))]
public sealed class DependencyInjectionTests
{
    private readonly InfrastructureSettingsFixture _fixture;

    public DependencyInjectionTests(InfrastructureSettingsFixture fixture)
        => _fixture = fixture;

    [Fact(DisplayName = "AddInfrastructure() should add Logger service to container")]
    [Trait("Infrastructure", "AddInfrastructure - Logger")]
    public void AddInfrastructure_ShouldAddLoggerToContainer()
    {
        // Arrange
        var services = DependencyInjectionFixture.GetServiceCollection();
        var infrastructureOptions = _fixture.GetSettings();

        // Act
        services.AddInfrastructure(infrastructureOptions);

        // Assert
        services.Should().NotBeNull();
        services.Any(x => x.ServiceType == typeof(ILogger)).Should().BeTrue();
    }

    [Fact(DisplayName = "AddInfrastructure() should add HealthCheck services to container")]
    [Trait("Infrastructure", "AddInfrastructure - HealthCheck")]
    public void AddInfrastructure_ShouldAddHealthCheckToContainer()
    {
        // Arrange
        var services = DependencyInjectionFixture.GetServiceCollection();
        var infrastructureOptions = _fixture.GetSettings();

        // Act
        services.AddInfrastructure(infrastructureOptions);

        // Assert
        services.Should().NotBeNull();
        services.Any(x => x.ServiceType == typeof(HealthCheckService)).Should().BeTrue();
    }
}
