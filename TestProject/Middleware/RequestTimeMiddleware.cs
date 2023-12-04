using System.Diagnostics;

namespace TestProject.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private Stopwatch _stopWatch;
        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _stopWatch = new Stopwatch();
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopWatch.Start();
            await next.Invoke(context);
            _stopWatch.Stop();

            if (_stopWatch.ElapsedMilliseconds > 4000)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {_stopWatch.ElapsedMilliseconds} ms";
                _logger.LogInformation(message);
            }
        }
    }
}
