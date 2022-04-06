using Domain.Models.Entities.Weather;
using DrivenAdapter.Mongo.Adapter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.UseCases.Weather
{
    public class WeatherUseCase : IWeatherUseCase
    {
        private readonly IWeatherAdapter _weatherAdapter;

        public WeatherUseCase(IWeatherAdapter weatherAdapter)
        {
            _weatherAdapter = weatherAdapter;
        }

        public async Task<WeatherInfoModel> CreateWeather(WeatherInfoModel weatherInfo)
        {
            return await _weatherAdapter.CreateWeatherInfo(weatherInfo);
        }

        public async Task<WeatherInfoModel> GetWeatherByCountryAndCity(string country, string city)
        {
            int countryId = await _weatherAdapter.GetCountryIdByName(country);
            int cityId = await _weatherAdapter.GetCityIdByName(city);

            return await _weatherAdapter.GetWeatherInfoByCountryAndCity(countryId, cityId);
        }

        public async Task<List<WeatherInfoModel>> GetWeathersByCityId(int cityId)
        {
            return await _weatherAdapter.GetWeatherInfosByCityId(cityId);
        }
    }
}
