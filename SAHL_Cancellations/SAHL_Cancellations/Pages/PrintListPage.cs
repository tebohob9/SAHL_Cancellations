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
    public class PrintListPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Print List Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public PrintListPage(IWebDriver driver)
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

        // UI Elements - All elements on the Print List page
        public IWebElement PrintListTab => driver.FindElement(By.XPath("//div[contains(text(),'Print List')]"));
        public IWebElement CancellationFiguresChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl00_ckDoc']"));
        public IWebElement ConsentToCancellationChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl01_ckDoc']"));
        public IWebElement Letter_InitialLetterCheckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl02_ckDoc']"));
        public IWebElement Letter_InstructionToLodgeCheckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl03_ckDoc']"));
        public IWebElement Account_ProFormaStatementChckBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl04_ckDoc'])[1]"));
        public IWebElement FormLLLChckBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl05_ckDoc'])[1]"));
        public IWebElement FormLLLLink => driver.FindElement(By.XPath("(//a[normalize-space()='Form LLL'])[1]"));
        public IWebElement RefundInstruction_HomeLoanUnderCancellationChckBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl06_ckDoc'])[1]"));
        public IWebElement RefundInstruction_MortgageBondChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl07_ckDoc']"));
        public IWebElement AbsaHomeLoansChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl08_ckDoc']"));
        public IWebElement PopiConsentChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl09_ckDoc']"));
        public IWebElement ApplicationForCopyOfLostDeedChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup7_rptGroup_ctl00_ckDoc']"));
        public IWebElement ConsentByBankChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup7_rptGroup_ctl01_ckDoc']"));
        public IWebElement ApplicationForCancellationLostBondChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup7_rptGroup_ctl02_ckDoc']"));
        public IWebElement NoticeOfApplicationChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup7_rptGroup_ctl03_ckDoc']"));
        public IWebElement Account_ProFormaStatement => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_C_PrintListGroup2_rptGroup_ctl04_ckDoc'])[1]"));
        public IWebElement UpploadAdditionalDocumentsBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_btnUploadAdditional']"));
        public IWebElement GenerateSelectedBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_btnGenerateSelected']"));
        public IWebElement MoveUpBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_dlSOA_ctl01_ImageButton1']"));

        // Generate all selected documents
        public void GenerateSelected()
        {
            try
            {
                LogInfo("Starting to generate selected documents");

                LogInfo("Clicking on Print List tab");
                PrintListTab.Click();
                LogSuccess("Clicked on Print List tab");

                

                // Select all checkboxes for documents
                LogInfo("Selecting Cancellation Figures checkbox");
                if (!CancellationFiguresChckBox.Selected)
                {
                    CancellationFiguresChckBox.Click();
                    LogSuccess("Selected Cancellation Figures checkbox");
                }

                LogInfo("Selecting Consent to Cancellation checkbox");
                if (!ConsentToCancellationChckBox.Selected)
                {
                    ConsentToCancellationChckBox.Click();
                    LogSuccess("Selected Consent to Cancellation checkbox");
                }

                LogInfo("Selecting Initial Letter checkbox");
                if (!Letter_InitialLetterCheckBox.Selected)
                {
                    Letter_InitialLetterCheckBox.Click();
                    LogSuccess("Selected Initial Letter checkbox");
                }

                LogInfo("Selecting Instruction to Lodge checkbox");
                if (!Letter_InstructionToLodgeCheckBox.Selected)
                {
                    Letter_InstructionToLodgeCheckBox.Click();
                    LogSuccess("Selected Instruction to Lodge checkbox");
                }

                LogInfo("Selecting Pro Forma Statement checkbox");
                if (!Account_ProFormaStatementChckBox.Selected)
                {
                    Account_ProFormaStatementChckBox.Click();
                    LogSuccess("Selected Pro Forma Statement checkbox");
                }

                LogInfo("Selecting Form LLL checkbox");
                if (!FormLLLChckBox.Selected)
                {
                    FormLLLChckBox.Click();
                    LogSuccess("Selected Form LLL checkbox");
                }

                LogInfo("Selecting Refund Instruction - Home Loan Under Cancellation checkbox");
                if (!RefundInstruction_HomeLoanUnderCancellationChckBox.Selected)
                {
                    RefundInstruction_HomeLoanUnderCancellationChckBox.Click();
                    LogSuccess("Selected Refund Instruction - Home Loan Under Cancellation checkbox");
                }

                LogInfo("Selecting Refund Instruction - Mortgage Bond checkbox");
                if (!RefundInstruction_MortgageBondChckBox.Selected)
                {
                    RefundInstruction_MortgageBondChckBox.Click();
                    LogSuccess("Selected Refund Instruction - Mortgage Bond checkbox");
                }

                LogInfo("Selecting Absa Home Loans checkbox");
                if (!AbsaHomeLoansChckBox.Selected)
                {
                    AbsaHomeLoansChckBox.Click();
                    LogSuccess("Selected Absa Home Loans checkbox");
                }

                LogInfo("Selecting POPI Consent checkbox");
                if (!PopiConsentChckBox.Selected)
                {
                    PopiConsentChckBox.Click();
                    LogSuccess("Selected POPI Consent checkbox");
                }

                LogInfo("Selecting Application for Copy of Lost Deed checkbox");
                if (!ApplicationForCopyOfLostDeedChckBox.Selected)
                {
                    ApplicationForCopyOfLostDeedChckBox.Click();
                    LogSuccess("Selected Application for Copy of Lost Deed checkbox");
                }

                LogInfo("Selecting Consent by Bank checkbox");
                if (!ConsentByBankChckBox.Selected)
                {
                    ConsentByBankChckBox.Click();
                    LogSuccess("Selected Consent by Bank checkbox");
                }

                LogInfo("Selecting Application for Cancellation Lost Bond checkbox");
                if (!ApplicationForCancellationLostBondChckBox.Selected)
                {
                    ApplicationForCancellationLostBondChckBox.Click();
                    LogSuccess("Selected Application for Cancellation Lost Bond checkbox");
                }

                LogInfo("Selecting Notice of Application checkbox");
                if (!NoticeOfApplicationChckBox.Selected)
                {
                    NoticeOfApplicationChckBox.Click();
                    LogSuccess("Selected Notice of Application checkbox");
                }

                Thread.Sleep(2000); // Wait for UI to update

                // Click the Generate Selected button
                LogInfo("Clicking Generate Selected button");
                GenerateSelectedBtn.Click();
                LogSuccess("Clicked Generate Selected button");

                Thread.Sleep(2000); // Wait for generation to complete

                LogSuccess("Successfully generated all selected documents");
                CaptureScreenshot($"{pageName}_GenerateSelected_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to generate selected documents", ex);
                CaptureScreenshot($"{pageName}_GenerateSelected_Failure");
                throw;
            }
        }

        // Generate only Pro Forma document
        public void GenerateProForma()
        {
            try
            {
                LogInfo("Starting to generate Pro Forma document");

                // Uncheck all checkboxes first to ensure only Pro Forma is selected
                LogInfo("Unchecking all document checkboxes");
                UncheckAllDocuments();
                LogSuccess("Unchecked all document checkboxes");

                // Select only the Pro Forma Statement checkbox
                LogInfo("Selecting Pro Forma Statement checkbox");
                if (!Account_ProFormaStatementChckBox.Selected)
                {
                    Account_ProFormaStatementChckBox.Click();
                    LogSuccess("Selected Pro Forma Statement checkbox");
                }

                Thread.Sleep(2000); // Wait for UI to update

                // Click the Generate Selected button
                LogInfo("Clicking Generate Selected button");
                GenerateSelectedBtn.Click();
                LogSuccess("Clicked Generate Selected button");

                Thread.Sleep(2000); // Wait for generation to complete

                LogSuccess("Successfully generated Pro Forma document");
                CaptureScreenshot($"{pageName}_GenerateProForma_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to generate Pro Forma document", ex);
                CaptureScreenshot($"{pageName}_GenerateProForma_Failure");
                throw;
            }
        }

        // Helper method to uncheck all document checkboxes
        private void UncheckAllDocuments()
        {
            try
            {
                LogInfo("Unchecking all document checkboxes");

                // Uncheck all checkboxes if they are selected
                if (CancellationFiguresChckBox.Selected) CancellationFiguresChckBox.Click();
                if (ConsentToCancellationChckBox.Selected) ConsentToCancellationChckBox.Click();
                if (Letter_InitialLetterCheckBox.Selected) Letter_InitialLetterCheckBox.Click();
                if (Letter_InstructionToLodgeCheckBox.Selected) Letter_InstructionToLodgeCheckBox.Click();
                if (Account_ProFormaStatementChckBox.Selected) Account_ProFormaStatementChckBox.Click();
                if (FormLLLChckBox.Selected) FormLLLChckBox.Click();
                if (RefundInstruction_HomeLoanUnderCancellationChckBox.Selected) RefundInstruction_HomeLoanUnderCancellationChckBox.Click();
                if (RefundInstruction_MortgageBondChckBox.Selected) RefundInstruction_MortgageBondChckBox.Click();
                if (AbsaHomeLoansChckBox.Selected) AbsaHomeLoansChckBox.Click();
                if (PopiConsentChckBox.Selected) PopiConsentChckBox.Click();
                if (ApplicationForCopyOfLostDeedChckBox.Selected) ApplicationForCopyOfLostDeedChckBox.Click();
                if (ConsentByBankChckBox.Selected) ConsentByBankChckBox.Click();
                if (ApplicationForCancellationLostBondChckBox.Selected) ApplicationForCancellationLostBondChckBox.Click();
                if (NoticeOfApplicationChckBox.Selected) NoticeOfApplicationChckBox.Click();

                LogSuccess("Successfully unchecked all document checkboxes");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to uncheck all document checkboxes", ex);
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




