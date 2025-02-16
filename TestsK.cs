using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestsK
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://exe.ua/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void AddKeyboardToCartTest()
        {
            // Очікуємо, поки поле пошуку стане видимим
            wait.Until(driver => driver.FindElement(By.Name("query")).Displayed);

            // Знаходимо поле пошуку
            IWebElement searchBox = driver.FindElement(By.Name("query"));
            searchBox.Click(); // Натискаємо на поле
            searchBox.Clear();
            searchBox.SendKeys("клавіатури");

            // Використовуємо кнопку пошуку
            IWebElement searchButton = driver.FindElement(By.CssSelector(".ssearch-submit"));
            searchButton.Click();
          
            // Очікуємо, поки кнопка "В кошик" стане видимою
            wait.Until(driver => driver.FindElement(By.CssSelector("button.btn.btn-primary.btn_add2cart")).Displayed);

        }
        
        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}
