using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities
{
    public static class MouseMoves
    {
        #region METHODS 

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static void MouseOver(this IWebElement element, IWebDriver driver)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static void MouseOverAndClick(this IWebElement elementToHover, IWebElement elementToClick, IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(elementToHover).MoveToElement(elementToClick).Click().Perform();

        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static void JScriptMouseOver(this IWebElement element)
        {
            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                                "evObj.initMouseEvent(\"mouseover\",true, false, window," +
                                " 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                                "arguments[0].dispatchEvent(evObj);";

            IJavaScriptExecutor executor = GlobalVariables.Browser.Driver as IJavaScriptExecutor;
            executor.ExecuteScript(javaScript, element);
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static void JSScrollTillElementVisible(this IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)GlobalVariables.Browser.Driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        #endregion METHODS
    }
}
