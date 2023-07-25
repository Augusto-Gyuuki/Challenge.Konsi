using Microsoft.Extensions.DependencyInjection;

namespace Challenge.Konsi.Integration;

public static class DependecyInjection
{
    public static IServiceCollection AddIntegration(this IServiceCollection service)
    {
        return service;
    }
}