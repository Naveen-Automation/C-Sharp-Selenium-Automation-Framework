using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class Payment : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public Payment(BaseBrowser browser) : base(browser) { }

        #endregion CONSTRUCTOR


        #region WEBELEMENTS

        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//h1[@class='page-heading' and contains(text(),'Please choose your payment method')]")]
        public IWebElement PaymentsTypeSelectionLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@class='bankwire' and  @title='Pay by bank wire']")]
        public IWebElement PayByBankWireLnk { get; set; }

        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@class='cheque' and @title='Pay by check.']")]
        public IWebElement PayByChequeLnk { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//span[@id='total_price']")]
        public IWebElement TotalPriceLbl { get; set; }


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
            isPageLoaded = PaymentsTypeSelectionLbl.WaitUntillDisplayedAndEnabled(Browser.Driver);
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
        public override void FillPageForm()
        {
            //Assertion to validate the Total price shown on summary screen is same as Payments screen
            ItemTotalPrice = Convert.ToDouble(TotalPriceLbl.Text.Substring(1).Trim());
            Assert.AreEqual(ItemTotalPrice, Summary.ItemTotalPrice);
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
                case "PAYBYBANKWIRE":
                    PayByBankWireLnk.WClick();
                    OrderPaymentType = GlobalConstants.BankWirePaymentType;   //TODO:  Add these as constants 
                    break;
                case "PAYBYCHEQUE":
                    PayByChequeLnk.WClick();
                    OrderPaymentType = GlobalConstants.ChequePaymentType;      //TODO:  Add these as constants 
                    break;
            }

        }

        #endregion METHODS


        #region PROPERTIES

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static double ItemTotalPrice { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string OrderPaymentType { get; set; }

        #endregion PROPERTIES

    }
}
