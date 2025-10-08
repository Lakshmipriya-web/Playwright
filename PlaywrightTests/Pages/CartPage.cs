using Microsoft.Playwright;
using PlaywrightTests.Helpers;

namespace PlaywrightTests.Pages
{
    public class CartPage(IPage page) : BasePage(page)
    {
        public readonly IPage _page = page;

        public static readonly string _continueShoppingButton = "#continue-shopping";
        public static readonly string _checkoutButton = "#checkout";

        public async Task<InventoryPage> ClickOnContinueShopping()
        {
            await UIActions.Click(_page, _continueShoppingButton);
            return new InventoryPage(_page);
        }

        public async Task<CheckoutStepOnePage> ClickOnCheckout()
        {
            await UIActions.Click(_page, _checkoutButton);
            return new CheckoutStepOnePage(_page);
        }
    }
}