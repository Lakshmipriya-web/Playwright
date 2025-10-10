using PlaywrightTests.Pages;
using PlaywrightTests.Constants;
using PlaywrightTests.Utils;
using PlaywrightTests.Tests.Base;

namespace PlaywrightTests.Tests;

public class Tests : BaseTest
{
    [Test]
    [Category("Smoke"), Category("Regression")]
    [Property("TestCaseId", "TC_Login_001")]
    [Property("TestCaseId", "TC_Login_002")]
    public async Task VerifyLoginTitle_Test()
    {
        LoginPage loginPage = new LoginPage(_page);
        await loginPage.Open(_baseUrl);
        InventoryPage _inventoryPage = (InventoryPage)await loginPage.LoginAs(_config.username, _config.password);

        var firstName = RandomDataGenerator.GetRandomName();
        var lastName = RandomDataGenerator.GetRandomName();
        var postalCode = RandomDataGenerator.GetRandomPostalCode();

        Assert.AreEqual(await _page.TitleAsync(), AppConstants.SwagLabs);
        _inventoryPage.ValidateUrl(AppConstants.Inventory);
        var _inventoryItemPage = await _inventoryPage.ClickOnSpecificProductName(AppConstants.SauceLabsBackpack);
        _inventoryItemPage.ClickOnAddToCart();

        var _cartPage = await _inventoryItemPage.ClickOnShoppingCartLink();

        _inventoryPage = await _cartPage.ClickOnContinueShopping();

        _inventoryItemPage = await _inventoryPage.ClickOnSpecificProductName(AppConstants.SauceLabsFleeceJacket);
        _inventoryItemPage.ClickOnAddToCart();

        _cartPage = await _inventoryItemPage.ClickOnShoppingCartLink();

        var _checkoutStepOnePage = await _cartPage.ClickOnCheckout();
        await _checkoutStepOnePage.EnterFirstName(firstName);
        await _checkoutStepOnePage.EnterLastName(lastName);
        await _checkoutStepOnePage.EnterPostalCode(postalCode);

        var __checkoutStepTwoPage = await _checkoutStepOnePage.ClickOnContinue();

        var _checkoutCompletePage = await __checkoutStepTwoPage.ClickOnFinish();
        await _checkoutCompletePage.VerifyTheOrderSuccessfulMessage(MessageConstants.OrderSuccess);
        await _page.WaitForTimeoutAsync(3000);
    }
}