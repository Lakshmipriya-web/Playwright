using Microsoft.Playwright;
using PlaywrightTests.Config;

namespace PlaywrightTests.Drivers;

public class DriverManager
{
    private static IPlaywright _driverInstance;
    private static IBrowser _browser;
    private static readonly object _lock = new();

    private DriverManager() { }

    /// <summary>
    /// Returns a singleton Playwright instance.
    /// </summary>
    public static async Task<IPlaywright> GetInstance()
    {
        if (_driverInstance == null)
        {
            var temp = await Playwright.CreateAsync();
            lock (_lock)
            {
                if (_driverInstance == null)
                {
                    _driverInstance = temp;
                }
            }
        }
        return _driverInstance;
    }

    /// <summary>
    /// Returns a singleton browser instance based on config or environment variable.
    /// </summary>
    public static async Task<IBrowser> GetBrowserAsync(TestConfig config)
    {
        if (_browser != null)
            return _browser;

        var playwright = await GetInstance();
        string browserName = Environment.GetEnvironmentVariable("BROWSER") ?? config.browser;

        BrowserTypeLaunchOptions options = new()
        {
            Headless = config.headless
        };

        _browser = browserName.ToLower() switch
        {
            "firefox" => await playwright.Firefox.LaunchAsync(options),
            "webkit" => await playwright.Webkit.LaunchAsync(options),
            _ => await playwright.Chromium.LaunchAsync(options)
        };
        Utils.Logger.Info($"Browser launched: {browserName.ToUpper()} (Headless: {config.headless})");
        return _browser;
    }
}
