using Challenge.Konsi.Infrastructure.Settings.Logger;

namespace Challenge.Konsi.Infrastructure.Settings;

public sealed class InfrastructureSettings
{
    public const string SectionName = "Infrastructure";

    public LoggerSettings? LoggerSettings { get; init; }
}
