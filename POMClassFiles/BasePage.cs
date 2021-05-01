using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public abstract class BasePage
    {
        #region GETTERS & SETTERS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        protected BaseBrowser Browser { get; private set; }

        #endregion GETTERS & SETTERS


        #region CONSTRUCTOR

        public BasePage(BaseBrowser browser)
        {
            if (browser.Driver != null)
            {
                PageFactory.InitElements(browser.Driver, this);
            }
            Browser = browser;
        }

        #endregion CONSTRUCTOR


        #region ABSTRACT METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public abstract bool CheckPageLoaded();


        #endregion  ABSTRACT METHODS


        #region VIRTUAL METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public virtual void FillPageForm(Table table) { }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        public virtual void MoveToNextPage(string elementName) { }

        #endregion


        #region METHODS
        public virtual void FillPageForm() { }

        public virtual void FillPageForm(string pageSectionaName, Table table) { }



        #endregion

    }
}
