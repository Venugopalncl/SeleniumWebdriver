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
            
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            TextBoxHelper.ClearTextBox(By.Id("Bugzilla_login"));
            CheckBoxHelper.IsCheckedBoxChecked(By.Id("Bugzilla_restrictlogin"));
            CheckBoxHelper.CheckedCheckBox(By.Id("Bugzilla_restrictlogin"));
        }

    }
}
