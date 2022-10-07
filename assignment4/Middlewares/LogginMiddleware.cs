using System.Diagnostics;
using System.Text;
using assignment4.Helper;

namespace assignment4.Middlewares
{
    public class LogginMiddleware
    {
        private readonly RequestDelegate _next;
        public LogginMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            var sb = new StringBuilder();

            var scheme = request.Scheme;
            sb.AppendLine("scheme :" + scheme);
            var host = (request.Host.HasValue ? request.Host.Value : "no host");
            sb.AppendLine("host :" + host);
            var path = request.Path.ToString();
            sb.AppendLine("path" + path);
            var query = request.Query;
            sb.AppendLine("Các Query" + query);
            var body = request.Body;
            sb.AppendLine("Body" + body);
            string info = sb.ToString();

            Debug.Write(info);
            File.WriteAllText("D:\\Local.txt", info);
            LogginHelper.WriteToFileByStream("D:\\", "Local.txt", info);

            await _next(context);
        }
    }
}