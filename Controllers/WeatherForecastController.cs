using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers;

[ApiController]
[Route("/cycle")]
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
    public Ok<Cycle1> Get()
    {
        var cycle1 = new Cycle1() { Id = 1, cycle2 = [] };
        var cycle2 = new Cycle2() { Id = 1, cycle1 = [cycle1] };
        cycle1.cycle2.Add(cycle2);
        return TypedResults.Ok(cycle1);
    }

    [HttpGet("result")]
    public Cycle1 Get2()
    {
        var cycle1 = new Cycle1() { Id = 1, cycle2 = [] };
        var cycle2 = new Cycle2() { Id = 1, cycle1 = [cycle1] };
        cycle1.cycle2.Add(cycle2);
        return cycle1;
    }
}

public class Cycle1
{
    public int Id { get; set; }
    public required List<Cycle2> cycle2 { get; set; }
}
public class Cycle2
{
    public int Id { get; set; }
    public required List<Cycle1> cycle1 { get; set; }
}
