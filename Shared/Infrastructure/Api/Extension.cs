using Infrastructure.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Infrastructure.Api
{
    internal static class Extension
    {
        public static IServiceCollection AddCorsPolicies(this IServiceCollection services)
        {
            var corsOptions = services.GetOptions<CorsOptions>("cors");

            return services
                .AddSingleton(corsOptions)
                .AddCors(cors =>
                {
                    var allowedHeaders = corsOptions.AllowedHeaders ?? Enumerable.Empty<string>();
                    var allowedMethods = corsOptions.AllowedMethods ?? Enumerable.Empty<string>();
                    var allowedOrigins = corsOptions.AllowedOrigins ?? Enumerable.Empty<string>();
                    var exposedHeaders = corsOptions.ExposedHeaders ?? Enumerable.Empty<string>();
                    cors.AddPolicy("cors", corsBuilder =>
                    {
                        var origins = allowedOrigins.ToArray();
                        if (corsOptions.AllowCredentials && origins.FirstOrDefault() != "*")
                        {
                            corsBuilder.AllowCredentials();
                        }
                        else
                        {
                            corsBuilder.DisallowCredentials();
                        }

                        corsBuilder.WithHeaders(allowedHeaders.ToArray())
                            .WithMethods(allowedMethods.ToArray())
                            .WithOrigins(origins.ToArray())
                            .WithExposedHeaders(exposedHeaders.ToArray());
                    });
                });
        }

       
    }
}