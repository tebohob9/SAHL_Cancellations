//using AventStack.ExtentReports;
//using Cancellations_Tests.Utilities;
//using OpenQA.Selenium;
//using TechTalk.SpecFlow;

//namespace Cancellations_Tests.Hooks
//{
//	[Binding]
//	public sealed class Hooks
//	{
//		private readonly ScenarioContext _scenarioContext;

//		public Hooks(ScenarioContext scenarioContext)
//		{
//			_scenarioContext = scenarioContext;
//		}

//		[BeforeTestRun]
//		public static void BeforeTestRun()
//		{
//			ExtentReport.ExtentReportInit();
//		}

//		[AfterTestRun]
//		public static void AfterTestRun()
//		{
//			ExtentReport.ExtentReportTearDown();
//		}

//		[BeforeFeature]
//		public static void BeforeFeature(FeatureContext featureContext)
//		{
//			ExtentReport._feature = ExtentReport._extentReports.CreateTest(featureContext.FeatureInfo.Title);
//		}

//		[BeforeScenario]
//		public void BeforeScenario()
//		{
//			ExtentReport._scenario = ExtentReport._feature.CreateNode(_scenarioContext.ScenarioInfo.Title);
//		}

//		[AfterScenario]
//		public void AfterScenario()
//		{
//			var driver = _scenarioContext.ContainsKey("driver") ? _scenarioContext["driver"] as IWebDriver : null;

//			if (_scenarioContext.TestError != null)
//			{
//				string screenshotPath = ScreenshotHelper.CaptureScreenshot(driver, _scenarioContext);
//				if (!string.IsNullOrEmpty(screenshotPath))
//				{
//					ExtentReport._scenario.Fail(_scenarioContext.TestError.Message)
//						.AddScreenCaptureFromPath(screenshotPath);
//				}
//				else
//				{
//					ExtentReport._scenario.Fail(_scenarioContext.TestError.Message);
//				}
//			}
//			else
//			{
//				ExtentReport._scenario.Pass("Scenario passed");
//			}
//		}
//	}
//}
