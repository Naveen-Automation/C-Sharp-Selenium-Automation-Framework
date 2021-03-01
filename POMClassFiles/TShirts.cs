using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;


namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class TShirts : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public TShirts(BaseBrowser browser) : base(browser) { }

        #endregion


        #region WEBELEMENTS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//span[@class='category-name' and contains(text(),'T-shirts')]")]
        public IWebElement TShirtsLbl { get; set; }

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//li[@class='display-title' and text()='View']")]
        public IWebElement ViewLbl { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//div[@class='right-block']//preceding-sibling::span[@class='availability']/span[@class='available-now']")]
        public IWebElement InStockLnk { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@class='button ajax_add_to_cart_button btn btn-default' and @title='Add to cart']")]
        public IWebElement AddToCartBtn { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        //TODO: This element is repeatable and cold be kept in ParentPOMClasses
        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-default button button-medium' and @title='Proceed to checkout']")]
        public IWebElement ProceedToCheckoutBtn { get; set; }

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
            isPageLoaded = TShirtsLbl.WaitUntillDisplayedAndEnabled(GlobalVariables.Browser.Driver);
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
            IList<IWebElement> InStockLnks = GlobalVariables.Browser.Driver.FindElements(By.XPath("//div[@class='right-block']//preceding-sibling::span[@class='availability']/span[@class='available-now']")); //
            if (InStockLnks.Count >= 1)
            {
                //Click on the first In stock TShirt.
                foreach (IWebElement element in InStockLnks)
                {
                    element.JSScrollTillElementVisible();
                    element.MouseOverAndClick(AddToCartBtn, GlobalVariables.Browser.Driver);
                    break;
                }
            }
            else
            {
                //Log There is no T-Shirt Available
            }
            ProceedToCheckoutBtn.WClick();
        }

        #endregion
    }
}
