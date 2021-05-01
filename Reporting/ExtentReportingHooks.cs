using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Browsers;
using Com.Test.VeerankiNaveen.Selenium_BDD_Framework.EnvVariables;
using System.IO;
using TechTalk.SpecFlow;


namespace Com.Test.VeerankiNaveen.Selenium_BDD_Framework.Reporting
{
    [Binding]
    public class ExtentReportingHooks : GlobalVariables
    {
        #region CLASS FIEDLS

        private static FeatureContext _featureContext;
        private static ScenarioContext _scenarioContext;
        private static ExtentHtmlReporter _extentHTMLReporter;
        private static ExtentReports _reporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private static ScenarioBlock _scenarioBlock;

        #endregion CLASS FIELDS


        #region BEFORE TEST RUN

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        [BeforeTestRun(Order = 2)]
        public static void StartReportingEnginee()
        {
            _extentHTMLReporter = new ExtentHtmlReporter($"{GlobalVariables.HTMLReportsPath}{TestReportRelativePath}");
            _extentHTMLReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _reporter = new ExtentReports();
            _reporter.AttachReporter(_extentHTMLReporter);

            #region Additional Details
            _reporter.AddSystemInfo("Chrome Version", string.Empty);
            //Can Add Execution environment related details here
            #endregion  Additional Details
        }

        #endregion BEFORE TEST RUN


        #region AFTER TEST RUN

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        [AfterTestRun]
        public static void GenerateHTMLReport()
        {
            //Saving & Generating HTML Report
            _reporter.Flush();
        }

        #endregion AFTER TEST RUN


        #region BEFORE FEATURE

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (featureContext != null)
            {
                _featureContext = featureContext;
                _feature = _reporter.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }

        #endregion  BEFORE FEATURE


        #region BEFORE SCENARIO

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        [BeforeScenario(Order = 1)]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext != null)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
        }


        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        [BeforeScenario(Order = 2)]
        public static void CreateFolderForScenario(ScenarioContext scenarioContext)
        {
            GlobalVariables.ScreenShotsPath = GlobalVariables.ScreenShotsFolderPath + "\\" + scenarioContext.ScenarioInfo.Title;
            Directory.CreateDirectory(GlobalVariables.ScreenShotsPath);
            //Resetting Screen shot counter to 0 again for new scenario
            GlobalVariables.ScreenShotCounter = 0;
        }


        #endregion BEFORE SCENARIO


        #region AFTER STEP

        /// <summary>
        /// Description of the method or class or property
        /// </summary>
        /// <param name="">Parameter description</param>
        /// <returns>Return details</returns>
        [AfterStep]
        public static void AfterEachStep()
        {
            _scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            var mediaEntity = BaseBrowser.TakeScreenShot(_scenarioContext.ScenarioInfo.Title.Trim());
            switch (_scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace,mediaEntity);
                    }
                    else
                    {
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass("", mediaEntity);
                    }
                    break;
                case ScenarioBlock.When:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace, mediaEntity);
                    }
                    else
                    {
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Pass("", mediaEntity);
                    }
                    break;
                case ScenarioBlock.Then:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace, mediaEntity);
                    }
                    else
                    {
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Pass("", mediaEntity);
                    }
                    break;
                default:
                    if (_scenarioContext.TestError != null)
                    {
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace, mediaEntity);
                    }
                    else
                    {
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Pass("", mediaEntity);
                    }
                    break;
            }
        }
        #endregion AFTER STEP
    }
}



