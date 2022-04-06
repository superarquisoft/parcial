using Domain.Models.Entities.Weather;
using Domain.UseCases.Weather;
using EntryPoint.ReactiveWeb.Controllers.Base;
using EntryPoint.ReactiveWeb.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EntryPoint.ReactiveWeb.Controllers.V2.Weather
{
    [Produces("application/json")]
    [ApiVersion("2.0")]
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
        public async Task<IActionResult> GetWeatherInfoList([FromQuery] int cityId) =>
            await HandleRequestAsync(async () =>
                await _weatherUseCase.GetWeathersByCityId(cityId));
    }
}
