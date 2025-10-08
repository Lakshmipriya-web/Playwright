using Microsoft.Playwright;
using PlaywrightTests.Pages;
namespace PlaywrightTests.Helpers
{

    public static class AssertionHelpers
    {
        public static async Task AssertTextAsync(ILocator locator, string expectedText)
        {
            await locator.WaitForAsync(); // optional: wait for element to appear
            var text = await locator.InnerTextAsync();
            Assert.AreEqual(expectedText, text, $"Expected text: {expectedText}, but found: {text}");
        }

        public static async Task AssertTextContainsAsync(ILocator locator, string expectedSubstring)
        {
            await locator.WaitForAsync();
            var text = await locator.InnerTextAsync();
            StringAssert.Contains(expectedSubstring, text, $"Expected text to contain: {expectedSubstring}, but found: {text}");
        }

        public static async Task AssertVisibleAsync(ILocator locator)
        {
            Assert.IsTrue(await locator.IsVisibleAsync(), "Expected element to be visible, but it was not.");
        }

        public static async Task AssertEnabledAsync(ILocator locator)
        {
            Assert.IsTrue(await locator.IsEnabledAsync(), "Expected element to be enabled, but it was disabled.");
        }

        public static async Task AssertDisabledAsync(ILocator locator)
        {
            Assert.IsFalse(await locator.IsEnabledAsync(), "Expected element to be disabled, but it was enabled.");
        }

        public static async Task AssertValueAsync(ILocator locator, string expectedValue)
        {
            var value = await locator.InputValueAsync();
            Assert.AreEqual(expectedValue, value, $"Expected input value: {expectedValue}, but found: {value}");
        }

        public static async Task AssertPageURLAsync(IPage page, string expectedUrl)
        {
            Assert.AreEqual(expectedUrl, page.Url, $"Expected URL: {expectedUrl}, but found: {page.Url}");
        }

        public static async Task AssertPageTitleAsync(IPage page, string expectedTitle)
        {
            var title = await page.TitleAsync();
            Assert.AreEqual(expectedTitle, title, $"Expected title: {expectedTitle}, but found: {title}");
        }
    }
}