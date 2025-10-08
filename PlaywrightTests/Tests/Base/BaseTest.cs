using Microsoft.Playwright;
using PlaywrightTests.Config;
using PlaywrightTests.Drivers;
using PlaywrightTests.Pages;
using NUnit.Framework.Interfaces;
using PlaywrightTests.Helpers;
using PlaywrightTests.Reports;
using AventStack.ExtentReports;

namespace PlaywrightTests.Tests.Base
{
    public class BaseTest
    {

        protected IPlaywright _playwright;
        protected IBrowser _browser;
        protected IPage _page;
        private Config.Config _config;
        protected InventoryPage _inventoryPage;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            // Initialize Extent Reports once for all tests
            ReportManager.InitReport();
            //create connection
            _playwright = await DriverManager.GetInstance();
            // using var playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
        }

        [SetUp]
        public async Task Setup()
        {
            _config = ConfigReader.LoadConfig();

            _page = await _browser.NewPageAsync();

            LoginPage loginPage = new LoginPage(_page);
            await loginPage.open(_config.baseUrl);
            _inventoryPage = await loginPage.LoginAs(_config.username, _config.password);

            // Create ExtentTest node for current test
            ReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public async Task TearDown()
        {
            var context = TestContext.CurrentContext;

            if (context.Result.Outcome.Status == TestStatus.Failed)
            {
                ReportManager.Log(Status.Fail, TestContext.CurrentContext.Result.Message);
                ReportManager.Log(Status.Fail, TestContext.CurrentContext.Result.Message);
                // ✅ This means the test failed
                await ScreenshotHelper.CaptureAsync(_page, context.Test.Name);

                Console.WriteLine($"Test FAILED: {context.Test.Name}");
                Console.WriteLine($"Reason: {context.Result.Message}");
            }
            else if (context.Result.Outcome.Status == TestStatus.Passed)
            {
                ReportManager.Log(Status.Pass, "Test passed");
                Console.WriteLine($"Test PASSED: {context.Test.Name}");
            }

            // Close only the page, not the browser
            await _page.CloseAsync();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            // Flush ExtentReports
            ReportManager.Flush();

            // Close browser and dispose Playwright
            if (_browser != null)
                await _browser.CloseAsync();
            _playwright?.Dispose();
        }
    }
}