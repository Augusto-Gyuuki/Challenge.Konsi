using Microsoft.Extensions.DependencyInjection;

namespace Challenge.Konsi.Tests.Unit.Common.Fixtures;

public sealed class DependencyInjectionFixture
{
    public static ServiceCollection GetServiceCollection()
    {
        return new ServiceCollection();
    }
}
