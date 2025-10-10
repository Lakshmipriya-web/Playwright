using Microsoft.Playwright;
using PlaywrightTests.Helpers;

namespace PlaywrightTests.Pages
{
    public class LoginPage(IPage page) : BasePage(page)
    {
        private readonly IPage _page = page;
        
        public static readonly string _loginButton = "#login-button";
        public static readonly string _passwordField = "#password";
        public static readonly string _usernameField = "#user-name";

        public async Task Open(string url)
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
        
        public async Task<BasePage> LoginAs(string username, string password)
        {
            await EnterUsername(username);
            await EnterPassword(password);
            await ClickLogin();
            // Check if login succeeded by verifying an element on Inventory page
            bool loginSuccess = _page.Url.Contains("/inventory.html");

            if (loginSuccess)
                return new InventoryPage(_page);
            else
                return new LoginPage(_page); // login failed, stay on LoginPage
        }
    }
}
