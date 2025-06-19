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
    public class InfoSheetPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Info Sheet Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public InfoSheetPage(IWebDriver driver)
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

        // UI Elements - All elements on the Info Sheet Page
        public IWebElement InfoSheetTab => driver.FindElement(By.XPath("//div[contains(text(),'Info Sheet')]"));
        public IWebElement EditSecretaryBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_btnEditCa']"));
        public IWebElement EditFileRefBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_btnEditCaFileRef']"));
        public IWebElement CloseResignMatter => driver.FindElement(By.XPath("//img[@id='ctl00_ctl00_ctl00_C_C_C_PopupPanel_close']"));
        public IWebElement ReassignMatterToDrpdwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_C_ddlDestination']"));
        public IWebElement OnlyThisMatterRadioBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_rbOption_0']"));
        public IWebElement AllMattersRadioBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_rbOption_1']"));
        public IWebElement SaveBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_btnSave']"));
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_btnCancel']"));
        public IWebElement EditFileRefTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_TextBoxFileRef']"));
        public IWebElement CloseEditFileRef => driver.FindElement(By.XPath("//img[@id='ctl00_ctl00_ctl00_C_C_C_PanelBoxFileRef_close']"));
        public IWebElement EditRefFileSaveBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_ButtonSaveFileRef']"));
        public IWebElement EditFFileRefCancelBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_ButtonCancelFileRef']"));

        // Edit Secretary Method
        public void EditSecretary()
        {
            try
            {
                LogInfo("Starting to edit secretary");

                LogInfo("Clicking Info Sheet tab");
                wait.Until(driver => InfoSheetTab.Displayed);
                InfoSheetTab.Click();
                LogSuccess("Clicked Info Sheet tab");

                LogInfo("Clicking Edit Secretary button");
                wait.Until(driver => EditSecretaryBtn.Displayed);
                EditSecretaryBtn.Click();
                LogSuccess("Clicked Edit Secretary button");

                LogInfo("Selecting All Matters radio button");
                wait.Until(driver => AllMattersRadioBtn.Displayed);
                AllMattersRadioBtn.Click();
                LogSuccess("Selected All Matters radio button");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                Thread.Sleep(2000);

                LogSuccess("Successfully edited secretary");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to edit secretary", ex);
                CaptureScreenshot($"{pageName}_EditSecretary_Failure");
                throw;
            }
        }

        // Method to edit file reference
        public void EditFileRef(string editFileRef)
        {
            try
            {
                LogInfo($"Starting to edit file reference with value: {editFileRef}");

                LogInfo("Clicking Edit File Reference button");
                wait.Until(driver => EditFileRefBtn.Displayed);
                EditFileRefBtn.Click();
                LogSuccess("Clicked Edit File Reference button");

                LogInfo($"Entering file reference: {editFileRef}");
                wait.Until(driver => EditFileRefTxtBox.Displayed);
                EditFileRefTxtBox.Clear();
                EditFileRefTxtBox.SendKeys(editFileRef);
                LogSuccess($"Entered file reference: {editFileRef}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button for file reference");
                EditRefFileSaveBtn.Click();
                LogSuccess("Clicked Save button for file reference");

                Thread.Sleep(2000);

                LogSuccess("Successfully edited file reference");
            }
            catch (Exception ex)
            {
                LogFailure($"Failed to edit file reference with value: {editFileRef}", ex);
                CaptureScreenshot($"{pageName}_EditFileRef_Failure");
                throw;
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




