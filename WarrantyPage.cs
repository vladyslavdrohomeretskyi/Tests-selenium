using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects
{
    public class WarrantyPage : BasePage

    {
        public WarrantyPage(IWebDriver driver) : base(driver)
        {
            header = new HeaderSection(driver);
        }

        public HeaderSection header;
    }
}