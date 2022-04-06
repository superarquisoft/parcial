using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DrivenAdapter.Mongo.Entities
{
    /// <summary>
    /// CityModel
    /// </summary>
    [BsonIgnoreExtraElements]
    public class CityEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        /// <summary>
        /// CityId
        /// </summary>
        [BsonElement("city_id")]
        public int CityId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// CountryCode
        /// </summary>
        [BsonElement("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// CountryId
        /// </summary>
        [BsonElement("country")]
        public CountryDetailEntity Country { get; set; }
    }

    public class CountryDetailEntity
    {
        /// <summary>
        /// CountryId
        /// </summary>
        [BsonElement("country_id")]
        public int CountryId { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [BsonElement("country")]
        public string Country { get; set; }
    }
}