using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using System.Threading;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities
{
    class Debug
    {
        public static void WaitTillDebugPopUpIsPresent()
        {
            int i = 0;
            do
            {
                Thread.Sleep(1000);
                if (i > 120)
                {
                    GlobalVariables.Browser.Driver.SwitchTo().Alert().Accept();
                }
                i += 1;
            } while (GlobalVariables.Browser.IsAlertPresent());
        }
    }
}
