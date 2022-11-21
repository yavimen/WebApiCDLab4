using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;
using WebApi.Services;

namespace WebApi.Extentions
{
    public static class ServicesExtention
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services) 
        {
            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<IDoctorService, DoctorService>();
            return services;
        }

        public static IServiceCollection CorsConfig(this IServiceCollection services, ConfigurationManager configuration)
        {
            var allowedOrigins = configuration.GetValue<string>("AllowedOrigins");

            var origins = allowedOrigins.Split(',').ToArray();

            services.AddCors(options =>
            {
                options.AddPolicy("Origins", policy =>
                {
                    policy
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowCredentials()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins(origins)
                        .Build();
                });
            });
            return services;
        }
    }
}
