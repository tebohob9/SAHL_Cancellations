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
    public class PropertyPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;
        private ExtentTest test; // ExtentTest instance for reporting
        private readonly string pageName = "Property Page"; // Page name for reporting

        // Constructor to initialize the WebDriver
        public PropertyPage(IWebDriver driver)
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

        // UI Elements - All elements on the Property page
        public IWebElement PropertyTab => driver.FindElement(By.XPath("(//a[@id='div_menu_property'])[1]"));
        public IWebElement DeedsOfficeDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_ctl00_C_C_ddlDeedsOffice']"));
        public IWebElement EditProperty => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_grdProperties_ctl02_IBEdit']"));
        public IWebElement DeleteProperty => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_grdProperties_ctl02_IBDelete']"));
        public IWebElement AddPropertyBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_btnAdd']"));
        public IWebElement PropertyTypeDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_PropertyControl1_ddlPropertyType'])[1]"));
        public IWebElement SubDivisionalTypeDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_PropertyControl1_ddlSubDivisionalType'])[1]"));
        public IWebElement ErfNumberTxtBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_PropertyControl1_txtPRP_PropertyNumber_txtPRP_PropertyNumberTextBox'])[1]"));
        public IWebElement TownshipTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_PropertyControl1_txtPRP_TownshipName'])[1]"));
        public IWebElement RegistrationDivisionTxtBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_PropertyControl1_txtPRP_RegistrationDivision'])[1]"));
        public IWebElement ProvinceDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_PropertyControl1_txtVAR_Province'])[1]"));
        public IWebElement ExtentTxtBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_PropertyControl1_txtPRP_ExtentOfProperty'])[1]"));
        public IWebElement ExtentDrpDwn => driver.FindElement(By.XPath("(//select[@id='ctl00_ctl00_C_C_PropertyControl1_txtVAR_MeasurmentUnit'])[1]"));
        public IWebElement AddressTxtBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtStreetAddress']"));
        public IWebElement RefreshBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_btnRefresh']"));
        public IWebElement LegalDescriptionTxtBox => driver.FindElement(By.XPath("(//textarea[@id='ctl00_ctl00_C_C_PropertyControl1_txtPRP_LegalDescription'])[1]"));
        public IWebElement SaveBtn => driver.FindElement(By.XPath("(//a[@id='ctl00_ctl00_C_C_btnSave1'])[1]"));
        public IWebElement ExtendingClauseChckBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_cbExtendingClauseDiffers']"));
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_btnCancel']"));
        public IWebElement HeldByTextbox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_PropertyControl1_txtPRP_HeldBy30_TextBox1'])[1]"));
        public IWebElement PortionNumberTextBox => driver.FindElement(By.XPath("(//input[@id='ctl00_ctl00_C_C_PropertyControl1_txtPRP_PortionNumber_txtPRP_PortionNumberTextBox'])[1]"));
        public IWebElement SectionNumberTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtSectionalTitleSectionNumber']"));
        public IWebElement SectionalPlanNumberTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtSectionalTitleSectionPlanNo']"));
        public IWebElement SchemeNameTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtSectionalTitleSectionSchemeName']"));
        public IWebElement SituateTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtSectionTitleSituatedAt']"));
        public IWebElement LocalAuthorityTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtLocalAuthority']"));
        public IWebElement FloorAreaTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtSectionalTitleFloorArea_txtSectionalTitleFloorAreaTextBox']"));
        public IWebElement AddressTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_txtStreetAddress']"));
        public IWebElement AddEAUBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_ucExclusiveUseArea_btnEUAAdd']"));
        public IWebElement DescriptionTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_ucExclusiveUseArea_txtEUA_Description']"));
        public IWebElement SizeTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_ucExclusiveUseArea_txtEUA_Size']"));
        public IWebElement SectionalPlanNoTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_ucExclusiveUseArea_txtEUA_SectionalPlanNo_TextBox1']"));
        public IWebElement ExtendingClauseBox => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_ucExclusiveUseArea_txtNotarialDeedNo_TextBox1']"));
        public IWebElement AddExclusiveSaveBtn => driver.FindElement(By.XPath("//input[@id='ctl00_ctl00_C_C_ucExclusiveUseArea_btnSaveEUA']"));
		public IWebElement NewTabBtn => driver.FindElement(By.XPath("//ul[@id='ctl00_ctl00_C_C_dtcProperties']//li[@title='New property']//a[1]"));

		// Complete the property form with ERF No SubDivisional Type
		public void CompleteERFNoSubDivisionalType(string Deeds_office, string Property_Type, string SubDivisional_Type, string Erf_Number,
            string Township, string Registration_Division, string Province, string Extent_Text, string Extent_DrpDwn,
            string Address, string Legal_Description, string HeldBy)
        {
            try
            {
                LogInfo("Starting to complete ERF No SubDivisional Type form");

                LogInfo("Clicking Property tab");
                PropertyTab.Click();
                LogSuccess("Clicked Property tab");

                //LogInfo($"Selecting Deeds Office: {Deeds_office}");
                //DeedsOfficeDrpDwn.SelectDropDownText(Deeds_office);
                //LogSuccess($"Selected Deeds Office: {Deeds_office}");

                //LogInfo("Clicking Add Property button");
                //AddPropertyBtn.Click();
                //LogSuccess("Clicked Add Property button");

                LogInfo($"Selecting Property Type: {Property_Type}");
                PropertyTypeDrpDwn.SelectDropDownText(Property_Type);
                LogSuccess($"Selected Property Type: {Property_Type}");

                LogInfo($"Selecting SubDivisional Type: {SubDivisional_Type}");
                SubDivisionalTypeDrpDwn.SelectDropDownText(SubDivisional_Type);
                LogSuccess($"Selected SubDivisional Type: {SubDivisional_Type}");

				Thread.Sleep(2000);

				LogInfo($"Entering ERF Number: {Erf_Number}");
                ErfNumberTxtBox.EnterText(Erf_Number);
                LogSuccess($"Entered ERF Number: {Erf_Number}");

				Thread.Sleep(2000);

				LogInfo($"Entering Township: {Township}");
                TownshipTextBox.EnterText(Township);
                LogSuccess($"Entered Township: {Township}");

                LogInfo($"Entering Registration Division: {Registration_Division}");
                RegistrationDivisionTxtBox.EnterText(Registration_Division);
                LogSuccess($"Entered Registration Division: {Registration_Division}");

                LogInfo($"Selecting Province: {Province}");
                ProvinceDrpDwn.SelectDropDownText(Province);
                LogSuccess($"Selected Province: {Province}");

                LogInfo($"Entering Extent: {Extent_Text}");
                ExtentTxtBox.EnterText(Extent_Text);
                LogSuccess($"Entered Extent: {Extent_Text}");

                //LogInfo($"Selecting Extent Type: {Extent_DrpDwn}");
                //ExtentDrpDwn.SelectDropDownText(Extent_DrpDwn);
                //LogSuccess($"Selected Extent Type: {Extent_DrpDwn}");

                //LogInfo($"Entering Address: {Address}");
                //AddressTxtBox.EnterText(Address);
                //LogSuccess($"Entered Address: {Address}");

                LogInfo($"Entering Legal Description: {Legal_Description}");
                LegalDescriptionTxtBox.EnterText(Legal_Description);
                LogSuccess($"Entered Legal Description: {Legal_Description}");

                Thread.Sleep(2000);

                //LogInfo("Clicking Refresh button");
                //RefreshBtn.Click();
                //LogSuccess("Clicked Refresh button");

                Thread.Sleep(2000);

                //LogInfo("Clicking Extending Clause checkbox");
                //ExtendingClauseChckBox.Click();
                //LogSuccess("Clicked Extending Clause checkbox");

                //Thread.Sleep(2000);

                LogInfo($"Entering Held By: {HeldBy}");
                HeldByTextbox.EnterText(HeldBy);
                LogSuccess($"Entered Held By: {HeldBy}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Successfully completed ERF No SubDivisional Type form");
                CaptureScreenshot($"{pageName}_CompleteERFNoSubDivisionalType_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete ERF No SubDivisional Type form", ex);
                CaptureScreenshot($"{pageName}_CompleteERFNoSubDivisionalType_Failure");
                throw;
            }
        }

        // Complete the property form with ERF Portion SubDivisional Type
        public void CompleteERFPortionSubDivisionalType(string Deeds_office, string Property_Type, string SubDivisional_Type, string Erf_Number,
            string PortionNumber, string Township, string Registration_Division, string Province, string Extent_Text, string Extent_DrpDwn,
            string Address, string Legal_Description, string HeldBy)
        {
            try
            {
                //LogInfo("Starting to complete ERF Portion SubDivisional Type form");

                LogInfo("Clicking Property tab");
                PropertyTab.Click();
                LogSuccess("Clicked Property tab");

                Thread.Sleep(5000);

				LogInfo("Clicking New Property tab");
				NewTabBtn.Click();
				LogSuccess("Clicked New Property tab");

				Thread.Sleep(5000); 

				LogInfo($"Selecting Property Type: {Property_Type}");
                PropertyTypeDrpDwn.SelectDropDownText(Property_Type);
                LogSuccess($"Selected Property Type: {Property_Type}");

                LogInfo($"Selecting SubDivisional Type: {SubDivisional_Type}");
                SubDivisionalTypeDrpDwn.SelectDropDownText(SubDivisional_Type);
                LogSuccess($"Selected SubDivisional Type: {SubDivisional_Type}");

				LogInfo($"Entering Portion Number: {PortionNumber}");
				PortionNumberTextBox.EnterText(PortionNumber);
				LogSuccess($"Entered Portion Number: {PortionNumber}");

				LogInfo($"Entering ERF Number: {Erf_Number}");
                ErfNumberTxtBox.EnterText(Erf_Number);
                LogSuccess($"Entered ERF Number: {Erf_Number}");

                //LogInfo($"Entering Portion Number: {PortionNumber}");
                //PortionNumberTextBox.EnterText(PortionNumber);
                //LogSuccess($"Entered Portion Number: {PortionNumber}");

                LogInfo($"Entering Township: {Township}");
                TownshipTextBox.EnterText(Township);
                LogSuccess($"Entered Township: {Township}");

                LogInfo($"Entering Registration Division: {Registration_Division}");
                RegistrationDivisionTxtBox.EnterText(Registration_Division);
                LogSuccess($"Entered Registration Division: {Registration_Division}");

                LogInfo($"Selecting Province: {Province}");
                ProvinceDrpDwn.SelectDropDownText(Province);
                LogSuccess($"Selected Province: {Province}");

                LogInfo($"Entering Extent: {Extent_Text}");
                ExtentTxtBox.EnterText(Extent_Text);
                LogSuccess($"Entered Extent: {Extent_Text}");

                LogInfo($"Selecting Extent Type: {Extent_DrpDwn}");
                ExtentDrpDwn.SelectDropDownText(Extent_DrpDwn);
                LogSuccess($"Selected Extent Type: {Extent_DrpDwn}");

                LogInfo($"Entering Address: {Address}");
                AddressTxtBox.EnterText(Address);
                LogSuccess($"Entered Address: {Address}");

                LogInfo($"Entering Legal Description: {Legal_Description}");
                LegalDescriptionTxtBox.EnterText(Legal_Description);
                LogSuccess($"Entered Legal Description: {Legal_Description}");

                Thread.Sleep(2000);

                LogInfo("Clicking Refresh button");
                RefreshBtn.Click();
                LogSuccess("Clicked Refresh button");

                Thread.Sleep(2000);

                LogInfo("Clicking Extending Clause checkbox");
                ExtendingClauseChckBox.Click();
                LogSuccess("Clicked Extending Clause checkbox");

                Thread.Sleep(2000);

                LogInfo($"Entering Held By: {HeldBy}");
                HeldByTextbox.EnterText(HeldBy);
                LogSuccess($"Entered Held By: {HeldBy}");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Successfully completed ERF Portion SubDivisional Type form");
                CaptureScreenshot($"{pageName}_CompleteERFPortionSubDivisionalType_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete ERF Portion SubDivisional Type form", ex);
                CaptureScreenshot($"{pageName}_CompleteERFPortionSubDivisionalType_Failure");
                throw;
            }
        }

        // Complete the property form with Sectional With EUA
        public void CompleteSectionalWithEUA(string Deeds_office, string Property_Type, string SectionNumber, string SectionalPlanNumber,
            string SchemeName, string Situate, string LocalAuthority, string FloorArea, string AddressText, string HeldBy,
            string Description, string Size, string SectionalPlanNo, string ExtendingClause)
        {
            try
            {
                LogInfo("Starting to complete Sectional With EUA form");

                LogInfo("Clicking Property tab");
                PropertyTab.Click();
                LogSuccess("Clicked Property tab");

                LogInfo($"Selecting Deeds Office: {Deeds_office}");
                DeedsOfficeDrpDwn.SelectDropDownText(Deeds_office);
                LogSuccess($"Selected Deeds Office: {Deeds_office}");

                LogInfo("Clicking Add Property button");
                AddPropertyBtn.Click();
                LogSuccess("Clicked Add Property button");

                LogInfo($"Selecting Property Type: {Property_Type}");
                PropertyTypeDrpDwn.SelectDropDownText(Property_Type);
                LogSuccess($"Selected Property Type: {Property_Type}");

                LogInfo($"Entering Section Number: {SectionNumber}");
                SectionNumberTextBox.EnterText(SectionNumber);
                LogSuccess($"Entered Section Number: {SectionNumber}");

                LogInfo($"Entering Sectional Plan Number: {SectionalPlanNumber}");
                SectionalPlanNumberTextBox.EnterText(SectionalPlanNumber);
                LogSuccess($"Entered Sectional Plan Number: {SectionalPlanNumber}");

                LogInfo($"Entering Scheme Name: {SchemeName}");
                SchemeNameTextBox.EnterText(SchemeName);
                LogSuccess($"Entered Scheme Name: {SchemeName}");

                LogInfo($"Entering Situate: {Situate}");
                SituateTextBox.EnterText(Situate);
                LogSuccess($"Entered Situate: {Situate}");

                LogInfo($"Entering Local Authority: {LocalAuthority}");
                LocalAuthorityTextBox.EnterText(LocalAuthority);
                LogSuccess($"Entered Local Authority: {LocalAuthority}");

                LogInfo($"Entering Floor Area: {FloorArea}");
                FloorAreaTextBox.EnterText(FloorArea);
                LogSuccess($"Entered Floor Area: {FloorArea}");

                LogInfo($"Entering Address: {AddressText}");
                AddressTextBox.EnterText(AddressText);
                LogSuccess($"Entered Address: {AddressText}");

                Thread.Sleep(2000);

                LogInfo($"Entering Extending Clause: {ExtendingClause}");
                ExtendingClauseBox.EnterText(ExtendingClause);
                LogSuccess($"Entered Extending Clause: {ExtendingClause}");

                LogInfo("Clicking Add EAU button");
                AddEAUBtn.Click();
                LogSuccess("Clicked Add EAU button");

                Thread.Sleep(2000);

                LogInfo($"Entering Description: {Description}");
                DescriptionTextBox.EnterText(Description);
                LogSuccess($"Entered Description: {Description}");

                LogInfo($"Entering Size: {Size}");
                SizeTextBox.EnterText(Size);
                LogSuccess($"Entered Size: {Size}");

                LogInfo($"Entering Sectional Plan No: {SectionalPlanNo}");
                SectionalPlanNoTextBox.EnterText(SectionalPlanNo);
                LogSuccess($"Entered Sectional Plan No: {SectionalPlanNo}");

                LogInfo($"Entering Description again: {Description}");
                DescriptionTextBox.EnterText(Description);
                LogSuccess($"Entered Description again: {Description}");

                LogInfo("Clicking Add Exclusive Save button");
                AddExclusiveSaveBtn.Click();
                LogSuccess("Clicked Add Exclusive Save button");

                LogInfo("Clicking Refresh button");
                RefreshBtn.Click();
                LogSuccess("Clicked Refresh button");

                Thread.Sleep(2000);

                LogInfo("Clicking Extending Clause checkbox");
                ExtendingClauseChckBox.Click();
                LogSuccess("Clicked Extending Clause checkbox");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Successfully completed Sectional With EUA form");
                CaptureScreenshot($"{pageName}_CompleteSectionalWithEUA_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete Sectional With EUA form", ex);
                CaptureScreenshot($"{pageName}_CompleteSectionalWithEUA_Failure");
                throw;
            }
        }

        // Complete the basic property form
        public void CompletePropertyForm(string Deeds_office, string Property_Type, string SubDivisional_Type, string Erf_Number,
            string Township, string Registration_Division, string Province, string Extent_Text, string Extent_DrpDwn,
            string Address, string Legal_Description)
        {
            try
            {
                LogInfo("Starting to complete basic property form");

                LogInfo("Clicking Property tab");
                PropertyTab.Click();
                LogSuccess("Clicked Property tab");

                LogInfo($"Selecting Deeds Office: {Deeds_office}");
                DeedsOfficeDrpDwn.SelectDropDownText(Deeds_office);
                LogSuccess($"Selected Deeds Office: {Deeds_office}");

                LogInfo("Clicking Add Property button");
                AddPropertyBtn.Click();
                LogSuccess("Clicked Add Property button");

                LogInfo($"Selecting Property Type: {Property_Type}");
                PropertyTypeDrpDwn.SelectDropDownText(Property_Type);
                LogSuccess($"Selected Property Type: {Property_Type}");

                LogInfo($"Selecting SubDivisional Type: {SubDivisional_Type}");
                SubDivisionalTypeDrpDwn.SelectDropDownText(SubDivisional_Type);
                LogSuccess($"Selected SubDivisional Type: {SubDivisional_Type}");

                LogInfo($"Entering ERF Number: {Erf_Number}");
                ErfNumberTxtBox.EnterText(Erf_Number);
                LogSuccess($"Entered ERF Number: {Erf_Number}");

                LogInfo($"Entering Township: {Township}");
                TownshipTextBox.EnterText(Township);
                LogSuccess($"Entered Township: {Township}");

                LogInfo($"Entering Registration Division: {Registration_Division}");
                RegistrationDivisionTxtBox.EnterText(Registration_Division);
                LogSuccess($"Entered Registration Division: {Registration_Division}");

                LogInfo($"Selecting Province: {Province}");
                ProvinceDrpDwn.SelectDropDownText(Province);
                LogSuccess($"Selected Province: {Province}");

                LogInfo($"Entering Extent: {Extent_Text}");
                ExtentTxtBox.EnterText(Extent_Text);
                LogSuccess($"Entered Extent: {Extent_Text}");

                LogInfo($"Selecting Extent Type: {Extent_DrpDwn}");
                ExtentDrpDwn.SelectDropDownText(Extent_DrpDwn);
                LogSuccess($"Selected Extent Type: {Extent_DrpDwn}");

                LogInfo($"Entering Address: {Address}");
                AddressTxtBox.EnterText(Address);
                LogSuccess($"Entered Address: {Address}");

                LogInfo($"Entering Legal Description: {Legal_Description}");
                LegalDescriptionTxtBox.EnterText(Legal_Description);
                LogSuccess($"Entered Legal Description: {Legal_Description}");

                Thread.Sleep(2000);

                LogInfo("Clicking Refresh button");
                RefreshBtn.Click();
                LogSuccess("Clicked Refresh button");

                Thread.Sleep(2000);

                LogInfo("Clicking Save button");
                SaveBtn.Click();
                LogSuccess("Clicked Save button");

                LogSuccess("Successfully completed basic property form");
                CaptureScreenshot($"{pageName}_CompletePropertyForm_Completed");
            }
            catch (Exception ex)
            {
                LogFailure("Failed to complete basic property form", ex);
                CaptureScreenshot($"{pageName}_CompletePropertyForm_Failure");
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




