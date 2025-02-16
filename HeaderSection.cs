using OpenQA.Selenium;

namespace PageObjects
{
    public class HeaderSection : BasePage
    {
        public HeaderSection(IWebDriver driver) : base(driver) { }

        private IWebElement btnLogin => driver.FindElement(By.XPath("//a[@href='/login/']"));
        private IWebElement btnContacts => driver.FindElement(By.XPath("//ul[contains(@class, 'site')]/li/a[@href='/contacts/']"));
        private IWebElement btnDelivery => driver.FindElement(By.XPath("//ul[contains(@class, 'site')]/li/a[@href='/payment-and-delivery/']"));
        private IWebElement btnWarranty => driver.FindElement(By.XPath("//ul[contains(@class, 'site')]/li/a[@href='/warranty-and-service/']"));
        private IWebElement btnCertificates => driver.FindElement(By.XPath("//ul[contains(@class, 'site')]/li/a[@href='/certificates/']"));
        private IWebElement btnPcBuilding => driver.FindElement(By.XPath("//ul[contains(@class, 'site')]/li/a[@href='/pc-building/']"));
        private IWebElement btnSale => driver.FindElement(By.XPath("//ul[contains(@class, 'site')]/li/a[@href='/category/c96871/']"));



        public LoginPage ClickLogin()
        {
            btnLogin.Click();
            return new LoginPage(driver);
        }


        public ContactsPage ClickContacts()
        {
            btnContacts.Click();
            return new ContactsPage(driver);
        }


        public DeliveryPage ClickDelivery()
        {
            btnDelivery.Click();
            return new DeliveryPage(driver);
        }


        public WarrantyPage ClickWarranty()
        {
            btnWarranty.Click();
            return new WarrantyPage(driver);
        }


        public CertificatesPage ClickCertificates()
        {
            btnCertificates.Click();
            return new CertificatesPage(driver);
        }


        public PcBuildingPage ClickPcBuilding()
        {
            btnPcBuilding.Click();
            return new PcBuildingPage(driver);
        }


        public SalePage ClickSale()
        {
            btnSale.Click();
            return new SalePage(driver);
        }
    }
}