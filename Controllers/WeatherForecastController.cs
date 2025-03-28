using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers;

[ApiController]
[Route("/")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("typedresult")]
    public Ok<Example> Get()
    {
        var example = new Example() { Id = 1};
        return TypedResults.Ok(example);
    }

    [HttpGet("result")]
    public Example Get2()
    {
        var example = new Example() { Id = 1};
        return example;
    }
}

public class Example
{
    public int Id { get; set; }
}
