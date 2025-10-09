using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public abstract class BasePage
    {
        protected readonly IPage _page;

        public BasePage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateAsync(string url)
        {
            await _page.GotoAsync(url);
        }

        public bool ValidateUrl(string expectedUrlPart)
        {
            return _page.Url.Contains(expectedUrlPart);
        }
    }
}