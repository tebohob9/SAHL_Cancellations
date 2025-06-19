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

        [OneTimeSetUp]
        public void Init()
        {
            // Initialize the WebDriver
            driver = InitializeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            // Initialize ExtentReports if not already initialized
            if (extent == null)
            {
                ExtentReport.ExtentReportInit();
                extent = ExtentReport._extentReports;
            }

            // Initialize LoginManager and perform login
            loginManager = new LoginManager(driver);
            try
            {
                loginManager.Login();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login failed: {ex.Message}");
                if (test != null)
                {
                    test.Log(Status.Error, $"Login failed: {ex.Message}");
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

        // For backward compatibility
        public void StartTest(string testName)
        {
            test = extent.CreateTest(testName);
        }

        // For backward compatibility
        public void LogTestStatus(Status status, string message)
        {
            test.Log(status, message);
            if (status == Status.Fail)
            {
                CaptureScreenshot(TestContext.CurrentContext.Test.Name + "_Failure");
            }
        }

        [SetUp]
        public void BeforeTest()
        {
            if (test == null)
            {
                StartTest(TestContext.CurrentContext.Test.Name);
            }
        }

        [TearDown]
        public void AfterTest()
        {
            // Capture screenshot after each test execution
            CaptureScreenshot(TestContext.CurrentContext.Test.Name);
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message ?? string.Empty;
            Status logStatus;
            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    logStatus = Status.Fail;
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    logStatus = Status.Pass;
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    logStatus = Status.Skip;
                    break;
                default:
                    logStatus = Status.Warning;
                    break;
            }
            LogTestStatus(logStatus, message);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver?.Dispose();
            // Flush the report
            ExtentReport.ExtentReportTearDown();

            // Close and quit the driver
            //if (driver != null)
            //{
            //    driver.Quit();
            //    driver.Dispose();
            //}
        }

        // Capture screenshot after the test execution
        public void CaptureScreenshot(string screenshotName)
        {
            try
            {
                if (driver != null)
                {
                    ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
                    Screenshot screenshot = takesScreenshot.GetScreenshot();
                    string screenshotPath = Path.Combine(ExtentReport.testResultPath, screenshotName + ".png");
                    screenshot.SaveAsFile(screenshotPath);

                    // Attach screenshot to the test
                    test.AddScreenCaptureFromPath(screenshotPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
            }
        }
    }
}




