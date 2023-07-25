using Challenge.Konsi.Infrastructure.Settings.Logger;
using FluentValidation;

namespace Challenge.Konsi.Infrastructure.Settings;

public sealed class InfrastructureSettingsValidator : AbstractValidator<InfrastructureSettings>
{
    public InfrastructureSettingsValidator()
    {
        RuleFor(x => x.LoggerSettings)
            .SetValidator(new LoggerSettingsValidator());
    }
}
