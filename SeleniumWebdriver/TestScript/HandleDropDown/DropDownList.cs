﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.ComponentHelpers;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.HandleDropDown
{
    [TestClass]
    public class DropDownList
    {
        [TestMethod]
        public void TestList()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("log_in"));
            ComboBoxHelper.SelectElement(By.Id("bug_severity"), 2);
            ComboBoxHelper.SelectElement(By.Id("bug_severity"), "blocker");
            foreach ( string str in ComboBoxHelper.GetAllItem(By.Id("bug_severity")))
            {
                Console.WriteLine("Text: {0}", str);
            }

        }
    }
}
