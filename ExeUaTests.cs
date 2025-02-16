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
            // ����������� �������� Chrome
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://exe.ua/");

            // ����������� ������ ����������
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void SearchTest()
        {
            // �������, ���� ���� ������ ����� �������
            wait.Until(driver => driver.FindElement(By.Name("query")).Displayed);

            // ��������� ���� ������
            IWebElement searchBox = driver.FindElement(By.Name("query"));
            searchBox.Clear();
            searchBox.SendKeys("�������");

            // ������������� ���������� ������� ��� ������ ������
            IWebElement searchButton = driver.FindElement(By.CssSelector(".ssearch-submit"));
            searchButton.Click();
            System.Threading.Thread.Sleep(2000);
        }

        [TearDown]
        public void TearDown()
        {
            // ��������� ������� � ������� �������
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }
}
