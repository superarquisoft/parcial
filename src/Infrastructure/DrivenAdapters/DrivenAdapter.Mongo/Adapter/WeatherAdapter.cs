using AutoMapper;
using Domain.Models.Entities.Weather;
using DrivenAdapter.Mongo.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrivenAdapter.Mongo.Adapter
{
    public class WeatherAdapter : IWeatherAdapter
    {
        private readonly IContextConfig _mongodb;
        private readonly IMapper _mapper;

        /// <summary>
        /// WeatherAdapter
        /// </summary>
        /// <param name="mongodb"></param>
        /// <param name="mapper"></param>
        public WeatherAdapter(IContextConfig mongodb, IMapper mapper)
        {
            _mongodb = mongodb;
            _mapper = mapper;
        }

        public async Task<int> GetCityIdByName(string cityName)
        {
            var city = await _mongodb.Cities.FindAsync(x => x.Name == cityName);
            return city.FirstOrDefault().CityId;
        }

        public async Task<int> GetCountryIdByName(string countryName)
        {
            var country = await _mongodb.Countries.FindAsync(x => x.Country == countryName);
            return country.FirstOrDefault().CountryId;
        }

        public async Task<WeatherInfoModel> GetWeatherInfoByCountryAndCity(int countryId, int cityId)
        {
            var weatherInfo = await _mongodb.WeatherInfos.FindAsync(x => x.CountryId == countryId && x.CityId == cityId);
            return _mapper.Map<WeatherInfoModel>(weatherInfo.FirstOrDefault());
        }

        public async Task<WeatherInfoModel> CreateWeatherInfo(WeatherInfoModel weatherInfo)
        {
            WeatherEntity weatherEntity = _mapper.Map<WeatherEntity>(weatherInfo);
            await _mongodb.WeatherInfos.InsertOneAsync(weatherEntity);
            return weatherInfo;
        }

        public async Task<List<WeatherInfoModel>> GetWeatherInfosByCityId(int cityId)
        {
            var weathers = await _mongodb.WeatherInfos.FindAsync(x => x.CityId == cityId);
            return _mapper.Map<List<WeatherInfoModel>>(await weathers.ToListAsync());
        }
    }
}
