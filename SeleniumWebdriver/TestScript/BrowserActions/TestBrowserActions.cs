using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWebdriver.ComponentHelpers;
using SeleniumWebdriver.Settings;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;

namespace SeleniumWebdriver.TestScript.BrowserActions
{
    [TestClass]
    public class TestBrowserActions
    {
        [TestMethod]
        public void TestActions()
        {
            NavigationHelper.NavigateToUrl("https://google.com");
            BrowserHelper.BrowserMaximize();
            TextBoxHelper.TypeInTextBox(By.XPath("//input[@title='Search']"), "My Name");
            BrowserHelper.GoBack();
            BrowserHelper.Forward();
            BrowserHelper.RefreshPage();
        }
    }
}
