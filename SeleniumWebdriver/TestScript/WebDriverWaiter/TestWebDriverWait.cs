using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumWebdriver.ComponentHelpers;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.WebDriverWaiter
{
    [TestClass]
    public class TestWebDriverWait
    {
        [TestMethod]
        public void TestWait()
        {
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
        }
        [TestMethod]
        public void TestDynamciWait()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(WaitForFileABug()).Click();
            wait.Until(WaitForUserNameTextBox()).SendKeys("Ashu");
        }
        /// <summary>
        /// ExpectedCondition is deprecated 
        /// </summary>
        [TestMethod, Ignore]
        public void TestExpCondition()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(WaitForFileABug()).Click();
            wait.Until(WaitForUserNameTextBox()).SendKeys("Ashu");
            wait.Until(ExpectedConditions.ElementExists(By.Id("Bugzilla_password")));
        }
        //acc -spe fun<in,out> { () => {}}

        private Func<IWebDriver, bool> waitforSearchbox()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Search Box");
                return x.FindElements(By.XPath("//input[@type='search']")).Count == 1;
            });
        }

        private Func<IWebDriver, IWebElement> WaitForFileABug()
        {
            return ((x) =>
            {
                if (x.FindElements(By.LinkText("File a Bug")).Count == 1)
                    return x.FindElement(By.LinkText("File a Bug"));
                return null;
            });
        }

        private Func<IWebDriver, IWebElement> WaitForUserNameTextBox()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for login user Text box");
                Console.WriteLine("Waiting for element");
                if (x.FindElements(By.Id("Bugzilla_login")).Count == 1)
                    return x.FindElement(By.Id("Bugzilla_login"));
                return null;
            });
        }

        private Func<IWebDriver, IWebElement> waitforLastElemet()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Last Element");
                if (
                    x.FindElements(
                        By.XPath("//span[contains(text(),'These 5 Habits Will Help You Improve Your Health')]")).Count ==
                    1)
                    return
                        x.FindElement(
                            By.XPath("//span[contains(text(),'These 5 Habits Will Help You Improve Your Health')]"));
                return null;
            });
        }

        private Func<IWebDriver, string> waitforpageTitle()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for Title");
                if (
                    x.FindElements(By.CssSelector(".course-title")).Count == 1)
                    return x.FindElement(By.CssSelector(".course-title")).Text;
                return null;
            });
        }
    }
}
