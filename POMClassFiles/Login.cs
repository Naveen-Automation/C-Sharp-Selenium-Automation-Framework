using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class Login : ParentPOMClasses
    {

        #region CONSTRUCTOR

        public Login(BaseBrowser browser) : base(browser) { }

        #endregion CONSTRUCTOR


        #region WEBELEMENTS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement SignInBtn { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailTxt { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement PasswordTxt { get; set; }

        #endregion WEBELEMENTS


        #region METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public override bool CheckPageLoaded()
        {
            bool isPageLoaded;
            isPageLoaded = SignInBtn.WaitUntillDisplayedAndEnabled(GlobalVariables.Browser.Driver);
            return isPageLoaded;
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public void EnterSignInDetials()
        {
            EmailTxt.WSendKeys(GlobalVariables.UserEmail);
            PasswordTxt.WSendKeys(GlobalVariables.Password);
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public override void MoveToNextPage(string elementName)
        {
            elementName = StringManipulation.RemoveSpaceInBetweenTrimUpperCase(elementName);
            switch (elementName)
            {
                case "SIGNIN":
                    SignInBtn.WClick();
                    break;
            }
        }

        #endregion METHODS
    }
}
