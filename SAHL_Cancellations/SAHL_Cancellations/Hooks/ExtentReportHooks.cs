using Cancellations_Tests.BasePage;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using Cancellations_Tests.Utilities;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System;

namespace Cancellations_Tests.Hooks
{
    [Binding]
    public class ExtentReportHooks
    {
        private readonly IObjectContainer _container;
        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;
        private IWebDriver _driver;

        public ExtentReportHooks(IObjectContainer container, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReport.ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReport.ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            ExtentReport._feature = ExtentReport._extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                _driver = _container.Resolve<IWebDriver>();
            }
            catch (Exception)
            {
                // Driver might not be initialized yet
            }

            ExtentReport._scenario = ExtentReport._feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            string stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepText = _scenarioContext.StepContext.StepInfo.Text;

            if (_scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        ExtentReport._scenario.CreateNode<Given>(stepText);
                        break;
                    case "When":
                        ExtentReport._scenario.CreateNode<When>(stepText);
                        break;
                    case "Then":
                        ExtentReport._scenario.CreateNode<Then>(stepText);
                        break;
                    case "And":
                        ExtentReport._scenario.CreateNode<And>(stepText);
                        break;
                }
            }
            else
            {
                try
                {
                    if (_driver != null)
                    {
                        var extentReport = new ExtentReport();
                        string screenshotPath = extentReport.AddScreenshot(_driver, _scenarioContext);

                        // Use MediaEntityBuilder for attaching screenshots
                        var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();

                        switch (stepType)
                        {
                            case "Given":
                                ExtentReport._scenario.CreateNode<Given>(stepText).Fail(_scenarioContext.TestError.Message, mediaEntity);
                                break;
                            case "When":
                                ExtentReport._scenario.CreateNode<When>(stepText).Fail(_scenarioContext.TestError.Message, mediaEntity);
                                break;
                            case "Then":
                                ExtentReport._scenario.CreateNode<Then>(stepText).Fail(_scenarioContext.TestError.Message, mediaEntity);
                                break;
                            case "And":
                                ExtentReport._scenario.CreateNode<And>(stepText).Fail(_scenarioContext.TestError.Message, mediaEntity);
                                break;
                        }
                    }
                    else
                    {
                        switch (stepType)
                        {
                            case "Given":
                                ExtentReport._scenario.CreateNode<Given>(stepText).Fail(_scenarioContext.TestError.Message);
                                break;
                            case "When":
                                ExtentReport._scenario.CreateNode<When>(stepText).Fail(_scenarioContext.TestError.Message);
                                break;
                            case "Then":
                                ExtentReport._scenario.CreateNode<Then>(stepText).Fail(_scenarioContext.TestError.Message);
                                break;
                            case "And":
                                ExtentReport._scenario.CreateNode<And>(stepText).Fail(_scenarioContext.TestError.Message);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to capture screenshot: {ex.Message}");

                    switch (stepType)
                    {
                        case "Given":
                            ExtentReport._scenario.CreateNode<Given>(stepText).Fail(_scenarioContext.TestError.Message);
                            break;
                        case "When":
                            ExtentReport._scenario.CreateNode<When>(stepText).Fail(_scenarioContext.TestError.Message);
                            break;
                        case "Then":
                            ExtentReport._scenario.CreateNode<Then>(stepText).Fail(_scenarioContext.TestError.Message);
                            break;
                        case "And":
                            ExtentReport._scenario.CreateNode<And>(stepText).Fail(_scenarioContext.TestError.Message);
                            break;
                    }
                }
            }
        }
    }
}

