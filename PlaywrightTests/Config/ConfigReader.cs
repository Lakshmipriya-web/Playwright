using Newtonsoft.Json;

namespace PlaywrightTests.Config
{
    public static class ConfigReader
    {
        public static TestConfig LoadConfig(string fileName = "config.json")
        {
            var basePath = AppContext.BaseDirectory;
            var configPath = Path.Combine(basePath, "Config", fileName);
            if (!File.Exists(configPath))
                throw new FileNotFoundException($"Config file not found: {configPath}");
            var json = File.ReadAllText(configPath);
            return JsonConvert.DeserializeObject<TestConfig>(json);
        }
    }
}
