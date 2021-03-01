using log4net;
using System.Runtime.CompilerServices;


namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Logs
{
    public class LogHelper
    {
        #region METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
        }
        #endregion METHODS 
    }
}
