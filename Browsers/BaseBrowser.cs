using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers
{
    public abstract class BaseBrowser
    {
        #region GETTERS AND SETTERS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public IWebDriver Driver { get; protected set; }

        #endregion


        #region ABSTRACT METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>

        public abstract void LaunchBrowser();
        #endregion


        #region METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public void LaunchApplication(string applicationName)
        {
            applicationName = applicationName.Replace(" ", string.Empty);
            applicationName = applicationName.Trim().ToUpper();
            switch (applicationName)
            {
                case "MYSTORE":
                    Driver.Navigate().GoToUrl(GlobalVariables.MyStoreURL);
                    break;
                case "ANYOTHERSTORE":
                    Driver.Navigate().GoToUrl(GlobalVariables.AnyOtherStore);
                    break;
            }
            //Implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVariables.timeOut); 
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public void ImplicitWait()
        {
            //Implicit wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(GlobalVariables.timeOut); 
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>

        public string GetBrowserTitle()
        {
            return Driver.Title;
            //Assert.AreEqual("Google", actualTitle);}
        }


        ///<summary>
        /// Method to take screen shot of the browser 
        ///</summary>
        ///<param name="fileName">File Path of the screen shot</param>
        public void TakeScreenShot(string fileName)
        {
            GlobalVariables.ScreenShotCounter = GlobalVariables.ScreenShotCounter + 1;
            Screenshot screenShot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenShot.SaveAsFile($"{GlobalVariables.ScreenShotsPath}\\{fileName}{GlobalVariables.ScreenShotCounter}.png", ScreenshotImageFormat.Png);

        }


        ///<summary>
        /// Method to wait till page is loaded
        ///</summary>
        ///<param name="waitForPageLoad">Boolean value which decides wheather to wait for page load or not</param>
        public void WaitForPageToLoad(bool waitForPageLoad = true)
        {
            if (waitForPageLoad)
            {
                var javaScriptExecutor = Driver as IJavaScriptExecutor;
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(GlobalVariables.TimeOut));
                bool readyCondition(IWebDriver driver) => (bool)javaScriptExecutor.ExecuteScript("return (document.readyState == 'complete')");
                wait.Until(readyCondition);
                //TODO:  Exception Handeling needs to be done
            }
        }

        #endregion 
    }
}
