using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ExeUaTests
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            // Ініціалізація драйвера Chrome
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://exe.ua/");

            // Ініціалізація явного очікування
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void SearchTest()
        {
            // Очікуємо, поки поле пошуку стане видимим
            wait.Until(driver => driver.FindElement(By.Name("query")).Displayed);

            // Знаходимо поле пошуку
            IWebElement searchBox = driver.FindElement(By.Name("query"));
            searchBox.Clear();
            searchBox.SendKeys("ноутбук");

            // Використовуємо правильний локатор для кнопки пошуку
            IWebElement searchButton = driver.FindElement(By.CssSelector(".ssearch-submit"));
            searchButton.Click();
            System.Threading.Thread.Sleep(2000);
        }

        [TearDown]
        public void TearDown()
        {
            // Закриваємо браузер і очищуємо ресурси
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}
