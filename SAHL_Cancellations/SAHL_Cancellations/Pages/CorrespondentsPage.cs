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
    public class CorrespondentsPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Correspondents Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public CorrespondentsPage(IWebDriver driver)
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

        // UI Elements - All elements on the Correspondents Page
        public IWebElement CorrespondentsTab => driver.FindElement(By.XPath("//div[contains(text(),'Correspondents')]"));
        public IWebElement SelectCheckbox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_GridView1_ctl02_chkSelected']"));
        public IWebElement EditCorreespondent => driver.FindElement(By.XPath("//img[@id='ctl00_ctl00_ctl00_C_C_C_GridView1_ctl02_btnEdit']"));
        public IWebElement EmailBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_btnEmailSelected']"));
        public IWebElement SmsBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_btnSMSSelected']"));
        public IWebElement AddNewBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_btnNew']"));
        public IWebElement SearchBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_DetailsView1_txtInsertReminderDate']"));
        public IWebElement ContactDetailsTab => driver.FindElement(By.XPath("//div[contains(text(),'Contact Details')]"));
        public IWebElement EntityTypeDrpdwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_C_EntityMappingForCorrespondence1_ddlVarEntityType']"));
        public IWebElement ContactPerson => driver.FindElement(By.XPath("//input[@id='txtCOR_Contact']"));
        public IWebElement ContactIdNumber => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_EntityMappingForCorrespondence1_txtCOR_ContactIDNo']"));
        public IWebElement TelWork => driver.FindElement(By.XPath("//input[@id='txtCOR_WorkTelNumber']"));
        public IWebElement TelCell => driver.FindElement(By.XPath("//input[@id='txtCOR_CellNumber']"));
        public IWebElement TelHome => driver.FindElement(By.XPath("//input[@id='txtCOR_HomeTelNumber']"));
        public IWebElement FaxTel => driver.FindElement(By.XPath("//input[@id='txtCOR_FaxTelNumber']"));
        public IWebElement EmailField => driver.FindElement(By.XPath("//input[@id='txtCOR_EmailAddressTextBox']"));
        public IWebElement LetterCaptionField => driver.FindElement(By.XPath("//input[@id='txtCOR_LetterCaption']"));
        public IWebElement CompanyField => driver.FindElement(By.XPath("//input[@id='txtCOR_Company']"));
        public IWebElement CompanyRegNo => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_EntityMappingForCorrespondence1_txt_COR_CompanyRegNumber']"));
        public IWebElement BranchField => driver.FindElement(By.XPath("//input[@id='txtCOR_Branch']"));
        public IWebElement DocexField => driver.FindElement(By.XPath("//input[@id='txtCOR_DocexNumber']"));
        public IWebElement SaveBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_EntityMappingForCorrespondence1_btnSubmit']"));
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_EntityMappingForCorrespondence1_Button2']"));
        public IWebElement AddressDetailsTab => driver.FindElement(By.XPath("//div[contains(text(),'Address Details')]"));
        public IWebElement PhysicalAddressLine1 => driver.FindElement(By.XPath("//input[@id='txtCOR_PhysicalAddressLine1']"));
        public IWebElement PhysicalAddressLine2 => driver.FindElement(By.XPath("//input[@id='txtCOR_PhysicalAddressLine2']"));
        public IWebElement PhysicalAddressLine3 => driver.FindElement(By.XPath("//input[@id='txtCOR_Suburb']"));
        public IWebElement City => driver.FindElement(By.XPath("//input[@id='txtCOR_City']"));
        public IWebElement PhysicalAddressCode => driver.FindElement(By.XPath("//input[@id='txtCOR_PhysicalAddressCode']"));
        public IWebElement Province => driver.FindElement(By.XPath("//select[@id='varProvince']"));
        public IWebElement Country => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_C_EntityMappingForCorrespondence1_ddlCountry']"));
        public IWebElement POBoxLine1 => driver.FindElement(By.XPath("//input[@id='txtCOR_POBoxLine1']"));
        public IWebElement POBoxLine2 => driver.FindElement(By.XPath("//input[@id='txtCOR_POBoxLine2']"));
        public IWebElement POBoxLine3 => driver.FindElement(By.XPath("//input[@id='txtCOR_POBoxLine3']"));
        public IWebElement PostalCode => driver.FindElement(By.XPath("//input[@id='txtCOR_PostalCode']"));
        public IWebElement TypeCheckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_GridView1_ctl02_chkSelected']"));
        public IWebElement Type2CheckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_C_GridView1_ctl03_chkSelected']"));
        public IWebElement Email2Btn => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_C_btnEmailSelected'])[1]"));
        public IWebElement Sms2Btn => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_C_btnSMSSelected'])[1]"));
        public IWebElement SubjectTextBox => driver.FindElement(By.XPath("(//input[@id='subject'])[1]"));
        public IWebElement LettersTab => driver.FindElement(By.XPath("//div[contains(text(),'Letters')]"));
        public IWebElement BondCancellationLink => driver.FindElement(By.XPath("//a[normalize-space()='Bond Cancellation']"));
        public IWebElement ParagraphsLink => driver.FindElement(By.XPath("//div[contains(text(),'Paragraphs')]"));
        public IWebElement PrintListLink => driver.FindElement(By.XPath("//div[@class='tab'][normalize-space()='Print List']"));
        public IWebElement ComposeLink => driver.FindElement(By.XPath("//a[@id='aCompose']"));
        public IWebElement DraftsLink => driver.FindElement(By.XPath("//a[@id='aDrafts']"));
        public IWebElement SentItemsLink => driver.FindElement(By.XPath("//a[@id='aSent']"));
        public IWebElement PreviewBtn => driver.FindElement(By.XPath("//input[@id='btnPreview']"));
        public IWebElement SaveDraftBtn => driver.FindElement(By.XPath("//input[@id='btnSaveDraft']"));
        public IWebElement SendBtn => driver.FindElement(By.XPath("//input[@id='btnSend']"));
        public IWebElement AttatchFromHardDriveLink => driver.FindElement(By.XPath("//span[@class='link']"));
        public IWebElement ChooseFileBtn => driver.FindElement(By.XPath("//input[@id='FileUploadControl']"));
        public IWebElement SmsMessageTextBox => driver.FindElement(By.XPath("//textarea[@id='ctl00_ctl00_ctl00_C_C_C_txtMessage']"));
        public IWebElement SendSmsBtn => driver.FindElement(By.XPath("//input[@id='btnsend']"));

        // Complete Contact Details form
        public void CompleteContactDetails(string EntityType, string Contact_Person, string Contact_IDNo, string Tel_Work,
            string Tel_Cell, string Tel_Home, string Fax, string Email, string Letter_Caption, string Company, string Company_RegNo,
            string Branch, string Docex)
        {
            try
            {
                LogInfo("Clicking on Correspondents tab");
                CorrespondentsTab.Click();
                LogSuccess("Clicked on Correspondents tab");

                LogInfo("Clicking Add New button");
                AddNewBtn.Click();
                LogSuccess("Clicked Add New button");

                LogInfo($"Selecting Entity Type: {EntityType}");
                EntityTypeDrpdwn.SelectDropDownText(EntityType);
                LogSuccess($"Selected Entity Type: {EntityType}");

                LogInfo($"Entering Contact Person: {Contact_Person}");
                ContactPerson.EnterText(Contact_Person);
                LogSuccess($"Entered Contact Person: {Contact_Person}");

                LogInfo($"Entering Contact ID Number: {Contact_IDNo}");
                ContactIdNumber.EnterText(Contact_IDNo);
                LogSuccess($"Entered Contact ID Number: {Contact_IDNo}");

                LogInfo($"Entering Work Telephone: {Tel_Work}");
                TelWork.EnterText(Tel_Work);
                LogSuccess($"Entered Work Telephone: {Tel_Work}");

                LogInfo($"Entering Cell Telephone: {Tel_Cell}");
                TelCell.EnterText(Tel_Cell);
                LogSuccess($"Entered Cell Telephone: {Tel_Cell}");

                LogInfo($"Entering Home Telephone: {Tel_Home}");
                TelHome.EnterText(Tel_Home);
                LogSuccess($"Entered Home Telephone: {Tel_Home}");

                LogInfo($"Entering Fax: {Fax}");
                FaxTel.EnterText(Fax);
                LogSuccess($"Entered Fax: {Fax}");

                LogInfo($"Entering Email: {Email}");
                EmailField.EnterText(Email);
                LogSuccess($"Entered Email: {Email}");

                LogInfo($"Entering Letter Caption: {Letter_Caption}");
                LetterCaptionField.EnterText(Letter_Caption);
                LogSuccess($"Entered Letter Caption: {Letter_Caption}");

                LogInfo($"Entering Company: {Company}");
                CompanyField.EnterText(Company);
                LogSuccess($"Entered Company: {Company}");

                LogInfo($"Entering Company Registration Number: {Company_RegNo}");
                CompanyRegNo.EnterText(Company_RegNo);
                LogSuccess($"Entered Company Registration Number: {Company_RegNo}");

                LogInfo($"Entering Branch: {Branch}");
                BranchField.EnterText(Branch);
                LogSuccess($"Entered Branch: {Branch}");

                LogInfo($"Entering Docex: {Docex}");
                DocexField.EnterText(Docex);
                LogSuccess($"Entered Docex: {Docex}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                Thread.Sleep(2000);

                LogSuccess("Contact details completed successfully");
                CaptureScreenshot($"{pageName}_ContactDetails_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete contact details", ex);
                CaptureScreenshot($"{pageName}_ContactDetails_Failure");
                throw;
            }
        }

        // Complete Address Details form
        public void CompleteAddressDetailsForm(string EntityType, string physical_address1, string physical_address2, string physical_address3, string city,
            string physical_address_code, string province, string country, string po_box_line1, string po_box_line2,
            string po_box_line3, string postal_code)
        {
            try
            {
                LogInfo("Clicking on Correspondents tab");
                CorrespondentsTab.Click();
                LogSuccess("Clicked on Correspondents tab");

                LogInfo("Clicking Add New button");
                AddNewBtn.Click();
                LogSuccess("Clicked Add New button");

                LogInfo($"Selecting Entity Type: {EntityType}");
                EntityTypeDrpdwn.SelectDropDownText(EntityType);
                LogSuccess($"Selected Entity Type: {EntityType}");

                LogInfo("Clicking Address Details tab");
                AddressDetailsTab.Click();
                LogSuccess("Clicked Address Details tab");

                LogInfo($"Entering Physical Address Line 1: {physical_address1}");
                PhysicalAddressLine1.EnterText(physical_address1);
                LogSuccess($"Entered Physical Address Line 1: {physical_address1}");

                LogInfo($"Entering Physical Address Line 2: {physical_address2}");
                PhysicalAddressLine2.EnterText(physical_address2);
                LogSuccess($"Entered Physical Address Line 2: {physical_address2}");

                LogInfo($"Entering Physical Address Line 3: {physical_address3}");
                PhysicalAddressLine3.EnterText(physical_address3);
                LogSuccess($"Entered Physical Address Line 3: {physical_address3}");

                LogInfo($"Entering City: {city}");
                City.EnterText(city);
                LogSuccess($"Entered City: {city}");

                LogInfo($"Entering Physical Address Code: {physical_address_code}");
                PhysicalAddressCode.EnterText(physical_address_code);
                LogSuccess($"Entered Physical Address Code: {physical_address_code}");

                LogInfo($"Selecting Province: {province}");
                Province.SelectDropDownText(province);
                LogSuccess($"Selected Province: {province}");

                LogInfo($"Selecting Country: {country}");
                Country.SelectDropDownText(country);
                LogSuccess($"Selected Country: {country}");

                LogInfo($"Entering PO Box Line 1: {po_box_line1}");
                POBoxLine1.EnterText(po_box_line1);
                LogSuccess($"Entered PO Box Line 1: {po_box_line1}");

                LogInfo($"Entering PO Box Line 2: {po_box_line2}");
                POBoxLine2.EnterText(po_box_line2);
                LogSuccess($"Entered PO Box Line 2: {po_box_line2}");

                LogInfo($"Entering PO Box Line 3: {po_box_line3}");
                POBoxLine3.EnterText(po_box_line3);
                LogSuccess($"Entered PO Box Line 3: {po_box_line3}");

                LogInfo($"Entering Postal Code: {postal_code}");
                PostalCode.EnterText(postal_code);
                LogSuccess($"Entered Postal Code: {postal_code}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                Thread.Sleep(2000);

                LogSuccess("Address details completed successfully");
                CaptureScreenshot($"{pageName}_AddressDetails_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete address details", ex);
                CaptureScreenshot($"{pageName}_AddressDetails_Failure");
                throw;
            }
        }

        // Send Email
        public void SendEmail(string Subject)
        {
            try
            {
                LogInfo("Clicking on Correspondents tab");
                CorrespondentsTab.Click();
                LogSuccess("Clicked on Correspondents tab");

                LogInfo("Selecting checkbox for recipient");
                TypeCheckBox.Click();
                LogSuccess("Selected checkbox for recipient");

                LogInfo("Clicking Email button");
                Email2Btn.Click();
                LogSuccess("Clicked Email button");

                Thread.Sleep(2000);

                LogInfo($"Entering Subject: {Subject}");
                SubjectTextBox.EnterText(Subject);
                LogSuccess($"Entered Subject: {Subject}");

                LogInfo("Clicking Letters tab");
                LettersTab.Click();
                LogSuccess("Clicked Letters tab");

                LogInfo("Clicking Bond Cancellation link");
                BondCancellationLink.Click();
                LogSuccess("Clicked Bond Cancellation link");

                LogInfo("Clicking Send button");
                SendBtn.Click();
                LogSuccess("Clicked Send button");

                LogSuccess("Email sent successfully");
                CaptureScreenshot($"{pageName}_EmailSent");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to send email", ex);
                CaptureScreenshot($"{pageName}_SendEmail_Failure");
                throw;
            }
        }

        // Send Multiple Emails
        public void SendMultipleEmails(string Subject)
        {
            try
            {
                LogInfo("Clicking on Correspondents tab");
                CorrespondentsTab.Click();
                LogSuccess("Clicked on Correspondents tab");

                LogInfo("Selecting first checkbox for recipient");
                TypeCheckBox.Click();
                LogSuccess("Selected first checkbox for recipient");

                LogInfo("Selecting second checkbox for recipient");
                Type2CheckBox.Click();
                LogSuccess("Selected second checkbox for recipient");

                Thread.Sleep(2000);

                LogInfo("Clicking Email button");
                Email2Btn.Click();
                LogSuccess("Clicked Email button");

                Thread.Sleep(2000);

                LogInfo($"Entering Subject: {Subject}");
                SubjectTextBox.EnterText(Subject);
                LogSuccess($"Entered Subject: {Subject}");

                LogInfo("Clicking Letters tab");
                LettersTab.Click();
                LogSuccess("Clicked Letters tab");

                LogInfo("Clicking Bond Cancellation link");
                BondCancellationLink.Click();
                LogSuccess("Clicked Bond Cancellation link");

                Thread.Sleep(2000);

                LogInfo("Clicking Send button");
                SendBtn.Click();
                LogSuccess("Clicked Send button");

                LogSuccess("Multiple emails sent successfully");
                CaptureScreenshot($"{pageName}_MultipleEmailsSent");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to send multiple emails", ex);
                CaptureScreenshot($"{pageName}_SendMultipleEmails_Failure");
                throw;
            }
        }

        // Send SMS
        public void SendSMS(string Message)
        {
            try
            {
                LogInfo("Clicking on Correspondents tab");
                CorrespondentsTab.Click();
                LogSuccess("Clicked on Correspondents tab");

                LogInfo("Selecting checkbox for recipient");
                TypeCheckBox.Click();
                LogSuccess("Selected checkbox for recipient");

                LogInfo("Clicking SMS button");
                Sms2Btn.Click();
                LogSuccess("Clicked SMS button");

                Thread.Sleep(2000);

                LogInfo($"Entering SMS Message: {Message}");
                SmsMessageTextBox.EnterText(Message);
                LogSuccess($"Entered SMS Message: {Message}");

                Thread.Sleep(2000);

                LogInfo("Clicking Send SMS button");
                SendSmsBtn.Click();
                LogSuccess("Clicked Send SMS button");

                LogSuccess("SMS sent successfully");
                CaptureScreenshot($"{pageName}_SMSSent");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to send SMS", ex);
                CaptureScreenshot($"{pageName}_SendSMS_Failure");
                throw;
            }
        }

        // Send Multiple SMS
        public void SendMultipleSMS(string Message)
        {
            try
            {
                LogInfo("Clicking on Correspondents tab");
                CorrespondentsTab.Click();
                LogSuccess("Clicked on Correspondents tab");

                LogInfo("Selecting first checkbox for recipient");
                TypeCheckBox.Click();
                LogSuccess("Selected first checkbox for recipient");

                LogInfo("Selecting second checkbox for recipient");
                Type2CheckBox.Click();
                LogSuccess("Selected second checkbox for recipient");

                LogInfo("Clicking SMS button");
                Sms2Btn.Click();
                LogSuccess("Clicked SMS button");

                Thread.Sleep(2000);

                LogInfo($"Entering SMS Message: {Message}");
                SmsMessageTextBox.EnterText(Message);
                LogSuccess($"Entered SMS Message: {Message}");

                Thread.Sleep(2000);

                LogInfo("Clicking Send SMS button");
                SendSmsBtn.Click();
                LogSuccess("Clicked Send SMS button");

                LogSuccess("Multiple SMS sent successfully");
                CaptureScreenshot($"{pageName}_MultipleSMSSent");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to send multiple SMS", ex);
                CaptureScreenshot($"{pageName}_SendMultipleSMS_Failure");
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




