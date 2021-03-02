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
            bool retValue = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalVariables.TimeOut)).Until<bool>(d =>
            {
                return shouldBeEnabled ? element.IsDisplayed() && element.IsEnabled() : element.IsDisplayed();
            });
            return retValue;
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static bool IsDisplayed(this IWebElement element)
        {
            bool isDisplayed;
            try
            {
                isDisplayed = element.Displayed;
            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is StaleElementReferenceException || ex is WebDriverException || ex is NoSuchWindowException || ex is TargetInvocationException)
                {
                    // Log error Logger.Error()ex, "Caught exception...\n Returning element displayed as ''false");
                    return false;
                }
                throw;
            }
            return isDisplayed;
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static bool IsEnabled(this IWebElement element)
        {
            bool isEnabled = false;
            try
            {
                if (element.IsDisplayed())
                {
                    isEnabled = element.Displayed;
                }

            }
            catch (Exception ex)
            {
                if (ex is NoSuchElementException || ex is StaleElementReferenceException || ex is WebDriverException || ex is NoSuchWindowException || ex is TargetInvocationException)
                {
                    // Log error Logger.Error()ex, "Caught exception...\n Returning element enabled as ''false");
                    return false;
                }
                throw;
            }
            return isEnabled;
        }


        #endregion METHODS
    }
}
