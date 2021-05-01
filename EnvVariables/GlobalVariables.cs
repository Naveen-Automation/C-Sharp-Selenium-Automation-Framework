using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using OpenQA.Selenium;
using System;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables
{
    public class GlobalVariables
    {

        #region PROPERTIES WITH DEFAULT VALUES

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static BaseBrowser Browser { get; set; } = null;


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static IWebDriver Driver { get; set; } = null;


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string AppSettingsJsonRelativePath { get; set; } = @"Configurations\AppSettings.json";


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string UserProfileFolderPath { get; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string ProjectFolderPath { get; } = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin"));


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static int ScreenShotCounter { get; set; } = 0;


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string HTMLReportsPath { get; set; } = string.Empty;

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string ScreenShotsFolderPath { get; set; } = string.Empty;


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string ScreenShotsPath { get; set; } = string.Empty;

        #endregion


        #region PROPERTIES MAPPED WITH APPSETTINGS JSON 

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string MyStoreURL { get; set; } = JsonFileReader.ReadJsonFile("MyStoreURL");


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string AnyOtherStore { get; set; } = JsonFileReader.ReadJsonFile("AnyOtherStore");


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string BrowserType { get; } = JsonFileReader.ReadJsonFile("BrowserType");

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static bool BrowserSyncFlag { get; set; } = Convert.ToBoolean(JsonFileReader.ReadJsonFile("BrowserSyncFlag"));


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string UserName { get; set; } = JsonFileReader.ReadJsonFile("UserName");


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string UserEmail { get; set; } = JsonFileReader.ReadJsonFile("UserEmail");


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string Password { get; set; } = JsonFileReader.ReadJsonFile("Password");


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static bool ScreenShotsFlag { get; set; } = Convert.ToBoolean(JsonFileReader.ReadJsonFile("ScreenShotsFlag"));


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string TestResultsRelativePath { get; set; } = JsonFileReader.ReadJsonFile("TestResultsRelativePath");


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string TestReportRelativePath { get; set; } = JsonFileReader.ReadJsonFile("TestReportRelativePath");


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static bool HeadlessBrowserFlag { get; } = Convert.ToBoolean(JsonFileReader.ReadJsonFile("HeadlessBrowserFlag"));


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static bool MaximizeBrowser { get; } = Convert.ToBoolean(JsonFileReader.ReadJsonFile("MaximizeBrowser"));


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static int TimeOut { get; set; } = Convert.ToInt32(JsonFileReader.ReadJsonFile("TimeOut"));



        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static bool DebugMode { get; set; } = Convert.ToBoolean(JsonFileReader.ReadJsonFile("DebugMode"));
        

        #endregion PROPERTIES MAPPED WITH APPSETTINGS JSON 
    }
}
