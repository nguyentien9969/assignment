using Microsoft.AspNetCore.Builder;
namespace assignment4.Middlewares
{
    public static class MiddlewareExtensions 
    {
        public static IApplicationBuilder UseLogginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogginMiddleware>();
        }
    }
}