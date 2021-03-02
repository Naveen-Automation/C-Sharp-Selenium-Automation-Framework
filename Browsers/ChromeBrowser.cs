using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers
{
    public sealed class ChromeBrowser : BaseBrowser
    {
        #region METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public override void LaunchBrowser()
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            //Option to disable 'Chrome is being controlled by automated test software' info bar
            chromeOptions.AddExcludedArgument("enable-automation");

            //Option to disable 'Saved Passwords' dialog
            chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);

            // Run chrome browser in headless mode, based on the flag passed from Config.json file
            if (GlobalVariables.HeadlessBrowserFlag)
            {
                chromeOptions.AddArguments("headless");
            }

            //Launch chrome driver instance
            Driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions, TimeSpan.FromSeconds(GlobalVariables.TimeOut));
            //GlobalVariables.Driver = Driver;

            // Run chrome browser in headless mode, based on the flag passed from Config.json file
            if (GlobalVariables.MaximizeBrowser)
            {
                Driver.Manage().Window.Maximize();
            }
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public override void ClearBrowserData()
        {
            string chromeDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Google", "Chrome", "UserData", "Default");
            ShellCommandExecutor shell = new ShellCommandExecutor();
            shell.ExecuteCommandWaitForExpectedResponse($"del /q /s /f \"{Path.Combine(chromeDataDir, "Cache", "*.*")}\">nul 2>&1");
            shell.ExecuteCommandWaitForExpectedResponse($"del /q /f \"{Path.Combine(chromeDataDir, "*Cookies*.*")}\">nul 2>&1");
            shell.ExecuteCommandWaitForExpectedResponse($"del /q /f \"{Path.Combine(chromeDataDir, "*History*.*")}\">nul 2>&1");
        }

        #endregion METHODS
    }
}
