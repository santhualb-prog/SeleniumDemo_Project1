using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace OrangeHRMFramework.Utils
{
    public static class TestDataReader
    {
        // 🔹 Reads a value from a JSON file in TestData
        public static string GetTestData(string fileName, string key)
        {
            try
            {
                // 🔹 Project root
                string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                // 🔹 Full path to test data file
                string filePath = Path.Combine(projectRoot, "TestData", fileName);

                // 🔹 Read JSON text
                string jsonData = File.ReadAllText(filePath);

                // 🔹 Parse JSON
                JObject jsonObject = JObject.Parse(jsonData);

                // 🔹 Return value of key
                return jsonObject[key]?.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading test data: {ex.Message}");
            }
        }
    }
}
