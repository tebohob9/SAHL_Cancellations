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
    public class InstructionDetailsPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Instruction Details Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public InstructionDetailsPage(IWebDriver driver)
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

        // UI Elements - All elements on the Instruction Details Page
        public IWebElement InstructionDetailsTab => driver.FindElement(By.XPath("//div[contains(text(),'Instruction Details')]"));
        public IWebElement TitleDeedNumberTxtBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_txtDeedOfTransfer_txtDeedOfTransferTextBox'])[1]"));
        public IWebElement DeedsOfficeDropdwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_C_C_ddlDeedsOffice']"));
        public IWebElement SaveBtn => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_C_btnSave']"));
        public IWebElement AddBtn => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_C_BtnAddMortgageBondDetails']"));
        public IWebElement CancellationAttorneyRadioBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_rdlSignatoryType_0']"));
        public IWebElement BankRadioBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_rdlSignatoryType_1']"));
        public IWebElement LegalBankDescriptionTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtLegalBank_txtbox']"));
        public IWebElement PANumberTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtPaNumber_txtbox']"));
        public IWebElement SignatoriesTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_dtListSignatories_ctl00_txtFooterSignatoryName']"));
        public IWebElement AddSignatoriesBtn => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_C_dtListSignatories_ctl00_btnAddNames']"));
        public IWebElement BondNumberTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtBondNumber']"));
        public IWebElement BondAmountTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtBondAmount_txtBondAmountTextBox']"));
        public IWebElement SaveSignatoriesBtn => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_C_btnSaveMortgageBond']"));
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//a[@id='ctl00_ctl00_C_C_btnCancelMortgageBond']"));

        // Complete Instruction Details Method
        public void CompleteInstructionDetails(string titleDeedNumber, string legalBankDescription, string paNumber,
            string signatories, string bondNumber, string bondAmount)
        {
            try
            {
                LogInfo("Starting to complete instruction details");

                LogInfo("Clicking Instruction Details tab");
                wait.Until(driver => InstructionDetailsTab.Displayed);
                InstructionDetailsTab.Click();
                LogSuccess("Clicked Instruction Details tab");

                LogInfo($"Entering Title Deed Number: {titleDeedNumber}");
                wait.Until(driver => TitleDeedNumberTxtBox.Displayed);
                TitleDeedNumberTxtBox.Clear();
                TitleDeedNumberTxtBox.SendKeys(titleDeedNumber);
                LogSuccess($"Entered Title Deed Number: {titleDeedNumber}");

                Thread.Sleep(2000);

                LogInfo("Clicking Add button");
                AddBtn.Click();
                LogSuccess("Clicked Add button");

                Thread.Sleep(2000);

                LogInfo($"Entering Legal Bank Description: {legalBankDescription}");
                wait.Until(driver => LegalBankDescriptionTxtBox.Displayed);
                LegalBankDescriptionTxtBox.Clear();
                LegalBankDescriptionTxtBox.SendKeys(legalBankDescription);
                LogSuccess($"Entered Legal Bank Description: {legalBankDescription}");

                LogInfo($"Entering PA Number: {paNumber}");
                PANumberTextBox.Clear();
                PANumberTextBox.SendKeys(paNumber);
                LogSuccess($"Entered PA Number: {paNumber}");

                LogInfo($"Entering Signatories: {signatories}");
                SignatoriesTxtBox.Clear();
                SignatoriesTxtBox.SendKeys(signatories);
                LogSuccess($"Entered Signatories: {signatories}");

                Thread.Sleep(2000);

                LogInfo("Clicking Add Signatories button");
                AddSignatoriesBtn.Click();
                LogSuccess("Clicked Add Signatories button");

                Thread.Sleep(2000);

                LogInfo($"Entering Bond Number: {bondNumber}");
                BondNumberTxtBox.Clear();
                BondNumberTxtBox.SendKeys(bondNumber);
                LogSuccess($"Entered Bond Number: {bondNumber}");

                LogInfo($"Entering Bond Amount: {bondAmount}");
                BondAmountTxtBox.Clear();
                BondAmountTxtBox.SendKeys(bondAmount);
                LogSuccess($"Entered Bond Amount: {bondAmount}");

                LogInfo("Clicking Save Signatories button");
                SaveSignatoriesBtn.Click();
                LogSuccess("Clicked Save Signatories button");

                Thread.Sleep(2000);

                LogSuccess("Successfully completed instruction details");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete instruction details", ex);
                CaptureScreenshot($"{pageName}_CompleteInstructionDetails_Failure");
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




