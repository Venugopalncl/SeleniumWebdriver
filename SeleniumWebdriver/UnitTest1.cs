using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebdriver.Configuration;
using SeleniumWebdriver.Interfaces;

namespace SeleniumWebdriver
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //IConfig config = new AppConfigReader();
            //Console.WriteLine("Browser : {0}", config.GetBrowser());
            //Console.WriteLine("Username : {0}", config.GetUsername());
            //Console.WriteLine("Password : {0}", config.GetPassword());
            Console.WriteLine("test");
        }
    }
}
