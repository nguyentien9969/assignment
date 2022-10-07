using assignment4.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseLogginMiddleware();

app.MapGet("/", () =>
 "Hello World!");

app.Run();
