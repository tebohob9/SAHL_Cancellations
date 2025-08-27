//using AventStack.ExtentReports;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using System;
//using System.Diagnostics;
//using TechTalk.SpecFlow;
//using Cancellations_Tests.BasePage;

//namespace Cancellations_Tests.Utilities
//{
//	[Binding]
//	public class Hooks : BaseClass
//	{
//		[BeforeTestRun]
//		public static void BeforeTestRun()
//		{
//			ExtentReport.ExtentReportInit();
//		}

//		[AfterTestRun]
//		public static void AfterTestRun()
//		{
//			ExtentReport.ExtentReportTearDown();

//			// ✅ Automatically open the report in the default browser
//			string reportPath = System.IO.Path.Combine(ExtentReport.testResultPath, "ExtentReport.html");
//			if (System.IO.File.Exists(reportPath))
//			{
//				try
//				{
//					Process.Start(new ProcessStartInfo(reportPath) { UseShellExecute = true });
//				}
//				catch (Exception ex)
//				{
//					Console.WriteLine($"Unable to open report automatically: {ex.Message}");
//				}
//			}
//		}

//		[BeforeFeature]
//		public static void BeforeFeature(FeatureContext featureContext)
//		{
//			ExtentReport._feature = ExtentReport._extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
//		}

//		[BeforeScenario]
//		public void BeforeScenario(ScenarioContext scenarioContext)
//		{
//			ExtentReport._scenario = ExtentReport._feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
//		}

//		[AfterScenario]
//		public void AfterScenario(ScenarioContext scenarioContext)
//		{
//			var status = scenarioContext.ScenarioExecutionStatus;

//			if (status == ScenarioExecutionStatus.TestError)
//			{
//				string screenshotPath = new ExtentReport().AddScreenshot(driver, scenarioContext);
//				ExtentReport._scenario.Fail("Scenario Failed")
//					.AddScreenCaptureFromPath(screenshotPath);
//			}
//			else
//			{
//				ExtentReport._scenario.Pass("Scenario Passed");
//			}
//		}
//	}
//}
