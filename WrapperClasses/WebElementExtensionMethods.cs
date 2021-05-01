using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Enum;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using OpenQA.Selenium;
using System;
using System.Reflection;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses
{
    public static class WebElementExtensionMethods
    {
        #region METHODS

        #region BUTTON ELEMENT
        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static void WClick(this IWebElement element)
        {
            string elementName = element.GetAttribute("value");
            if (element != null)
            {
                try
                {
                    if (element.Enabled)
                    {
                        element.Click();
                        //Log that click has been performed
                    }
                    GlobalVariables.Browser.WaitForPageToLoad(GlobalVariables.BrowserSyncFlag);
                }
                catch (Exception ex)
                {
                    if (ex is ElementClickInterceptedException || ex is TargetInvocationException)
                    {
                        element.JSWClick(elementName);
                    }
                    else
                    {
                        //Log Error
                        string exString = ex.ToString();
                        if (!exString.Contains("Errro executing JavaScript") && !exString.Contains("Error from JavaScript") && !(ex is NullReferenceException))
                        {
                            if (GlobalVariables.DebugMode)
                            {
                                Msgbox.Display("Error: Element was not clicked");
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }

            }

        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static void JSWClick(this IWebElement element, string elementName)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.Browser.Driver;
                executor.ExecuteScript("arguments[0].click();", element);
                //Log that element is clicked
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is WebDriverException)
                {
                    //Log the exception message
                }
                else
                {
                    throw;
                }
            }
            GlobalVariables.Browser.WaitForPageToLoad(GlobalVariables.BrowserSyncFlag);
        }

        #endregion BUTTON ELEMENT


        #region TEXTBOX ELELEMNT

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static void WSendKeys(this IWebElement element, string value, bool clearFlag = false)
        {
            string elementName = element.GetAttribute("value");
            if (element == null)
            {

            }
            if (!string.IsNullOrEmpty(value))
            {
                if (clearFlag)
                {
                    element.Clear();
                }
                element.SendKeys(value);
                try
                {
                    //Log that value is set in a textbox
                }
                catch (Exception ex)
                {
                    if (ex is StaleElementReferenceException)
                    {
                        //TODO: Write method wait untill element is displayed based on configurable timeout
                        //Log that value is set in a textbox
                    }
                    else if (ex is TargetInvocationException)
                    {
                        //Log Error Message
                    }
                }
            }

        }

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static void JSWSendKeys(this IWebElement element, BaseBrowser browser, string elementName, string value)
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)browser.Driver;
                executor.ExecuteScript("argument[0].value=arguments[1];", element, value);
                //Log that element is clicked
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is WebDriverException)
                {
                    //Log the exception message
                }
                else
                {
                    throw;
                }
            }
            browser.WaitForPageToLoad(GlobalVariables.BrowserSyncFlag);
        }



        #endregion TEXTBOX ELEMENT


        #region CHECKBOX

        public static void CheckBox(this IWebElement element, Switch value)
        {
            if ((value == Switch.ON && !element.Selected) || (value == Switch.OFF && element.Selected))
            {
                element.Click();
            }
        }


        #endregion CHECKBOX


        #region GENERIC METHODS
        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static void Highlighter(this IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)GlobalVariables.Browser.Driver;
            string highlighJavaScript = @"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: red"";";
            jsDriver.ExecuteScript(highlighJavaScript, new object[] { element });
        }

        #endregion GENERIC METHODS

        #endregion METHODS
    }


}
