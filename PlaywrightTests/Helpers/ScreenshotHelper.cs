using Microsoft.Playwright;

namespace PlaywrightTests.Helpers
{
    public static class ScreenshotHelper
    {
        public static async Task CaptureAsync(IPage page, string testName)
        {
            var screenshotDir = "Screenshots";
            Directory.CreateDirectory(screenshotDir); // ensure folder exists

            var screenshotPath = Path.Combine(
                screenshotDir,
                $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png"
            );

            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = screenshotPath,
                FullPage = true
            });

            TestContext.AddTestAttachment(screenshotPath, "Failure Screenshot");
        }
    }
}
