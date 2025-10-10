using PlaywrightTests.Config;

namespace PlaywrightTests.Helpers
{
    public static class UrlHelper
    {
        public static string GetBaseUrlAsync(TestConfig config)
        {
            return Environment.GetEnvironmentVariable("BASE_URL") ?? config.baseUrl;
        }
    }
}