using Microsoft.Playwright;
using PlaywrightTests.Helpers;

namespace PlaywrightTests.Pages
{
    public class InventoryPage(IPage page) : BasePage(page)
    {
        public readonly IPage _page = page;

        public async Task<InventoryItemPage> ClickOnSpecificProductName(string productname)
        {
            await UIActions.ClickByText(_page, productname);
            return new InventoryItemPage(_page);
        }
    }
}