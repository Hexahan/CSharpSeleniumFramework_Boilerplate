using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSeleniumFramework.Tests
{
    [TestFixture]
    public class MultiStepUITest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Step 1: Set up ChromeDriver automatically
            new DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test, Category("UI")]
        public void GoogleSearchWorkflow()
        {
            // Step 2: Navigate to Google
            driver.Navigate().GoToUrl("https://www.google.com");

            // Step 3: Verify page title
            Assert.AreEqual("Google", driver.Title, "Page title does not match.");

            // Step 4: Enter text in the search box
            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium WebDriver");

            // Step 5: Submit the search
            searchBox.Submit();

            // Step 6: Verify results page title
            Assert.IsTrue(driver.Title.Contains("Selenium WebDriver"),
                "Search results page title does not contain the search term.");
        }

        [TearDown]
        public void Teardown()
        {
            // Step 7: Close the browser
            driver.Quit();
        }
    }
}