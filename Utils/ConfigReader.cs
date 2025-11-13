using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace OrangeHRMFramework.Utils
{
    public static class ConfigReader
    {
        private static JObject config;

        // 🔹 Load appsettings.json once
        static ConfigReader()
        {
            try
            {
                // 🔹 Get project root dynamically
                string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                // 🔹 Full path to appsettings.json
                string filePath = Path.Combine(projectRoot, "TestData", "appsettings.json");

                // 🔹 Read and parse JSON
                string jsonData = File.ReadAllText(filePath);
                config = JObject.Parse(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading configuration: {ex.Message}");
            }
        }

        // 🔹 Get string value
        public static string Get(string key)
        {
            return config[key]?.ToString();
        }

        // 🔹 Get int value
        public static int GetInt(string key)
        {
            if (int.TryParse(config[key]?.ToString(), out int result))
                return result;
            throw new Exception($"Config value for '{key}' is not a valid integer!");
        }

        // 🔹 Get bool value
        public static bool GetBool(string key)
        {
            if (bool.TryParse(config[key]?.ToString(), out bool result))
                return result;
            throw new Exception($"Config value for '{key}' is not a valid boolean!");
        }

        // 🔹 Alias for backward compatibility
        public static string GetConfigValue(string key)
        {
            return Get(key);
        }
    }
}
