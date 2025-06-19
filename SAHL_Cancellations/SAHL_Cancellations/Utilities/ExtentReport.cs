using NUnit.Framework;
using Cancellations_Tests.BasePage;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Cancellations_Tests.Utilities
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;
        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void ExtentReportInit()
        {
            // Ensure the directory exists
            Directory.CreateDirectory(testResultPath);

            // For ExtentReports 5.0.4, we use ExtentSparkReporter instead of ExtentHtmlReporter
            var sparkReporter = new ExtentSparkReporter(Path.Combine(testResultPath, "ExtentReport.html"));

            // Configure the reporter
            sparkReporter.Config.DocumentTitle = "Cancellations Automation Report";
            sparkReporter.Config.ReportName = "Cancellations Automation Report";
            sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(sparkReporter);

            _extentReports.AddSystemInfo("Application", "Absa Cancellations");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotName = scenarioContext.ScenarioInfo.Title + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            string screenshotLocation = Path.Combine(testResultPath, screenshotName);

            // Use the correct method for saving screenshots
            screenshot.SaveAsFile(screenshotLocation);

            return screenshotLocation;
        }
    }
}



