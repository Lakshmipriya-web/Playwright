using Microsoft.Playwright;
using PlaywrightTests.Helpers;

namespace PlaywrightTests.Pages
{
    public class LoginPage(IPage page) : BasePage(page)
    {
        private readonly IPage _page = page;
        // Locators as private fields
        public static readonly string _usernameField = "#user-name";
        public static readonly string _passwordField = "#password";
        public static readonly string _loginButton = "#login-button";

        public async Task open(string url)
        {
            await NavigateAsync(url);
        }

        public async Task EnterUsername(string username)
        {
            await UIActions.FillText(_page, _usernameField, username);
        }

        public async Task EnterPassword(string password)
        {
            await UIActions.FillText(_page, _passwordField, password);
        }
        public async Task ClickLogin()
        {
            await UIActions.Click(_page, _loginButton);
        }
        public async Task<InventoryPage> LoginAs(string username, string password)
        {
            await EnterUsername(username);
            await EnterPassword(password);
            await ClickLogin();
            return new InventoryPage(_page);
        }

        // public static async Task LoginAsync(IPage page)
    // {
    //     LoginPage loginPage = new(page);
    //     await loginPage.NavigateAsync();
    //     await loginPage.LoginAs("standard_user", "secret_sauce");
    //     // await page.GotoAsync("https://www.saucedemo.com/");
    //     // await page.FillAsync(LoginPage._usernameField, "standard_user");
    //     // await page.FillAsync(LoginPage._passwordField, "secret_sauce");
    //     // await page.ClickAsync(LoginPage._loginButton);
    //     Assert.AreEqual(await page.TitleAsync(), "Swag Labs");
    // }
    }
}
