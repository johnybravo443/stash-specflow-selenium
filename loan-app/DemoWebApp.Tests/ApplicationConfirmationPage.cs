using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoWebApp.Tests
{
    class ApplicationConfirmationPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement firstName;

        public ApplicationConfirmationPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public string FirstName => firstName.Text;
    }
}
