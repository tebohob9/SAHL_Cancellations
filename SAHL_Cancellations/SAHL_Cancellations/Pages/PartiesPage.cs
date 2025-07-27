using NUnit.Framework;
using Cancellations_Tests.BasePage;
using SAHL_Cancellations.Utilities;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using System;
using System.Threading;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;
using OpenQA.Selenium.Support.UI;

namespace SAHL_Cancellations.Pages
{
    public class PartiesPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Parties Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public PartiesPage(IWebDriver driver)
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

        // UI Elements - All elements on the Request Cancellation page
        public IWebElement PartiesTab => driver.FindElement(By.XPath("(//a[@id='div_menu_parties'])[1]"));
        public IWebElement SelectMortgagorTypeDprDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_ddlEntity'])[1]"));
		public IWebElement AddPartyBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_cmdAdd'])[1]")); 
        public IWebElement SelectPartyDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_ddlParty'])[1]"));
        public IWebElement AgeCategoryDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_details_varSupp']"));
        public IWebElement FirstNamesTxtBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_details_TFT_FirstNamesTextBox'])[1]"));
        public IWebElement SurnamesTxtBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_details_TFT_SurnameTextBox'])[1]"));
        public IWebElement GenderDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_ctl00_C_C_details_ddlVarGender'])[1]"));
        public IWebElement NameChangeChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_chkTFT_Section93_1']"));
        public IWebElement MethodOfIdentificationDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_ctl00_C_C_details_ddlVarMethodID'])[1]"));
        public IWebElement IdentityNumberTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_ctl00_C_C_details_TFT_IdentityNumberTextBox'])[1]"));
        public IWebElement MaritalStatusDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_ctl00_C_C_details_VARMaritalStatus'])[1]"));
        public IWebElement SaveBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_ctl00_C_C_save_btnSubmit1'])[1]"));
        public IWebElement SaveLegalDescriptions => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_btnSubmit1']"));
        public IWebElement BackBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_btnBack']"));

        public IWebElement CompanyTypeDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_details_varCompanyType']"));
        public IWebElement NameOfCompanyTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtNameOrg']"));
        public IWebElement RegistrationNumber1TextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtRegistrationNo1']"));
        public IWebElement RegistrationNumber2TextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtRegistrationNo2']"));
        public IWebElement RegistrationNumber3TextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtLastRegNoPart']"));
        public IWebElement EntitySaveBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_btnSave']"));
        public IWebElement NameOfCloseCorporationTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtNameOrg']"));
        public IWebElement EntityTypeDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_details_varPartyType']"));
        public IWebElement TrustTypeDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_details_varTrustType']"));
        public IWebElement NameOfTrustTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtNameOrg']"));
        public IWebElement AuthorityNumberTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtLetterAppointmentNo']"));
        public IWebElement NameTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtPartName_txtPartNameTextBox']"));
        public IWebElement AddPartnerBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_btnAdd']"));
        public IWebElement ReasonForExclusionDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_details_varReasonForExclusion']"));
        public IWebElement ExclusionDate => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtExclusionDate']"));
        public IWebElement TodayBtn => driver.FindElement(By.XPath("//button[normalize-space()='Today']"));
        public IWebElement TypeDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_details_ddlInstitutionType']"));
        public IWebElement CouncilTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtName_txtNameTextBox']"));
        public IWebElement SaveInstitutionBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_btnSave']"));
        public IWebElement NameOfStratutoryBodyTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtName_txtNameTextBox']"));
        public IWebElement EstablishedInTermsOfTextBx => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_details_txtEstablished_txtEstablishedTextBox']"));
        public IWebElement ProvinceDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_ctl00_C_C_details_ddlProvince']"));
        public IWebElement NationalGovernmentLegalDescriptionTxtBox => driver.FindElement(By.XPath("//textarea[@id='ctl00_ctl00_ctl00_C_C_TxtAreaTFT_DeedLegalDescription']"));
        public IWebElement SaveLegalDescriptionBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_ctl00_C_C_btnSubmit1']"));

        // Helper methods for logging
        private void LogInfo(string message)
        {
            if (test != null)
            {
                test.Info(message);
            }
            Console.WriteLine($"INFO: {message}");
        }

        private void LogSuccess(string message)
        {
            if (test != null)
            {
                test.Pass(message);
            }
            Console.WriteLine($"SUCCESS: {message}");
        }

