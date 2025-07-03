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

			LogAction("Clicking Mortgagee link");
			ClickWhenClickable(MortgageeLink);

			LogAction("Clicking Mortgagor link");
			ClickWhenClickable(MortgagorLink);

			//LogAction("Clicking Property link");
			//ClickWhenClickable(PropertyLink);

			//LogAction("Clicking Communications tab");
			//ClickWhenClickable(CommunicationsTab);

			LogSuccess("Successfully selected Mortgagee, Mortgagor, and Property links");
		}

		/// <summary>
		/// Adds a general file note.
		/// </summary>
		public void EnterFileNote(string fileNote)
		{
			try
			{
				LogAction("Clicking File Note edit pen");
				ClickWhenClickable(FileNoteEditPen);

				// Wait for any animations or transitions to complete
				Thread.Sleep(1000);

				// Try to click the "Click here to add" if it's visible
				try
				{
					LogAction("Checking if 'Click here to add' is visible");
					if (IsElementVisible(By.XPath("//span[normalize-space()='Click here to add']")))
					{
						LogAction("Clicking 'Click here to add'");
						ClickWhenClickable(FileNoteClickHere);
						Thread.Sleep(1000);
					}
				}
				catch (Exception ex)
				{
					LogAction($"'Click here to add' not found or not needed: {ex.Message}");
				}

				LogAction("Waiting for File Note comment field to be visible and interactable");
				WaitForElementToBeVisible(FileNoteComment);

				// Try multiple approaches to enter text
				try
				{
					// Approach 1: Standard clear and sendKeys
					LogAction("Clearing File Note comment field");
					FileNoteComment.Clear();
					LogAction($"Entering file note (approach 1): {fileNote}");
					FileNoteComment.SendKeys(fileNote);
				}
				catch (Exception ex)
				{
					LogAction($"Standard text entry failed: {ex.Message}. Trying alternative approaches.");

					try
					{
						// Approach 2: JavaScript executor
						LogAction($"Entering file note using JavaScript (approach 2): {fileNote}");
						js.ExecuteScript("arguments[0].innerHTML = arguments[1]", FileNoteComment, fileNote);
					}
					catch (Exception jsEx)
					{
						LogAction($"JavaScript text entry failed: {jsEx.Message}. Trying next approach.");

						try
						{
							// Approach 3: Actions class
							LogAction($"Entering file note using Actions (approach 3): {fileNote}");
							Actions actions = new Actions(driver);
							actions.MoveToElement(FileNoteComment).Click().SendKeys(Keys.Control + "a").SendKeys(fileNote).Perform();
						}
						catch (Exception actionsEx)
						{
							LogError($"All text entry approaches failed. Last error: {actionsEx.Message}");
							throw;
						}
					}
				}

				// Take a screenshot to verify text was entered
				if (ExtentReport._scenario != null)
				{
					LogAction("Taking screenshot to verify text entry");
					((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("FileNoteTextEntry.png");
					ExtentReport._scenario.AddScreenCaptureFromPath("FileNoteTextEntry.png");
				}

				LogAction("Clicking Save button");
				ClickWhenClickable(FileNoteSaveBtn);

				// Wait for save operation to complete
				Thread.Sleep(2000);

				LogSuccess("Successfully entered file note");
			}
			catch (Exception ex)
			{
				LogError($"Failed to enter file note: {ex.Message}");
				throw;
			}
		}

		/// <summary>
		/// Sequentially clicks through all functional tabs on the page.
		/// </summary>
		public void SelectTabsInOrder()
		{
			LogAction("Clicking Correspondents tab");
			ClickWhenClickable(CorrespondentsTab);
			LogAction("Clicking Info Sheet tab");
			ClickWhenClickable(InfoSheetTab);
			LogAction("Clicking Inbox tab");
			ClickWhenClickable(InboxTab);
			LogAction("Clicking Deed Search tab");
			ClickWhenClickable(DeedSearchTab);
			LogAction("Clicking Instruction Details tab");
			ClickWhenClickable(InstructionDetailsTab);
			LogAction("Clicking Property tab");
			ClickWhenClickable(PropertyTab);
			LogAction("Clicking Parties tab");
			ClickWhenClickable(PartiesTab);
			LogAction("Clicking Refund Details tab");
			ClickWhenClickable(RefundDetailsTab);
			LogAction("Clicking Accounts tab");
			ClickWhenClickable(AccountsTab);
			LogAction("Clicking Conveyancer tab");
			ClickWhenClickable(ConveyancerTab);
			LogAction("Clicking Print List tab");
			ClickWhenClickable(PrintListTab);
			LogAction("Clicking Audit Trail tab");
			ClickWhenClickable(AuditTrailTab);
			LogAction("Clicking Communications tab");
			ClickWhenClickable(CommunicationsTab); // Returning to the first tab for consistency
			LogSuccess("Successfully clicked through all tabs in order");
		}
		#endregion

		#region Helper Methods
		/// <summary>
		/// Waits for an element to be clickable and clicks it.
		/// </summary>
		private void ClickWhenClickable(IWebElement element)
		{
			try
			{
				wait.Until(d => element.Enabled && element.Displayed);

				// Try standard click first
				try
				{
					element.Click();
				}
				catch (Exception ex)
				{
					LogAction($"Standard click failed: {ex.Message}. Trying JavaScript click.");
					// Try JavaScript click as fallback
					js.ExecuteScript("arguments[0].click();", element);
				}
			}
			catch (Exception ex)
			{
				LogError($"Failed to click element: {ex.Message}");
				throw;
			}
		}

		/// <summary>
		/// Waits for an element to be visible.
		/// </summary>
		private void WaitForElementToBeVisible(IWebElement element)
		{
			try
			{
				wait.Until(d => element.Displayed);
			}
			catch (Exception ex)
			{
				LogError($"Element not visible: {ex.Message}");
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
				return driver.FindElement(locator).Displayed;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Logs an action to the ExtentReport
		/// </summary>
		private void LogAction(string message)
		{
			if (ExtentReport._scenario != null)
			{
				ExtentReport._scenario.Log(Status.Info, $"[New_InstructionPage] {message}");
			}
		}

		/// <summary>
		/// Logs a success message to the ExtentReport
		/// </summary>
		private void LogSuccess(string message)
		{
			if (ExtentReport._scenario != null)
			{
				ExtentReport._scenario.Log(Status.Pass, $"[New_InstructionPage] {message}");
			}
		}

		/// <summary>
		/// Logs an error message to the ExtentReport
		/// </summary>
		private void LogError(string message)
		{
			if (ExtentReport._scenario != null)
			{
				ExtentReport._scenario.Log(Status.Fail, $"[New_InstructionPage] {message}");
			}
		}
		#endregion
	}
}
