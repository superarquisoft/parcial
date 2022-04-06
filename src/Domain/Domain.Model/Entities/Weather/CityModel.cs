namespace Domain.Models.Entities.Weather
{
    /// <summary>
    /// CityModel
    /// </summary>
    public class CityModel
    {
        /// <summary>
        /// CityId
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// CountryCode
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// CountryId
        /// </summary>
        public CountryDetail Country { get; set; }
    }

    public class CountryDetail
    {
        /// <summary>
        /// CountryId
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
    }
}