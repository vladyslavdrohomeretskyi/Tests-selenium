using OpenQA.Selenium;

namespace PageObjects
{
    public class BasePage
    {
        protected static IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        private IWebElement header => driver.FindElement(By.TagName("h1"));

        public string GetHeaderText() => header.Text;
    }
}