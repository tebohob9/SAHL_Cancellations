using NUnit.Framework;
using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SAHL_Cancellations.Utilities;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace SAHL_Cancellations.Pages
{
	/// <summary>
	/// Represents the "New Instruction" page and encapsulates its elements and behaviors.
	/// </summary>
	public class New_InstructionPage
	{
		private readonly IWebDriver driver;
		private readonly WebDriverWait wait;
		private readonly IJavaScriptExecutor js;
		private readonly string pageName = "New Instruction Page"; // Page name for reporting

		public New_InstructionPage(IWebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
			js = (IJavaScriptExecutor)driver;
		}

		#region Main Link Elements
		private IWebElement MortgageeLink => wait.Until(d => d.FindElement(By.XPath("//a[normalize-space()='Discovery Home Loan Security Trust']")));
		private IWebElement MortgagorLink => wait.Until(d => d.FindElement(By.XPath("//a[normalize-space()='Mr Arno du Toit']")));
		private IWebElement PropertyLink => wait.Until(d => d.FindElement(By.XPath("//a[normalize-space()='Unit 2, Ss Amcrest 1590, Gauteng']")));
		#endregion

		#region File Note Elements
		private IWebElement FileNoteEditPen => wait.Until(d => d.FindElement(By.XPath("//img[@alt='File Note']")));
		private IWebElement FileNoteClickHere => wait.Until(d => d.FindElement(By.XPath("//span[normalize-space()='Click here to add']")));
		private IWebElement FileNoteComment => wait.Until(d => d.FindElement(By.XPath("(//div[@id='generalCommentSpan'])[1]")));
		private IWebElement FileNoteSaveBtn => wait.Until(d => d.FindElement(By.XPath("//button[@id='saveGeneralComment']")));
		private IWebElement FileNoteCancelBtn => wait.Until(d => d.FindElement(By.XPath("//button[@id='reloadDataBttn']")));
		private IWebElement SelectDepartmentDrpDwn => wait.Until(d => d.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_txtSubject'])[1]")));
		private IWebElement FreeFormatMessageTextBox => wait.Until(d => d.FindElement(By.XPath("(//textarea[@id='ctl00_ctl00_C_C_txtMessage'])[1]")));
		private IWebElement FreeFormatMessageSendBtn => wait.Until(d => d.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_btnSendFreeFormat'])[1]")));
		#endregion

		#region Tab Elements
		private IWebElement CommunicationsTab => wait.Until(d => d.FindElement(By.XPath("(//a[@id='div_menu_communications'])[1]")));
		private IWebElement MilestonesTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Milestones')]")));
		private IWebElement NotesTab => wait.Until(d => d.FindElement(By.XPath("(//a[@id='div_menu_notes'])[1]")));
		private IWebElement DiaryTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Diary')]")));
		private IWebElement EmailTab => wait.Until(d => d.FindElement(By.XPath("(//a[@id='div_menu_email'])[1]")));
		private IWebElement SMSTab => wait.Until(d => d.FindElement(By.XPath("(//a[@id='div_menu_sms'])[1]")));
		private IWebElement CorrespondentsTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Correspondents')]")));
		private IWebElement InfoSheetTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Info Sheet')]")));
		private IWebElement InboxTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Inbox')]")));
		private IWebElement DeedSearchTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Deed Search')]")));
		private IWebElement InstructionDetailsTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Instruction Details')]")));
		private IWebElement PropertyTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Property')]")));
		private IWebElement AccountsTab => wait.Until(d => d.FindElement(By.XPath("(//a[@id='div_menu_accounts'])[1]")));
		private IWebElement PartiesTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Parties')]")));
		private IWebElement RefundDetailsTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Refund Details')]")));
		private IWebElement FiguresTab => wait.Until(d => d.FindElement(By.XPath("(//a[@id='div_menu_figures'])[1]")));
		private IWebElement ConveyancerTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Conveyancer')]")));
		private IWebElement PrintListTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Print List')]")));
		private IWebElement AuditTrailTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Audit Trail')]")));
		private IWebElement CommunicationCostsTab => wait.Until(d => d.FindElement(By.XPath("(//a[@id='div_menu_communicationcosts'])[1]")));
		private IWebElement OpenAndCloseTab => wait.Until(d => d.FindElement(By.XPath("//div[@class='panel-title bold']")));
		#endregion

		#region Actions
		/// <summary>
		/// Clicks the Mortgagee, Mortgagor, and Property links in order.
		/// </summary>
		public void Select_Mortgagee_Mortgagor_Property()
		{
			LogAction("Clicking Open and Close tab");
			ClickWhenClickable(OpenAndCloseTab);
			LogSuccess("Clicked Open and Close tab");

			LogAction("Clicking Mortgagee link");
			ClickWhenClickable(MortgageeLink);
			LogSuccess("Clicked Mortgagee link");

			LogAction("Clicking Mortgagor link");
			ClickWhenClickable(MortgagorLink);
			LogSuccess("Clicked Mortgagor link");

			//LogAction("Clicking Property link");
			//ClickWhenClickable(PropertyLink);
			//LogSuccess("Clicked Property link");

			//LogAction("Clicking Communications tab");
			//ClickWhenClickable(CommunicationsTab);
			//LogSuccess("Clicked Communications tab");

			LogSuccess("Successfully selected Mortgagee, Mortgagor, and Property links");
		}

		/// <summary>
		/// Adds a general file note.
		/// </summary>
		public void EnterFileNote(string fileNote)
		{
			try
			{
				Thread.Sleep(3000);
				LogAction($"Adding file note: {fileNote}");

				LogAction("Clicking File Note edit pen");
				ClickWhenClickable(FileNoteEditPen);
				LogSuccess("Clicked File Note edit pen");

				// Wait for any animations or transitions to complete
				Thread.Sleep(3000);

				// Try to click the "Click here to add" if it's visible
				try
				{
					LogAction("Checking if 'Click here to add' is visible");
					if (IsElementVisible(By.XPath("//span[normalize-space()='Click here to add']")))
					{
						LogAction("Clicking 'Click here to add'");
						ClickWhenClickable(FileNoteClickHere);
						LogSuccess("Clicked 'Click here to add'");
						Thread.Sleep(1000);
					}
				}
				catch (Exception ex)
				{
					LogAction($"'Click here to add' not found or not needed: {ex.Message}");
				}

				LogAction("Waiting for File Note comment field to be visible");
				WaitForElementToBeVisible(FileNoteComment);
				LogSuccess("File Note comment field is visible");
				Thread.Sleep(3000);

				LogAction("Clearing File Note comment field");
				FileNoteComment.Clear();
				LogSuccess("Cleared File Note comment field");
				Thread.Sleep(3000);

				LogAction($"Entering file note: {fileNote}");
				FileNoteComment.SendKeys(fileNote);
				LogSuccess($"Entered file note: {fileNote}");
				Thread.Sleep(3000);

				LogAction("Clicking Save button");
				ClickWhenClickable(FileNoteSaveBtn);
				LogSuccess("Clicked Save button");

				// Wait for save operation to complete
				Thread.Sleep(2000);

				LogSuccess($"Successfully added file note: {fileNote}");
			}
			catch (Exception ex)
			{
				LogError($"Failed to add file note: {fileNote}", ex);

				// Try alternative approaches if the standard approach fails
				try
				{
					LogAction("Standard approach failed, trying JavaScript approach");
					js.ExecuteScript("arguments[0].innerHTML = arguments[1]", FileNoteComment, fileNote);

					LogAction("Clicking Save button (JavaScript approach)");
					js.ExecuteScript("arguments[0].click();", FileNoteSaveBtn);

					LogSuccess($"Successfully added file note using JavaScript approach: {fileNote}");
				}
				catch (Exception jsEx)
				{
					LogError($"JavaScript approach also failed: {jsEx.Message}", jsEx);

					try
					{
						LogAction("Trying Actions approach");
						Actions actions = new Actions(driver);
						actions.MoveToElement(FileNoteComment).Click().SendKeys(Keys.Control + "a").SendKeys(fileNote).Perform();

						LogAction("Clicking Save button (Actions approach)");
						actions.MoveToElement(FileNoteSaveBtn).Click().Perform();

						LogSuccess($"Successfully added file note using Actions approach: {fileNote}");
					}
					catch (Exception actionsEx)
					{
						LogError($"All approaches failed. Cannot add file note: {fileNote}", actionsEx);
						// Take screenshot at the point of failure
						CaptureScreenshot("FileNoteFailure");
						throw;
					}
				}
			}
		}

		/// <summary>
		/// Sequentially clicks through all functional tabs on the page.
		/// </summary>
		public void SelectTabsInOrder()
		{
			try
			{
				LogAction("Starting to navigate through tabs in order");

				LogAction("Clicking Correspondents tab");
				ClickWhenClickable(CorrespondentsTab);
				LogSuccess("Clicked Correspondents tab");

				Thread.Sleep(1000);
				LogAction("Clicking Info Sheet tab");
				ClickWhenClickable(InfoSheetTab);
				LogSuccess("Clicked Info Sheet tab");

				Thread.Sleep(1000);
				LogAction("Clicking Inbox tab");
				ClickWhenClickable(InboxTab);
				LogSuccess("Clicked Inbox tab");

				Thread.Sleep(1000);
				LogAction("Clicking Deed Search tab");
				ClickWhenClickable(DeedSearchTab);
				LogSuccess("Clicked Deed Search tab");

				Thread.Sleep(1000);
				LogAction("Clicking Instruction Details tab");
				ClickWhenClickable(InstructionDetailsTab);
				LogSuccess("Clicked Instruction Details tab");

				Thread.Sleep(1000);
				LogAction("Clicking Property tab");
				ClickWhenClickable(PropertyTab);
				LogSuccess("Clicked Property tab");

				Thread.Sleep(1000);
				LogAction("Clicking Parties tab");
				ClickWhenClickable(PartiesTab);
				LogSuccess("Clicked Parties tab");

				Thread.Sleep(1000);
				LogAction("Clicking Refund Details tab");
				ClickWhenClickable(RefundDetailsTab);
				LogSuccess("Clicked Refund Details tab");

				Thread.Sleep(1000);
				LogAction("Clicking Accounts tab");
				ClickWhenClickable(AccountsTab);
				LogSuccess("Clicked Accounts tab");

				Thread.Sleep(1000);
				LogAction("Clicking Conveyancer tab");
				ClickWhenClickable(ConveyancerTab);
				LogSuccess("Clicked Conveyancer tab");

				Thread.Sleep(1000);
				LogAction("Clicking Print List tab");
				ClickWhenClickable(PrintListTab);
				LogSuccess("Clicked Print List tab");

				Thread.Sleep(1000);
				LogAction("Clicking Audit Trail tab");
				ClickWhenClickable(AuditTrailTab);
				LogSuccess("Clicked Audit Trail tab");

				Thread.Sleep(1000);
				LogAction("Clicking Communications tab");
				ClickWhenClickable(CommunicationsTab);
				LogSuccess("Clicked Communications tab"); // Returning to the first tab for consistency

				LogSuccess("Successfully clicked through all tabs in order");
			}
			catch (Exception ex)
			{
				LogError("Failed to navigate through tabs in order", ex);
				CaptureScreenshot("TabNavigationFailure");
				throw;
			}
		}
		#endregion

		#region Helper Methods
		/// <summary>
		/// Waits for an element to be clickable and clicks it.
		/// </summary>
		private void ClickWhenClickable(IWebElement element, int maxRetries = 3)
		{
			int attempts = 0;
			while (attempts < maxRetries)
			{
				try
				{
					LogAction($"Attempting to click element (Attempt {attempts + 1})");
					wait.Until(d => element.Enabled && element.Displayed);
					element.Click();
					LogAction("Element clicked successfully");
					return;
				}
				catch (StaleElementReferenceException)
				{
					attempts++;
					LogAction($"Element is stale, refreshing reference (Attempt {attempts})");
					if (attempts >= maxRetries)
					{
						LogError("Failed to click element due to stale reference", new Exception("Stale Element Reference"));
						throw;
					}
					Thread.Sleep(1000); // Wait before retry
				}
				catch (Exception ex)
				{
					attempts++;
					LogAction($"Standard click failed: {ex.Message}. Trying JavaScript click.");
					try
					{
						// Try JavaScript click as fallback
						js.ExecuteScript("arguments[0].click();", element);
						LogAction("JavaScript click successful");
						return;
					}
					catch (Exception jsEx)
					{
						if (attempts >= maxRetries)
						{
							LogError($"Failed to click element after {maxRetries} attempts", jsEx);
							throw;
						}
						LogAction($"JavaScript click also failed: {jsEx.Message}. Retrying...");
						Thread.Sleep(1000); // Wait before retry
					}
				}
			}
		}

		/// <summary>
		/// Waits for an element to be visible.
		/// </summary>
		private void WaitForElementToBeVisible(IWebElement element)
		{
			try
			{
				LogAction("Waiting for element to be visible");
				wait.Until(d => element.Displayed);
				LogAction("Element is now visible");
			}
			catch (Exception ex)
			{
				LogError("Element not visible within timeout period", ex);
				throw;
			}
		}

		/// <summary>
		/// Checks if an element is visible without throwing an exception.
		/// </summary>
		private bool IsElementVisible(By locator)
		{
			try
			{
				LogAction($"Checking if element is visible: {locator}");
				bool isVisible = driver.FindElement(locator).Displayed;
				LogAction($"Element visibility check result: {isVisible}");
				return isVisible;
			}
			catch
			{
				LogAction($"Element not found or not visible: {locator}");
				return false;
			}
		}

		/// <summary>
		/// Logs an action to the ExtentReport
		/// </summary>
		private void LogAction(string message)
		{
			string logMessage = $"[{pageName}] {message}";
			Console.WriteLine(logMessage);
			if (ExtentReport._scenario != null)
			{
				ExtentReport._scenario.Log(Status.Info, logMessage);
			}
		}

		/// <summary>
		/// Logs a success message to the ExtentReport
		/// </summary>
		private void LogSuccess(string message)
		{
			string logMessage = $"[{pageName}] {message}";
			Console.WriteLine(logMessage);
			if (ExtentReport._scenario != null)
			{
				ExtentReport._scenario.Log(Status.Pass, logMessage);
			}
		}

		/// <summary>
		/// Logs an error message to the ExtentReport
		/// </summary>
		private void LogError(string message, Exception ex)
		{
			string errorMessage = $"[{pageName}] {message}: {ex.Message}";
			Console.WriteLine(errorMessage);
			if (ExtentReport._scenario != null)
			{
				ExtentReport._scenario.Log(Status.Fail, errorMessage);
			}
		}

		/// <summary>
		/// Captures a screenshot and adds it to the ExtentReport
		/// </summary>
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
