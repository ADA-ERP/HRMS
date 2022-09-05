
using System.Runtime.CompilerServices;
using Configuration.Api.Mapper;
using Configuration.Infrastructure;
using Configuration.Infrastructure.Data;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: InternalsVisibleTo("Bootstrapper")]
namespace Modules.Configuration.Api
{

    internal static class ConfigurationModule 
    {
    
        public static IServiceCollection  AddConfigurationModule(this IServiceCollection services)
        {
            services.AddCore();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
        public static async Task<IApplicationBuilder> UseConfigurationModuleAsync(this IApplicationBuilder app)
        {
            var host = app.ApplicationServices.CreateAsyncScope();
                var services = host.ServiceProvider;
                var context = services.GetRequiredService<HRMDBContext>();
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    await context.Database.MigrateAsync();
                    await SeedHRMDBContext.SeedAsync(context,loggerFactory);
                }
                catch (Exception ex)
                {
                var logger = loggerFactory.CreateLogger(nameof(ConfigurationModule));
                logger.LogError(ex,"Error On program, while migrating/seeding to database"); 
                }

            return app;
        }
    
    }
}
