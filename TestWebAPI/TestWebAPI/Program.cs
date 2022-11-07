
using Test.Data;
using Microsoft.EntityFrameworkCore;


using TestWebAPI.Services;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
var configuration = builder.Configuration;
builder.Services.AddDbContext<BookContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnString")));// Add services to the container.

builder.Services.AddTransient<ITestService, TestService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
