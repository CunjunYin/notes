using Microsoft.AspNetCore.Http;

namespace Core.Middlewares
{
    public class DemoMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;

        public DemoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

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