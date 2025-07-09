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
	public class EmailPage
	{
		public readonly IWebDriver driver;  // WebDriver to interact with the browser
		private readonly WebDriverWait wait;
		private ExtentTest test; // ExtentTest instance for reporting
		private readonly string pageName = "Correspondents Page"; // Page name for reporting

		// Constructor to initialize the WebDriver
		public EmailPage(IWebDriver driver)
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
		public IWebElement EmailTab => driver.FindElement(By.XPath("(//a[@id='div_menu_email'])[1]"));
		public IWebElement TelCell => driver.FindElement(By.XPath("//input[@id='txtCOR_CellNumber']"));
		public IWebElement BrowseBtn => driver.FindElement(By.XPath("//button[@id='buttonBrowse']"));
		public IWebElement AddAttachmentBtn => driver.FindElement(By.XPath("//button[@id='Button1']"));
		public IWebElement ToEmailField => driver.FindElement(By.XPath("//input[@id='address']"));
		public IWebElement LetterCaptionField => driver.FindElement(By.XPath("//input[@id='txtCOR_LetterCaption']"));
		public IWebElement CompanyField => driver.FindElement(By.XPath("//input[@id='txtCOR_Company']"));
		public IWebElement CompanyRegNo => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_EntityMappingForCorrespondence1_txt_COR_CompanyRegNumber']"));
		public IWebElement BranchField => driver.FindElement(By.XPath("//input[@id='txtCOR_Branch']"));
		public IWebElement DocexField => driver.FindElement(By.XPath("//input[@id='txtCOR_DocexNumber']"));
		public IWebElement SaveBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_EntityMappingForCorrespondence1_btnSubmit']"));
		public IWebElement CancelBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_EntityMappingForCorrespondence1_Button2']"));
		public IWebElement AddressDetailsTab => driver.FindElement(By.XPath("//div[contains(text(),'Address Details')]"));
		public IWebElement PhysicalAddressLine1 => driver.FindElement(By.XPath("//input[@id='txtCOR_PhysicalAddressLine1']"));
		public IWebElement PhysicalAddressLine2 => driver.FindElement(By.XPath("//input[@id='txtCOR_PhysicalAddressLine2']"));
		public IWebElement PhysicalAddressLine3 => driver.FindElement(By.XPath("//input[@id='txtCOR_Suburb']"));
		public IWebElement City => driver.FindElement(By.XPath("//input[@id='txtCOR_City']"));
		public IWebElement PhysicalAddressCode => driver.FindElement(By.XPath("//input[@id='txtCOR_PhysicalAddressCode']"));
		public IWebElement Province => driver.FindElement(By.XPath("//select[@id='varProvince']"));
		public IWebElement Country => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_C_EntityMappingForCorrespondence1_ddlCountry']"));
		public IWebElement POBoxLine1 => driver.FindElement(By.XPath("//input[@id='txtCOR_POBoxLine1']"));
		public IWebElement POBoxLine2 => driver.FindElement(By.XPath("//input[@id='txtCOR_POBoxLine2']"));
		public IWebElement POBoxLine3 => driver.FindElement(By.XPath("//input[@id='txtCOR_POBoxLine3']"));
		public IWebElement PostalCode => driver.FindElement(By.XPath("//input[@id='txtCOR_PostalCode']"));
		public IWebElement TypeCheckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_GridView1_ctl02_chkSelected']"));
		public IWebElement Type2CheckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_GridView1_ctl03_chkSelected']"));
		public IWebElement Email2Btn => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_C_btnEmailSelected'])[1]"));
		public IWebElement Sms2Btn => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_C_btnSMSSelected'])[1]"));
		public IWebElement SubjectTextBox => driver.FindElement(By.XPath("(//input[@id='subject'])[1]"));
		public IWebElement LettersTab => driver.FindElement(By.XPath("(//a[contains(text(),'Letters')])[1]"));
		public IWebElement BondCancellationLink => driver.FindElement(By.XPath("//a[normalize-space()='Bond Cancellation']"));
		public IWebElement ParagraphsLink => driver.FindElement(By.XPath("//div[contains(text(),'Paragraphs')]"));
		public IWebElement PrintListLink => driver.FindElement(By.XPath("//div[@class='tab'][normalize-space()='Print List']"));
		public IWebElement ComposeLink => driver.FindElement(By.XPath("//a[@id='aCompose']"));
		public IWebElement DraftsLink => driver.FindElement(By.XPath("//a[@id='aDrafts']"));
		public IWebElement SentItemsLink => driver.FindElement(By.XPath("//a[@id='aSent']"));
		public IWebElement PreviewBtn => driver.FindElement(By.XPath("//input[@id='btnPreview']"));
		public IWebElement SaveDraftBtn => driver.FindElement(By.XPath("//input[@id='btnSaveDraft']"));
		public IWebElement SendBtn => driver.FindElement(By.XPath("//button[@id='btnSend']"));
		public IWebElement AttatchFromHardDriveLink => driver.FindElement(By.XPath("//span[@class='link']"));
		public IWebElement ChooseFileBtn => driver.FindElement(By.XPath("//input[@id='FileUploadControl']"));
		public IWebElement SmsMessageTextBox => driver.FindElement(By.XPath("//textarea[@id='ctl00_ctl00_ctl00_C_C_C_txtMessage']"));
		public IWebElement SendSmsBtn => driver.FindElement(By.XPath("//input[@id='btnsend']"));

		// Complete Contact Details form
		public void SendEmail(string ToEmail, string Subject)
		{
			try
			{
				LogInfo("Clicking on Correspondents tab");
				EmailTab.Click();
				LogSuccess("Clicked on Correspondents tab");

				LogInfo($"Entering Contact Person: {ToEmail}");
				ToEmailField.EnterText(ToEmail);
				//ToEmailField.SendKeys(Keys.Enter); // Add this line to press Enter after entering text
				LogSuccess($"Entered Contact Person: {ToEmail}");


				LogInfo($"Entering Contact Person: {Subject}");
				SubjectTextBox.EnterText(Subject);
				LogSuccess($"Entered Contact Person: {Subject}");

				LogInfo("Clicking Letters Tab");
				LettersTab.Click();
				LogSuccess("Clicked Letters Tab");

				LogInfo("Clicking Bond Cancellation");
				BondCancellationLink.Click();
				LogSuccess("Clicked Bond Cancellation");

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




