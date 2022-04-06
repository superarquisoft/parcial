using AutoMapper;
using Domain.Models.Entities.Weather;
using DrivenAdapter.Mongo.Entities;

namespace Weather.AppService.Automapper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<CityModel, CityEntity>().ReverseMap();
            CreateMap<CountryModel, CountryEntity>().ReverseMap();
            CreateMap<WeatherInfoModel, WeatherEntity>().ReverseMap();
        }
    }
}
