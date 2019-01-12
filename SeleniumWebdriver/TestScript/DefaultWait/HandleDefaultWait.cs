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

namespace SeleniumWebdriver.TestScript.DefaultWait
{
    [TestClass]
    public class HandleDefaultWait
    {
        [TestMethod]
        public void TestDefaultWait()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.LinkText("File a Bug"));
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_login"), ObjectRepository.Config.GetUsername());
            TextBoxHelper.TypeInTextBox(By.Id("Bugzilla_password"), ObjectRepository.Config.GetPassword());
            ButtonHelper.ClickButton(By.Id("log_in"));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(1);
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(ObjectRepository.Driver.FindElement(By.Id("bug_severity")));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.Timeout = TimeSpan.FromSeconds(50);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wait.Until(ChangeOfValue());
            Console.WriteLine("After wait: {0}", wait.Until(ChangeOfValue()));
            //Instead of these above lines we can call the generic method for wait

            //GenericHelper.WaitForWebElement(By.Id("bug_severity"), TimeSpan.FromSeconds(50));
            //IWebElement ele = GenericHelper.WaitForWebElementInPage(By.Id("bug_severity"), TimeSpan.FromSeconds(50));
        }
        private Func<IWebElement, string> ChangeOfValue()
        {
            return ((x) =>
            {
                Console.WriteLine("Waiting for value change");
                SelectElement select = new SelectElement(x);
                if (select.SelectedOption.Text.Equals("major"))
                    return select.SelectedOption.Text;
                return null;
            });
        }
    }
}
