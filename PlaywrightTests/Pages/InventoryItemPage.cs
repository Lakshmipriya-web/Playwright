using Microsoft.Playwright;
using PlaywrightTests.Helpers;

namespace PlaywrightTests.Pages
{
    public class InventoryItemPage(IPage page) : BasePage(page)
    {
        public readonly IPage _page = page;

        public static readonly string _addToCartButton = "#add-to-cart";
        public static readonly string _shoppingCartLink = "//a[@data-test='shopping-cart-link']";

        public void ClickOnAddToCart()
        {

            UIActions.Click(_page, _addToCartButton);
        }

        public async Task<CartPage> ClickOnShoppingCartLink()
        {
            await UIActions.Click(_page, _shoppingCartLink);
            return new CartPage(_page);
       }
    }
       
        
}