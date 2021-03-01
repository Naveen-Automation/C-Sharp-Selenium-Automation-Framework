using OpenQA.Selenium.IE;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers
{
    public class IEBrowser : BaseBrowser
    {
        #region METHODS 

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public override void LaunchBrowser()
        {
            Driver = new InternetExplorerDriver();
        }

        #endregion  METHODS
    }
}
