using Domain.Models.Entities.Weather;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.UseCases.Weather
{
    public interface IWeatherUseCase
    {
        /// <summary>
        /// GetWeatherByCountryAndCity
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        Task<WeatherInfoModel> GetWeatherByCountryAndCity(string country, string city);

        /// <summary>
        /// CreateWeather
        /// </summary>
        /// <param name="weatherInfo"></param>
        /// <returns></returns>
        Task<WeatherInfoModel> CreateWeather(WeatherInfoModel weatherInfo);

        /// <summary>
        /// Gets the weather by city identifier.
        /// </summary>
        /// <param name="cityId">The city identifier.</param>
        /// <returns></returns>
        Task<List<WeatherInfoModel>> GetWeathersByCityId(int cityId);
    }
}
