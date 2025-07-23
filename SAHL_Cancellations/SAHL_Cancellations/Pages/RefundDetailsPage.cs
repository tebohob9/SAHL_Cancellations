using NUnit.Framework;
using Cancellations_Tests.BasePage;
using SAHL_Cancellations.Utilities;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;

namespace SAHL_Cancellations.Pages
{
    public class RefundDetailsPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Refund Details Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public RefundDetailsPage(IWebDriver driver)
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

        // UI Elements - All elements on the Refund Details page
        public IWebElement RefundDetailsTab => driver.FindElement(By.XPath("(//a[@id='div_menu_refunddetails'])[1]"));
		public IWebElement BeneficiaryTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtBeneficiaryAccount']")); 
        public IWebElement BankTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_txtBank'])[1]"));
        public IWebElement BranchNameTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtBranchName']"));
        public IWebElement BranchCodeTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtBranchCode']"));
		public IWebElement TelephoneTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtTelephone']"));
		public IWebElement AccountHolderTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_TxtAccountHolder_TxtAccountHolderTextBox']")); 
        public IWebElement AccountNumberTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtAccountNumber']"));
        public IWebElement AccountTypeDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_C_C_ddlVAR_AccountType']"));
        public IWebElement EmailTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtEmail']"));
        public IWebElement SaveBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_btnSaveRefundDetails'])[1]"));

        // Complete the refund details form with provided values
        public void CompleteRefundDetailsForm(string Beneficiary, string bank, string accountNumber, 
            string branchName, string branchCode, string Telephone,
            string email)
        {
            try
            {
                LogInfo("Starting to complete refund details form");

                LogInfo("Clicking Refund Details tab");
                wait.Until(driver => RefundDetailsTab.Displayed);
                RefundDetailsTab.Click();
                LogSuccess("Clicked Refund Details tab");

				LogInfo($"Entering Beneficiary: {Beneficiary}");
				wait.Until(driver => BeneficiaryTxtBox.Displayed);
				BeneficiaryTxtBox.Clear();
				BeneficiaryTxtBox.SendKeys(Beneficiary);
				LogSuccess($"Entered Beneficiary: {Beneficiary}");

				LogInfo($"Entering Bank: {bank}");
                wait.Until(driver => BankTextBox.Displayed);
                BankTextBox.Clear();
                BankTextBox.SendKeys(bank);
                LogSuccess($"Entered Bank: {bank}");

				LogInfo($"Entering Account Number: {accountNumber}");
				AccountNumberTxtBox.Clear();
				AccountNumberTxtBox.SendKeys(accountNumber);
				LogSuccess($"Entered Account Number: {accountNumber}");

				LogInfo($"Entering Branch Name: {branchName}");
                BranchNameTextBox.Clear();
                BranchNameTextBox.SendKeys(branchName);
                LogSuccess($"Entered Branch Name: {branchName}");

                LogInfo($"Entering Branch Code: {branchCode}");
                BranchCodeTxtBox.Clear();
                BranchCodeTxtBox.SendKeys(branchCode);
                LogSuccess($"Entered Branch Code: {branchCode}");

				LogInfo($"Entering Telephone: {Telephone}");
				TelephoneTxtBox.Clear();
				TelephoneTxtBox.SendKeys(Telephone);
				LogSuccess($"Entered Telephone: {Telephone}");

                LogInfo($"Entering Email: {email}");
                EmailTxtBox.Clear();
                EmailTxtBox.SendKeys(email);
                LogSuccess($"Entered Email: {email}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

				Thread.Sleep(10000);

				LogSuccess("Successfully completed refund details form");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete refund details form", ex);
                CaptureScreenshot($"{pageName}_CompleteRefundDetailsForm_Failure");
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




