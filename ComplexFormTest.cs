using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace SeleniumTests
{
    public class ComplexFormTest : IDisposable
    {
        private IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
        }

        [Test]
        public void FillRegistrationForm()
        {
            WebDriverWait wait = new WebDriverWait(driver!, TimeSpan.FromSeconds(3));

            // Введення імені та прізвища
            driver!.FindElement(By.Id("firstName")).SendKeys("Іван");
            driver.FindElement(By.Id("lastName")).SendKeys("Петров");

            // Введення email
            driver.FindElement(By.Id("userEmail")).SendKeys("ivan.petrov@example.com");

            // Вибір статі (чоловік) 
            IWebElement genderRadio = driver.FindElement(By.CssSelector("label[for='gender-radio-1']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", genderRadio);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", genderRadio);

            // Введення номера телефону
            driver.FindElement(By.Id("userNumber")).SendKeys("1234567890");

            // Вибір дати народження
            driver.FindElement(By.Id("dateOfBirthInput")).Click();
            new SelectElement(driver.FindElement(By.ClassName("react-datepicker__month-select"))).SelectByText("May");
            new SelectElement(driver.FindElement(By.ClassName("react-datepicker__year-select"))).SelectByText("1995");
            driver.FindElement(By.ClassName("react-datepicker__day--015")).Click();

            // Введення предметів (Subject)
            var subjectInput = driver.FindElement(By.Id("subjectsInput"));
            subjectInput.SendKeys("Maths");
            subjectInput.SendKeys(Keys.Enter);

            // Вибір хобі (Sports + Music)
            driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-1']")).Click();
            driver.FindElement(By.CssSelector("label[for='hobbies-checkbox-3']")).Click();

            // Завантаження файлу (файл повинен існувати в директорії проєкту)
            string filePath = Path.GetFullPath("testfile.png");
            driver.FindElement(By.Id("uploadPicture")).SendKeys(filePath);

            // Введення адреси
            driver.FindElement(By.Id("currentAddress")).SendKeys("123, Київ, Україна");

            // Вибір штату
            driver.FindElement(By.Id("state")).Click();
            wait.Until(d => d.FindElement(By.XPath("//div[contains(text(), 'NCR')]"))).Click();

            // Вибір міста
            driver.FindElement(By.Id("city")).Click();
            wait.Until(d => d.FindElement(By.XPath("//div[contains(text(), 'Delhi')]"))).Click();

            // Натискання кнопки Submit
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submitButton);

            // Перевірка, що з’явилось вікно успішного відправлення
            wait.Until(d => d.FindElement(By.ClassName("modal-content")).Displayed);
            Assert.IsTrue(driver.FindElement(By.ClassName("modal-content")).Displayed, "Форма не була відправлена!");
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
