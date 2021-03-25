using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoWebApp.Tests
{
    class LoanApplicationPage
    {
        private readonly IWebDriver _driver;
        private const string pageUrl = @"https://localhost:44345/Home/StartLoanApplication";

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement firstName;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement lastName;

        [FindsBy(How = How.Id, Using = "Loan")]
        private IWebElement loan;

        [FindsBy(How = How.Name, Using = "TermsAcceptance")]
        private IWebElement terms;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary")]
        private IWebElement submitButton;

        [FindsBy(How = How.CssSelector, Using = ".validation-summary-errors ul li")]
        private IWebElement termsError;


        public LoanApplicationPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(driver, this);
        }

        public static LoanApplicationPage NaviateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(pageUrl);

            return new LoanApplicationPage(driver);
        }

        public string FirstName 
        {
            set
            {
                firstName.SendKeys(value);
            } 
        }

        public string LastName
        {
            set
            {
                lastName.SendKeys(value);
            }
        }

        public void ExistingLoan()
        {
            loan.Click();
        }

        public void TermsAndCondition()
        {
            terms.Click();
        }

        public ApplicationConfirmationPage SubmitApplication()
        {
            submitButton.Click();

            return new ApplicationConfirmationPage(_driver);
        }

        public string ErrorText => termsError.Text;


    }
}
