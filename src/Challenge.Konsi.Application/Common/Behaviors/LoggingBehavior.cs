﻿using ErrorOr;
using MediatR;
using Serilog;

namespace Challenge.Konsi.Application.Common.Behaviors;

public class LoggingBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
    where TRequest : IRequest<TResult>
    where TResult : IErrorOr
{
    private readonly ILogger _logger;

    public LoggingBehavior(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        _logger.Information("Starting request {RequestName}", typeof(TRequest).Name);

        var result = await next();

        if (result.IsError)
        {
            _logger.Error("Error in request {RequestName} with message {ErrorMessage}", typeof(TRequest).Name, result?.Errors?.First().Description);
        }

        _logger.Information("Completed request {RequestName}", typeof(TRequest).Name);

        return result;
    }
}
