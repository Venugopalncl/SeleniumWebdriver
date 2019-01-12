using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using SeleniumWebdriver.ComponentHelpers;

namespace SeleniumWebdriver.TestScript.Popups
{
    [TestClass]
    [DeploymentItem(@"Resources")]
    public class TestPopups
    {
        [TestMethod]
        public void TestAlert()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/js_popup.asp");
            ButtonHelper.ClickButton(By.XPath("//div[@id='main']/descendant::a[position()=3]"));
            BrowserHelper.SwitchToWindow(1);
            IWebElement textarea = ObjectRepository.Driver.FindElement(By.Id("textareaCode"));
            JavaScriptExecutor.ExecuteScript("document.getElementById('textareaCode').setAttribute('style','display: inline;')");
            TextBoxHelper.ClearTextBox(By.CssSelector("#textareawrapper"));
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            var text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.ClickOkOnPopup();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));
            //GenericHelper.Wait(ExpectedConditions.ElementIsVisible(By.Id("id")), TimeSpan.FromSeconds(60));

        }


        [TestMethod]
        public void TestConfimPopup()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/tryit.asp?filename=tryjs_confirm");
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            var text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.ClickOkOnPopup();
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            JavaScriptPopHelper.ClickCancelOnPopup();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));

        }

        [TestMethod]
        public void TestPrompt()
        {
            NavigationHelper.NavigateToUrl("http://www.w3schools.com/js/tryit.asp?filename=tryjs_prompt");
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            var text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.SendKeys(text);
            JavaScriptPopHelper.ClickOkOnPopup();
            BrowserHelper.RefreshPage();
            BrowserHelper.SwitchToFrame(By.Id("iframeResult"));
            ButtonHelper.ClickButton(By.XPath("//button[text()='Try it']"));
            text = JavaScriptPopHelper.GetPopUpText();
            JavaScriptPopHelper.SendKeys(text + "abc");
            JavaScriptPopHelper.ClickCancelOnPopup();
            ObjectRepository.Driver.SwitchTo().DefaultContent();
            GenericHelper.WaitForWebElement(By.Id("textareaCode"), TimeSpan.FromSeconds(60));
        }

    }
}