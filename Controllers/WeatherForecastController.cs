using Microsoft.AspNetCore.Mvc;

namespace webapi_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    //Code added, static collection
    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    //constructor
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if(ListWeatherForecast == null || !ListWeatherForecast.Any()){
            ListWeatherForecast = Enumerable.Range(1, 10).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToList();
        }

    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/weatherforecast")]
    [Route("Get/weatherforecast2")]
    [Route("[action]")] //alows to use the method as a route ej. /get depending on the name given below
    //http://localhost:5253/api/WeatherForecast/get
    
    public IEnumerable<WeatherForecast> Get() //needs to match
    {
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);

        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);

        return Ok();
    }

    
}
