using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;
using OpenQA.Selenium;
using System;
using System.IO;

namespace SAHL_Cancellations.BasePage
{
    public class BasePageLogging
    {
        protected readonly IWebDriver driver;
        protected readonly string pageName;
        protected ExtentTest test;

        public BasePageLogging(IWebDriver driver, string pageName)
        {
            this.driver = driver;
            this.pageName = pageName;

            // Try to get the current test from ExtentReport if available
            try
            {
                if (ExtentReport._scenario != null)
                {
                    test = ExtentReport._scenario;
                    LogInfo($"Initialized {pageName}");
                }
            }
            catch (Exception)
            {
                // If ExtentReport._scenario is not available, test will remain null
                // This is fine as we'll check for null before using it
            }
        }

        #region Logging Methods
        /// <summary>
        /// Logs an informational message to the ExtentReport
        /// </summary>
        protected void LogInfo(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Info, $"[{pageName}] {message}");
            }
        }

        /// <summary>
        /// Logs an action to the ExtentReport
        /// </summary>
        protected void LogAction(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Info, $"[{pageName}] {message}");
            }
        }

        /// <summary>
        /// Logs a success message to the ExtentReport
        /// </summary>
        protected void LogSuccess(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Pass, $"[{pageName}] {message}");
            }
        }

        /// <summary>
        /// Logs an error message to the ExtentReport
        /// </summary>
        protected void LogError(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Fail, $"[{pageName}] {message}");
            }
        }

        /// <summary>
        /// Logs a warning message to the ExtentReport
        /// </summary>
        protected void LogWarning(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Warning, $"[{pageName}] {message}");
            }
        }

        /// <summary>
        /// Captures a screenshot and adds it to the ExtentReport
        /// </summary>
        protected void CaptureScreenshot(string screenshotName)
        {
            try
            {
                if (driver != null)
                {
                    ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
                    Screenshot screenshot = takesScreenshot.GetScreenshot();
                    string screenshotPath = Path.Combine(ExtentReport.testResultPath, screenshotName + ".png");
                    screenshot.SaveAsFile(screenshotPath);
                    if (ExtentReport._scenario != null)
                    {
                        ExtentReport._scenario.AddScreenCaptureFromPath(screenshotPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
                if (ExtentReport._scenario != null)
                {
                    ExtentReport._scenario.Log(Status.Warning, $"Failed to capture screenshot: {ex.Message}");
                }
            }
        }
        #endregion
    }
}