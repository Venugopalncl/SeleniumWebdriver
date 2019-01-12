using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWebdriver.ComponentHelpers;
using SeleniumWebdriver.Settings;
using OpenQA.Selenium;

namespace SeleniumWebdriver.TestScript.HyperLink
{
    [TestClass]
    public class TestHyperlink
    {
        [TestMethod]
        public void ClickLInk()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            //IWebElement element = ObjectRepository.Driver.FindElement(By.PartialLinkText("File"));
            LinkHelper.ClickLink(By.LinkText("File a Bug"));

        }
    }
}
