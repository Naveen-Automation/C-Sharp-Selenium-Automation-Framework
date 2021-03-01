using OpenQA.Selenium;


namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers
{
    class BrowserFactory
    {
        #region GETTERS & SETTERS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static IWebDriver Driver { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static BaseBrowser Browser { get; set; }

        #endregion GETTERS & SETTERS


        #region METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static BaseBrowser Launch(string browserType)
        {
            switch (browserType.ToUpper())
            {
                case "CHROME":
                    Browser = new ChromeBrowser();
                    break;
                case "FIREFOX":
                    Browser = new FirefoxBrowser();
                    break;
                case "IE":
                    Browser = new IEBrowser();
                    break;
            }
            Browser.LaunchBrowser();
            return Browser;
        }

        #endregion METHODS
    }
}
