using AventStack.ExtentReports;
using Cancellations_Tests.BasePage;
using Cancellations_Tests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SAHL_Cancellations.Utilities;
using System;
using System.Reactive.Subjects;
using System.Threading;

namespace SAHL_Cancellations.Pages
{
	public class SMSPage
	{
		public readonly IWebDriver driver;  // WebDriver to interact with the browser
		private readonly WebDriverWait wait;
		private ExtentTest test; // ExtentTest instance for reporting
		private readonly string pageName = "Correspondents Page"; // Page name for reporting

		// Constructor to initialize the WebDriver
		public SMSPage(IWebDriver driver)
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

		// UI Elements - All elements on the Correspondents Page
		public IWebElement SMSTab => driver.FindElement(By.XPath("(//a[@id='div_menu_sms'])[1]"));
		public IWebElement TelCell => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_txtRecipients'])[1]"));
		public IWebElement MessageTxtBox => driver.FindElement(By.XPath("(//textarea[@id='ctl00_ctl00_C_C_txtMessage'])[1]"));
		public IWebElement SendBtn => driver.FindElement(By.XPath("//a[@id='btnsend']"));
		
		// Complete Contact Details form
		public void SendSMS(string ToCell, string Message)
		{
			try
			{
				LogInfo("Clicking on Correspondents tab");
				SMSTab.Click();
				LogSuccess("Clicked on Correspondents tab");

				LogInfo($"Entering Contact Person: {ToCell}");
				TelCell.EnterText(ToCell);
				//ToEmailField.SendKeys(Keys.Enter); // Add this line to press Enter after entering text
				LogSuccess($"Entered Contact Person: {ToCell}");


				LogInfo($"Entering Contact Person: {Message}");
				MessageTxtBox.EnterText(Message);
				LogSuccess($"Entered Contact Person: {Message}");


				Thread.Sleep(5000);

				LogInfo("Clicking Save Button");
				SendBtn.Click();
				LogSuccess("Clicked Save Button");


				Thread.Sleep(5000);

				LogSuccess("Contact details completed successfully");
				CaptureScreenshot($"{pageName}_ContactDetails_Completed");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to complete contact details", ex);
				CaptureScreenshot($"{pageName}_ContactDetails_Failure");
				throw;
			}
		}

		// Complete Address Details form


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




