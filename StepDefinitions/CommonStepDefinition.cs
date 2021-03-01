using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Selenium_BDD_Framework
{
    [Binding]
    public class CommonStepDefinition
    {
        #region STEPS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        [When(@"I launch the browser and navigate to ""(.*)"" application")]
        public void WhenILaunchBrowserAndNavigateToApplication(string applicationName)
        {
            GlobalVariables.Browser = BrowserFactory.Launch(GlobalVariables.BrowserType);
            GlobalVariables.Browser.LaunchApplication(applicationName);
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>

        [When(@"I enter sign in details in ""(.*)"" page and click on ""(.*)"" button")]
        public void WhenIEnterSignInDetailsAndClickOnButton(string pageName, string elementName)
        {
            Login login = new Login(GlobalVariables.Browser);
            login.EnterSignInDetials();
            login.MoveToNextPage(elementName);
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>

        [Then(@"I should see a success message on ""(.*)"" screen")]
        public void ThenIShouldSeeMessage(string pageName)
        {
            MyPersonalInformation yourPersonalInfo = new MyPersonalInformation(GlobalVariables.Browser);
            yourPersonalInfo.ValidateSucessMessage();
            GlobalVariables.Browser.TakeScreenShot(pageName);
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        [When(@"I key the below details in ""(.*)"" screen and I click on ""(.*)"" button")]
        [When(@"I key the below details in ""(.*)"" screen and I click on ""(.*)"" Link")]
        public void WhenIKeyTheBelowDetailsInScreenAndIClickOnButton(string pageName, string elementName, Table table)
        {
            BasePage pageObject = POMHelpers.CreatePageObjectAtRunTime(pageName, GlobalVariables.Browser);
            pageObject.FillPageForm(table);
            GlobalVariables.Browser.TakeScreenShot(pageName);
            pageObject.MoveToNextPage(elementName);
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        [When(@"I fill all the mandatory details on ""(.*)"" page and click on ""(.*)"" button")]
        public void WhenIKeyTheBelowDetailsInScreenAndIClickOnButton(string pageName, string elementName)
        {
            BasePage pageObject = POMHelpers.CreatePageObjectAtRunTime(pageName, GlobalVariables.Browser);
            pageObject.FillPageForm();
            GlobalVariables.Browser.TakeScreenShot(pageName);
            pageObject.MoveToNextPage(elementName);
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        [When(@"I click on ""(.*)"" link on ""(.*)"" page")]
        [When(@"I click on ""(.*)"" button on ""(.*)"" page")]
        public void WhenIClickOnButtonOnPage(string elementName, string pageName)
        {
            BasePage pageObject = POMHelpers.CreatePageObjectAtRunTime(pageName, GlobalVariables.Browser);
            pageObject.MoveToNextPage(elementName);
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        /// see the same order reference of the item on
        [Then(@"I should see the same order reference on ""(.*)"" page that is shown on order confirmation page")]
        [Then(@"I should get the order reference of the item on ""(.*)"" page")]
        [Then(@"The total item price should be equal to the sum of item price, shipping price and tax on ""(.*)"" page")]
        [Then(@"The shipping price on ""(.*)"" page should be equal to the shipping price shown on summary page")]
        [Then(@"I should get the same total price on ""(.*)"" page as schown on summary page")]
        public void ThenIShouldGetTheCorrectTotalPriceOfTheItemOnPage(string pageName)
        {
            BasePage pageObject = POMHelpers.CreatePageObjectAtRunTime(pageName, GlobalVariables.Browser);
            pageObject.FillPageForm();
        }




        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>

        [Then(@"I should see ""(.*)"" page")]
        public void ThenIShouldSeeRequestedPage(string pageName)
        {
            BasePage pageObject = POMHelpers.CreatePageObjectAtRunTime(pageName, GlobalVariables.Browser);
            Assert.IsTrue(pageObject.CheckPageLoaded());
            GlobalVariables.Browser.TakeScreenShot(pageName);
        }

        #endregion STEPS
    }
}
