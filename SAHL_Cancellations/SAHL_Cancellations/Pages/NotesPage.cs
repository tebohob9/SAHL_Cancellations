using NUnit.Framework;
using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using SAHL_Cancellations.Utilities;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualBasic;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;

namespace SAHL_Cancellations.Pages
{
	public class NotesPage
	{
		public readonly IWebDriver driver;  // WebDriver to interact with the browser
		private readonly WebDriverWait wait;
		private ExtentTest test; // ExtentTest instance for reporting
		private readonly string pageName = "Diary Page"; // Page name for reporting

		// Constructor to initialize the WebDriver
		public NotesPage(IWebDriver driver)
		{
			this.driver = driver;  // Assigning the driver to the class variable
			this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));  // Default wait time of 10 seconds

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

		// UI Elements - All elements on the Diary Page
		public IWebElement NotesTab => driver.FindElement(By.XPath("(//a[@id='div_menu_notes'])[1]"));
		public IWebElement EnterCommentTxtBox=> driver.FindElement(By.XPath("//textarea[@id='txtAuditTrailComment']"));
		public IWebElement AddNoteBtn => driver.FindElement(By.XPath("//button[@data-bind='click: $root.SaveAuditTrailComment']"));
		public IWebElement AddComment_Btn => driver.FindElement(By.XPath("//button[@data-bind='click: $root.SaveAuditTrailComment']"));
		public IWebElement DescriptionTxtBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_DetailsView1_txtMilestone'])[1]"));
		
		// Methods to interact with elements on the Diary Page
		

		// Add Custom Diary Item Method
		public void AddComment(string Notes)
		{
			try
			{
				LogInfo("Starting to add custom diary item");

				// Click on the Diary Tab
				LogInfo("Clicking on Diary tab");
				Thread.Sleep(2000);
				NotesTab.Click();
				LogSuccess("Clicked on Diary tab");

				//// Optionally, click to include completed diaries
				//LogInfo("Checking if Include Completed Diaries checkbox is selected");
				//if (!IncludeCompletdDiaries_Checkbox.Selected)
				//{
				//    LogInfo("Clicking Include Completed Diaries checkbox");
				//    IncludeCompletdDiaries_Checkbox.Click();
				//    LogSuccess("Clicked Include Completed Diaries checkbox");
				//}
				//else
				//{
				//    LogInfo("Include Completed Diaries checkbox is already selected");
				//}

				// Wait for the page elements to load using WebDriverWait instead of Thread.Sleep
				//LogInfo("Waiting for Description textbox to be visible");
				//wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_txtMilestone']")));
				//LogSuccess("Description textbox is visible");

				// Enter the notes for the diary item
				LogInfo($"Entering notes: {Notes}");
				EnterCommentTxtBox.EnterText(Notes);
				LogSuccess($"Entered notes: {Notes}");

				// Click the "Save" button to save the new diary item
				LogInfo("Clicking Save button");
				AddComment_Btn.Click();
				LogSuccess("Clicked Save button");
				Thread.Sleep(2000);

				LogSuccess("Successfully added custom diary item");
				CaptureScreenshot($"{pageName}_AddCustomDiaryItem_Completed");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to add custom diary item", ex);
				CaptureScreenshot($"{pageName}_AddCustomDiaryItem_Failure");
				throw;
			}
		}

		

		// Helper methods for logging
		private void LogInfo(string message)
		{
			string logMessage = $"[{pageName}] {message}";
			Console.WriteLine(logMessage);
			if (test != null)
			{
				test.Log(Status.Info, logMessage);
			}
		}

		private void LogSuccess(string message)
		{
			string logMessage = $"[{pageName}] {message}";
			Console.WriteLine(logMessage);
			if (test != null)
			{
				test.Log(Status.Pass, logMessage);
			}
		}

		private void LogFailure(string message, Exception ex)
		{
			string errorMessage = $"[{pageName}] {message}: {ex.Message}";
			Console.WriteLine(errorMessage);
			if (test != null)
			{
				test.Log(Status.Fail, errorMessage);
			}
		}

		private void CaptureScreenshot(string screenshotName)
		{
			try
			{
				if (driver != null)
				{
					ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
					Screenshot screenshot = takesScreenshot.GetScreenshot();
					string screenshotPath = System.IO.Path.Combine(ExtentReport.testResultPath, screenshotName + ".png");
					screenshot.SaveAsFile(screenshotPath);
					if (test != null)
					{
						test.AddScreenCaptureFromPath(screenshotPath);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
			}
		}
	}
}




