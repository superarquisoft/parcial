using Domain.UseCases.Weather;
using DrivenAdapter.Mongo.Adapter;
using Microsoft.Extensions.DependencyInjection;
using Weather.AppService.Automapper;

namespace Weather.AppService.Configuration
{
    public static class ConfigureServices
    {
        /// <summary>
        /// AddServices
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            #region AutoMapper
            services.AddAutoMapper(typeof(EntityProfile));
            #endregion AutoMapper

            #region Adapters
            services.AddScoped<IWeatherAdapter, WeatherAdapter>();
            #endregion Adapters

            #region UseCase
            services.AddScoped<IWeatherUseCase, WeatherUseCase>();
            #endregion UseCase

            return services;
        }
    }
}
