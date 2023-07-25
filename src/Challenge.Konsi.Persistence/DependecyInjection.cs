using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Challenge.Konsi.Persistence;

[ExcludeFromCodeCoverage]
public static class DependecyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection service)
    {
        return service;
    }
}