using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumTests
{
    [TestFixture]
    public class ExeUaTest
    {
        private IWebDriver driver = null!;
        private WebDriverWait wait = null!;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));  
        }

        [Test]
        public void AddToWishlistTest()
        {
            // Перехід на головну сторінку сайту
            driver.Navigate().GoToUrl("https://exe.ua/");

            // Знайти пошукове поле за id і виконати пошук
            var searchBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("search")));
            searchBox.SendKeys("Навушники");
            searchBox.SendKeys(Keys.Enter);

            // Дочекатися завантаження результатів пошуку
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("catalog-item")));

            // Вибрати перший товар зі списку результатів
            var firstProduct = driver.FindElement(By.CssSelector(".catalog-item"));

            // Знайти кнопку додавання до списку бажаних
            var wishlistButton = firstProduct.FindElement(By.CssSelector(".add-to-wishlist"));
            wishlistButton.Click();

            // Дочекатися появи повідомлення
            var notification = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".toast-message")));
            Assert.That(notification.Text.Contains("додано до списку бажань"), Is.True, "Товар не було додано до списку бажаних!");

            // Перевірити, чи оновився лічильник товарів у списку бажаних
            var wishlistCount = driver.FindElement(By.CssSelector(".wishlist-counter"));
            Assert.That(notification.Text.Contains("додано до списку бажань"), Is.True, "Товар не було додано до списку бажань!");

        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
