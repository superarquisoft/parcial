using Domain.Models.Entities.Weather;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrivenAdapter.Mongo.Adapter
{
    public interface IWeatherAdapter
    {
        /// <summary>
        /// GetCityIdByName
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        Task<int> GetCityIdByName(string cityName);

        /// <summary>
        /// GetCountryIdByName
        /// </summary>
        /// <param name="countryName"></param>
        /// <returns></returns>
        Task<int> GetCountryIdByName(string countryName);

        /// <summary>
        /// GetWeatherInfoByCountryAndCity
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        Task<WeatherInfoModel> GetWeatherInfoByCountryAndCity(int countryId, int cityId);

        /// <summary>
        /// CreateWeatherInfo
        /// </summary>
        /// <param name="weatherInfo"></param>
        /// <returns></returns>
        Task<WeatherInfoModel> CreateWeatherInfo(WeatherInfoModel weatherInfo);

        /// <summary>
        /// Gets the weather infos by city identifier.
        /// </summary>
        /// <param name="cityId">The city identifier.</param>
        /// <returns></returns>
        Task<List<WeatherInfoModel>> GetWeatherInfosByCityId(int cityId);
    }
}
