

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities
{
    #region METHODS

    /// <summary>
    /// Description of the method or class or property
    /// </summary>
    /// <param name="">Parameter description</param>
    /// <returns>Return details</returns>
    public class StringManipulation
    {
        public static string RemoveSpaceInBetweenTrimUpperCase(string text)
        {
            text = text.Replace(" ", string.Empty);
            return text.Trim().ToUpper();
        }
    }

    #endregion METHODS
}
