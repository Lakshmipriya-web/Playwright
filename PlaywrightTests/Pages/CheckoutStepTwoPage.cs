using Microsoft.Playwright;
using PlaywrightTests.Helpers;

namespace PlaywrightTests.Pages
{
    public class CheckoutStepTwoPage(IPage page) : BasePage(page)
    {
        public readonly IPage _page = page;

        public static readonly string _finishButton = "#finish";
        
        public async Task<CheckoutCompletePage> ClickOnFinish()
        {
            await UIActions.Click(_page, _finishButton);
            return new CheckoutCompletePage(_page);
        }
    }
}