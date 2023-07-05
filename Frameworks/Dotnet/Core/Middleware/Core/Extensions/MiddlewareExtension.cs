using Core.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseDemoMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DemoMiddleware>();
        }
    }
}