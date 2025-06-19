using Cancellations_Tests.BasePage;
using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SAHL_Cancellations.Utilities
{
    public class CustomReport
    {
        private string _reportDirectory;
        private string _screenshotDirectory;

        public CustomReport(string reportDirectory)
        {
            _reportDirectory = reportDirectory;
            _screenshotDirectory = Path.Combine(reportDirectory, "Screenshots");
            Directory.CreateDirectory(_reportDirectory);
            Directory.CreateDirectory(_screenshotDirectory);
        }

        // Method to log test info
        public void LogTestInfo(string testName, string message)
        {
            string logFile = Path.Combine(_reportDirectory, "TestLog.txt");
            File.AppendAllText(logFile, $"[{DateTime.Now}] {testName}: {message}{Environment.NewLine}");
        }

        // Method to log test results and screenshots
        public void LogTestResult(string testName, string result, string screenshotPath = null)
        {
            string logFile = Path.Combine(_reportDirectory, "TestLog.txt");
            File.AppendAllText(logFile, $"[{DateTime.Now}] {testName} - Result: {result}{Environment.NewLine}");

            if (!string.IsNullOrEmpty(screenshotPath))
            {
                File.AppendAllText(logFile, $"Screenshot saved at: {screenshotPath}{Environment.NewLine}");
            }
        }

        // Capture screenshot and return the file path
        public string CaptureScreenshot(IWebDriver driver, string testName)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string screenshotPath = Path.Combine(_screenshotDirectory, $"{testName}_{timestamp}.png");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotPath);
            return screenshotPath;
        }
    }
}




