using MediatR;
using Microsoft.Extensions.Logging;

namespace Whisx.User.Application.Common.Behaviors;

public sealed class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse> where TResponse : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling request: {@request}", request);

        try
        {
            var response = await next(cancellationToken);
            logger.LogInformation("Completed request: {@request} with response: {@response}", request, response);
            return response;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Request failed: {@request}", request);
            throw;
        }
    }
}