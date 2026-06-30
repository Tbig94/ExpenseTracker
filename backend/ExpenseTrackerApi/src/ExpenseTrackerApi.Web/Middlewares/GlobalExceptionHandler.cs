using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExpenseTrackerApi.Web.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext context, 
                                                Exception exception,
                                                CancellationToken cancellationToken)
    {
        _logger.LogError(exception,
                         "An unhandled exception occured during request {TacreId}: {Message}",
                         context.TraceIdentifier,
                         exception.Message);

        var statusCode = HttpStatusCode.InternalServerError;
        var title = "An unexpected error occured.";

        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/problem+json";

        var problemDetails = new ProblemDetails
        {
            Status = (int)statusCode,
            Title = title,
            Instance = context.Request.Path,
            Extensions = { { "traceId", context.TraceIdentifier } }
        };

        await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}
