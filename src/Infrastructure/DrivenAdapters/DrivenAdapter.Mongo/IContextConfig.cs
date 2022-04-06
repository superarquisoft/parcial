using DrivenAdapter.Mongo.Entities;
using MongoDB.Driver;

namespace DrivenAdapter.Mongo
{
    public interface IContextConfig
    {
        IMongoCollection<CityEntity> Cities { get; }

        IMongoCollection<CountryEntity> Countries { get; }

        IMongoCollection<WeatherEntity> WeatherInfos { get; }
    }
}
