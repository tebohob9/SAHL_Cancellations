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
    public class RequestCancellationPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Request Cancellation Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public RequestCancellationPage(IWebDriver driver)
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

        // UI Elements - All elements on the Request Cancellation page
        public IWebElement RequestCancellationButton => driver.FindElement(By.XPath("//a[normalize-space()='Request Cancellation']"));
        public IWebElement CancellationsTab => driver.FindElement(By.XPath("//div[normalize-space()='Cancellations']"));
        public IWebElement AccountNumberTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_C_txtAccountNumber']"));
        public IWebElement CancellationsTypeDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_C_ddlCancellationType']"));
        public IWebElement TitleDrpdwn => driver.FindElement(By.XPath("//select[@id='ctl00_C_ddlTitle']"));
        public IWebElement InitialsTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_C_txtInitials']"));
        public IWebElement FullNameTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_C_txtFullName']"));
        public IWebElement RegionDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_C_ddlRegion']"));
        public IWebElement CancellationReasonDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_C_ddlReason']"));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//input[@id='ctl00_C_btnSubmit']"));

        // Click on the "Cancellations" tab
        public void ClickCancellationsTab()
        {
            try
            {
                LogInfo("Clicking on Request Cancellation button");
                RequestCancellationButton.Click();
                LogSuccess("Clicked on Request Cancellation button");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to click on Request Cancellation button", ex);
                throw;
            }
        }

        // Complete the cancellation form with provided values
        public void CompleteForm(string account_number, string cancellation_type, string title, string initials,
            string full_name, string region, string cancellation_reason)
        {
            try
            {
                LogInfo($"Completing form with Account: {account_number}, Type: {cancellation_type}");

                LogInfo($"Entering account number: {account_number}");
                AccountNumberTextBox.EnterText(account_number);
                LogSuccess($"Entered account number: {account_number}");

                LogInfo($"Selecting cancellation type: {cancellation_type}");
                CancellationsTypeDrpDwn.SelectDropDownText(cancellation_type);
                LogSuccess($"Selected cancellation type: {cancellation_type}");

                LogInfo($"Selecting title: {title}");
                TitleDrpdwn.SelectDropDownText(title);
                LogSuccess($"Selected title: {title}");

                LogInfo($"Entering initials: {initials}");
                InitialsTextBox.EnterText(initials);
                LogSuccess($"Entered initials: {initials}");

                LogInfo($"Entering full name: {full_name}");
                FullNameTextBox.EnterText(full_name);
                LogSuccess($"Entered full name: {full_name}");

                LogInfo($"Selecting region: {region}");
                RegionDrpDwn.SelectDropDownText(region);
                LogSuccess($"Selected region: {region}");

                Thread.Sleep(2000);

                LogInfo($"Selecting cancellation reason: {cancellation_reason}");
                CancellationReasonDrpDwn.SelectDropDownText(cancellation_reason);
                LogSuccess($"Selected cancellation reason: {cancellation_reason}");

                LogInfo("Clicking Submit button");
                SubmitButton.Click();
                LogSuccess("Clicked Submit button");

                Thread.Sleep(1000);

                LogInfo("Clicking Cancellations tab");
                CancellationsTab.Click();
                LogSuccess("Clicked Cancellations tab");

                LogSuccess("Form completed successfully");
                CaptureScreenshot($"{pageName}_FormCompleted");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete form", ex);
                CaptureScreenshot($"{pageName}_CompleteForm_Failure");
                throw;
            }
        }

        // Click the Submit button
        public void ClickSubmitButton()
        {
            try
            {
                LogInfo("Clicking Submit button");
                SubmitButton.Click();
                LogSuccess("Clicked Submit button");
                CaptureScreenshot($"{pageName}_SubmitButton_Clicked");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to click Submit button", ex);
                CaptureScreenshot($"{pageName}_SubmitButton_Failure");
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




