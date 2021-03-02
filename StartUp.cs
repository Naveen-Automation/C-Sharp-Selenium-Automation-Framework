using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Logs;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using log4net;
using System;
using TechTalk.SpecFlow;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]


namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework
{
    [Binding]
    public class StartUp
    {
        #region CLASS FIELDS

        /// <summary>
        /// Description of the method or class or prope
        /// </summary>
        public static IServiceProvider Services { get; set; }


        /// <summary>
        /// Description of the method or class or prope
        /// </summary>
        private static readonly ILog _log = LogHelper.GetLogger();

        #endregion CLASS FIELDS


        #region METHODS

        /// <summary>
        /// Description of the method or class or prope
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        /// </summary>
        [BeforeTestRun(Order = 1)]
        public static void Initialise()
        {
            new ChromeBrowser().ClearBrowserData();
            FileSystem.CreateDirectory(GlobalConstants.TestResultsFolderPrefix);
            FileSystem.CreateDirectory(GlobalConstants.TestResultsScreenShotsFolderPrefix);
        }


        /// <summary>
        /// Description of the method or class or prope
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        /// </summary>
        [AfterScenario]
        public static void Terminate()
        {
            GlobalVariables.Browser.CloseBrowser();
        }

        #endregion METHODS
    }

}


