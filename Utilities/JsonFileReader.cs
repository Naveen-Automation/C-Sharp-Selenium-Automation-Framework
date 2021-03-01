using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using System.IO;


namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities
{
    class JsonFileReader
    {
        #region METHODS
        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public static string ReadJsonFile(string keyName)
        {
            dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText($"{GlobalVariables.ProjectFolderPath}{GlobalVariables.AppSettingsJsonRelativePath}"));
            JToken appURL = jsonFile.SelectToken($"{GlobalConstants.JsonRootAttribute}.{keyName}");
            return (string)appURL;
        }

        #endregion METHODS
    }
}
