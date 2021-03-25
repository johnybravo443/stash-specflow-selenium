using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;

namespace DemoWebApp.Tests
{
    public class LoanApplicationTests
    {
        [Fact]
        public void StartApplication()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:44344/");
                driver.FindElement(By.Id("startApplication")).Click();
                Assert.Equal("Start Loan Application - Loan Application", driver.Title);
            }
        }

        [Fact]
        public void SubmitApplication()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:44344/Home/StartLoanApplication");
                
                driver.FindElement(By.Id("FirstName")).SendKeys("Sarah");
                driver.FindElement(By.Id("LastName")).SendKeys("Sanders");
                driver.FindElement(By.Id("Loan")).Click();
                driver.FindElement(By.Name("TermsAcceptance")).Click();
                driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();

                Assert.Equal("Sarah", driver.FindElement(By.Id("firstName")).Text);

            }
        }

    }
}
