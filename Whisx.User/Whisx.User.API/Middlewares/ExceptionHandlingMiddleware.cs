using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Whisx.User.API.Middlewares;

internal sealed class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError("Exception occurred: {Message}", exception.Message);

        var problemDetails = FormProblemDetailsFromException(exception, httpContext.Request.Path);

        httpContext.Response.ContentType = "application/problem+json";
        httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static ProblemDetails FormProblemDetailsFromException(Exception exception, string requestPath)
    {
        var problemDetails = new ProblemDetails
        {
            Instance = requestPath,
            Title = "An error occurred while processing your request",
            Type = exception.GetType().Name,
            
        };
        
        switch (exception)
        {
            case KeyNotFoundException:
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Title = exception.Message;
                break;
        }

        return problemDetails;
    }
    
}