using PlaywrightTests.Pages;
using PlaywrightTests.Constants;
using PlaywrightTests.Utils;
using PlaywrightTests.Tests.Base;

namespace PlaywrightTests.Tests;

public class Tests : BaseTest
{
    // protected IPlaywright _playwright;
    // protected IBrowser _browser;
    // protected IPage _page;
    // private Config.Config _config;
    // private InventoryPage _inventoryPage;
    private InventoryItemPage _inventoryItemPage;
    private CartPage _cartPage;
    private CheckoutStepOnePage _checkoutStepOnePage;
    private CheckoutStepTwoPage __checkoutStepTwoPage;
    private CheckoutCompletePage _checkoutCompletePage;

    // [OneTimeSetUp]
    // public async Task Setup()
    // {
    //     _config = ConfigReader.LoadConfig();

    //     //create connection
    //     _playwright = await DriverManager.GetInstance();
    //     // using var playwright = await Playwright.CreateAsync();
    //     _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    //     {
    //         Headless = false
    //     });
    //     _page = await _browser.NewPageAsync();

    //     LoginPage loginPage = new LoginPage(_page);
    //     await loginPage.open(_config.baseUrl);
    //     _inventoryPage = await loginPage.LoginAs(_config.username, _config.password);

    // }

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
        // await page.GetByRole(AriaRole.Button, new() { Name = "start here" }).ClickAsync();
    }

    // [Test]
    // public async Task Test2()
    // {

    //     var loginTextbox = _page.GetByPlaceholder("Username");
    //     var passwordTextbox = _page.GetByPlaceholder("Password");
    //     // var loginButton = _page.Locator("[type=submit]");
    //     var loginButton = _page.GetByRole(AriaRole.Button, new() { Name = "Login" });

    //     await _page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
    //     await loginTextbox.FillAsync("Admin");
    //     await passwordTextbox.FillAsync("admin123");
    //     await loginButton.ClickAsync();
    //     //   IDialog alert =   _page.Dialog();
    //     ILocator PageTitle = _page.Locator("h6");
    //     string x = await PageTitle.InnerTextAsync();
    //     Assert.AreEqual(x, "Dashboard");

    // }

    // [Test]
    // public async Task Test3()
    // {
    //     await _page.GotoAsync("https://demoqa.com/automation-practice-form");
    //     await _page.GetByText("Alerts, Frame & Windows").ClickAsync();
    //     await _page.Locator("li.btn", new() { HasTextString = "Alerts" }).ClickAsync();
    //     await _page.WaitForTimeoutAsync(5000);
    //     await _page.Locator("[id='alertButton']").ClickAsync();
    //     // await _page.Locator("[id='alertButton']").ClickAsync(new LocatorClickOptions { Force = true });
    //     // await _page.WaitForTimeoutAsync(5000);
    //     // _page.Dialog += async (_, dialog) => { await dialog.AcceptAsync(); };
    // }

    // [Test]
    // public async Task Test4()
    // {
    //     await _page.GotoAsync("https://demoqa.com/automation-practice-form");
    //     await _page.Locator("[id='firstName']").FillAsync("Lakshmi");
    //     await _page.Locator("[id='userEmail']").FillAsync("xuy@example.com");
    //     // await _page.GetByLabel("Female").CheckAsync(); // ✅ Cleanest and most accessible

    //    await _page.Locator("//input[@value='Female']").ClickAsync(new LocatorClickOptions { Force = true });
    //     await _page.Locator("[id='userNumber']").FillAsync("9134025719");
    //     await _page.WaitForTimeoutAsync(5000);
    // }
}