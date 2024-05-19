using Application.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;

        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation(
               "Starting request {@RequestName}, {@DateTimeUtc}",
               typeof(TRequest).Name,
               DateTime.UtcNow);

                var result = await next();

                _logger.LogInformation(
                   "Completed request {@RequestName}, {@DateTimeUtc}",
                   typeof(TRequest).Name,
                   DateTime.UtcNow);

                return result;

            }
            catch(Exception ex)
            {
                string name= ex.GetType().Name;
                var exception = ex as IServiceException;
                var errorDetails = exception?.ErrorMessage;

                _logger.LogError(
                    "Request failure {@RequestName}, {@ErrorOrigin}, {@ErrorDetails} - {@DateTimeUtc}",
                    typeof(TRequest).Name,
                    name,
                    errorDetails,
                    DateTime.UtcNow);

                throw;
            }
           

            
        }
    }

   
    
}
