using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.Settings;
using SeleniumWebdriver.ComponentHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebdriver.TestScript.WebElement
{
    [TestClass]
    public class TestWebElement
    {
        [TestMethod]
         public void GetElement()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.config.GetWebsite());
            try
            {
                IReadOnlyCollection<IWebElement> col
                    = ObjectRepository.Driver.FindElements(By.TagName("input"));
                Console.WriteLine("Size {0}:", col.Count());
                Console.WriteLine("First INput Element {0}: ", col.ElementAt(0));
            }
            catch (NoSuchElementException e)
            {
                Console.Write(e.Message.ToString());
            }
            
        }
    }
}
