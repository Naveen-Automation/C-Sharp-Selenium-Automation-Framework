using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;
using Com.Test.VeerankiNaveen;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses
{
    public static class Synchronization
    {
        #region METHODS 

        ///// <summary>
        ///// Description of the method or class or property
        ///// </summary>
        ///// <param name="">Parameter description</param>
        ///// <returns>Return details</returns>
        //public static bool WaitUntillElementIsDisplayedAndEnabled(this IWebElement element, IWebDriver driver, bool shouldBeEnabled = true)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalVariables.TimeOut));
        //    bool retValue = wait.Until(d =>
        //    {
        //        //The below return statement is for ananymous method 
        //        return shouldBeEnabled ? element.IsDisplayed() && element.IsEnabled() : element.IsDisplayed();
        //    });
        //    //Below return statment is for the overall method
        //    return retValue;
        //}


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static bool WaitUntillDisplayedAndEnabled(this IWebElement element, IWebDriver driver, bool shouldBeEnabled = true)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalVariables.TimeOut));
            return wait.Until(d => element.IsElementDisplayedAndEnabled(shouldBeEnabled));
            //return wait.Until<bool>(Func<IWebDriver,bool>() =>);
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static bool IsElementDisplayedAndEnabled(this IWebElement element, bool shouldBeEnabled)
        {
            return shouldBeEnabled ? element.IsDisplayed() && element.IsEnabled() : element.IsDisplayed();
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
