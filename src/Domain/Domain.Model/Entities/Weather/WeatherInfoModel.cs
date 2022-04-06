namespace Domain.Models.Entities.Weather
{
    /// <summary>
    /// WeatherInfoModel
    /// </summary>
    public class WeatherInfoModel
    {
        /// <summary>
        /// CountryId
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// CityId
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Cloudiness
        /// </summary>
        public string Cloudiness { get; set; }

        /// <summary>
        /// Temperature
        /// </summary>
        public string Temperature { get; set; }

        /// <summary>
        /// Rh
        /// </summary>
        public string Rh { get; set; }

        /// <summary>
        /// WindSpeed
        /// </summary>
        public string WindSpeed { get; set; }
    }
}