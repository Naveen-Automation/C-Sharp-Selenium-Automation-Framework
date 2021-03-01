using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Utilities;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.WrapperClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.POMClassFiles
{
    public class MyPersonalInformation : ParentPOMClasses
    {
        #region CONSTRUCTOR

        public MyPersonalInformation(BaseBrowser browser) : base(browser) { }

        #endregion CONSTRUCTOR


        #region WEBELEMENTS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>   
        [FindsBy(How = How.Id, Using = "firstname")]
        public IWebElement FirstNameTxt { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>   
        [FindsBy(How = How.Id, Using = "lastname")]
        public IWebElement LastNameTxt { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>   
        [FindsBy(How = How.XPath, Using = "//a[@title='View my customer account']")]
        public IWebElement AccountOwnerNameLnk { get; set; }




        /// <summary>
        /// Description of the method or class or property
        /// </summary> 
        [FindsBy(How = How.Id, Using = "old_passwd")]
        public IWebElement CurrentPasswordTxt { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary> 
        [FindsBy(How = How.XPath, Using = "//button[@name='submitIdentity']")]
        public IWebElement SaveBtn { get; set; }


        /// <summary>
        /// Description of the method or class or property
        /// </summary> 
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Your personal information has been successfully updated.')]")]
        public IWebElement SuccessMessageLbl { get; set; }

        #endregion WEBELEMENGTS


        #region METHODS

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>    
        public override bool CheckPageLoaded()
        {
            bool isPageLoaded;
            isPageLoaded = FirstNameTxt.WaitUntillDisplayedAndEnabled(Browser.Driver);
            return isPageLoaded;
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>    
        public override void FillPageForm(Table table)
        {
            var testData = table.CreateInstance<YourPersonalInformationData>();
            FirstNameTxt.WSendKeys(testData.FirstName, true);
            FirstName = testData.FirstName;
            LastName = LastNameTxt.GetAttribute("value");
            CurrentPasswordTxt.WSendKeys(GlobalVariables.Password);
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>    
        public void ValidateSucessMessage()
        {
            //Assertion to validate the success message displayed by application
            Assert.IsTrue(SuccessMessageLbl.WaitUntillDisplayedAndEnabled(Browser.Driver));

            //Second level validation whether the updated name is displayed on the application top bar
            Assert.AreEqual(AccountOwnerNameLnk.Text.Trim(), FirstName + " " + LastName);
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
                case "SAVE":
                    SaveBtn.WClick();
                    break;
            }
        }

        #endregion METHODS


        #region GETTERS & SETTERS

        /// <summary>
        ///Class to mapp test data passed from Specflow table to below properties
        /// </summary>
        public static string FirstName { get; set; }


        /// <summary>
        ///Class to mapp test data passed from Specflow table to below properties
        /// </summary>
        public static string LastName { get; set; }

        #endregion GETTERS & SETTERS
    }


    public class YourPersonalInformationData
    {
        /// <summary>
        ///Class to mapp test data passed from Specflow table to below properties
        /// </summary>
        public string FirstName { get; set; }
    }
}
