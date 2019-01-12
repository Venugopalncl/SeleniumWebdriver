using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumWebdriver.ComponentHelpers;
using SeleniumWebdriver.Settings;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace SeleniumWebdriver.TestScript.FindElements
{
    [TestClass]
    public class HandleElements
    {
        [TestMethod]
        public void GetAllElements()
        {
            //Identify all inputs and get the ids of those
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ReadOnlyCollection <IWebElement>  elements= ObjectRepository.Driver.FindElements(By.XPath("//input"));
            ReadOnlyCollection<IWebElement> elements2 = ObjectRepository.Driver.FindElements(By.Id("id"));

            foreach (var ele in elements)
            {
                Console.WriteLine("ID : {0}", ele.GetAttribute("id"));
            }
        }
    }
}
