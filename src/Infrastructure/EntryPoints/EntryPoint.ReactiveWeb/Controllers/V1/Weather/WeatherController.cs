using Domain.Models.Entities.Weather;
using Domain.UseCases.Weather;
using EntryPoint.ReactiveWeb.Controllers.Base;
using EntryPoint.ReactiveWeb.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EntryPoint.ReactiveWeb.Controllers.V1.Weather
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class WeatherController : BaseController<WeatherController>
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherUseCase _weatherUseCase;
        public WeatherController(ILogger<WeatherController> logger, IWeatherUseCase weatherUseCase) : base(logger)
        {
            _logger = logger;
            _weatherUseCase = weatherUseCase;
        }


        [HttpGet]
        public async Task<IActionResult> GetWeatherInfo([FromQuery] WeatherRequestDto weather) =>
            await HandleRequestAsync(async () =>
                await _weatherUseCase.GetWeatherByCountryAndCity(weather.Country, weather.City));


        [HttpPost]
        public async Task<IActionResult> CreateWeatherInfo([FromBody] WeatherInfoModel weather) =>
            await HandleRequestAsync(async () =>
                await _weatherUseCase.CreateWeather(weather));

    }
}
