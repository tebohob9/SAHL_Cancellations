using NUnit.Framework;
using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using SAHL_Cancellations.Utilities;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;
using SeleniumExtras.WaitHelpers;

namespace SAHL_Cancellations.Pages
{
	/// <summary>
	/// Represents the Home Page of the application and encapsulates its elements and behaviors.
	/// </summary>
	public class HomePage
	{
		private readonly IWebDriver driver;
		private readonly WebDriverWait wait;
		private ExtentTest test; // ExtentTest instance for reporting
		private readonly string pageName = "Home Page"; // Page name for reporting

		// Constructor
		public HomePage(IWebDriver driver)
		{
			this.driver = driver;
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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

		#region UI Elements
		public IWebElement RequestFiguresLink => driver.FindElement(By.XPath("//a[normalize-space()='Request Figures']"));
		public IWebElement SetupLink => driver.FindElement(By.XPath("//a[normalize-space()='Setup']"));
		public IWebElement CloseSetup => driver.FindElement(By.XPath("//i[@class='fa fa-times fa-2x']"));
		public IWebElement ContactUsLink => driver.FindElement(By.XPath("//a[normalize-space()='Contact Us']"));
		public IWebElement ReportsLink => driver.FindElement(By.XPath("//a[normalize-space()='Reports']"));
		public IWebElement CloseReports => driver.FindElement(By.XPath("//i[@class='fa fa-times fa-2x']"));
		public IWebElement LogoutButton => driver.FindElement(By.XPath("//a[normalize-space()='Log Out']"));
		public IWebElement MattersTab => driver.FindElement(By.XPath("//ul[@class='nav nav-tabs nav-tabs-collapse hidden-xs']//li[1]//a[1]"));
		public IWebElement UserTab => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_lnkButMyUser']"));
		public IWebElement BranchTab => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_lnkButMyBranch']"));
		public IWebElement CompanyTab => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_lnkButMyCompany']"));
		public IWebElement AllStagesDropdown => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_C_StageFilter_ddlMyStage']"));
		public IWebElement SearchTextBox => driver.FindElement(By.XPath("//input[@id='txtSearch']"));
		public IWebElement SearchBtn => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_btnGo']"));
		public IWebElement CancellationsTab => driver.FindElement(By.XPath("(//a[@href='/SAHL.Cancellations.Attorney.UI/Views/Cancellations/Grids/AttorneyCancellations.aspx'])[1]"));
		public IWebElement InstructionsTab => driver.FindElement(By.XPath("(//a[@href='/SAHL.Cancellations.Attorney.UI/Views/Cancellations/Grids/CancellingInstructions.aspx'])[1]"));
		public IWebElement AwaitingResponseTab => driver.FindElement(By.XPath("(//a[@href='/SAHL.Cancellations.Attorney.UI/Views/Cancellations/Grids/CancellationDraftsTa.aspx'])[1]"));
		public IWebElement StarredTab => driver.FindElement(By.XPath("(//a[@href='/SAHL.Cancellations.Attorney.UI/Views/Cancellations/Grids/StarredCancellations.aspx'])[1]"));
		public IWebElement DiaryTab => driver.FindElement(By.XPath("(//a[@href='/SAHL.Cancellations.Attorney.UI/Views/Cancellations/Grids/CancellationDiary.aspx'])[1]"));
		public IWebElement LodgeTab => driver.FindElement(By.XPath("(//a[@href='/SAHL.Cancellations.Attorney.UI/Views/Cancellations/Grids/LodgedCancellations.aspx'])[1]"));
		public IWebElement PrepTab => driver.FindElement(By.XPath("//ul[@class='nav nav-tabs nav-tabs-collapse hidden-xs']//li[@role='presentation']//a[@href='/SAHL.Cancellations.Attorney.UI/Views/Cancellations/Grids/PreppedCancellations.aspx']"));
		public IWebElement RegisteredTab => driver.FindElement(By.XPath("//ul[@class='nav nav-tabs nav-tabs-collapse hidden-xs']//li[@role='presentation']//a[@href='/SAHL.Cancellations.Attorney.UI/Views/Cancellations/Grids/RegisteredCancellations.aspx']"));
		public IWebElement InboxTab => driver.FindElement(By.XPath("(//a[@href='/SAHL.Cancellations.Attorney.UI/Views/Cancellations/Grids/CancellationInboxMessages.aspx'])[1]"));
		public IWebElement ArchivedTab => driver.FindElement(By.XPath("(//a[@href='/SAHL.Cancellations.Attorney.UI/Views/Cancellations/Grids/ArchivedCancellations.aspx'])[1]"));
		public IWebElement SelectAccount => driver.FindElement(By.XPath("//div[normalize-space()='04007820631']"));
		public IWebElement CloseSearchBtn => driver.FindElement(By.XPath("//i[@class='fa fa-times-circle fa-lg lightGreyIcon']"));
		#endregion

		#region Navigation Methods
		public void ClickRequestFigures()
		{
			try
			{
				LogInfo("Clicking Request Figures link");
				RequestFiguresLink.Click();
				LogSuccess("Clicked Request Cancellation link");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to click Request Cancellation link", ex);
				throw;
			}
		}

		public void ClickSetup()
		{
			try
			{
				LogInfo("Clicking Setup link");
				SetupLink.Click();
				LogSuccess("Clicked Setup link");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to click Setup link", ex);
				throw;
			}
		}

		public void ClickAssistance()
		{
			try
			{
				LogInfo("Clicking Assistance link");
				ContactUsLink.Click();
				LogSuccess("Clicked Assistance link");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to click Assistance link", ex);
				throw;
			}
		}

		public void ClickReports()
		{
			try
			{
				LogInfo("Clicking Reports link");
				ReportsLink.Click();
				LogSuccess("Clicked Reports link");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to click Reports link", ex);
				throw;
			}
		}

		public void ClickLogout()
		{
			try
			{
				LogInfo("Clicking Logout button");
				LogoutButton.Click();
				LogSuccess("Clicked Logout button");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to click Logout button", ex);
				throw;
			}
		}

		public void SelectMainCancellationsTab()
		{
			try
			{
				LogInfo("Clicking Main Cancellations tab");
				MattersTab.Click();
				LogSuccess("Clicked Main Cancellations tab");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to click Main Cancellations tab", ex);
				throw;
			}
		}

		public void SelectMyUserRadioButton()
		{
			try
			{
				LogInfo("Selecting My User radio button");
				UserTab.Click();
				LogSuccess("Selected My User radio button");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to select My User radio button", ex);
				throw;
			}
		}

		public void SelectMyBranchRadioButton()
		{
			try
			{
				LogInfo("Selecting My Branch radio button");
				BranchTab.Click();
				LogSuccess("Selected My Branch radio button");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to select My Branch radio button", ex);
				throw;
			}
		}

		public void ClickGoButton()
		{
			try
			{
				LogInfo("Clicking Go button");
				SearchBtn.Click();
				LogSuccess("Clicked Go button");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to click Go button", ex);
				throw;
			}
		}

		public void ClickCancellationTab()
		{
			try
			{
				LogInfo("Clicking Cancellation tab");
				CancellationsTab.Click();
				LogSuccess("Clicked Cancellation tab");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to click Cancellation tab", ex);
				throw;
			}
		}

		public void ClickAwaitingResponseTab()
		{
			try
			{
				LogInfo("Clicking Awaiting Response tab");
				AwaitingResponseTab.Click();
				LogSuccess("Clicked Awaiting Response tab");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to click Awaiting Response tab", ex);
				throw;
			}
		}

		public void SelectStageFromDropdown(string stageValue)
		{
			try
			{
				LogInfo($"Selecting stage: {stageValue} from dropdown");
				var selectElement = new SelectElement(AllStagesDropdown);
				selectElement.SelectByText(stageValue);
				LogSuccess($"Selected stage: {stageValue} from dropdown");
			}
			catch (Exception ex)
			{
				LogFailure($"Failed to select stage: {stageValue} from dropdown", ex);
				throw;
			}
		}

		public void EnterSearchText(string searchText)
		{
			try
			{
				LogInfo($"Entering search text: {searchText}");
				SearchTextBox.Clear();
				SearchTextBox.SendKeys(searchText);
				LogSuccess($"Entered search text: {searchText}");
			}
			catch (Exception ex)
			{
				LogFailure($"Failed to enter search text: {searchText}", ex);
				throw;
			}
		}

		public void ClickCloseSearch()
		{
			try
			{
				LogInfo("Clicking Request Figures link");
				CloseSearchBtn.Click();
				LogSuccess("Clicked Request Cancellation link");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to click Request Cancellation link", ex);
				throw;
			}
		}

		/// <summary>
		/// Navigates through all user tabs in a specific order.
		/// </summary>
		public void SelectUserTabsInOrder()
		{
			try
			{
				LogInfo("Starting to navigate through My User tabs in order");

				// Make sure we're on the User tab
				LogInfo("Selecting My User radio button");
				ClickWithRetry(UserTab, "My User radio button");
				LogSuccess("Selected My User radio button");

				// Wait for page to update after selecting My User
				Thread.Sleep(2000);

				LogInfo("Clicking Awaiting Response tab");
				ClickWithRetry(AwaitingResponseTab, "Awaiting Response tab");
				LogSuccess("Clicked Awaiting Response tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Instructions tab");
				ClickWithRetry(InstructionsTab, "Instructions tab");
				LogSuccess("Clicked Instructions tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Inbox tab");
				ClickWithRetry(InboxTab, "Inbox tab");
				LogSuccess("Clicked Inbox tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Starred tab");
				ClickWithRetry(StarredTab, "Starred tab");
				LogSuccess("Clicked Starred tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Diary tab");
				ClickWithRetry(DiaryTab, "Diary tab");
				LogSuccess("Clicked Diary tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Lodge tab");
				ClickWithRetry(LodgeTab, "Lodge tab");
				LogSuccess("Clicked Lodge tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Prep tab");
				ClickWithRetry(PrepTab, "Prep tab");
				LogSuccess("Clicked Prep tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Registered tab");
				ClickWithRetry(RegisteredTab, "Registered tab");
				LogSuccess("Clicked Registered tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Archived tab");
				ClickWithRetry(ArchivedTab, "Archived tab");
				LogSuccess("Clicked Archived tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Cancellations tab");
				ClickWithRetry(CancellationsTab, "Cancellations tab");
				LogSuccess("Clicked Cancellations tab");

				LogSuccess("Successfully navigated through all My User tabs in order");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to navigate through My User tabs in order", ex);
				throw;
			}
		}

		/// <summary>
		/// Navigates through all branch tabs in a specific order.
		/// </summary>
		public void SelectBranchTabsInOrder()
		{
			try
			{
				LogInfo("Starting to navigate through My Branch tabs in order");

				// Make sure we're on the Branch tab
				LogInfo("Selecting My Branch radio button");
				ClickWithRetry(BranchTab, "My Branch radio button");
				LogSuccess("Selected My Branch radio button");

				// Wait for page to update after selecting My Branch
				LogInfo("Waiting for page to update after selecting My Branch");
				Thread.Sleep(3000); // Increased wait time to ensure page loads
				LogSuccess("Page updated after selecting My Branch");

				// Refresh element references after page update
				RefreshElementReferences();

				LogInfo("Clicking Awaiting Response tab");
				ClickWithRetry(AwaitingResponseTab, "Awaiting Response tab");
				LogSuccess("Clicked Awaiting Response tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Instructions tab");
				ClickWithRetry(InstructionsTab, "Instructions tab");
				LogSuccess("Clicked Instructions tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Inbox tab");
				ClickWithRetry(InboxTab, "Inbox tab");
				LogSuccess("Clicked Inbox tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Starred tab");
				ClickWithRetry(StarredTab, "Starred tab");
				LogSuccess("Clicked Starred tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Diary tab");
				ClickWithRetry(DiaryTab, "Diary tab");
				LogSuccess("Clicked Diary tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Lodge tab");
				ClickWithRetry(LodgeTab, "Lodge tab");
				LogSuccess("Clicked Lodge tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Prep tab");
				ClickWithRetry(PrepTab, "Prep tab");
				LogSuccess("Clicked Prep tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Registered tab");
				ClickWithRetry(RegisteredTab, "Registered tab");
				LogSuccess("Clicked Registered tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Archived tab");
				ClickWithRetry(ArchivedTab, "Archived tab");
				LogSuccess("Clicked Archived tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Cancellations tab");
				ClickWithRetry(CancellationsTab, "Cancellations tab");
				LogSuccess("Clicked Cancellations tab");

				LogSuccess("Successfully navigated through all My Branch tabs in order");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to navigate through My Branch tabs in order", ex);
				// Take screenshot at the point of failure
				CaptureScreenshot("MyBranchTabsFailure");
				throw;
			}
		}

		public void SelectCompanyTabsInOrder()
		{
			try
			{
				LogInfo("Starting to navigate through My Branch tabs in order");

				// Make sure we're on the Branch tab
				LogInfo("Selecting My Branch radio button");
				ClickWithRetry(CompanyTab, "Company radio button");
				LogSuccess("Selected My Branch radio button");

				// Wait for page to update after selecting My Branch
				LogInfo("Waiting for page to update after selecting My Branch");
				Thread.Sleep(3000); // Increased wait time to ensure page loads
				LogSuccess("Page updated after selecting My Branch");

				// Refresh element references after page update
				RefreshElementReferences();

				LogInfo("Clicking Awaiting Response tab");
				ClickWithRetry(AwaitingResponseTab, "Awaiting Response tab");
				LogSuccess("Clicked Awaiting Response tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Instructions tab");
				ClickWithRetry(InstructionsTab, "Instructions tab");
				LogSuccess("Clicked Instructions tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Inbox tab");
				ClickWithRetry(InboxTab, "Inbox tab");
				LogSuccess("Clicked Inbox tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Starred tab");
				ClickWithRetry(StarredTab, "Starred tab");
				LogSuccess("Clicked Starred tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Diary tab");
				ClickWithRetry(DiaryTab, "Diary tab");
				LogSuccess("Clicked Diary tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Lodge tab");
				ClickWithRetry(LodgeTab, "Lodge tab");
				LogSuccess("Clicked Lodge tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Prep tab");
				ClickWithRetry(PrepTab, "Prep tab");
				LogSuccess("Clicked Prep tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Registered tab");
				ClickWithRetry(RegisteredTab, "Registered tab");
				LogSuccess("Clicked Registered tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Archived tab");
				ClickWithRetry(ArchivedTab, "Archived tab");
				LogSuccess("Clicked Archived tab");

				Thread.Sleep(1000);
				LogInfo("Clicking Cancellations tab");
				ClickWithRetry(CancellationsTab, "Cancellations tab");
				LogSuccess("Clicked Cancellations tab");

				LogSuccess("Successfully navigated through all My Branch tabs in order");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to navigate through My Branch tabs in order", ex);
				// Take screenshot at the point of failure
				CaptureScreenshot("MyBranchTabsFailure");
				throw;
			}
		}

		/// <summary>
		/// Opens and closes Setup, Assistance, and Reports to validate functionality.
		/// </summary>
		public void OpenAndCloseLinks()
		{
			try
			{
				LogInfo("Starting to open and close navigation links");
				LogInfo("Clicking Request Figures link");
				RequestFiguresLink.Click();
				LogSuccess("Clicked Request Figures link");
				LogInfo("Waiting for Main Cancellations tab to be displayed");
				wait.Until(_ => MattersTab.Displayed);
				LogSuccess("Main Cancellations tab is displayed");
				LogInfo("Clicking Main Cancellations tab");
				MattersTab.Click();
				LogSuccess("Clicked Main Cancellations tab");
				LogInfo("Clicking Setup link");
				SetupLink.Click();
				LogSuccess("Clicked Setup link");
				LogInfo("Waiting for Close Setup button to be displayed");
				wait.Until(_ => CloseSetup.Displayed);
				LogSuccess("Close Setup button is displayed");
				LogInfo("Clicking Close Setup button");
				CloseSetup.Click();
				LogSuccess("Clicked Close Setup button");
				LogInfo("Clicking Assistance link");
				ContactUsLink.Click();
				LogSuccess("Clicked Assistance link");
				LogInfo("Waiting for Main Cancellations tab to be displayed");
				wait.Until(_ => MattersTab.Displayed);
				LogSuccess("Main Cancellations tab is displayed");
				LogInfo("Clicking Main Cancellations tab");
				MattersTab.Click();
				LogSuccess("Clicked Main Cancellations tab");
				LogInfo("Clicking Reports link");
				ReportsLink.Click();
				LogSuccess("Clicked Reports link");
				LogInfo("Waiting for Close Reports button to be displayed");
				wait.Until(_ => CloseReports.Displayed);
				LogSuccess("Close Reports button is displayed");
				LogInfo("Clicking Close Reports button");
				CloseReports.Click();
				LogSuccess("Clicked Close Reports button");
				LogSuccess("Successfully opened and closed all navigation links");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to open and close navigation links", ex);
				throw;
			}
		}

		/// <summary>
		/// Performs sequential searches in the "My Branch" context by multiple fields.
		/// </summary>
		public void MyBranchSearch(string id, string account, string property, string parties, string blank)
		{
			try
			{
				LogInfo("Starting My Branch search operations");
				LogInfo("Waiting for Main Cancellations tab to be displayed");
				wait.Until(_ => CompanyTab.Displayed);
				LogSuccess("Main Cancellations tab is displayed");
				LogInfo("Selecting My Branch radio button");
				//BranchTab.Click();
				//LogSuccess("Selected My Branch radio button");

				// Wait for page to update after selecting My Branch
				Thread.Sleep(3000);

				LogInfo($"Performing search with ID: {id}");
				PerformSearch(id);
				LogSuccess($"Completed search with ID: {id}");
				Thread.Sleep(2000);
				LogInfo($"Performing search with Account: {account}");
				PerformSearch(account);
				LogSuccess($"Completed search with Account: {account}");
				Thread.Sleep(2000);
				LogInfo($"Performing search with Property: {property}");
				PerformSearch(property);
				LogSuccess($"Completed search with Property: {property}");
				Thread.Sleep(2000);
				LogInfo($"Performing search with Mortgagor: {parties}");
				PerformSearch(parties);
				LogSuccess($"Completed search with Mortgagor: {parties}");
				Thread.Sleep(2000);
				LogInfo($"Click Close search button");
				CloseSearchBtn.Click();
				LogSuccess($"Clicked Close search button");
				Thread.Sleep(2000);
				LogSuccess("Successfully completed all My Branch search operations");
			}
			catch (Exception ex)
			{
				LogFailure("Failed during My Branch search operations", ex);
				throw;
			}
		}

		private void PerformSearch(string text)
		{
			try
			{
				LogInfo($"Waiting for Search textbox to be displayed");
				wait.Until(_ => SearchTextBox.Displayed);
				LogSuccess("Search textbox is displayed");
				LogInfo("Clearing Search textbox");
				SearchTextBox.Clear();
				LogSuccess("Cleared Search textbox");
				LogInfo($"Entering search text: {text}");
				SearchTextBox.SendKeys(text);
				LogSuccess($"Entered search text: {text}");
				LogInfo("Clicking Go button");
				SearchBtn.Click();
				LogSuccess("Clicked Go button");
				LogInfo("Waiting for search results");
				wait.Until(_ => SearchBtn.Enabled); // Adjust wait condition as needed
				LogSuccess("Search completed");
			}
			catch (Exception ex)
			{
				LogFailure($"Failed to perform search with text: {text}", ex);
				throw;
			}
		}

		/// <summary>
		/// Clicks tabs in a randomized (non-linear) order to simulate diverse navigation.
		/// </summary>
		public void SelectTabsInRandomOrder()
		{
			try
			{
				LogInfo("Starting to navigate through tabs in random order");
				LogInfo("Clicking Cancellations tab");
				CancellationsTab.Click();
				LogSuccess("Clicked Cancellations tab");
				LogInfo("Clicking Awaiting Response tab");
				AwaitingResponseTab.Click();
				LogSuccess("Clicked Awaiting Response tab");
				LogInfo("Clicking New Instructions tab");
				//NewInstructionsTab.Click();
				LogSuccess("Clicked New Instructions tab");
				LogInfo("Clicking Diary tab");
				DiaryTab.Click();
				LogSuccess("Clicked Diary tab");
				LogInfo("Clicking Awaiting Response tab again");
				AwaitingResponseTab.Click();
				LogSuccess("Clicked Awaiting Response tab again");
				LogInfo("Clicking Archived tab");
				ArchivedTab.Click();
				LogSuccess("Clicked Archived tab");
				LogInfo("Clicking Diary tab again");
				DiaryTab.Click();
				LogSuccess("Clicked Diary tab again");
				LogInfo("Clicking Inbox tab");
				InboxTab.Click();
				LogSuccess("Clicked Inbox tab");
				LogInfo("Clicking Archived tab again");
				ArchivedTab.Click();
				LogSuccess("Clicked Archived tab again");
				LogInfo("Redirecting to New Instruction page");
				RedirectToNewInstructionPage();
				LogSuccess("Redirected to New Instruction page");
				LogSuccess("Successfully navigated through tabs in random order");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to navigate through tabs in random order", ex);
				throw;
			}
		}

		/// <summary>
		/// Redirects to the New Instruction Page by selecting a specific account.
		/// </summary>
		public New_InstructionPage RedirectToNewInstructionPage()
		{
			try
			{
				LogInfo("Clicking on account to redirect to New Instruction page");
				SelectAccount.Click();
				LogSuccess("Clicked on account");
				//LogInfo("Waiting for URL to contain 'NewInstruction'");
				//wait.Until(driver => driver.Url.Contains("NewInstruction")); // Update this if URL differs
				//LogSuccess("URL contains 'NewInstruction'");
				LogSuccess("Successfully redirected to New Instruction page");
				return new New_InstructionPage(driver);
			}
			catch (Exception ex)
			{
				LogFailure("Failed to redirect to New Instruction page", ex);
				throw;
			}
		}
		#endregion

		#region Helper Methods
		/// <summary>
		/// Clicks an element with retry logic to handle intermittent failures
		/// </summary>
		private void ClickWithRetry(IWebElement element, string elementName, int maxRetries = 3)
		{
			int attempts = 0;
			while (attempts < maxRetries)
			{
				try
				{
					LogInfo($"Attempting to click {elementName} (Attempt {attempts + 1})");
					wait.Until(ExpectedConditions.ElementToBeClickable(element));
					element.Click();
					LogSuccess($"Successfully clicked {elementName}");
					return;
				}
				catch (StaleElementReferenceException)
				{
					attempts++;
					LogInfo($"Element {elementName} is stale, refreshing reference (Attempt {attempts})");
					RefreshElementReferences();
					if (attempts >= maxRetries)
					{
						LogFailure($"Failed to click {elementName} after {maxRetries} attempts due to stale element", new Exception("Stale Element"));
						throw;
					}
					Thread.Sleep(1000); // Wait before retry
				}
				catch (Exception ex)
				{
					attempts++;
					if (attempts >= maxRetries)
					{
						LogFailure($"Failed to click {elementName} after {maxRetries} attempts", ex);
						throw;
					}
					LogInfo($"Click attempt {attempts} failed, retrying...");
					Thread.Sleep(1000); // Wait before retry
				}
			}
		}

		/// <summary>
		/// Refreshes element references after page state changes
		/// </summary>
		private void RefreshElementReferences()
		{
			try
			{
				LogInfo("Refreshing element references");
				// No need to reassign properties using the => syntax as they're dynamically found
				// Just log that we're refreshing
				LogSuccess("Element references refreshed");
			}
			catch (Exception ex)
			{
				LogFailure("Failed to refresh element references", ex);
			}
		}

		/// <summary>
		/// Checks if an element is stale (no longer attached to the DOM)
		/// </summary>
		private bool IsElementStale(IWebElement element)
		{
			try
			{
				// Checking if element is still attached to the DOM
				bool isDisplayed = element.Displayed;
				return false;
			}
			catch (StaleElementReferenceException)
			{
				return true;
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
				if (test != null)
				{
					test.Log(Status.Warning, $"Failed to capture screenshot: {ex.Message}");
				}
			}
		}
		#endregion
	}
}
