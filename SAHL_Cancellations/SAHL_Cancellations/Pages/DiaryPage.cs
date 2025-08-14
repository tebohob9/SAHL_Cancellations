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
    public class DiaryPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Diary Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public DiaryPage(IWebDriver driver)
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
        public IWebElement DiaryTab => driver.FindElement(By.XPath("(//a[@id='div_menu_diary'])[1]"));
        public IWebElement IncludeCompletdDiaries_Checkbox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_chkComlete']"));
        public IWebElement DiaryEntry => driver.FindElement(By.XPath("(//td[@align='left'][normalize-space()='Shopping Complex'])[1]"));
        public IWebElement AddDiaryItem_Btn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_btnAddNote'])[1]"));
        public IWebElement DescriptionTxtBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_DetailsView1_txtMilestone'])[1]"));
        public IWebElement DueDate => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_DetailsView1_txtInsertDueDate'])[1]"));
        public IWebElement ReminderDate => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_DetailsView1_txtInsertReminderDate'])[1]"));
        public IWebElement AddNoteTxtBox => driver.FindElement(By.XPath("(//textarea[@id='ctl00_ctl00_C_C_DetailsView1_txtNote'])[1]"));
        public IWebElement SaveBtn => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_C_DetailsView1_Button1']"));
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_btnCancel']"));
        public IWebElement EditBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_DetailsView1_Button1'])[1]"));
        public IWebElement EditSaveBtn => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_Button1'])[1]"));
        public IWebElement ArchiveBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_btnArchive']"));
        public IWebElement BackBtn => driver.FindElement(By.XPath("//div[contains(text(),'Diary')]"));
        public IWebElement DownloadICalenderLink => driver.FindElement(By.XPath("(//a[normalize-space()='Download iCalender for Outlook'])[1]"));
        public IWebElement AddNoteBtn => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_C_btnAddNote']"));
        public IWebElement AddNotesTxtBox => driver.FindElement(By.XPath("(//textarea[@id='ctl00_ctl00_C_C_DetailsView1_txtNote'])[1]"));
		public IWebElement EditNotesTxtBox => driver.FindElement(By.XPath("//textarea[@id='ctl00_ctl00_C_C_txtNote']"));
		public IWebElement TypeInNewNoteTxtBox => driver.FindElement(By.XPath("(//textarea[@id='ctl00_ctl00_C_C_txtNote'])[1]"));
		public IWebElement AddBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_btnAddNote'])[1]"));

		// Date Range Elements
		public IWebElement DeleteNoteBtn => driver.FindElement(By.XPath("(//span[@class='pointer fa fa-trash-o fa-lg'])[1]"));
        public IWebElement DateCapturedBetweenCheckbox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_txtInsertDueDate']"));
        public IWebElement DueDateTextbox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_DetailsView1_txtInsertDueDate'])[1]"));
        public IWebElement EndDateTextbox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_txtEndDate']"));
        public IWebElement TodayBtn => driver.FindElement(By.XPath("(//button[@onclick='TodayClicked();'])[1]"));
        public IWebElement MilestonesTab => driver.FindElement(By.XPath("//div[contains(text(),'Milestones')]"));
        public IWebElement MilestonesDiaryFlag => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_ctl00_C_C_C_dlMilestones_ctl00_lnkDiary']"));
        public IWebElement MilestonesAddNotesTxtBox => driver.FindElement(By.XPath("(//textarea[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_txtNote'])[1]"));

        // Methods to interact with elements on the Diary Page
        public void ClickIncludeCompletedDiaries()
        {
            try
            {
                LogInfo("Clicking Include Completed Diaries checkbox");
                IncludeCompletdDiaries_Checkbox.Click();
                LogSuccess("Clicked Include Completed Diaries checkbox");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to click Include Completed Diaries checkbox", ex);
                throw;
            }
        }

        public void ClickDiary()
        {
            try
            {
                LogInfo("Clicking Diary entry");
                DiaryEntry.Click();
                LogSuccess("Clicked Diary entry");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to click Diary entry", ex);
                throw;
            }
        }

        public void ClickAddCustomDiaryItem()
        {
            try
            {
                LogInfo("Clicking Add Custom Diary Item button");
                AddDiaryItem_Btn.Click();
                LogSuccess("Clicked Add Custom Diary Item button");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to click Add Custom Diary Item button", ex);
                throw;
            }
        }

        // Add Custom Diary Item Method
        public void AddCustomDiaryItem(string Description, string dueDate, string Notes)
        {
            try
            {
                LogInfo("Starting to add custom diary item");

                // Click on the Diary Tab
                LogInfo("Clicking on Diary tab");
                Thread.Sleep(2000);
                DiaryTab.Click();
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

                // Click the "Add Custom Diary Item" button
                LogInfo("Clicking Add Custom Diary Item button");
                AddDiaryItem_Btn.Click();
                LogSuccess("Clicked Add Custom Diary Item button");

                // Wait for the page elements to load using WebDriverWait instead of Thread.Sleep
                //LogInfo("Waiting for Description textbox to be visible");
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_txtMilestone']")));
                //LogSuccess("Description textbox is visible");

                // Enter the description of the diary item
                LogInfo($"Entering description: {Description}");
                DescriptionTxtBox.EnterText(Description);
                LogSuccess($"Entered description: {Description}");

                // Set Due Date (using the dynamically passed date)
                LogInfo($"Entering due date");
                DueDate.Click();
                LogSuccess($"Entered due date");

                LogInfo("Clicking Today button");
                TodayBtn.Click();
                LogSuccess("Clicked Today button");

				// Wait for the page elements to load using WebDriverWait instead of Thread.Sleep
				Thread.Sleep(5000);

				LogInfo($"Entering due date");
				ReminderDate.Click();
				LogSuccess($"Entered due date");

				LogInfo("Clicking Today button");
				TodayBtn.Click();
				LogSuccess("Clicked Today button");

				// Enter the notes for the diary item
				LogInfo($"Entering notes: {Notes}");
                AddNoteTxtBox.EnterText(Notes);
                LogSuccess($"Entered notes: {Notes}");

                // Click the "Save" button to save the new diary item
                LogInfo("Clicking Save button");
                SaveBtn.Click();
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

        public void SaveWithoutCompulsoryfields()
        {
            try
            {
                LogInfo("Testing save without compulsory fields");

                // Click on the Diary Tab
                LogInfo("Clicking on Diary tab");
                Thread.Sleep(2000);
                DiaryTab.Click();
                LogSuccess("Clicked on Diary tab");

                // Click the "Add Custom Diary Item" button
                LogInfo("Clicking Add Custom Diary Item button");
                AddDiaryItem_Btn.Click();
                LogSuccess("Clicked Add Custom Diary Item button");

                //// Wait for the page elements to load using WebDriverWait instead of Thread.Sleep
                //LogInfo("Waiting for Description textbox to be visible");
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_txtMilestone']")));
                //LogSuccess("Description textbox is visible");

                // Click the "Save" button to save the new diary item
                LogInfo("Clicking Save button without entering required fields");
                SaveBtn.Click();
                LogSuccess("Clicked Save button - expecting validation errors");
                Thread.Sleep(2000);

                LogSuccess("Successfully tested save without compulsory fields");
                CaptureScreenshot($"{pageName}_SaveWithoutCompulsoryfields_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to test save without compulsory fields", ex);
                CaptureScreenshot($"{pageName}_SaveWithoutCompulsoryfields_Failure");
                throw;
            }
        }

        // Method to select a date range for the diary entries
        public void SelectDateRange(string startDate, string endDate)
        {
            try
            {
                LogInfo("Starting to select date range");

                // Check the checkbox for "Date Captured Between" if it's not already checked
                LogInfo("Checking if Date Captured Between checkbox is selected");
                if (!DateCapturedBetweenCheckbox.Selected)
                {
                    LogInfo("Clicking Date Captured Between checkbox");
                    DateCapturedBetweenCheckbox.Click();
                    LogSuccess("Clicked Date Captured Between checkbox");
                }
                else
                {
                    LogInfo("Date Captured Between checkbox is already selected");
                }

                // Enter the start and end date values into the respective textboxes
                LogInfo($"Entering start date: {startDate}");
                DueDateTextbox.SendKeys(startDate);
                LogSuccess($"Entered start date: {startDate}");

                LogInfo($"Entering end date: {endDate}");
                EndDateTextbox.SendKeys(endDate);
                LogSuccess($"Entered end date: {endDate}");

                LogSuccess("Successfully selected date range");
                CaptureScreenshot($"{pageName}_SelectDateRange_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to select date range", ex);
                CaptureScreenshot($"{pageName}_SelectDateRange_Failure");
                throw;
            }
        }

        public void EditDiary(string Description)
        {
            try
            {
                LogInfo("Starting to edit diary item");

                // Click on the Diary Tab
                LogInfo("Clicking on Diary tab");
                Thread.Sleep(2000);
                DiaryTab.Click();
                LogSuccess("Clicked on Diary tab");

                LogInfo("Clicking Diary entry");
                DiaryEntry.Click();
                LogSuccess("Clicked Diary entry");

                LogInfo("Clicking Edit button");
                EditBtn.Click();
                LogSuccess("Clicked Edit button");

                Thread.Sleep(2000);

				//// Wait for the page elements to load using WebDriverWait instead of Thread.Sleep
				//LogInfo("Waiting for Description textbox to be visible");
				//wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_txtMilestone']")));
				//LogSuccess("Description textbox is visible");

				// Enter the description of the diary item
				LogInfo($"Entering description: {Description}");
				TypeInNewNoteTxtBox.EnterText(Description);
                LogSuccess($"Entered description: {Description}");

				Thread.Sleep(2000);

				//// Wait for the page elements to load using WebDriverWait instead of Thread.Sleep
				//LogInfo("Waiting for Description textbox to be visible");
				//wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_txtMilestone']")));
				//LogSuccess("Description textbox is visible");

				// Click the "Save" button to save the new diary item
				LogInfo("Clicking Save button");
                AddBtn.Click();
                LogSuccess("Clicked Save button");
                Thread.Sleep(2000);

                LogSuccess("Successfully edited diary item");
                CaptureScreenshot($"{pageName}_EditDiary_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to edit diary item", ex);
                CaptureScreenshot($"{pageName}_EditDiary_Failure");
                throw;
            }
        }

        public void DownloadDiary()
        {
            try
            {
                LogInfo("Starting to download diary");

                // Click on the Diary Tab
                LogInfo("Clicking Download iCalender link");
                Thread.Sleep(2000);
                DownloadICalenderLink.Click();
                LogSuccess("Clicked Download iCalender link");

                Thread.Sleep(2000);

                LogSuccess("Successfully downloaded diary");
                CaptureScreenshot($"{pageName}_DownloadDiary_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to download diary", ex);
                CaptureScreenshot($"{pageName}_DownloadDiary_Failure");
                throw;
            }
        }

        public void AddEditRemoveNote(string Notes)
        {
            try
            {
                LogInfo("Starting to add, edit, and remove note");

                // Click on the Diary Tab
                LogInfo("Entering notes");
                Thread.Sleep(2000);
                EditNotesTxtBox.EnterText(Notes);
                LogSuccess($"Entered notes: {Notes}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save Note button");
                AddNoteBtn.Click();
                LogSuccess("Clicked Save Note button");

                Thread.Sleep(2000);

                LogInfo("Clicking Delete Note button");
                DeleteNoteBtn.Click();
                LogSuccess("Clicked Delete Note button");

                Thread.Sleep(2000);

                LogSuccess("Successfully added, edited, and removed note");
                CaptureScreenshot($"{pageName}_AddEditRemoveNote_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to add, edit, or remove note", ex);
                CaptureScreenshot($"{pageName}_AddEditRemoveNote_Failure");
                throw;
            }
        }

        public void DiaryReminderMilestones(string Description, string dueDate, string Notes)
        {
            try
            {
                LogInfo("Starting to test diary reminder and milestones");

                // Click on the Diary Tab
                LogInfo("Clicking on Milestones tab");
                Thread.Sleep(2000);
                MilestonesTab.Click();
                LogSuccess("Clicked on Milestones tab");

                Thread.Sleep(2000);

                LogInfo("Clicking Milestones Diary Flag");
                MilestonesDiaryFlag.Click();
                LogSuccess("Clicked Milestones Diary Flag");

                // Set Due Date (using the dynamically passed date)
                LogInfo($"Entering due date: {dueDate}");
                DueDate.EnterText(dueDate);
                LogSuccess($"Entered due date: {dueDate}");

                LogInfo("Clicking Today button");
                TodayBtn.Click();
                LogSuccess("Clicked Today button");

                // Enter the notes for the diary item
                LogInfo($"Entering notes: {Notes}");
                MilestonesAddNotesTxtBox.EnterText(Notes);
                LogSuccess($"Entered notes: {Notes}");

                // Click the "Save" button to save the new diary item
                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");
                Thread.Sleep(2000);

                LogSuccess("Successfully tested diary reminder and milestones");
                CaptureScreenshot($"{pageName}_DiaryReminderMilestones_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to test diary reminder and milestones", ex);
                CaptureScreenshot($"{pageName}_DiaryReminderMilestones_Failure");
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




