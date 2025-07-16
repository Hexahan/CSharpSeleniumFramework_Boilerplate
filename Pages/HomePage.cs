using OpenQA.Selenium;

namespace CSharpSeleniumFramework.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetTitle()
        {
            return driver.Title;
        }
    }
}