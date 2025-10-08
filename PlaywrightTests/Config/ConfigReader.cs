using Newtonsoft.Json;

namespace PlaywrightTests.Config
{
    public static class ConfigReader
    {
        public static Config LoadConfig(string path = "Config/config.json")
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Config>(json);
        }
    }
}
