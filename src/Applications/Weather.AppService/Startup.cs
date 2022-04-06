using DrivenAdapter.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using Weather.AppService.Configuration;

namespace Weather.AppService
{
    /// <summary>
    /// Startup
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {

        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger<Startup> _logger;

        // <summary>
        /// EnvironmentHost
        /// </summary>
        public IWebHostEnvironment EnvironmentHost { get; }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="environment"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment environment, ILogger<Startup> logger)
        {
            Configuration = configuration;
            EnvironmentHost = environment;
            _logger = logger;
        }

        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();
            services.AddSwaggerAndVersioning();

            #region Mongo
            string mongoConn = Configuration.GetValue<string>("MongoConfiguration:ConnectionString");
            string mongoDb = Configuration.GetValue<string>("MongoConfiguration:Database");
            services.AddSingleton<IContextConfig>(provider => new ContextConfig(mongoConn, mongoDb));
            #endregion Mongo

            #region Logging
            _logger.LogInformation("================= STARTUP =================");
            _logger.LogInformation("=========================================== ");
            #endregion Logging
        }


        public void Configure(IApplicationBuilder app, IHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.AppSwaggerUI(provider);
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
