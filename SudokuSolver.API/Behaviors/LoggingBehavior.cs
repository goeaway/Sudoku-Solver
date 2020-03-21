using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace SudokuSolver.API.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public LoggingBehavior(ILogger logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var clientIP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
            var name = typeof(TRequest).Name;
            _logger.Information("Handling {name} request from {clientIP}", name, clientIP);

            return next();
        }
    }
}
