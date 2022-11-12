using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace InBoxOutBoxExample.Persistence
{
    public static class Configuration
    {
        static public string PostgreSQLConnectionString
        {
            get
            {
                IConfigurationSection section = ConfigFile.GetSection("PostgreSQL");
                string Host = section["Host"];
                int Port = Int32.Parse(section["Port"]);
                string Database = section["Database"];
                string User = section["User"];
                string Password = section["Password"];

                return $"User ID={User};Password={Password};Host={Host};Port={Port};Database={Database};";
            }
        }

        static public IConfigurationSection MongoDBConfig
        {
            get
            {
                return ConfigFile.GetSection("MongoDB");
            }
        }

        static public ConnectionFactory RabbitMqConfig
        {
            get
            {
                IConfigurationSection section = ConfigFile.GetSection("RabbitMQ");
                string Host = section["Host"];
                string User = section["User"];
                string Password = section["Password"];
                int Port = Int32.Parse(section["Port"]);
                
                bool AutomaticRecoveryEnabled = Boolean.Parse(section["AutomaticRecoveryEnabled"]);
                
                return new ConnectionFactory()
                {
                    HostName = Host,
                    UserName = User,
                    Password = Password,
                    Port = Port,
                    AutomaticRecoveryEnabled = AutomaticRecoveryEnabled,
                };
            }
        }
        static public ConfigurationManager ConfigFile
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory()));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager;
            }
        }

    }
}
