using Contrato.Models;
using Contrato.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Contrato.Extension
{
    public static class ConfigExtension
    {
        public static T AddConfiguration<T>(this IServiceCollection services, IConfiguration configuration, string configurationNode) where T : class
        {
            if (string.IsNullOrEmpty(configurationNode))
            {
                configurationNode = typeof(T).Name;
            }

            var instance = Activator.CreateInstance<T>();
            new ConfigureFromConfigurationOptions<T>(configuration.GetSection(configurationNode)).Configure(instance);
            services.AddSingleton(instance);
            return configuration.GetSection(configurationNode).Get<T>();
        }

        public static void AddDIContainer(this IServiceCollection services)
        {
            services.AddScoped<IPayMob, PayMob>();
        }

        public static void AppSettingMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfiguration<Integration>(configuration, "Integration");
        }
    }
}
