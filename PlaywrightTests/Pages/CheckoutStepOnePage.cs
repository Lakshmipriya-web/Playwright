using Microsoft.Playwright;
using PlaywrightTests.Helpers;

namespace PlaywrightTests.Pages
{
    public class CheckoutStepOnePage(IPage page) : BasePage(page)
    {
        public readonly IPage _page = page;

        public static readonly string _firstName = "#first-name";
        public static readonly string _lastName = "#last-name";
        public static readonly string _postalCode = "#postal-code";
        public static readonly string _continueButton = "#continue";

        public async Task EnterFirstName(string firstName)
        {
            await UIActions.FillText(_page, _firstName, firstName);
        }

        public async Task EnterLastName(string lastName)
        {
            await UIActions.FillText(_page, _lastName, lastName);
        }

        public async Task EnterPostalCode(string postalCode)
        {
            await UIActions.FillText(_page, _postalCode, postalCode);
        }
        
         public async Task<CheckoutStepTwoPage> ClickOnContinue()
        {
            await UIActions.Click(_page, _continueButton);
            return new CheckoutStepTwoPage(_page);
        }
    }
}