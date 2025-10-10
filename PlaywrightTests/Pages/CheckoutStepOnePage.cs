using Microsoft.Playwright;
using PlaywrightTests.Helpers;

namespace PlaywrightTests.Pages
{
    public class CheckoutStepOnePage(IPage page) : BasePage(page)
    {
        public readonly IPage _page = page;

        public static readonly string _continueButton = "#continue";
        public static readonly string _firstNameTextBox = "#first-name";
        public static readonly string _lastNameTextBox = "#last-name";
        public static readonly string _postalCodeTextBox = "#postal-code";

        public async Task EnterFirstName(string firstName)
        {
            await UIActions.FillText(_page, _firstNameTextBox, firstName);
        }

        public async Task EnterLastName(string lastName)
        {
            await UIActions.FillText(_page, _lastNameTextBox, lastName);
        }

        public async Task EnterPostalCode(string postalCode)
        {
            await UIActions.FillText(_page, _postalCodeTextBox, postalCode);
        }

        public async Task<CheckoutStepTwoPage> ClickOnContinue()
        {
            await UIActions.Click(_page, _continueButton);
            return new CheckoutStepTwoPage(_page);
        }
    }
}