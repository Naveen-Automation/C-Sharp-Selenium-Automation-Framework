using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Enum;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class Shipping : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public Shipping(BaseBrowser browser) : base(browser) { }

        #endregion CONSTRUCTOR


        #region WEBELEMENTS

        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//h1[@class='page-heading' and contains(text(),'Shipping')]")]
        public IWebElement ShippingLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//td[@class='delivery_option_price']")]
        public IWebElement ShippingCostLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.Id, Using = "cgv")]
        public IWebElement TermsNConditionsChk { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//button[@name='processCarrier']")]
        public IWebElement ProceedToCheckOutBtn { get; set; }

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
            isPageLoaded = ShippingLbl.WaitUntillDisplayedAndEnabled(Browser.Driver);
            return isPageLoaded;
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>    
        public override void FillPageForm()
        {
            TermsNConditionsChk.CheckBox(Switch.ON);

            //Assertion to validate that shipping price shown on Summary page is same on Shipping page
            double shippingPrice = Convert.ToDouble(ShippingCostLbl.Text.Substring(1).Trim());
            Assert.AreEqual(shippingPrice, Summary.ShippingPrice);
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
                case "PROCEEDTOCHECKOUT":
                    ProceedToCheckOutBtn.WClick();
                    break;
            }
        }

        #endregion METHODS

    }
}
