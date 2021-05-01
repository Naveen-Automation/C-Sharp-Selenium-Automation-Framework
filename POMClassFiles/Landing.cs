using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class Landing : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public Landing(BaseBrowser browser) : base(browser) { }

        #endregion CONSTRUCTOR


        #region WEBELEMENTS

        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@title='Log in to your customer account']")]
        public IWebElement SignInLnk { get; set; }

        #endregion


        #region METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>    
        public override bool CheckPageLoaded()
        {
            bool isPageLoaded;
            isPageLoaded = SignInLnk.WaitUntillDisplayedAndEnabled(Browser.Driver);
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
                case "SIGNIN":
                    SignInLnk.WClick();
                    //Msgbox.Display("{ if (! window.focus) return true; window.open('', windowname, height = 200, width = 400, scrollbars = yes'); myform.target=windowname; return true;}");
                    break;
            }

        }

        #endregion METHODS
    }
}

//string n = "<SCRIPT TYPE="test/javascript"> function popupform(myform, windowname) { if (! window.focus) return true; window.open('', windowname, height = 200, width = 400, scrollbars = yes'); myform.target=windowname; return true;}</SCRIPT>";