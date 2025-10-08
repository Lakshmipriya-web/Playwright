using PlaywrightTests.Pages;
using PlaywrightTests.Constants;
using PlaywrightTests.Utils;
using PlaywrightTests.Tests.Base;

namespace PlaywrightTests.Tests;

public class Tests : BaseTest
{
    private InventoryItemPage _inventoryItemPage;
    private CartPage _cartPage;
    private CheckoutStepOnePage _checkoutStepOnePage;
    private CheckoutStepTwoPage __checkoutStepTwoPage;
    private CheckoutCompletePage _checkoutCompletePage;

    [Test]
    public async Task VerifyLoginTitle_Test()
    {
        var firstName = RandomDataGenerator.GetRandomName();
        var lastName = RandomDataGenerator.GetRandomName();
        var postalCode = RandomDataGenerator.GetRandomPostalCode();

        Assert.AreEqual(await _page.TitleAsync(), AppConstants.SwagLabs);
        _inventoryPage.ValidateUrl("inventory");
        _inventoryItemPage = await _inventoryPage.ClickOnSpecificProductName(AppConstants.SauceLabsBackpack);
        _inventoryItemPage.ClickOnAddToCart();

        _cartPage = await _inventoryItemPage.ClickOnShoppingCartLink();

        _inventoryPage = await _cartPage.ClickOnContinueShopping();

        _inventoryItemPage = await _inventoryPage.ClickOnSpecificProductName(AppConstants.SauceLabsFleeceJacket);
        _inventoryItemPage.ClickOnAddToCart();

        _cartPage = await _inventoryItemPage.ClickOnShoppingCartLink();

        _checkoutStepOnePage = await _cartPage.ClickOnCheckout();
        await _checkoutStepOnePage.EnterFirstName(firstName);
        await _checkoutStepOnePage.EnterLastName(lastName);
        await _checkoutStepOnePage.EnterPostalCode(postalCode);

        __checkoutStepTwoPage = await _checkoutStepOnePage.ClickOnContinue();

        _checkoutCompletePage = await __checkoutStepTwoPage.ClickOnFinish();
        await _checkoutCompletePage.VerifyTheOrderSuccessfulMessage("Thank you for your order!");
        await _page.WaitForTimeoutAsync(3000);
    }
}