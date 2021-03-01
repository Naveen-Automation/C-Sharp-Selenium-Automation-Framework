using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using System;
using System.IO;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities
{
    public class FileSystem
    {
        #region METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static void CreateDirectory(string prefix)
        {
            if (prefix.Equals(GlobalConstants.TestResultsFolderPrefix))
            {
                string dirName = string.Format("{0}_On_{1:ddd MM.dd.yyyy_'AT'_HH_mm_ss_tt}", prefix, DateTime.Now);
                string dirPath = GlobalVariables.ProjectFolderPath + GlobalVariables.TestResultsRelativePath + dirName;
                GlobalVariables.HTMLReportsPath = dirPath;
                Directory.CreateDirectory(dirPath);
            }
            else if (prefix.Equals(GlobalConstants.TestResultsScreenShotsFolderPrefix))
            {
                string dirPath = GlobalVariables.HTMLReportsPath + "\\" + prefix;
                GlobalVariables.ScreenShotsFolderPath = dirPath;
                Directory.CreateDirectory(dirPath);
            }
        }

        #endregion
    }
}
