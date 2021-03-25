using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;
using System;

namespace DemoWebApp.Tests
{
    [Binding]
    public class LoanApplicationSteps
    {

        private IWebDriver _driver;
        private LoanApplicationPage _loanPage;
        private ApplicationConfirmationPage _appConfirmationPage;

        [Given(@"I am on the loan application page")]
        public void GivenIAmOnTheLoanApplicationPage()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            _driver = new FirefoxDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            _loanPage = LoanApplicationPage.NaviateTo(_driver);
            //_driver.Navigate().GoToUrl("http://localhost:44344/Home/StartLoanApplication");
        }

        [Given(@"I enter a first name of (.*)")]
        public void GivenIEnterAFirstNameOf(string firstName)
        {
            //_driver.FindElement(By.Id("FirstName")).SendKeys(firstName);
            _loanPage.FirstName = firstName;
        }

        [Given(@"I enter a last name of (.*)")]
        public void GivenIEnterALastNameOf(string lastName)
        {
            _loanPage.LastName = lastName;
            //_driver.FindElement(By.Id("LastName")).SendKeys(lastName);
        }

        [Given(@"I select that I have an existing loan application")]
        public void GivenISelectThatIHaveAnExistingLoanApplication()
        {
            _loanPage.ExistingLoan(); ;
            //_driver.FindElement(By.Id("Loan")).Click();
        }

        [Given(@"I confirm my acceptance of the terms and conditions")]
        public void GivenIConfirmMyAcceptanceOfTheTermsAndConditions()
        {
            _loanPage.TermsAndCondition();
            //_driver.FindElement(By.Name("TermsAcceptance")).Click();
        }

        [When(@"I submit the application")]
        public void WhenISubmitTheApplication()
        {
            _appConfirmationPage = _loanPage.SubmitApplication();
            //_driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
        }

        [Then(@"I should see the application complete confirmation page for (.*)")]
        public void ThenIShouldSeeTheApplicationCompleteConfirmationPagefor(string firstName)
        {
            //Assert.Equal(firstName, _driver.FindElement(By.Id("firstName")).Text);
            Assert.Equal(firstName, _appConfirmationPage.FirstName);
        }

        [Then(@"I should see an error message telling me that I must accept terms and conditions")]
        public void ThenIShouldSeeAnErrorMessageTellingMeThatIMustAcceptTermsAndConditions()
        {
            //Assert.Equal("You must accept the terms and conditions", _driver.FindElement(By.CssSelector(".validation-summary-errors ul li")).Text);
            Assert.Equal("You must accept the terms and conditions", _loanPage.ErrorText);
        }

        [AfterScenario]
        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}
