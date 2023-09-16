using martianRobots.Core.Models;
using martianRobots.Core.Models.Land;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace martianRobots.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ILand _land;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ILand land)
    {
        _logger = logger;
        _land = land;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("/api/", Name = "GetMars")]
    public string GetMars()
    {
        _land.NewCoordinates(new TwoDCoordinates(8, 9));
        return _land.ToString() ?? string.Empty;
    }
}
