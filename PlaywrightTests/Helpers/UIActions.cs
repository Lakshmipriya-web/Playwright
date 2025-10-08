using Microsoft.Playwright;

namespace PlaywrightTests.Helpers
{
    public static class UIActions
    {
        public static async Task Click(IPage page, string selector)
        {
            await page.Locator(selector).ClickAsync();
        }

        public static async Task ClickByText(IPage page, string text)
        {
            await page.GetByText(text).ClickAsync();
        }

        public static async Task FillText(IPage page, string selector, string text)
        {
            await page.Locator(selector).FillAsync(text);
        }

        public static async Task<string> GetText(IPage page, string selector)
        {
            return await page.Locator(selector).InnerTextAsync();
        }

        public static async Task<bool> IsVisible(IPage page, string selector)
        {
            return await page.Locator(selector).IsVisibleAsync();
        }
        
        public static async Task Hover(IPage page, string selector)
        {
            await page.Locator(selector).HoverAsync();
        }

        public static async Task SelectDropdown(IPage page, string selector, string value)
        {
            await page.Locator(selector).SelectOptionAsync(new SelectOptionValue { Value = value });
        }
    }
}
