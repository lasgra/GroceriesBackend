
using Microsoft.AspNetCore.Http.HttpResults;
using TestProject.Exceptions;

namespace TestProject.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(BadRequestException BadRequest)
            {
                context.Response.StatusCode = 400;
                context.Response.WriteAsync(BadRequest.Message);
            }
            catch(NotFoundException notFound)
            {
                context.Response.StatusCode = 404;
                context.Response.WriteAsync(notFound.Message);
            }
            catch(ForbidException forbid)
            {
                context.Response.StatusCode = 403;
                context.Response.WriteAsync(forbid.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
