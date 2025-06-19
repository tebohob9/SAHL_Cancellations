using NUnit.Framework;
using Cancellations_Tests.BasePage;
using SAHL_Cancellations.Utilities;
using OpenQA.Selenium;
using System;
using System.Threading;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;

namespace SAHL_Cancellations.Pages
{
    public class AuditTrailPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Audit Trail Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public AuditTrailPage(IWebDriver driver)
        {
            this.driver = driver;  // Assigning the driver to the class variable

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

        // UI Elements - All elements on the Audit Trail page
        public IWebElement AuditTrailTab => driver.FindElement(By.XPath("//div[contains(text(),'Audit Trail')]"));
        public IWebElement CommentTextBox => driver.FindElement(By.XPath("//textarea[@id='ctl00_ctl00_C_C_txtComment']"));
        public IWebElement AddCommentBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_btnAddComment']"));
        public IWebElement SearchTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtSearch']"));
        public IWebElement SearchBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_btnSearch']"));
        public IWebElement DownloadBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_btnDownload']"));
        public IWebElement RefreshBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_btnRefresh']"));

        // Add a comment and search for it
        public void AddComment(string comment, string searchText)
        {
            try
            {
                LogInfo("Clicking on Audit Trail tab");
                AuditTrailTab.Click();
                LogSuccess("Clicked on Audit Trail tab");

                Thread.Sleep(2000);

                LogInfo($"Entering comment: {comment}");
                CommentTextBox.EnterText(comment);
                LogSuccess($"Entered comment: {comment}");

                LogInfo("Clicking Add Comment button");
                AddCommentBtn.Click();
                LogSuccess("Clicked Add Comment button");

                Thread.Sleep(2000);

                LogInfo($"Entering search text: {searchText}");
                SearchTextBox.EnterText(searchText);
                LogSuccess($"Entered search text: {searchText}");

                LogInfo("Clicking Search button");
                SearchBtn.Click();
                LogSuccess("Clicked Search button");

                Thread.Sleep(2000);

                LogInfo("Clicking Download button");
                DownloadBtn.Click();
                LogSuccess("Clicked Download button");

                LogSuccess("Successfully added comment, searched, and downloaded");
                CaptureScreenshot($"{pageName}_AddComment_Search_Download_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to add comment, search, or download", ex);
                CaptureScreenshot($"{pageName}_AddComment_Search_Download_Failure");
                throw;
            }
        }

        // Click the Refresh button
        public void ClickRefreshButton()
        {
            try
            {
                LogInfo("Clicking Refresh button");
                RefreshBtn.Click();
                LogSuccess("Clicked Refresh button");
                CaptureScreenshot($"{pageName}_RefreshButton_Clicked");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to click Refresh button", ex);
                CaptureScreenshot($"{pageName}_RefreshButton_Failure");
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




