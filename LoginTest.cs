
using NUnit.Framework;
using PageObjects;
using System.Threading;

namespace Tests
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void LoginWithWrongEmailAndPassword()
        {
            InitPage initPage = new InitPage(driver);
            initPage.header.ClickLogin();

            LoginPage loginPage = initPage.header.ClickLogin();

            loginPage.SetEmaile("vladyslav.drohomeretskyi-ip224@nung.edu.ua");
            loginPage.SetPassword("1234");
            loginPage.ClickLogin();


            Thread.Sleep(5000);
        }
    }
}