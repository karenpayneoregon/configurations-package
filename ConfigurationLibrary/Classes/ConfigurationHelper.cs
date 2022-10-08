using System;
using ConfigurationLibrary.LanguageExtensions;
using Microsoft.Extensions.Configuration;
using static ConfigurationLibrary.Classes.ConnectionsConfiguration;

namespace ConfigurationLibrary.Classes
{
    public class ConfigurationHelper
    {

        public static ConnectionsConfiguration CurrentEnvironment { get; private set; }

        public static bool CheckSectionExists()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var section = configuration.GetSection("ConnectionsConfiguration");
            return section.Exists();
        }
        public static bool CheckSectionAspExists()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var section = configuration.GetSection("ConnectionStrings");
            return section.Exists();

        }

        public static string ConnectionStringWeb()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var map = configuration.GetSection("ConnectionStrings").Get<ConfigurationMap>();

            ConnectionsConfiguration environment = map.ActiveEnvironment
                .ToEnum(Development);

            CurrentEnvironment = environment;

            return environment switch
            {
                Development => map.Development,
                Stage => map.Stage,
                Production => map.Production,
                _ => map.Development
            };

        }
        /// <summary>
        /// Current connection string by 'ActiveEnvironment'
        /// </summary>
        /// <returns>Connection string</returns>
        public static string ConnectionString()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var map = configuration.GetSection("ConnectionsConfiguration").Get<ConfigurationMap>();

            ConnectionsConfiguration environment = map.ActiveEnvironment
                .ToEnum(Development);

            CurrentEnvironment = environment;

            return environment switch
            {
                Development => map.Development,
                Stage => map.Stage,
                Production => map.Production,
                _ => map.Development
            };

        }
        /// <summary>
        /// Get all environment connection strings
        /// </summary>
        /// <returns><see cref="ConfigurationMap"/></returns>
        public static ConfigurationMap Connections()
        {
            var configuration = Builder();
            return configuration.GetSection("ConnectionsConfiguration").Get<ConfigurationMap>();
        }

        private static IConfigurationRoot Builder()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            return configuration;
        }
    }
}
