using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelpers;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.RadioButton
{
    [TestClass]
    public class HanldeRadioButton
    {
        [TestMethod]
        public void TestRadio()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("log_in"));
            LinkHelper.ClickLink(By.XPath("//div[@id='header']/ul[1]/li[9]/a"));
            LinkHelper.ClickLink(By.XPath("//dt[@id='parameters']/a"));
            RadioButtonHelper.ClickRadioButton(By.Id("ssl_redirect-on"));
        }
    }
}
