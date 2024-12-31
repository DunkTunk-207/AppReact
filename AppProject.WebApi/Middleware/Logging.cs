using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AppProject.WebApi.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var sw = Stopwatch.StartNew();
            var requestTime = DateTime.UtcNow;
            var requestId = Activity.Current?.Id ?? context.TraceIdentifier;

            try
            {
                _logger.LogInformation(
                    "Request {RequestId} {RequestMethod} {RequestPath} started at {RequestTime}",
                    requestId, context.Request.Method, context.Request.Path, requestTime);

                await _next(context);
                sw.Stop();

                _logger.LogInformation(
                    "Request {RequestId} completed with status {StatusCode} in {ElapsedMilliseconds}ms",
                    requestId, context.Response.StatusCode, sw.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                sw.Stop();
                _logger.LogError(
                    ex,
                    "Request {RequestId} failed with status {StatusCode} in {ElapsedMilliseconds}ms",
                    requestId, context.Response.StatusCode, sw.ElapsedMilliseconds);
                throw;
            }
        }
    }
}