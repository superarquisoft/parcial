using DrivenAdapter.Mongo.Entities;
using MongoDB.Driver;

namespace DrivenAdapter.Mongo
{
    public class ContextConfig : IContextConfig
    {
        private static volatile ContextConfig _instance;
        private static readonly object SyncLock = new object();
        private readonly IMongoDatabase _database;

        /// <summary>
        ///     Context
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        public ContextConfig(string connectionString, string databaseName)
        {
            var mongoClient = new MongoClient(connectionString);
            _database = mongoClient.GetDatabase(databaseName);
        }

        /// <summary>
        /// Cities
        /// </summary>
        public IMongoCollection<CityEntity> Cities => _database.GetCollection<CityEntity>("City");

        /// <summary>
        /// Countries
        /// </summary>
        public IMongoCollection<CountryEntity> Countries => _database.GetCollection<CountryEntity>("Country");

        /// <summary>
        /// WeatherInfos
        /// </summary>
        public IMongoCollection<WeatherEntity> WeatherInfos => _database.GetCollection<WeatherEntity>("WeatherInfo");

        /// <summary>
        ///     GetMongoDatabase
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static ContextConfig GetMongoDatabase(string connectionString, string databaseName)
        {
            if (_instance == null)
            {
                lock (SyncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ContextConfig(connectionString, databaseName);
                    }
                }
            }

            return _instance;
        }
    }
}
