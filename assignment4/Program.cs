using assignment4.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<LogginMiddleware>();

app.MapGet("/", () =>
 "Hello World!");

app.Run();
