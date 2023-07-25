using Challenge.Konsi.Application;
using Challenge.Konsi.Infrastructure;
using Challenge.Konsi.Infrastructure.Settings;
using Challenge.Konsi.Integration;
using Challenge.Konsi.Persistence;
using Challenge.Konsi.Presentation;
using Challenge.Konsi.Presentation.Common.Extensions;
using Challenge.Konsi.Presentation.Middlewares;
using FastEndpoints;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    var infrastructureSettings = builder.Configuration
        .GetSection(InfrastructureSettings.SectionName)
        .Get<InfrastructureSettings>();

    builder.Services
        .AddPersistence()
        .AddApplication()
        .AddPresentation()
        .AddIntegration()
        .AddInfrastructure(infrastructureSettings);
}

var app = builder.Build();
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    app.UseFastEndpoints(c =>
    {
        c.Endpoints.RoutePrefix = "api";
    });

    app.UseOpenApi();

    app.UseRequestTimeInfo();
    app.UseHttpsRedirection();
    app.UseCustomExceptionHandler();

    app.UseAuthorization();
    app.Run();
}