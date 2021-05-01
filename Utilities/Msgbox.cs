using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities
{
    class Msgbox
    {
        public static void Display(string alertMessageToDisplay)
        {
            string javaScript = $"alert('{alertMessageToDisplay}')";
            IJavaScriptExecutor executor = GlobalVariables.Browser.Driver as IJavaScriptExecutor;
            executor.ExecuteScript(javaScript);
        }
    }
}
