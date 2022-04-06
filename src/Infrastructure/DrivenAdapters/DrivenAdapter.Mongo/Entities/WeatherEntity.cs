using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DrivenAdapter.Mongo.Entities
{
    /// <summary>
    /// WeatherInfoModel
    /// </summary>
    [BsonIgnoreExtraElements]
    public class WeatherEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        /// <summary>
        /// CountryId
        /// </summary>
        [BsonElement("country_id")]
        public int CountryId { get; set; }

        /// <summary>
        /// CityId
        /// </summary>
        [BsonElement("city_id")]
        public int CityId { get; set; }

        /// <summary>
        /// Cloudiness
        /// </summary>
        [BsonElement("cloudiness")]
        public string Cloudiness { get; set; }

        /// <summary>
        /// Temperature
        /// </summary>
        [BsonElement("temperature")]
        public string Temperature { get; set; }

        /// <summary>
        /// Rh
        /// </summary>
        [BsonElement("rh")]
        public string Rh { get; set; }

        /// <summary>
        /// WindSpeed
        /// </summary>
        [BsonElement("wind_speed")]
        public string WindSpeed { get; set; }
    }
}