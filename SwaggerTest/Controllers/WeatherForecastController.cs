using Microsoft.AspNetCore.Mvc;

namespace SwaggerTest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    ];

    private readonly ILogger<WeatherForecastController> _logger = logger;

    [HttpGet]
    [Route("GetWeather")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpPost]
    [Route("Test")]
    public string GetTest(
        [FromForm]string someJson)
    {
        var ab = System.Text.Json.JsonSerializer.Deserialize<AB>(someJson);
        return nameof(GetTest);
    }
}

public class AB(int a, int b)
{
    public int A { get; } = a;
    public int B { get; } = b;
}