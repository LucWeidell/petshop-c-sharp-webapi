using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace petshop.Controllers
{
    // NOTE attributes
    //  APitController tells Dotnet regisyer this class as a controller (tells internal build system)
    [ApiController]
    // super() = : Route {"[controller]"} injects the name of the Controller
    // ex: WeatherForecastController injects as WeatherForecast
    [Route("/api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //  Junk Code for demo purposes
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        //  Junk Code for demo purposes

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }







        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
