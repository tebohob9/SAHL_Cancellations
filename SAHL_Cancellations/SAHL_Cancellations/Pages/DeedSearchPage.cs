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
    public class DeedSearchPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Deed Search Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public DeedSearchPage(IWebDriver driver)
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

        // UI Elements - All elements on the Deed Search Page
        public IWebElement DeadSearchTab => driver.FindElement(By.XPath("//div[contains(text(),'Deed Search')]"));
        public IWebElement NewSearchBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_SearchWorksUserControl_cmdNewSearch']"));
        public IWebElement ShowOnlyImportableResultsCheckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_SearchWorksUserControl_cbUserResultsOnly']"));
        public IWebElement OnlyMyResultsCheckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_btnInsertSprint']"));
        public IWebElement SearchTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_SearchWorksUserControl_txtFilter']"));
        public IWebElement FirstCalender => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_SearchWorksUserControl_txtDateFrom']"));
        public IWebElement SecondCalender => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_txtInsertReminderDate']"));
        public IWebElement FindBtn => driver.FindElement(By.XPath("//input[@id='cmdSearchHistory']"));
        public IWebElement DownloadPdf => driver.FindElement(By.XPath("(//input[@id='btnExportSWPDF'])[1]"));
        public IWebElement PageOne => driver.FindElement(By.XPath("(//span[contains(text(),'1')])[9]"));
        public IWebElement PageTwo => driver.FindElement(By.XPath("//a[normalize-space()='2']"));
        public IWebElement ClearBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_SearchWorksUserControl_cmdClear']"));

        // Method to download PDF from Deed Search
        public void DownlaodPdf(string Search)
        {
            try
            {
                LogInfo("Starting Deed Search PDF download process");
                Thread.Sleep(2000);

                LogInfo("Clicking on Deed Search tab");
                DeadSearchTab.Click();
                LogSuccess("Clicked on Deed Search tab");

                LogInfo($"Entering search text: {Search}");
                SearchTxtBox.EnterText(Search);
                LogSuccess($"Entered search text: {Search}");

                Thread.Sleep(2000);

                LogInfo("Clicking Find button");
                FindBtn.Click();
                LogSuccess("Clicked Find button");

                Thread.Sleep(2000);

                LogInfo("Clicking Download PDF button");
                DownloadPdf.Click();
                LogSuccess("Clicked Download PDF button");

                Thread.Sleep(3000);

                LogInfo("Clicking New Search button");
                NewSearchBtn.Click();
                LogSuccess("Clicked New Search button");

                LogSuccess("Successfully completed Deed Search PDF download process");
                CaptureScreenshot($"{pageName}_DownloadPdf_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to download PDF from Deed Search", ex);
                CaptureScreenshot($"{pageName}_DownloadPdf_Failure");
                throw;
            }
        }

        // Method to initiate a new search
        public void ClickNewSearch()
        {
            try
            {
                LogInfo("Clicking New Search button");
                NewSearchBtn.Click();
                LogSuccess("Clicked New Search button");
                CaptureScreenshot($"{pageName}_NewSearch_Clicked");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to click New Search button", ex);
                CaptureScreenshot($"{pageName}_NewSearch_Failure");
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




