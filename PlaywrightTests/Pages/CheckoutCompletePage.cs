using Microsoft.Playwright;
using PlaywrightTests.Helpers;

namespace PlaywrightTests.Pages
{
    public class CheckoutCompletePage(IPage page) : BasePage(page)
    {
        public readonly IPage _page = page;

        public static readonly string headerText = "h2[class='complete-header']";

        public async Task VerifyTheOrderSuccessfulMessage(string expectedText)
        {
            var locator = _page.Locator(headerText);
            await AssertionHelpers.AssertTextAsync(locator, expectedText);
        }
    }
}