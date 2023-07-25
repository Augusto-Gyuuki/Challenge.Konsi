using Challenge.Konsi.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.Konsi.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<AssemblyReference>();

            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>), ServiceLifetime.Scoped);
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>), ServiceLifetime.Scoped);
        });

        return service;
    }
}
