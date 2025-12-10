using Cancellations_Tests.BasePage;
using Cancellations_Tests.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.IO;
using SAHL_Cancellations.Utilities;

namespace Cancellations_Tests.BasePage
{
	public class BaseClass
	{
		protected IWebDriver driver;
		protected LoginManager loginManager;
		protected static ExtentReports extent;
		protected ExtentTest test;
		protected Reporting Reporter;
		protected string currentTestName;

		[OneTimeSetUp]
		public void Init()
		{
			// Initialize the WebDriver
			driver = InitializeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

			// Initialize our new Reporting framework
			Reporter = new Reporting(driver);

			// For backward compatibility, set the static extent reference
			extent = Reporter.Report;
			ExtentReport._extentReports = extent;

			// Initialize LoginManager and perform login
			loginManager = new LoginManager(driver);
			try
			{
				loginManager.Login();

				// Log successful login with screenshot
				if (Reporter.Test != null)
				{
					Reporter.LogStepWithScreenshot(Status.Pass, "Successfully logged in");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Login failed: {ex.Message}");

				// Log failed login with screenshot
				if (Reporter.Test != null)
				{
					Reporter.LogStepWithScreenshot(Status.Error, $"Login failed: {ex.Message}");
				}
			}
		}

		private IWebDriver InitializeDriver()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArgument("--start-maximized");
			// Add additional options to help with stability
			options.AddArgument("--disable-extensions");
			options.AddArgument("--disable-popup-blocking");
			options.AddArgument("--disable-infobars");
			options.AddArgument("--no-sandbox");
			options.AddArgument("--disable-gpu");
			// Set page load strategy
			options.PageLoadStrategy = OpenQA.Selenium.PageLoadStrategy.Normal;
			return new ChromeDriver(options);
		}

		[SetUp]
		public void BeforeTest()
		{
			// Get the current test name and store it for use throughout the test
			currentTestName = TestContext.CurrentContext.Test.Name;

			// Get the test class name
			string testClassName = TestContext.CurrentContext.Test.ClassName.Split('.').Last();

			// Create a new test for each test method with a descriptive name that includes both class and method
			string fullTestName = $"{testClassName}_{currentTestName}";
			test = Reporter.CreateReport(fullTestName);

			// Set the current test for page objects to use (for backward compatibility)
			ExtentReport._scenario = test;

			// Log test start with screenshot
			Reporter.LogStepWithScreenshot(Status.Info, $"Starting test: {fullTestName}");
		}

		[TearDown]
		public void AfterTest()
		{
			// Log test result status
			var status = TestContext.CurrentContext.Result.Outcome.Status;
			var errorMessage = TestContext.CurrentContext.Result.Message;

			if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
			{
				Reporter.LogStepWithScreenshot(Status.Fail, $"Test failed with message: {errorMessage}");
			}
			else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
			{
				Reporter.LogStepWithScreenshot(Status.Pass, "Test passed successfully");
			}
		}

		[OneTimeTearDown]
		public void TearDown()
		{
			try
			{
				// Flush the report
				Reporter.Flush();
				Console.WriteLine($"Report generated at: {Reporter.FullExtentReportPath()}");

				// Close and quit the driver
				if (driver != null)
				{
					driver.Quit();
					driver.Dispose();
					driver = null;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error during teardown: {ex.Message}");
			}
		}

		// Capture screenshot method for backward compatibility
		public void CaptureScreenshot(string screenshotName)
		{
			try
			{
				if (driver != null)
				{
					// Include the current test name in the screenshot name for better organization
					string fullScreenshotName = $"{currentTestName}_{screenshotName}";
					Reporter.TakeScreenshot(driver, test, Status.Info, fullScreenshotName);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
			}
		}
	}
}
