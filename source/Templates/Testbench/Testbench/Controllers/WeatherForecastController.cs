using Devon4Net.Infrastructure.MongoDb.MongoDb;
using Devon4Net.Infrastructure.MongoDb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Testbench.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly IMongoDbContext _mongoDbContext;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IMongoDbContext mongoDbContext, ILogger<WeatherForecastController> logger)
        {
            _mongoDbContext = mongoDbContext;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            Repository<WeatherForecast> repository = new Repository<WeatherForecast>(_mongoDbContext);

            return repository.Get(x => x.TemperatureC == 35);
        }

        [HttpGet("{id}")]
        public WeatherForecast Get(Guid guid)
        {
            Repository<WeatherForecast> repository = new Repository<WeatherForecast>(_mongoDbContext);

            return repository.GetFirstOrDefault(x => x._id == guid);
        }

        [HttpPut(Name = "PutWeatherForecast")]
        public void Put()
        {
            WeatherForecast forecast = new WeatherForecast();
            forecast.TemperatureC = 35;
            forecast._id = Guid.NewGuid();
            
            Repository<WeatherForecast> repository = new Repository<WeatherForecast>(_mongoDbContext);

            repository.Create(forecast);
        }
    }
}