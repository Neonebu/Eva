using Microsoft.AspNetCore.Mvc;

namespace Eva.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EvaController : ControllerBase
    {
        private readonly ILogger<EvaController> _logger;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public EvaController(ILogger<EvaController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "GetEva")]
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
    }
}
