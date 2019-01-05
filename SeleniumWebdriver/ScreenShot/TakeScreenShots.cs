using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumWebdriver.ComponentHelpers;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.ScreenShot
{
    [TestClass]
    public  class TakeScreenShots
    {
        [TestMethod]
        public void ScreenShot()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.config.GetPassword());
            GenericHelper.TakeScreenShot();//Without argument
            GenericHelper.TakeScreenShot("Test.jpeg");//With argument
        }
    }
}
