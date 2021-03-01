using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class OrderSummary : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public OrderSummary(BaseBrowser browser) : base(browser) { }

        #endregion CONSTRUCTOR


        #region WEBELEMENTS

        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//h1[@class='page-heading' and contains(text(),'Order summary')]")]
        public IWebElement OrderSummaryLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//button[@class='button btn btn-default button-medium']")]
        public IWebElement IConfirmMyOrderBtn { get; set; }

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
            isPageLoaded = OrderSummaryLbl.WaitUntillDisplayedAndEnabled(Browser.Driver);
            return isPageLoaded;
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>    
        public override void FillPageForm(Table table)
        {
            throw new NotImplementedException();
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
                case "ICONFIRMMYORDER":
                    IConfirmMyOrderBtn.WClick();
                    break;
            }

        }

        #endregion METHODS
    }
}
