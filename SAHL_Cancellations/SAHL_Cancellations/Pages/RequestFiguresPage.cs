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
    public class RequestFiguresPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Request Cancellation Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public RequestFiguresPage(IWebDriver driver)
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
        public IWebElement RequestFigureslink => driver.FindElement(By.XPath("//a[normalize-space()='Request Figures']"));
        public IWebElement MattersTab => driver.FindElement(By.XPath("//ul[@class='nav nav-tabs nav-tabs-collapse hidden-xs']//li[1]//a[1]"));
		public IWebElement InstitutionDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_C_ddlInstitution'])[1]"));
		public IWebElement AccountNumberTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_C_txtAccountNo'])[1]"));
        public IWebElement TypeOfTransactionTypeDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_C_ddlCancellationType'])[1]"));
		public IWebElement SwitchingToDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_C_ddlSwitchingBank'])[1]")); 
        public IWebElement TitleDrpdwn => driver.FindElement(By.XPath("//select[@id='ctl00_C_ddlTitle']"));
        public IWebElement PartyTextBox => driver.FindElement(By.XPath("(//textarea[@id='ctl00_C_txtParty'])[1]"));
        public IWebElement PropertyTextBox => driver.FindElement(By.XPath("(//textarea[@id='ctl00_C_txtProperty'])[1]"));
        public IWebElement TransferAttorney => driver.FindElement(By.XPath("(//input[@id='ctl00_C_transferAttorneySelection_txtbox'])[1]"));
        public IWebElement TransferEmailTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_C_txtTransferEmail'])[1]"));
        public IWebElement TransferMobileTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_C_txtTransferMobile'])[1]"));
		public IWebElement RequestBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_C_btnSendRequest'])[1]"));
		public IWebElement CancelBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_C_btnCancel'])[1]"));


		// Click on the "Cancellations" tab
		public void ClickCancellationsTab()
        {
            try
            {
                LogInfo("Clicking on Request Cancellation button");
                RequestFigureslink.Click();
                LogSuccess("Clicked on Request Cancellation button");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to click on Request Cancellation button", ex);
                throw;
            }
        }

        // Complete the cancellation form with provided values
        public void CompleteForm(string Institution,
            string account_number, string TypeOfTransaction, string SwitchingTo,
            string party, string property,
            string TransferEmail, string TransferMobile)
        {
            try
            {
				LogInfo("Clicking on Request Cancellation button");
				RequestFigureslink.Click();
				LogSuccess("Clicked on Request Cancellation button");

                Thread.Sleep(2000);

				LogInfo($"Selecting cancellation type: {Institution}");
				InstitutionDrpDwn.SelectDropDownText(Institution);
				LogSuccess($"Selected cancellation type: {Institution}");

				Thread.Sleep(2000);

				LogInfo($"Entering account number: {account_number}");
                AccountNumberTextBox.EnterText(account_number);
                LogSuccess($"Entered account number: {account_number}");

				Thread.Sleep(2000);

				LogInfo($"Selecting cancellation type: {TypeOfTransaction}");
                TypeOfTransactionTypeDrpDwn.SelectDropDownText(TypeOfTransaction);
                LogSuccess($"Selected cancellation type: {TypeOfTransaction}");

				Thread.Sleep(2000);

				LogInfo($"Selecting cancellation type: {SwitchingTo}");
				SwitchingToDrpDwn.SelectDropDownText(SwitchingTo);
				LogSuccess($"Selected cancellation type: {SwitchingTo}");

				Thread.Sleep(2000);

				LogInfo($"Entering initials: {party}");
                PartyTextBox.EnterText(party);
                LogSuccess($"Entered initials: {party}");

				Thread.Sleep(2000);

				LogInfo($"Entering full name: {property}");
                PropertyTextBox.EnterText(property);
                LogSuccess($"Entered full name: {property}");

				Thread.Sleep(5000);

				LogInfo($"Entering full name: {TransferEmail}");
				TransferEmailTextBox.EnterText(TransferEmail);
				LogSuccess($"Entered full name: {TransferEmail}");

				Thread.Sleep(2000);

				LogInfo($"Entering full name: {TransferMobile}");
				TransferMobileTextBox.EnterText(TransferMobile);
				LogSuccess($"Entered full name: {TransferMobile}");

				Thread.Sleep(2000);


				LogInfo("Clicking Submit button");
                RequestBtn.Click();
                LogSuccess("Clicked Submit button");

                Thread.Sleep(1000);

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




