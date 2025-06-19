using NUnit.Framework;
using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using SAHL_Cancellations.Utilities;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;

namespace SAHL_Cancellations.Pages
{
    public class InboxPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Inbox Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public InboxPage(IWebDriver driver)
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

        // UI Elements - All elements on the Inbox Page
        public IWebElement InboxTab => driver.FindElement(By.XPath("//div[contains(text(),'Inbox')]"));
        public IWebElement Message => driver.FindElement(By.XPath("(//div[contains(text(),'2534 - CANCELLATION FIGURES NOT YET ISSUED')])[1]"));
        public IWebElement MarkAsReadChckBx => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_chkMarkAsRead']"));
        public IWebElement CloseMessageBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_BtnClose']"));

        // Read Inbox Message Method
        public void ReadInboxMessage()
        {
            try
            {
                LogInfo("Starting to read inbox message");

                LogInfo("Clicking Inbox tab");
                wait.Until(driver => InboxTab.Displayed);
                InboxTab.Click();
                LogSuccess("Clicked Inbox tab");

                Thread.Sleep(1000); // Short wait for inbox messages to load

                LogInfo("Checking if message exists");
                if (IsElementPresent(By.XPath("(//div[contains(text(),'2534 - CANCELLATION FIGURES NOT YET ISSUED')])[1]")))
                {
                    LogInfo("Clicking on message");
                    Message.Click();
                    LogSuccess("Clicked on message");

                    Thread.Sleep(2000);

                    LogInfo("Marking message as read");
                    MarkAsReadChckBx.Click();
                    LogSuccess("Marked message as read");

                    Thread.Sleep(2000);

                    LogInfo("Closing message");
                    CloseMessageBtn.Click();
                    LogSuccess("Closed message");

                    LogSuccess("Successfully read inbox message");
                }
                else
                {
                    LogInfo("No messages found in inbox");
                }
            }
            catch (Exception ex)
            {
                LogFailure("Failed to read inbox message", ex);
                CaptureScreenshot($"{pageName}_ReadInboxMessage_Failure");
                throw;
            }
        }

        // Helper method to check if an element exists
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        #region Helper Methods
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




