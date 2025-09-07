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
    public class ConveyancerPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Conveyancer Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public ConveyancerPage(IWebDriver driver)
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

        // UI Elements - All elements on the Conveyancer page
        public IWebElement ConveyancerTab => driver.FindElement(By.XPath("(//a[@id='div_menu_conveyancer'])[1]"));
        public IWebElement DateOfSignature => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_txtDateOfSignature'])[1]"));
        public IWebElement TodayBtn => driver.FindElement(By.XPath("//button[@onclick='TodayClicked();']"));
        public IWebElement PlaceOfSignatureTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_txtPlaceOfSign'])[1]"));
        public IWebElement LogingFirmMyBranchRadioBtn => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_rdBranchLodgingFirm'])[1]"));
        public IWebElement LodgingFirmCorrespondentRadioBtn => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_chklodgementstamp'])[1]"));
        public IWebElement LodgmentStampChkBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_chklodgementstamp'])[1]"));
        public IWebElement LodgementNumberTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_txtLodgementNumber'])[1]"));
		public IWebElement ExternalConveyancerChkBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_chkExternalConveyancer'])[1]"));
		public IWebElement PreparingConveyancerDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_ddlPreparer'])[1]"));
        public IWebElement CommisonerOfOathsDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_ddlCommissioner'])[1]"));
        public IWebElement SaveBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_btnSave'])[1]"));
        public IWebElement CorrespondentNameTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_txtCorrespondentFirm_txtbox'])[1]"));
        public IWebElement CorrespondentNameRadioBtn => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_rdCorrespondentLodgingFirm'])[1]"));
        public IWebElement CorrespondentBranchDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_ddlCorrespondentBranch'])[1]"));
		public IWebElement ConveyencerTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_txtSurnameInitial'])[1]"));
		// Complete the My Branch details form with provided values
		public void SaveMyBranchDetails(string DateOf_Signature, string PlaceOfSignature, string LodgementNumber,
			string ConveyencerName)
        {
            try
            {
                LogInfo("Clicking on Conveyancer tab");
                ConveyancerTab.Click();
                LogSuccess("Clicked on Conveyancer tab");

                // Date of Signature is commented out in the original code
                // LogInfo($"Entering Date of Signature: {DateOf_Signature}");
                // DateOfSignature.SendKeys(DateOf_Signature);
                // LogSuccess($"Entered Date of Signature: {DateOf_Signature}");

                // Today button is commented out in the original code
                // LogInfo("Clicking Today button");
                // TodayBtn.Click();
                // LogSuccess("Clicked Today button");

                LogInfo($"Entering Place of Signature: {PlaceOfSignature}");
                PlaceOfSignatureTextBox.EnterText(PlaceOfSignature);
                LogSuccess($"Entered Place of Signature: {PlaceOfSignature}");

                Thread.Sleep(2000);

                LogInfo("Clicking Include Lodgment Stamp checkbox");
                LodgmentStampChkBox.Click();
                LogSuccess("Clicked Include Lodgment Stamp checkbox");

                Thread.Sleep(2000);

                LogInfo($"Entering Lodgement Number: {LodgementNumber}");
                LodgementNumberTextBox.EnterText(LodgementNumber);
                LogSuccess($"Entered Lodgement Number: {LodgementNumber}");

				
				LogInfo("Clicking Include External Conveyancer checkbox");
				ExternalConveyancerChkBox.Click();
				LogSuccess("Clicked Include External Conveyancer checkbox");

				LogInfo($"Entering Correspondent Name: {ConveyencerName}");
				ConveyencerTextBox.EnterText(ConveyencerName);
				LogSuccess($"Entered Correspondent Name: {ConveyencerName}");

				Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("My Branch details saved successfully");
                CaptureScreenshot($"{pageName}_MyBranchDetails_Saved");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to save My Branch details", ex);
                CaptureScreenshot($"{pageName}_MyBranchDetails_Failure");
                throw;
            }
        }

        // Complete the Correspondent details form with provided values
        public void SaveCorrespondentDetails(string PlaceOfSignature, string CorrespondentName, string CorrespondentBranch,
            string LodgementNumber, string CommisionerOfOaths)
        {
            try
            {
                Thread.Sleep(2000);

                LogInfo("Clicking on Conveyancer tab");
                ConveyancerTab.Click();
                LogSuccess("Clicked on Conveyancer tab");

                // Date of Signature is commented out in the original code
                // LogInfo($"Entering Date of Signature: {DateOf_Signature}");
                // DateOfSignature.SendKeys(DateOf_Signature);
                // LogSuccess($"Entered Date of Signature: {DateOf_Signature}");

                // Today button is commented out in the original code
                // LogInfo("Clicking Today button");
                // TodayBtn.Click();
                // LogSuccess("Clicked Today button");

                LogInfo($"Entering Place of Signature: {PlaceOfSignature}");
                PlaceOfSignatureTextBox.EnterText(PlaceOfSignature);
                LogSuccess($"Entered Place of Signature: {PlaceOfSignature}");

				Thread.Sleep(2000);

				LogInfo("Clicking Correspondent Name radio button");
                CorrespondentNameRadioBtn.Click();
                LogSuccess("Clicked Correspondent Name radio button");

                Thread.Sleep(5000);

    //            LogInfo($"Entering Correspondent Name: {CorrespondentName}");
    //            CorrespondentNameTextBox.EnterText(CorrespondentName);
    //            LogSuccess($"Entered Correspondent Name: {CorrespondentName}");

    //            Thread.Sleep(5000);

    //            LogInfo("Pressing Enter key in Correspondent Branch field");
				//CorrespondentBranchDrpDwn.SelectDropDownText(CorrespondentBranch);
    //            LogSuccess("Pressed Enter key in Correspondent Branch field");

                //LogInfo($"Selecting Correspondent Branch: {CorrespondentBranch}");
                //CorrespondentBranchDrpDwn.SelectDropDownText(CorrespondentBranch);
                //LogSuccess($"Selected Correspondent Branch: {CorrespondentBranch}");

                LogInfo("Clicking Include Lodgment Stamp checkbox");
                LodgmentStampChkBox.Click();
                LogSuccess("Clicked Include Lodgment Stamp checkbox");

                //LogInfo("Clicking Include Lodgment Stamp checkbox");
                //LodgmentStampChkBox.Click();
                //LogSuccess("Clicked Include Lodgment Stamp checkbox");

                Thread.Sleep(2000);

                LogInfo($"Entering Lodgement Number: {LodgementNumber}");
                LodgementNumberTextBox.EnterText(LodgementNumber);
                LogSuccess($"Entered Lodgement Number: {LodgementNumber}");

                // Preparer dropdown is commented out in the original code
                // LogInfo($"Selecting Preparer: {Preparer}");
                // PreparerDrpDwn.SelectDropDownText(Preparer);
                // LogSuccess($"Selected Preparer: {Preparer}");

                // Commissioner of Oaths dropdown is commented out in the original code
                // LogInfo($"Selecting Commissioner of Oaths: {CommisionerOfOaths}");
                // CommisonerOfOathsDrpDwn.SelectDropDownText(CommisionerOfOaths);
                // LogSuccess($"Selected Commissioner of Oaths: {CommisionerOfOaths}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Correspondent details saved successfully");
                CaptureScreenshot($"{pageName}_CorrespondentDetails_Saved");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to save Correspondent details", ex);
                CaptureScreenshot($"{pageName}_CorrespondentDetails_Failure");
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




