using System.Runtime.CompilerServices;
using Infrastructure.Api;
using Infrastructure.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Shared.Abstractions.Exceptions;
using Shared.Infrastructure.Api;
using Shared.Middlewares;

[assembly: InternalsVisibleTo("Bootstrapper")]
namespace Infrastructure.Modules
{
    public static class Extension
    {
       
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddCorsPolicies();
            services.AddControllers().ConfigureApplicationPartManager(manage =>
            manage.FeatureProviders.Add(new InternalControllerFeatureProvider()));
            services.AddMvcCore(op=>{
            op.SuppressAsyncSuffixInActionNames = false;
            });
           
            return services;
        }

        public static IServiceCollection AddSqlServerOption<T>(this IServiceCollection services) where T : DbContext
        {
            var option = services.GetOptions<SqlServerOption>("SqlServer");
            services.AddDbContext<T>(x => x.UseSqlServer(option.ConnectionString));

            return services;
        }

        public static IServiceCollection AddValidationState(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = actionContext =>
                {
                    var result = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
                            .SelectMany(e => e.Value.Errors).Select(e => e.ErrorMessage).ToArray();

                    return new BadRequestObjectResult(new ApiValidationErrorResponse
                    {
                        Errors = result
                    });
                };
            });

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder application)
        {
            application.UseMiddleware<ExceptionMiddleware>();
            application.UseStatusCodePagesWithReExecute("/errors/{0}");
            application.UseCustomCore();
         
            return application;
        }

        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            return configuration.GetOptions<T>(sectionName);
        }
        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
        {
            var options = new T();
            configuration.GetSection(sectionName).Bind(options);
            return options;
        }

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
                {
                    swagger.CustomSchemaIds(x => x.FullName);
                    swagger.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Modular API",
                        Version = "v1"
                    });
                });
           
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v0", new OpenApiInfo { Title = "ADA HRM API", Version = "v0" });
            // });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder application)
        {
            application.UseSwagger();
             application.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v0/swagger.json", "ADA HRM API v0"); });
            return application;
        }
    }
}