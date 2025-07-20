using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using Cancellations_Tests.Utilities;
using OpenQA.Selenium;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Cancellations_Tests.Hooks
{
	[Binding]
	public class ExtentReportHooks
	{
		// Use readonly to prevent accidental reassignment
		private readonly IObjectContainer container;
		private readonly ScenarioContext scenarioContext;
		private readonly FeatureContext featureContext;
		private IWebDriver driver;

		// Constructor with dependency injection
		public ExtentReportHooks(IObjectContainer container, ScenarioContext scenarioContext, FeatureContext featureContext)
		{
			this.container = container;
			this.scenarioContext = scenarioContext;
			this.featureContext = featureContext;
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
				driver = container.Resolve<IWebDriver>();
			}
			catch (Exception ex)
			{
				// Driver might not be initialized yet
				Console.WriteLine($"Driver not yet initialized: {ex.Message}");
			}
			ExtentReport._scenario = ExtentReport._feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
		}

		[AfterStep]
		public void AfterStep()
		{
			string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
			string stepText = scenarioContext.StepContext.StepInfo.Text;

			if (scenarioContext.TestError == null)
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
					if (driver != null)
					{
						var extentReport = new ExtentReport();
						string screenshotPath = extentReport.AddScreenshot(driver, scenarioContext);

						// Ensure the directory exists
						string directory = Path.GetDirectoryName(screenshotPath);
						if (!Directory.Exists(directory))
						{
							Directory.CreateDirectory(directory);
						}

						// Use MediaEntityBuilder for attaching screenshots
						var mediaEntity = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();

						switch (stepType)
						{
							case "Given":
								ExtentReport._scenario.CreateNode<Given>(stepText).Fail(scenarioContext.TestError.Message, mediaEntity);
								break;
							case "When":
								ExtentReport._scenario.CreateNode<When>(stepText).Fail(scenarioContext.TestError.Message, mediaEntity);
								break;
							case "Then":
								ExtentReport._scenario.CreateNode<Then>(stepText).Fail(scenarioContext.TestError.Message, mediaEntity);
								break;
							case "And":
								ExtentReport._scenario.CreateNode<And>(stepText).Fail(scenarioContext.TestError.Message, mediaEntity);
								break;
						}
					}
					else
					{
						switch (stepType)
						{
							case "Given":
								ExtentReport._scenario.CreateNode<Given>(stepText).Fail(scenarioContext.TestError.Message);
								break;
							case "When":
								ExtentReport._scenario.CreateNode<When>(stepText).Fail(scenarioContext.TestError.Message);
								break;
							case "Then":
								ExtentReport._scenario.CreateNode<Then>(stepText).Fail(scenarioContext.TestError.Message);
								break;
							case "And":
								ExtentReport._scenario.CreateNode<And>(stepText).Fail(scenarioContext.TestError.Message);
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
							ExtentReport._scenario.CreateNode<Given>(stepText).Fail(scenarioContext.TestError.Message);
							break;
						case "When":
							ExtentReport._scenario.CreateNode<When>(stepText).Fail(scenarioContext.TestError.Message);
							break;
						case "Then":
							ExtentReport._scenario.CreateNode<Then>(stepText).Fail(scenarioContext.TestError.Message);
							break;
						case "And":
							ExtentReport._scenario.CreateNode<And>(stepText).Fail(scenarioContext.TestError.Message);
							break;
					}
				}
			}
		}
	}
}
