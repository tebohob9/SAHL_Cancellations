using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using NUnit.Framework;

namespace SAHL_Cancellations.Utilities
{
	public class Reporting : FileOperations
	{
		public ExtentReports Report { get; private set; }
		public ExtentTest Test { get; private set; }
		ExtentSparkReporter SparkReporter { get; set; }
		string TestName { get; set; }
		public IWebDriver Webdriver { get; set; }

		public Reporting()
		{
			if (CreatedReportDirectory == null)
			{
				Assert.IsTrue(CreateTestResultsDirectory(null), "Failed to create an Extent Report folder.");
			}
			InitializeReport();
		}

		public Reporting(IWebDriver driver)
		{
			if (CreatedReportDirectory == null)
			{
				Assert.IsTrue(CreateTestResultsDirectory(null, true), "Failed to create an Extent Report folder.");
			}
			InitializeReport();
			Webdriver = driver;
		}

		private void InitializeReport()
		{
			Report = new ExtentReports();
			SparkReporter = new ExtentSparkReporter(FullExtentReportPath());

			// Configure the reporter
			SparkReporter.Config.DocumentTitle = "Investec Cancellations Automation Report";
			SparkReporter.Config.ReportName = "Test Execution Report";
			SparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;

			Report.AttachReporter(SparkReporter);

			// Add system info
			Report.AddSystemInfo("Environment", "Test Environment");
			Report.AddSystemInfo("Browser", "Chrome");
			Report.AddSystemInfo("OS", Environment.OSVersion.ToString());

			Flush();
		}

		public void Flush() => Report.Flush();

		public ExtentTest CreateReport(string testName)
		{
			Test = Report.CreateTest(testName);
			return Test;
		}

		// Method to log a step with screenshot
		public void LogStepWithScreenshot(Status status, string stepDescription)
		{
			if (Test != null && Webdriver != null)
			{
				TakeScreenshot(Webdriver, Test, status, stepDescription);
			}
			else
			{
				Console.WriteLine("Cannot log step with screenshot: Test or Webdriver is null");
			}
		}

		// Method to log a step without screenshot
		public void LogStep(Status status, string stepDescription)
		{
			if (Test != null)
			{
				Test.Log(status, stepDescription);
			}
			else
			{
				Console.WriteLine("Cannot log step: Test is null");
			}
		}
	}
}
