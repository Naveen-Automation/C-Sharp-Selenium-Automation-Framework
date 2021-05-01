using AventStack.ExtentReports;
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

        #endregion ABSTRACT METHODS


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
                case "MYSTORE": //TODO: Make it constant
                    Driver.Navigate().GoToUrl(GlobalVariables.MyStoreURL);
                    break;
                case "ANYOTHERSTORE":    //TODO: Make it constant
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


        public bool IsAlertPresent()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(Driver);
#pragma warning restore CS0618 // Type or member is obsolete
            return (null != alert);

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
            Driver = null;
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public string GetBrowserTitle()
        {
            return Driver.Title;
        }


        ///<summary>
        /// Method to take screen shot of the browser 
        ///</summary>
        ///<param name="fileName">File Path of the screen shot</param>
        public static MediaEntityModelProvider TakeScreenShot(string fileName)
        {
            GlobalVariables.ScreenShotCounter = GlobalVariables.ScreenShotCounter + 1;
            //Screenshot screenShotInFolder = ((ITakesScreenshot)GlobalVariables.Browser.Driver).GetScreenshot();
            //screenShotInFolder.SaveAsFile($"{GlobalVariables.ScreenShotsPath}\\{fileName}{GlobalVariables.ScreenShotCounter}.png", ScreenshotImageFormat.Png);

            string screenShot = ((ITakesScreenshot)GlobalVariables.Browser.Driver).GetScreenshot().AsBase64EncodedString;
                return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, fileName).Build();
            //return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, $"{GlobalVariables.ScreenShotsPath}\\{fileName}{GlobalVariables.ScreenShotCounter}.png").Build();
            
        }

        //public void TakeScreenShot(string fileName)
        //{
        //    GlobalVariables.ScreenShotCounter = GlobalVariables.ScreenShotCounter + 1;
        //    Screenshot screenShot = ((ITakesScreenshot)Driver).GetScreenshot();
        //    screenShot.SaveAsFile($"{GlobalVariables.ScreenShotsPath}\\{fileName}{GlobalVariables.ScreenShotCounter}.png", ScreenshotImageFormat.Png);
        //}


        ///<summary>
        /// Method to wait till page is loaded
        ///</summary>
        ///<param name="waitForPageLoad">Boolean value which decides wheather to wait for page load or not</param>
        public void WaitForPageToLoad(bool waitForPageLoad = true)
        {
            if (waitForPageLoad)
            {
                var javaScriptExecutor = Driver as IJavaScriptExecutor;
                //try
                //{
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(GlobalVariables.TimeOut));
                wait.Until(driver => (bool)javaScriptExecutor.ExecuteScript($"return (document.readyState == 'complete')"));

                if ((bool)javaScriptExecutor.ExecuteScript($"return window.jQuery != undefined"))
                {

                    WebDriverWait jwait = new WebDriverWait(Driver, TimeSpan.FromSeconds(GlobalVariables.TimeOut));
                    jwait.Until(driver => (bool)javaScriptExecutor.ExecuteScript($"return (jQuery.active == 0)"));
                }
                //}
                //catch (InvalidOperationException ex)
                //{
                //    //Log error
                //}
                //catch (NoSuchWindowException ex)
                //{
                //    //Log error
                //}

                //catch (WebDriverException ex)
                //{
                //    //Log error
                //}
                //catch (NullReferenceException ex)
                //{
                //    //Log error
                //}
            }
        }


        public virtual void ClearBrowserData() { }

        #endregion 
    }
}
