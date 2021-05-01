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
    public class Home : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public Home(BaseBrowser browser) : base(browser) { }

        #endregion CONSTRUCTOR


        #region WEBELEMENTS

        /// <summary>
        /// Description of the method or class or property
        /// </summary> 
        [FindsBy(How = How.XPath, Using = "//span[text()='My personal information']")]
        public IWebElement MyPersonalInfoLnk { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary> 
        [FindsBy(How = How.XPath, Using = "//a[@title='Log me out']")]
        public IWebElement SingnOutLnk { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary> 
        [FindsBy(How = How.XPath, Using = "//a[@title='Blouses']//parent::li//preceding-sibling::li//a[@title='T-shirts']")]
        public IWebElement TShirtLnk { get; set; }


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
            isPageLoaded = SingnOutLnk.WaitUntillDisplayedAndEnabled(GlobalVariables.Browser.Driver);
            return isPageLoaded;
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
                case "TSHIRTS":
                    TShirtLnk.WClick();
                    break;
                case "MYPERSONALINFORMATION":
                    MyPersonalInfoLnk.WClick();
                    break;
            }
        }

        #endregion
    }
}
