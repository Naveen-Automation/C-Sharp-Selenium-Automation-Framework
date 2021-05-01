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
    public class Summary : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public Summary(BaseBrowser browser) : base(browser) { }

        #endregion CONSTRUCTOR


        #region WEBELEMENTS

        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//h1[@id='cart_title' and contains(text(),'Shopping-cart summary')]")]
        public IWebElement OrderSummaryLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@class='button btn btn-default standard-checkout button-medium' and @title='Proceed to checkout']")]
        public IWebElement ProceedToCheckoutBtn { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//tr[@class='cart_total_price']/td[@id='total_product']")]
        public IWebElement ItemPriceLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//tr[@class='cart_total_delivery']/td[@id='total_shipping']")]
        public IWebElement ShippingPriceLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//tr[@class='cart_total_tax']/td[@id='total_tax']")]
        public IWebElement TaxLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//tr[@class='cart_total_price']/td[@id='total_price_container']")]
        public IWebElement TotalPriceLbl { get; set; }

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
            isPageLoaded = OrderSummaryLbl.WaitUntillDisplayedAndEnabled(Browser.Driver);
            return isPageLoaded;
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>    
        public override void FillPageForm()
        {
            double itemPrice = Convert.ToDouble(ItemPriceLbl.Text.Substring(1).Trim());
            ShippingPrice = Convert.ToDouble(ShippingPriceLbl.Text.Substring(1).Trim());
            double itemTax = Convert.ToDouble(TaxLbl.Text.Substring(1).Trim());
            ItemTotalPrice = Convert.ToDouble(TotalPriceLbl.Text.Substring(1).Trim());
            Assert.AreEqual(ItemTotalPrice, itemPrice + ShippingPrice + itemTax);
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
                    ProceedToCheckoutBtn.WClick();
                    break;
            }

        }

        #endregion METHODS


        #region GETTERS & SETTERS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static double ItemTotalPrice { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static double ShippingPrice { get; set; }

        #endregion GETTERS & SETTERS
    }
}
