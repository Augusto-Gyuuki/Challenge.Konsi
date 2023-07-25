using Serilog.Events;

namespace Challenge.Konsi.Infrastructure.Settings.Logger;

public sealed class LoggerSettings
{
    public string ApplicationName { get; init; } = string.Empty;

    public string SeqUrl { get; init; } = string.Empty;

    public string SeqApiKey { get; init; } = string.Empty;

    public LogEventLevel LogEventLevel { get; init; }
}
