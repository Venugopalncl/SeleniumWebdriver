using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelpers;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.CheckBox
{
    [TestClass]
    public class TestCheckBox
    {
        [TestMethod]
        public void TestBox()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.config.GetPassword());
            TextBoxHelper.ClearTextBox(By.Id("Bugzilla_login"));
            CheckBoxHelper.IsCheckedBoxChecked(By.Id("Bugzilla_restrictlogin"));
            CheckBoxHelper.CheckedCheckBox(By.Id("Bugzilla_restrictlogin"));
        }

    }
}
