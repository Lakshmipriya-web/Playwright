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
        protected TestConfig _config;
        protected InventoryPage _inventoryPage;
        protected string _baseUrl;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            // Initialize Extent Reports once for all tests
            ReportManager.InitReport();
            // Load environment-specific config (Dev/QA etc.)
            _config = ConfigReader.LoadConfig();
            //create connection
            _playwright = await DriverManager.GetInstance();
            // Launch browser based on config or environment variable
            _browser = await DriverManager.GetBrowserAsync(_config);
        }

        [SetUp]
        public async Task Setup()
        {
            // Create a fresh context + page for each test
            var context = await _browser.NewContextAsync();
            _page = await context.NewPageAsync();
            // Initialize global base URL
            _baseUrl = UrlHelper.GetBaseUrlAsync(_config);
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
                // This means the test failed
                await ScreenshotHelper.CaptureAsync(_page, context.Test.Name);
                Utils.Logger.Error($"Test FAILED: {context.Test.Name}");
                Utils.Logger.Error($"Reason: {context.Result.Message}");
            }
            else if (context.Result.Outcome.Status == TestStatus.Passed)
            {
                ReportManager.Log(Status.Pass, "Test passed");
                Utils.Logger.Info($"Test PASSED: {context.Test.Name}");
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