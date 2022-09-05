using Configuration.Infrastructure.Data;
using Infrastructure.Modules;
using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions.DataAccess;

namespace Configuration.Infrastructure
{
    public static class Extension
    {
       
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
                services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
                services.AddScoped<IUnitOfWork, ConfigurationUnitOfWork>();
                services.AddSqlServerOption<HRMDBContext>();
                
               return services;
        }

        
    }
}