        private void LogFailure(string message, Exception ex = null)
        {
            if (test != null)
            {
                if (ex != null)
                {
                    test.Fail($"{message}. Exception: {ex.Message}");
                }
                else
                {
                    test.Fail(message);
                }
            }
            Console.WriteLine($"FAILURE: {message}. {(ex != null ? $"Exception: {ex.Message}" : "")}");
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

        // Complete the cancellation form with provided values
        public void CompleteNaturalPersonUnmariedForm(string SelectMortgagorType, string SelectPartyType,
            string FirstName, string Surname, string Gender,
            string MethodOfIdentifiaction, string IdentityNumber, string MartialStatus)
        {
            try
            {
                LogInfo("Starting to complete Natural Person Unmarried Form");

                LogInfo("Clicking Parties Tab");
                PartiesTab.Click();
                LogSuccess("Clicked Parties Tab");

                LogInfo($"Selecting Party Type: {SelectMortgagorType}");
                SelectMortgagorTypeDprDwn.SelectDropDownText(SelectMortgagorType);
                LogSuccess($"Selected Party Type: {SelectMortgagorType}");

				LogInfo($"Selecting Party Type: {SelectPartyType}");
				SelectPartyDrpDwn.SelectDropDownText(SelectPartyType);
				LogSuccess($"Selected Party Type: {SelectPartyType}");

				Thread.Sleep(5000);

				LogInfo("Clicking Add Party button");
                AddPartyBtn.Click();
                LogSuccess("Clicked Add Party button");

                Thread.Sleep(5000);

				LogInfo($"Entering First Name: {FirstName}");
                FirstNamesTxtBox.EnterText(FirstName);
                LogSuccess($"Entered First Name: {FirstName}");

                LogInfo($"Entering Surname: {Surname}");
                SurnamesTxtBox.EnterText(Surname);
                LogSuccess($"Entered Surname: {Surname}");

                LogInfo($"Selecting Gender: {Gender}");
                GenderDrpDwn.SelectDropDownText(Gender);
                LogSuccess($"Selected Gender: {Gender}");

                LogInfo($"Selecting Method of Identification: {MethodOfIdentifiaction}");
                MethodOfIdentificationDrpDwn.SelectDropDownText(MethodOfIdentifiaction);
                LogSuccess($"Selected Method of Identification: {MethodOfIdentifiaction}");

                LogInfo("Clicking Identity Number field");
                IdentityNumberTextBox.Click();
                Thread.Sleep(1000);

                LogInfo($"Entering Identity Number: {IdentityNumber}");
                IdentityNumberTextBox.EnterText(IdentityNumber);
                Thread.Sleep(1000);
                LogSuccess($"Entered Identity Number: {IdentityNumber}");

                LogInfo($"Selecting Marital Status: {MartialStatus}");
                MaritalStatusDrpDwn.SelectDropDownText(MartialStatus);
                LogSuccess($"Selected Marital Status: {MartialStatus}");

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Successfully completed Natural Person Unmarried Form");
                CaptureScreenshot($"{pageName}_NaturalPersonUnmarried_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Natural Person Unmarried Form", ex);
                CaptureScreenshot($"{pageName}_NaturalPersonUnmarried_Failure");
                throw;
            }
        }

        public void CompleteEntityCompanyForm(string SelectPartyType, string SelectCompanyType, string NameOfCompany, string RegistrationNumber1,
            string RegistrationNumber2, string RegistrationNumber3)
        {
            try
            {
                LogInfo("Starting to complete Entity Company Form");

                LogInfo("Clicking Parties Tab");
                PartiesTab.Click();
                LogSuccess("Clicked Parties Tab");

                LogInfo($"Selecting Party Type: {SelectPartyType}");
				SelectMortgagorTypeDprDwn.SelectDropDownText(SelectPartyType);
                LogSuccess($"Selected Party Type: {SelectPartyType}");

                LogInfo("Clicking Add Party button");
                AddPartyBtn.Click();
                LogSuccess("Clicked Add Party button");

                LogInfo($"Selecting Company Type: {SelectCompanyType}");
                CompanyTypeDrpDwn.SelectDropDownText(SelectCompanyType);
                LogSuccess($"Selected Company Type: {SelectCompanyType}");

                LogInfo($"Entering Company Name: {NameOfCompany}");
                NameOfCompanyTextBox.EnterText(NameOfCompany);
                LogSuccess($"Entered Company Name: {NameOfCompany}");

                LogInfo($"Entering Registration Number Part 1: {RegistrationNumber1}");
                RegistrationNumber1TextBox.EnterText(RegistrationNumber1);
                LogSuccess($"Entered Registration Number Part 1: {RegistrationNumber1}");

                LogInfo($"Entering Registration Number Part 2: {RegistrationNumber2}");
                RegistrationNumber2TextBox.EnterText(RegistrationNumber2);
                LogSuccess($"Entered Registration Number Part 2: {RegistrationNumber2}");

                LogInfo($"Entering Registration Number Part 3: {RegistrationNumber3}");
                RegistrationNumber3TextBox.EnterText(RegistrationNumber3);
                LogSuccess($"Entered Registration Number Part 3: {RegistrationNumber3}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                EntitySaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Successfully completed Entity Company Form");
                CaptureScreenshot($"{pageName}_EntityCompany_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Entity Company Form", ex);
                CaptureScreenshot($"{pageName}_EntityCompany_Failure");
                throw;
            }
        }

        public void CompleteEntityCloseCorporationForm(string SelectPartyType, string EntityType, string NameOfCloseCorporation, string RegistrationNumber1,
    string RegistrationNumber2, string RegistrationNumber3)
        {
            try
            {
                LogInfo("Starting to complete Entity Close Corporation Form");

                LogInfo("Clicking Parties Tab");
                PartiesTab.Click();
                LogSuccess("Clicked Parties Tab");

                LogInfo($"Selecting Party Type: {SelectPartyType}");
                SelectMortgagorTypeDprDwn.SelectDropDownText(SelectPartyType);
                LogSuccess($"Selected Party Type: {SelectPartyType}");

                LogInfo("Clicking Add Party button");
                AddPartyBtn.Click();
                LogSuccess("Clicked Add Party button");

                LogInfo($"Selecting Entity Type: {EntityType}");
                EntityTypeDrpDwn.SelectDropDownText(EntityType);
                LogSuccess($"Selected Entity Type: {EntityType}");

                LogInfo($"Entering Close Corporation Name: {NameOfCloseCorporation}");
                NameOfCloseCorporationTextBox.EnterText(NameOfCloseCorporation);
                LogSuccess($"Entered Close Corporation Name: {NameOfCloseCorporation}");

                LogInfo($"Entering Registration Number Part 1: {RegistrationNumber1}");
                RegistrationNumber1TextBox.EnterText(RegistrationNumber1);
                LogSuccess($"Entered Registration Number Part 1: {RegistrationNumber1}");

                LogInfo($"Entering Registration Number Part 2: {RegistrationNumber2}");
                RegistrationNumber2TextBox.EnterText(RegistrationNumber2);
                LogSuccess($"Entered Registration Number Part 2: {RegistrationNumber2}");

                LogInfo($"Entering Registration Number Part 3: {RegistrationNumber3}");
                RegistrationNumber3TextBox.EnterText(RegistrationNumber3);
                LogSuccess($"Entered Registration Number Part 3: {RegistrationNumber3}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                EntitySaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Successfully completed Entity Close Corporation Form");
                CaptureScreenshot($"{pageName}_EntityCloseCorporation_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Entity Close Corporation Form", ex);
                CaptureScreenshot($"{pageName}_EntityCloseCorporation_Failure");
                throw;
            }
        }

        public void CompleteEntityTrustForm(string SelectPartyType, string EntityType, string TrustType,
            string NameOfTrust, string AuthorityNumber)
        {
            try
            {
                LogInfo("Starting to complete Entity Trust Form");

                LogInfo("Clicking Parties Tab");
                PartiesTab.Click();
                LogSuccess("Clicked Parties Tab");

                LogInfo($"Selecting Party Type: {SelectPartyType}");
                SelectMortgagorTypeDprDwn.SelectDropDownText(SelectPartyType);
                LogSuccess($"Selected Party Type: {SelectPartyType}");

                LogInfo("Clicking Add Party button");
                AddPartyBtn.Click();
                LogSuccess("Clicked Add Party button");

                LogInfo($"Selecting Entity Type: {EntityType}");
                EntityTypeDrpDwn.SelectDropDownText(EntityType);
                LogSuccess($"Selected Entity Type: {EntityType}");

                LogInfo($"Selecting Trust Type: {TrustType}");
                TrustTypeDrpDwn.SelectDropDownText(TrustType);
                LogSuccess($"Selected Trust Type: {TrustType}");

                LogInfo($"Entering Trust Name: {NameOfTrust}");
                NameOfTrustTextBox.EnterText(NameOfTrust);
                LogSuccess($"Entered Trust Name: {NameOfTrust}");

                LogInfo($"Entering Authority Number: {AuthorityNumber}");
                AuthorityNumberTextBox.EnterText(AuthorityNumber);
                LogSuccess($"Entered Authority Number: {AuthorityNumber}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                EntitySaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Successfully completed Entity Trust Form");
                CaptureScreenshot($"{pageName}_EntityTrust_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Entity Trust Form", ex);
                CaptureScreenshot($"{pageName}_EntityTrust_Failure");
                throw;
            }
        }

        public void CompletePartnershipForm(string SelectPartyType, string Name, string FirstName, string Surname, string Gender,
    string MethodOfIdentifiaction, string IdentityNumber, string MartialStatus)
        {
            try
            {
                LogInfo("Starting to complete Partnership Form");

                LogInfo("Clicking Parties Tab");
                PartiesTab.Click();
                LogSuccess("Clicked Parties Tab");

                LogInfo($"Selecting Party Type: {SelectPartyType}");
                SelectMortgagorTypeDprDwn.SelectDropDownText(SelectPartyType);
                LogSuccess($"Selected Party Type: {SelectPartyType}");

                LogInfo("Clicking Add Party button");
                AddPartyBtn.Click();
                LogSuccess("Clicked Add Party button");

                LogInfo($"Entering Partnership Name: {Name}");
                NameTextBox.EnterText(Name);
                LogSuccess($"Entered Partnership Name: {Name}");

                LogInfo("Clicking Add Partner button");
                AddPartnerBtn.Click();
                LogSuccess("Clicked Add Partner button");

                Thread.Sleep(2000);

                LogInfo($"Entering First Name: {FirstName}");
                FirstNamesTxtBox.EnterText(FirstName);
                LogSuccess($"Entered First Name: {FirstName}");

                LogInfo($"Entering Surname: {Surname}");
                SurnamesTxtBox.EnterText(Surname);
                LogSuccess($"Entered Surname: {Surname}");

                LogInfo($"Selecting Gender: {Gender}");
                GenderDrpDwn.SelectDropDownText(Gender);
                LogSuccess($"Selected Gender: {Gender}");

                LogInfo($"Selecting Method of Identification: {MethodOfIdentifiaction}");
                MethodOfIdentificationDrpDwn.SelectDropDownText(MethodOfIdentifiaction);
                LogSuccess($"Selected Method of Identification: {MethodOfIdentifiaction}");

                LogInfo("Clicking Identity Number field");
                IdentityNumberTextBox.Click();
                Thread.Sleep(1000);

                LogInfo($"Entering Identity Number: {IdentityNumber}");
                IdentityNumberTextBox.EnterText(IdentityNumber);
                Thread.Sleep(1000);
                LogSuccess($"Entered Identity Number: {IdentityNumber}");

                LogInfo($"Selecting Marital Status: {MartialStatus}");
                MaritalStatusDrpDwn.SelectDropDownText(MartialStatus);
                LogSuccess($"Selected Marital Status: {MartialStatus}");

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Successfully completed Partnership Form");
                CaptureScreenshot($"{pageName}_Partnership_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Partnership Form", ex);
                CaptureScreenshot($"{pageName}_Partnership_Failure");
                throw;
            }
        }

        public void CompleteNaturalPersonOutOfCommunityForm(string SelectPartyType, string FirstName, string Surname, string Gender,
            string MethodOfIdentifiaction, string IdentityNumber, string MartialStatus, string ReasonForExclusion, string Exclusion)
        {
            try
            {
                LogInfo("Starting to complete Natural Person Out Of Community Form");

                LogInfo("Clicking Parties Tab");
                PartiesTab.Click();
                LogSuccess("Clicked Parties Tab");

                LogInfo($"Selecting Party Type: {SelectPartyType}");
                SelectMortgagorTypeDprDwn.SelectDropDownText(SelectPartyType);
                LogSuccess($"Selected Party Type: {SelectPartyType}");

                LogInfo("Clicking Add Party button");
                AddPartyBtn.Click();
                LogSuccess("Clicked Add Party button");

                LogInfo($"Entering First Name: {FirstName}");
                FirstNamesTxtBox.EnterText(FirstName);
                LogSuccess($"Entered First Name: {FirstName}");

                LogInfo($"Entering Surname: {Surname}");
                SurnamesTxtBox.EnterText(Surname);
                LogSuccess($"Entered Surname: {Surname}");

                LogInfo($"Selecting Gender: {Gender}");
                GenderDrpDwn.SelectDropDownText(Gender);
                LogSuccess($"Selected Gender: {Gender}");

                LogInfo($"Selecting Method of Identification: {MethodOfIdentifiaction}");
                MethodOfIdentificationDrpDwn.SelectDropDownText(MethodOfIdentifiaction);
                LogSuccess($"Selected Method of Identification: {MethodOfIdentifiaction}");

                LogInfo("Clicking Identity Number field");
                IdentityNumberTextBox.Click();
                Thread.Sleep(1000);

                LogInfo($"Entering Identity Number: {IdentityNumber}");
                IdentityNumberTextBox.EnterText(IdentityNumber);
                Thread.Sleep(1000);
                LogSuccess($"Entered Identity Number: {IdentityNumber}");

                LogInfo($"Selecting Marital Status: {MartialStatus}");
                MaritalStatusDrpDwn.SelectDropDownText(MartialStatus);
                LogSuccess($"Selected Marital Status: {MartialStatus}");

                LogInfo($"Selecting Reason for Exclusion: {ReasonForExclusion}");
                ReasonForExclusionDrpDwn.SelectDropDownText(ReasonForExclusion);
                LogSuccess($"Selected Reason for Exclusion: {ReasonForExclusion}");

                LogInfo($"Entering Exclusion Date: {Exclusion}");
                ExclusionDate.EnterText(Exclusion);
                Thread.Sleep(1000);
                LogSuccess($"Entered Exclusion Date: {Exclusion}");

                LogInfo("Clicking Today button");
                TodayBtn.Click();
                LogSuccess("Clicked Today button");

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Successfully completed Natural Person Out Of Community Form");
                CaptureScreenshot($"{pageName}_NaturalPersonOutOfCommunity_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Natural Person Out Of Community Form", ex);
                CaptureScreenshot($"{pageName}_NaturalPersonOutOfCommunity_Failure");
                throw;
            }
        }

        public void CompleteInstitutionCouncilForm(string SelectPartyType, string Type, string Council)
        {
            try
            {
                LogInfo("Starting to complete Institution Council Form");

                LogInfo("Clicking Parties Tab");
                PartiesTab.Click();
                LogSuccess("Clicked Parties Tab");

                LogInfo($"Selecting Party Type: {SelectPartyType}");
                SelectMortgagorTypeDprDwn.SelectDropDownText(SelectPartyType);
                LogSuccess($"Selected Party Type: {SelectPartyType}");

                LogInfo("Clicking Add Party button");
                AddPartyBtn.Click();
                LogSuccess("Clicked Add Party button");

                LogInfo($"Selecting Type: {Type}");
                TypeDrpDwn.SelectDropDownText(Type);
                LogSuccess($"Selected Type: {Type}");

                LogInfo($"Entering Council: {Council}");
                CouncilTextBox.EnterText(Council);
                LogSuccess($"Entered Council: {Council}");

                Thread.Sleep(1000);

                LogInfo("Clicking Save Institution button");
                SaveInstitutionBtn.Click();
                LogSuccess("Clicked Save Institution button");

                LogSuccess("Successfully completed Institution Council Form");
                CaptureScreenshot($"{pageName}_InstitutionCouncil_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Institution Council Form", ex);
                CaptureScreenshot($"{pageName}_InstitutionCouncil_Failure");
                throw;
            }
        }

        public void CompleteInstitutionStatutoryBodyForm(string SelectPartyType, string Type,
    string NameOfStratutoryBody, string EstablishedInTermsOf)
        {
            try
            {
                LogInfo("Starting to complete Institution Statutory Body Form");

                LogInfo("Clicking Parties Tab");
                PartiesTab.Click();
                LogSuccess("Clicked Parties Tab");

                LogInfo($"Selecting Party Type: {SelectPartyType}");
                SelectMortgagorTypeDprDwn.SelectDropDownText(SelectPartyType);
                LogSuccess($"Selected Party Type: {SelectPartyType}");

                LogInfo("Clicking Add Party button");
                AddPartyBtn.Click();
                LogSuccess("Clicked Add Party button");

                LogInfo($"Selecting Type: {Type}");
                TypeDrpDwn.SelectDropDownText(Type);
                LogSuccess($"Selected Type: {Type}");

                LogInfo($"Entering Statutory Body Name: {NameOfStratutoryBody}");
                NameOfStratutoryBodyTextBox.EnterText(NameOfStratutoryBody);
                LogSuccess($"Entered Statutory Body Name: {NameOfStratutoryBody}");

                LogInfo($"Entering Established In Terms Of: {EstablishedInTermsOf}");
                EstablishedInTermsOfTextBx.EnterText(EstablishedInTermsOf);
                LogSuccess($"Entered Established In Terms Of: {EstablishedInTermsOf}");

                Thread.Sleep(1000);

                LogInfo("Clicking Save Institution button");
                SaveInstitutionBtn.Click();
                LogSuccess("Clicked Save Institution button");

                LogSuccess("Successfully completed Institution Statutory Body Form");
                CaptureScreenshot($"{pageName}_InstitutionStatutoryBody_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Institution Statutory Body Form", ex);
                CaptureScreenshot($"{pageName}_InstitutionStatutoryBody_Failure");
                throw;
            }
        }

        public void CompleteInstitutionProvincialAdministrationForm(string SelectPartyType, string Type,
            string Province)
        {
            try
            {
                LogInfo("Starting to complete Institution Provincial Administration Form");

                LogInfo("Clicking Parties Tab");
                PartiesTab.Click();
                LogSuccess("Clicked Parties Tab");

                LogInfo($"Selecting Party Type: {SelectPartyType}");
                SelectMortgagorTypeDprDwn.SelectDropDownText(SelectPartyType);
                LogSuccess($"Selected Party Type: {SelectPartyType}");

                LogInfo("Clicking Add Party button");
                AddPartyBtn.Click();
                LogSuccess("Clicked Add Party button");

                LogInfo($"Selecting Type: {Type}");
                TypeDrpDwn.SelectDropDownText(Type);
                LogSuccess($"Selected Type: {Type}");

                LogInfo($"Selecting Province: {Province}");
                ProvinceDrpDwn.SelectDropDownText(Province);
                LogSuccess($"Selected Province: {Province}");

                Thread.Sleep(1000);

                LogInfo("Clicking Save Institution button");
                SaveInstitutionBtn.Click();
                LogInfo("Clicking Save Institution button");
                SaveInstitutionBtn.Click();
                LogSuccess("Clicked Save Institution button");

                LogSuccess("Successfully completed Institution Provincial Administration Form");
                CaptureScreenshot($"{pageName}_InstitutionProvincialAdmin_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Institution Provincial Administration Form", ex);
                CaptureScreenshot($"{pageName}_InstitutionProvincialAdmin_Failure");
                throw;
            }
        }

        public void CompleteInstitutionNationalGovernmentForm(string SelectPartyType, string Type,
            string NationalGovernmentLegalDescription)
        {
            try
            {
                LogInfo("Starting to complete Institution National Government Form");

                LogInfo("Clicking Parties Tab");
                PartiesTab.Click();
                LogSuccess("Clicked Parties Tab");

                LogInfo($"Selecting Party Type: {SelectPartyType}");
                SelectMortgagorTypeDprDwn.SelectDropDownText(SelectPartyType);
                LogSuccess($"Selected Party Type: {SelectPartyType}");

                LogInfo("Clicking Add Party button");
                AddPartyBtn.Click();
                LogSuccess("Clicked Add Party button");

                LogInfo($"Selecting Type: {Type}");
                TypeDrpDwn.SelectDropDownText(Type);
                LogSuccess($"Selected Type: {Type}");

                Thread.Sleep(1000);

                LogInfo("Clicking Save Institution button");
                SaveInstitutionBtn.Click();
                LogSuccess("Clicked Save Institution button");

                LogInfo($"Entering National Government Legal Description: {NationalGovernmentLegalDescription}");
                NationalGovernmentLegalDescriptionTxtBox.EnterText(NationalGovernmentLegalDescription);
                LogSuccess($"Entered National Government Legal Description: {NationalGovernmentLegalDescription}");

                LogInfo("Clicking Save Legal Description button");
                SaveLegalDescriptionBtn.Click();
                LogSuccess("Clicked Save Legal Description button");

                LogSuccess("Successfully completed Institution National Government Form");
                CaptureScreenshot($"{pageName}_InstitutionNationalGovernment_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Institution National Government Form", ex);
                CaptureScreenshot($"{pageName}_InstitutionNationalGovernment_Failure");
                throw;
            }
        }
    }
}




