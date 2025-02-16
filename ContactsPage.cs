using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class ContactsPage : BasePage

    {
        public ContactsPage(IWebDriver driver) : base(driver)
        {
            header = new HeaderSection(driver);
        }

        public HeaderSection header;
    }
}
