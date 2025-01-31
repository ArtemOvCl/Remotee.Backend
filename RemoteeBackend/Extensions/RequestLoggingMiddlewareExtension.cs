using Microsoft.AspNetCore.Builder;
using RemoteAccess.Middlewares;

namespace RemoteAccess.Extensions
{
    public static class RequestLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middlewares.RequestLoggingMiddleware>();
        }
    }
}