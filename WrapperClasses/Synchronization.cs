using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses
{
    public static class Synchronization
    {
        #region METHODS 

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static bool WaitUntillDisplayedAndEnabled(this IWebElement element, IWebDriver driver, bool shouldBeEnabled = true)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalVariables.TimeOut));
            return wait.Until<bool>(d =>
            {
                try
                {
                    return shouldBeEnabled ? element.Displayed && element.Enabled : element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    //TODO: Logging Error pending
                    return false;
                }
                catch (TargetInvocationException)
                {
                    //TODO: Logging Error pending
                    try
                    {
                        return shouldBeEnabled ? element.Displayed && element.Enabled : element.Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        //TODO: Logging Error pending
                        return false;
                    }
                    finally
                    {
                        //TODO: Logging the exit of the method
                    }
                }
            });
        }
        #endregion METHODS
    }
}
