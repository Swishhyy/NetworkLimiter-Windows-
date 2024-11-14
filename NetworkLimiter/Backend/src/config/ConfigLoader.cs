using System;
using System.IO;
using System.Text.Json;

namespace NetworkLimit.Config
{
    public static class ConfigLoader
    {
        private static readonly string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config", "appsettings.json");

        public static ServiceConfig LoadConfig()
        {
            if (File.Exists(configFilePath))
            {
                string json = File.ReadAllText(configFilePath);
                return JsonSerializer.Deserialize<ServiceConfig>(json);
            }
            return new ServiceConfig(); // Return defaults if config is missing
        }
    }
}
