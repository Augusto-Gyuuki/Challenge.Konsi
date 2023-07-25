using Challenge.Konsi.Infrastructure.Settings;
using Challenge.Konsi.Infrastructure.Settings.Logger;
using Challenge.Konsi.Tests.Unit.Common.Fixtures;
using Serilog.Events;

namespace Challenge.Konsi.Tests.Unit.InfrastructureLayer;

[CollectionDefinition(nameof(InfrastructureSettingsFixture))]
public sealed class InfrastructureSettingsFixture : BaseFixture, ICollectionFixture<InfrastructureSettingsFixture>
{
    public InfrastructureSettings GetSettings()
    {
        return new InfrastructureSettings
        {
            LoggerSettings = new LoggerSettings
            {
                ApplicationName = Faker.Lorem.Text(),
                SeqUrl = Faker.Internet.Url(),
                SeqApiKey = Faker.Lorem.Text(),
                LogEventLevel = Faker.PickRandom<LogEventLevel>(),
            }
        };
    }
}