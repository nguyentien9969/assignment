using System.Text;

namespace assignment4.Middlewares
{
    public class LogginMiddleware
    {
        private readonly RequestDelegate _next;
        public LogginMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext context)
        {
            
            var request = context.Request ;
            var sb = new StringBuilder();
            var scheme = request.Scheme;
            sb.AppendLine("scheme :" + scheme);

            var host = (request.Host.HasValue ? request.Host.Value : "no host");
            sb.AppendLine("host :" + host);

            var path = request.Path.ToString();
            sb.AppendLine("path" + path);

            var listquery = request.Query.Select((header) => $"{header.Key}: {header.Value}");
            var queryhtml = string.Join("", listquery);
            sb.AppendLine("Các Query" + queryhtml);

            
            string info = sb.ToString();
            await context.Response.WriteAsync(text:info + sb.AppendLine(request.Method) );
        }
    }
}