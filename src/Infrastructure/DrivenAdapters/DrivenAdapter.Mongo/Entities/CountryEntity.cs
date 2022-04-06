using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DrivenAdapter.Mongo.Entities
{
    /// <summary>
    /// CountryModel
    /// </summary>
    [BsonIgnoreExtraElements]
    public class CountryEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        /// <summary>
        /// Iso
        /// </summary>
        [BsonElement("iso")]
        public string Iso { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [BsonElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// Capital
        /// </summary>
        [BsonElement("capital")]
        public string Capital { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [BsonElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// CountryId
        /// </summary>
        [BsonElement("country_id")]
        public int CountryId { get; set; }
    }
}