using Microsoft.AspNetCore.Http;

namespace Core.Middlewares
{
    public class DemoMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Log the incoming request path
            string requestPath = context.Request.Path;
            Console.WriteLine($"Request path: {requestPath}");

            // Call the next middleware in the pipeline
            await next(context);
        }
    }
}