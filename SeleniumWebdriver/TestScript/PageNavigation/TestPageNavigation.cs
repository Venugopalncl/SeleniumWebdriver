using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebdriver.Configuration;
using SeleniumWebdriver.Interfaces;
using SeleniumWebdriver.Settings;
using SeleniumWebdriver.ComponentHelpers;

namespace SeleniumWebdriver.TestScript.PageNavigation
{
    [TestClass]
    public class TestPageNavigation
    {
        [TestMethod]
        public void OpenPage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Console.WriteLine("Title of page: {0}", WindowHelper.GetTitle());
        }
    }
}
