using Microsoft.AspNetCore.Mvc;
using BlazorAppRESTAPIAssignments.Shared.Models;

namespace BlazorAppRESTAPIAssignments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] ColdWords = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool"
        };

        private static readonly string[] WarmWords = new[]
        {
            "Warm", "Mild", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            int temp = Random.Shared.Next(-26, 60);

            return Enumerable.Range(0, 7).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = temp,
                Summary = temp > 20 ? WarmWords[Random.Shared.Next(WarmWords.Length)] : ColdWords[Random.Shared.Next(ColdWords.Length)],
                Vindstyrke = Random.Shared.Next(0, 120)
            })
            .ToArray();
    }
}

}

