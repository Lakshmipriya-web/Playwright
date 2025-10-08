using Newtonsoft.Json;

namespace PlaywrightTests.Config
{
    public static class ConfigReader
    {
        public static Config LoadConfig(string path = "Config/config.json")
        {

            // var path = Path.Combine(AppContext.BaseDirectory, "Config", "config.json");
            var json = File.ReadAllText(path);
            Console.Write("Json path", json);
            // return JsonSerializer.Deserialize<ConfigReader>(json,
            //     new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            // var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Config>(json);
        }
}
}
