using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSharpSeleniumFramework.Pages;

namespace CSharpSeleniumFramework.Tests
{
    public class SampleTest
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test, Category("UI")]
        public void VerifyHomePageTitle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.GetTitle().Contains("Google"));
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}