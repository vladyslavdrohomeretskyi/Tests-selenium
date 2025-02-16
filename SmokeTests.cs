using NUnit.Framework;
using PageObjects;
using System;

namespace Tests
{
    public class SmokeTests : BaseTest
    {
        [Test]
        public void VerifyHeaders()
        {
            InitPage initPage = new InitPage(driver);
            var certPage = initPage.header.ClickCertificates();
            Assert.That(certPage.GetHeaderText(), Is.EqualTo("Сертифікати"), "Header of Certificates page is wrong");

            var contPage = certPage.header.ClickContacts();
            Assert.That(contPage.GetHeaderText(), Is.EqualTo("Контакти"), "Header of Contacts page is wrong");

            var delivPage = contPage.header.ClickDelivery();
            Assert.That(delivPage.GetHeaderText(), Is.EqualTo("Доставка і оплата"), "Header of Delivery page is wrong");

            var pcPage = delivPage.header.ClickPcBuilding();
            Assert.That(pcPage.GetHeaderText(), Is.EqualTo("Збірка ПК"), "Header of PC Building page is wrong");

            var salePage = pcPage.header.ClickSale();
            Assert.That(salePage.GetHeaderText(), Is.EqualTo("Акції"), "Header of Sale page is wrong");

            var warrantyPage = salePage.header.ClickWarranty();
            Assert.That(warrantyPage.GetHeaderText(), Is.EqualTo("Гарантія та сервіс"), "Header of Warranty page is wrong");
        }
    }
}
