using workflow_kubernetes.Models;
using Microsoft.AspNetCore.Mvc;

namespace workflow_kubernetes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> _weatherForecasts = new List<WeatherForecast>();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecasts;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WeatherForecast weatherForecast)
        {
            if (weatherForecast == null)
            {
                return BadRequest("Weather forecast cannot be null.");
            }

            _weatherForecasts.Add(weatherForecast);
            _logger.LogInformation($"Added weather forecast: Date = {weatherForecast.Date}, Temperature = {weatherForecast.TemperatureC}°C, Summary = {weatherForecast.Summary}");

            return CreatedAtAction(nameof(Get), new { id = weatherForecast.Date }, weatherForecast);
        }

        [HttpPut("{date}")]
        public async Task<IActionResult> Put(DateOnly date, [FromBody] WeatherForecast weatherForecast)
        {
            if (weatherForecast == null)
            {
                return BadRequest("Weather forecast cannot be null.");
            }

            var existingForecast = _weatherForecasts.FirstOrDefault(w => w.Date == date);

            if (existingForecast == null)
            {
                return NotFound($"Weather forecast for {date} not found.");
            }

            existingForecast.TemperatureC = weatherForecast.TemperatureC;
            existingForecast.Summary = weatherForecast.Summary;
            _logger.LogInformation($"Updated weather forecast for {date}: Temperature = {existingForecast.TemperatureC}°C, Summary = {existingForecast.Summary}");

            return NoContent(); // 204 No Content is returned after an update.
        }

        [HttpDelete("{date}")]
        public async Task<IActionResult> Delete(DateOnly date)
        {
            var existingForecast = _weatherForecasts.FirstOrDefault(w => w.Date == date);

            if (existingForecast == null)
            {
                return NotFound($"Weather forecast for {date} not found.");
            }

            _weatherForecasts.Remove(existingForecast);
            _logger.LogInformation($"Deleted weather forecast for {date}");

            return NoContent(); // 204 No Content is returned after deletion.
        }
    }
}
