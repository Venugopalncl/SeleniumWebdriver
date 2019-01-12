using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumWebdriver.ComponentHelpers;
using SeleniumWebdriver.Configuration;
using SeleniumWebdriver.CustomException;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.BaseClasses
{
    [TestClass]
    public class BaseClass
    {
        //private static FirefoxProfile GetFirefoxptions()
        //{
        //    FirefoxProfile profile = new FirefoxProfile();
        //    FirefoxProfileManager manager = new FirefoxProfileManager();
        //    //profile = manager.GetProfile("default");
        //    return profile;
        //}
        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            //option.AddArgument("headless");//Not working do more effort
            //option.AddExtension(@"if we have postman extension in chrome give the path")
            return option;
        }
        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions option = new InternetExplorerOptions();
            option.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            option.EnsureCleanSession = true;
            return option;
        }
        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }
        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }
        [AssemblyInitialize]
        public static void InitWebDriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;
                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    break;
                default:
                    throw new NoSuitableDriverFound("Driver not found:" + ObjectRepository.Config.GetBrowser().ToString());
            }
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ObjectRepository.Driver.Manage()
            .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeout());
            ObjectRepository.Driver.Manage()
            .Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
        }
            [AssemblyCleanup]
            public static void TearDown()
            {
               if (ObjectRepository.Driver!=null)
               {
                   ObjectRepository.Driver.Close();
                   ObjectRepository.Driver.Quit();
               }
            }
        
    }
}
