using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class OrderHistory : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public OrderHistory(BaseBrowser browser) : base(browser) { }

        #endregion CONSTRUCTOR


        #region WEBELEMENTS

        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//h1[@class='page-heading bottom-indent' and contains(text(),'Order history')]")]
        public IWebElement OrderHistoryLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//tr[@class='first_item ']/td[@class='history_link bold footable-first-column']/a[@class='color-myaccount']")]
        public IWebElement OrderReferenceLnk { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//tr[@class='first_item ']/td[@class='history_date bold']")]
        public IWebElement OrderDateLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//tr[@class='first_item ']/td[@class='history_price']")]
        public IWebElement OrderTotalPriceLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//tr[@class='first_item ']/td[@class='history_method']")]
        public IWebElement OrderPaymentTypeLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-default button button-small']/span[contains(text(),'Home')]")]
        public IWebElement HomeLnk { get; set; }

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
            isPageLoaded = OrderHistoryLbl.WaitUntillDisplayedAndEnabled(Browser.Driver);
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
            //Assertion to validate Order reference generated on Order Confirmation page is present on Order History page
            string orderReference = OrderReferenceLnk.Text.Trim();
            Assert.AreEqual(orderReference, OrderConfirmation.OrderReference);

            //AssertionException to validate that Order data is same as The system date
            //string orderDate = OrderDateLbl.Text.Trim();
            //Assert.AreEqual(orderDate, DateTime.Now.ToString("MM/dd/yyyy"));

            //AssertionException to validate that Order data is same as The system date
            double orderTotalPrice = Convert.ToDouble(OrderTotalPriceLbl.Text.Substring(1).Trim());
            Assert.AreEqual(orderTotalPrice, Summary.ItemTotalPrice);

            //AssertionException to validate that Order data is same as The system date
            string orderPaymentType = OrderPaymentTypeLbl.Text.ToUpper().Trim();
            Assert.AreEqual(orderPaymentType, Payment.OrderPaymentType);
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
                case "HOME":
                    HomeLnk.WClick();
                    break;
            }

        }

        #endregion METHODS

    }
}
