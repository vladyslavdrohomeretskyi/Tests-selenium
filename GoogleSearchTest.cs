using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public class GoogleSearchTest : IDisposable
    {
        private IWebDriver? driver; // Додаємо nullable, щоб уникнути попереджень

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SearchInGoogle()
        {
            driver!.Navigate().GoToUrl("https://www.google.com");

            // Очікування для стабільної роботи тесту
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Name("q")).Displayed);

            // Знаходимо поле пошуку і вводимо запит
            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium C#");
            searchBox.SendKeys(Keys.Enter);

            // Очікуємо появу результатів пошуку
            wait.Until(d => d.FindElement(By.Id("search")).Displayed);
            Assert.IsTrue(driver.FindElement(By.Id("search")).Displayed, "Результати пошуку не відображаються!");
            System.Threading.Thread.Sleep(2000);
        }


        [TearDown]
        public void Cleanup()
        {
            Dispose();
        }

        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
