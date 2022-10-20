using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private static readonly List<TaskForecast> _tasks = new List<TaskForecast>
    {
        new TaskForecast() {
            Title = "A",
        },
        new TaskForecast() {
            Title = "B",
        },
        new TaskForecast() {
            Title = "c",
        },
        new TaskForecast() {
            Title = "d",
        }
    };

    private readonly ILogger<TaskController> _logger;

    public TaskController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetTaskList")]
    public IEnumerable<Task> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
