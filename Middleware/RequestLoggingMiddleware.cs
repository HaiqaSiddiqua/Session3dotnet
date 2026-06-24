using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Session1LinqApp.Middleware
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
            // Start a stopwatch to track the duration of the request
            var stopwatch = Stopwatch.StartNew();

            // Extract incoming request details
            var method = context.Request.Method;
            var path = context.Request.Path;

            // Hand the request off to the next component in the pipeline (the Controller)
            await _next(context);

            // The controller has finished executing; stop the clock
            stopwatch.Stop();

            // Extract final outgoing response details
            var statusCode = context.Response.StatusCode;
            var elapsedMs = stopwatch.ElapsedMilliseconds;

            // Log the structured data to the terminal console
            _logger.LogInformation(
                "HTTP {Method} {Path} responded {StatusCode} in {ElapsedMs} ms", 
                method, path, statusCode, elapsedMs);
        }
    }
}
