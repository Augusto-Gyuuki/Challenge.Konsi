using Challenge.Konsi.Application.Common.Interfaces.HealthCheck;
using Challenge.Konsi.Infrastructure.Settings;
using Challenge.Konsi.Infrastructure.Settings.Logger;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Challenge.Konsi.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, InfrastructureSettings infrastructureOptions)
    {
        service
            .AddLogger(infrastructureOptions.LoggerSettings)
            .AddHealthCheck();

        return service;
    }

    private static IServiceCollection AddLogger(this IServiceCollection service, LoggerSettings loggerSettings)
    {
        var logger = new LoggerConfiguration()
                .WriteTo.Seq(loggerSettings.SeqUrl, loggerSettings.LogEventLevel, apiKey: loggerSettings.SeqApiKey)
                .Enrich.WithMachineName()
                .Enrich.FromLogContext()
                .Enrich.WithProperty(nameof(LoggerSettings.ApplicationName), loggerSettings.ApplicationName)
                .CreateLogger();

        service.AddSingleton<ILogger>(logger);

        return service;
    }

    private static IServiceCollection AddHealthCheck(this IServiceCollection service)
    {
        var healthBuilder = service.AddHealthChecks();

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var healthCheckType = typeof(IHealthChecker);

        var implementations = assemblies
            .SelectMany(a => a.GetExportedTypes())
            .Where(t => !t.IsInterface
                    && !t.IsAbstract
                    && healthCheckType.IsAssignableFrom(t))
            .Select(t => (IHealthChecker)Activator.CreateInstance(t))
            .ToList();

        implementations.ForEach(healtCheckImplementation =>
        {
            if (healtCheckImplementation is null)
            {
                return;
            }

            healthBuilder.AddCheck(healtCheckImplementation.Name, healtCheckImplementation);
        });

        return service;
    }
}