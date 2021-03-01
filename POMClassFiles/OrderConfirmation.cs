using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class OrderConfirmation : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public OrderConfirmation(BaseBrowser browser) : base(browser) { }

        #endregion CONSTRUCTOR


        #region WEBELEMENTS

        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//h1[@class='page-heading' and contains(text(),'Order confirmation')]")]
        public IWebElement OrderConfirmationLbl { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@title='Back to orders']")]
        public IWebElement BackToOrdersBtn { get; set; }


        /// /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//div[@class='box']")]
        public IWebElement OrderDetailsWithReferenceLbl { get; set; }

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
            isPageLoaded = OrderConfirmationLbl.WaitUntillDisplayedAndEnabled(Browser.Driver);
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
            string delimitar1 = "order reference";
            string delimitar2 = "in the subject";
            OrderReference = OrderDetailsWithReferenceLbl.Text;
            OrderReference = OrderReference.Substring(OrderReference.IndexOf(delimitar1) + delimitar1.Length);
            OrderReference = OrderReference.Substring(0, OrderReference.IndexOf(delimitar2)).Trim();
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
                case "BACKTOORDERS":
                    BackToOrdersBtn.WClick();
                    break;
            }

        }

        #endregion METHODS


        #region GETTERS & SETTERS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        public static string OrderReference { get; set; }

        #endregion GETTERS & SETTERS

    }
}
