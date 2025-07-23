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
    public class AccountsPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Accounts Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public AccountsPage(IWebDriver driver)
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
            }
        }

        // UI Elements - All elements on the Accounts page
        public IWebElement AccountsTab => driver.FindElement(By.XPath("(//a[@id='div_menu_accounts'])[1]"));
        public IWebElement ExportBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_FinalAccount1_lnkExport'])[1]"));
        public IWebElement PaymethodDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_C_C_dlSOA_ctl01_varPaymentMethod']"));
        public IWebElement PayDateTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_dlSOA_ctl01_txtPaymentDate']"));
        public IWebElement TodayBtn => driver.FindElement(By.XPath("//button[normalize-space()='Today']"));
        public IWebElement RecalculateBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_dlSOA_ctl01_btnCalculate']"));
        public IWebElement DeleteBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_dlSOA_ctl01_btnDelete']"));
        public IWebElement MoveUpBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_dlSOA_ctl01_ImageButton1']"));
        public IWebElement MoveDownBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_dlSOA_ctl01_ImageButton2']"));
        public IWebElement EditBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_dlSOA_ctl01_ImageButton3']"));
        public IWebElement RefreshBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_btnRefresh']"));
        public IWebElement AddItemBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_FinalAccount1_btnAdditionalFees'])[1]"));
        public IWebElement SaveBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_btnSave'])[1]"));
        public IWebElement BankDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_ddlBanks'])[1]"));
        public IWebElement DescriptionTxtBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_FinalAccount1_txtAdditionalCostDesc'])[1]"));
        public IWebElement ItemTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtAdditionalCostDesc']"));
        public IWebElement ProFormaCheckBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_FinalAccount1_chkProformaCost'])[1]"));
        public IWebElement DebitTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_FinalAccount1_txtDebitFee_txtDebitFeeTextBox'])[1]"));
        public IWebElement CreditTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_FinalAccount1_txtCreditFee_txtCreditFeeTextBox'])[1]"));
        public IWebElement VatableBtn => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_FinalAccount1_chkIsAdditionalVatable'])[1]"));
        public IWebElement PaymentDateTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtPaymentDate']"));
        public IWebElement AddItemSaveBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_FinalAccount1_btnInsertGrid'])[1]"));
        public IWebElement VatableCheckBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_FinalAccount1_chkIsAdditionalVatable'])[1]"));
        public IWebElement SaveAddBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_btnSave'])[1]"));
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_btnClose']"));

        // Complete the Add Item form with provided values
        public void CompleteAddItemForm(string Description, string Debit, string Credit, string PaymentMethod)
        {
            try
            {
                LogInfo($"Clicking on Accounts tab");
                AccountsTab.Click();
                LogSuccess($"Clicked on Accounts tab");

                LogInfo($"Clicking on Add Item button");
                AddItemBtn.Click();
                LogSuccess($"Clicked on Add Item button");

                LogInfo($"Entering item description: {Description}");
                DescriptionTxtBox .EnterText(Description);
                LogSuccess($"Entered item description: {Description}");

				LogInfo($"Clicking on ProForma check box");
				ProFormaCheckBox.Click();
				LogSuccess($"Clicked on ProForma check box");

				LogInfo($"Entering debit amount: {Debit}");
				DebitTextBox.EnterText(Debit);
				LogSuccess($"Entered debit amount: {Debit}");

				LogInfo($"Entering credit amount: {Credit}");
                CreditTextBox.EnterText(Credit);
                LogSuccess($"Entered credit amount: {Credit}");

                LogInfo($"Clicking on Vatable check box");
                VatableCheckBox.Click();
                LogSuccess($"Clicked on Vatable check box");

                Thread.Sleep(2000);

                LogInfo($"Clicking Save button");
                AddItemSaveBtn.Click();
                LogSuccess($"Clicked Save button");

                LogInfo($"Add Item form completed successfully");
                CaptureScreenshot($"{pageName}_AddItemForm_Completed");
            }
            catch (Exception ex)
            {
                LogFailure($"Failed to complete Add Item form", ex);
                CaptureScreenshot($"{pageName}_AddItemForm_Failure");
                throw;
            }
        }

        public void ClickRefreshBtn()
        {
            try
            {
                LogInfo($"Clicking Refresh button");
                RefreshBtn.Click();
                LogSuccess($"Clicked Refresh button");
                CaptureScreenshot($"{pageName}_RefreshButton_Clicked");
            }
            catch (Exception ex)
            {
                LogFailure($"Failed to click Refresh button", ex);
                CaptureScreenshot($"{pageName}_RefreshButton_Failure");
                throw;
            }
        }

        public void ClickExportBtn()
        {
            try
            {
                LogInfo($"Clicking Export button");
                ExportBtn.Click();
                LogSuccess($"Clicked Export button");
                CaptureScreenshot($"{pageName}_ExportButton_Clicked");
            }
            catch (Exception ex)
            {
                LogFailure($"Failed to click Export button", ex);
                CaptureScreenshot($"{pageName}_ExportButton_Failure");
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




