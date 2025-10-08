using System.Runtime.CompilerServices;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;

namespace PlaywrightTests.Drivers;

public class DriverManager
{
    private static IPlaywright _driverInstance;
    private static readonly object _lock = new();

    private DriverManager() { }

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
}   
