using OpenQA.Selenium.Firefox;


namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers
{
    public class FirefoxBrowser : BaseBrowser
    {
        #region METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public override void LaunchBrowser()
        {
            //TODO:  Implementation due
            Driver = new FirefoxDriver();
        }

        #endregion METHODS
    }
}
