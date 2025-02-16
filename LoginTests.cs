using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace SeleniumTests
{
    public class LoginTests
    {
        private IWebDriver? driver = null; // Дозволяємо null-значення

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void TestLogin()
        {
            driver?.Navigate().GoToUrl("https://example.com/login");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            if (driver?.FindElements(By.TagName("iframe")).Count > 0)
            {
                driver.SwitchTo().Frame(0);
            }

            Thread.Sleep(3000);

            IWebElement usernameField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
            IWebElement passwordField = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
            IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("loginButton")));

            usernameField.SendKeys("testuser");
            passwordField.SendKeys("password123");
            loginButton.Click();

            IWebElement welcomeMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("welcome")));
            Assert.That(welcomeMessage.Displayed, Is.True, "Login failed - Welcome message not displayed");
        }

        [Test]
        public void TestPageTitle()
        {
            driver?.Navigate().GoToUrl("https://example.com");
            string pageTitle = driver?.Title ?? "";
            Assert.That(pageTitle, Is.EqualTo("Expected Title"), "Page title does not match");
        }

        [TearDown]
        public void Teardown()
        {
            driver?.Dispose(); // Коректне завершення роботи драйвера
            driver?.Quit();
        }
    }
}
