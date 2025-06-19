using NUnit.Framework;
using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using SAHL_Cancellations.Utilities;  // Make sure to include this for reusable methods
using OpenQA.Selenium.Support.UI;
using System;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;

namespace SAHL_Cancellations.Pages
{
    public class SetupPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;

        // Constructor to initialize the WebDriver
        public SetupPage(IWebDriver driver)
        {
            this.driver = driver;  // Assigning the driver to the class variable
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // UI Elements - All elements on the SetupPage
        public IWebElement CloseSetupPage => wait.Until(d => d.FindElement(By.XPath("//i[@class='fa fa-times fa-2x']")));
        public IWebElement CloseThisBranch => wait.Until(d => d.FindElement(By.XPath("//i[@class='fa fa-times-circle ']")));
        public IWebElement FirmDetailsTab => wait.Until(d => d.FindElement(By.XPath("(//a[normalize-space()='Firm Details'])[1]")));
        public IWebElement DeedConditionsTab => wait.Until(d => d.FindElement(By.XPath("(//a[normalize-space()='Deed Conditions'])[1]")));
        public IWebElement PropertyLibraryTab => wait.Until(d => d.FindElement(By.XPath("(//a[normalize-space()='Property Library'])[1]")));
        public IWebElement BranchDetailsTab => wait.Until(d => d.FindElement(By.XPath("(//a[contains(text(),'Branch Details')])[1]")));
        public IWebElement UsersTab => wait.Until(d => d.FindElement(By.XPath("(//a[contains(text(),'Users')])[1]")));
        public IWebElement RolesTab => wait.Until(d => d.FindElement(By.XPath("(//a[contains(text(),'Roles')])[1]")));
        public IWebElement PreferencesTab => wait.Until(d => d.FindElement(By.XPath("(//a[contains(text(),'Preferences')])[1]")));
        public IWebElement AccountsTab => wait.Until(d => d.FindElement(By.XPath("(//a[contains(text(),'Accounts')])[1]")));
        public IWebElement CommunicationsTab => wait.Until(d => d.FindElement(By.XPath("(//a[contains(text(),'Communications')])[1]")));
        public IWebElement DeedsOfficeTab => wait.Until(d => d.FindElement(By.XPath("(//a[contains(text(),'Deeds Office')])[1]")));
        public IWebElement PowerOfAttorneyTab => wait.Until(d => d.FindElement(By.XPath("(//a[contains(text(),'Power of Attorney')])[1]")));
        public IWebElement MilestonesTab => wait.Until(d => d.FindElement(By.XPath("(//a[contains(text(),'Milestones')])[1]")));
        public IWebElement BranchTextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='BranchName']")));
        public IWebElement TelephoneTextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='Tel']")));
        public IWebElement FaxTextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='Fax']")));
        public IWebElement EmailTextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='Email']")));
        public IWebElement TaxTextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='BRH_TaxNumber']")));
        public IWebElement DocexTextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='DocexAddress']")));
        public IWebElement VatRegisteredCheckBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='IsVatRegistered']")));
        public IWebElement PhysicalAddressLine1TextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='PhysicalAddress1']")));
        public IWebElement PhysicalAddressLine2TextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='PhysicalAddress2']")));
        public IWebElement PostalAddressLine1TextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='PostalAddress1']")));
        public IWebElement PostalAddressLine2TextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='PostalAddress2']")));
        public IWebElement SuburbTextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='Suburb']")));
        public IWebElement PostalCodeTextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='PostalCode']")));
        public IWebElement Line1TextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='PhysicalAddress1']")));
        public IWebElement CityTextBox => wait.Until(d => d.FindElement(By.XPath("//input[@id='City']")));
        public IWebElement CountryDrpDwn => wait.Until(d => d.FindElement(By.XPath("//select[@id='Country']")));
        public IWebElement LProvinceDrpDwn => wait.Until(d => d.FindElement(By.XPath("//select[@id='Province']")));
        public IWebElement SaveButton => wait.Until(d => d.FindElement(By.XPath("//button[normalize-space()='Save']")));
        public IWebElement CancelButton => wait.Until(d => d.FindElement(By.XPath("//a[normalize-space()='Cancel']")));
        public IWebElement BranchSavedMessage => wait.Until(d => d.FindElement(By.XPath("//label[normalize-space()='Branch saved']")));
        public IWebElement RequiredFiledsMessage => wait.Until(d => d.FindElement(By.XPath("//label[normalize-space()='Please complete all the highlighted fields.']")));

        // Click on Setup Page's Close button using the reusable Click method
        public void ClickCloseSetupPage()
        {
            try
            {
                LogAction("Clicking Close Setup Page button");
                CloseSetupPage.Click();
                LogSuccess("Successfully closed Setup Page");
            }
            catch (Exception ex)
            {
                LogError($"Failed to close Setup Page: {ex.Message}");
                throw;
            }
        }

        // Generalized method to click on tabs using reusable method
        public void ClickTab(string tabName)
        {
            try
            {
                LogAction($"Clicking on tab: {tabName}");
                var tabElement = wait.Until(d => d.FindElement(By.XPath($"(//a[normalize-space()='{tabName}'])[1]")));
                tabElement.Click();
                LogSuccess($"Successfully clicked on tab: {tabName}");
            }
            catch (Exception ex)
            {
                LogError($"Failed to click on tab {tabName}: {ex.Message}");
                throw;
            }
        }

        // Method to select an option from a dropdown using reusable SelectDropDownText method
        public void SelectDropdownOption(IWebElement dropdownElement, string optionText)
        {
            try
            {
                LogAction($"Selecting option '{optionText}' from dropdown");
                dropdownElement.SelectDropDownText(optionText);  // Reusable method for selecting dropdown
                LogSuccess($"Successfully selected option '{optionText}' from dropdown");
            }
            catch (Exception ex)
            {
                LogError($"Failed to select option '{optionText}' from dropdown: {ex.Message}");
                throw;
            }
        }

        // Fill in text fields using reusable EnterTextInField method
        public void EnterTextInField(IWebElement textBoxElement, string text)
        {
            try
            {
                LogAction($"Entering text: {text}");
                textBoxElement.EnterText(text);  // Reusable method for entering text
                LogSuccess($"Successfully entered text: {text}");
            }
            catch (Exception ex)
            {
                LogError($"Failed to enter text '{text}': {ex.Message}");
                throw;
            }
        }

        // Example usage to fill and submit a form using reusable methods
        public void CompleteSetupForm(string branch, string telephone, string fax, string email, string taxNumber, string docex,
            string physicalAddressLine1, string postalAddressLine1, string physicalAddressLine2, string postalAddressLine2,
            string suburb, string postalCode, string city)
        {
            try
            {
                LogAction($"Entering Branch: {branch}");
                BranchTextBox.EnterText(branch);

                LogAction($"Entering Telephone: {telephone}");
                TelephoneTextBox.EnterText(telephone);

                LogAction($"Entering Fax: {fax}");
                FaxTextBox.EnterText(fax);

                LogAction($"Entering Email: {email}");
                EmailTextBox.EnterText(email);

                LogAction($"Entering Tax Number: {taxNumber}");
                TaxTextBox.EnterText(taxNumber);

                LogAction($"Entering Docex: {docex}");
                DocexTextBox.EnterText(docex);

                LogAction($"Entering Physical Address Line 1: {physicalAddressLine1}");
                PhysicalAddressLine1TextBox.EnterText(physicalAddressLine1);

                LogAction($"Entering Postal Address Line 1: {postalAddressLine1}");
                PostalAddressLine1TextBox.EnterText(postalAddressLine1);

                LogAction($"Entering Physical Address Line 2: {physicalAddressLine2}");
                PhysicalAddressLine2TextBox.EnterText(physicalAddressLine2);

                LogAction($"Entering Postal Address Line 2: {postalAddressLine2}");
                PostalAddressLine2TextBox.EnterText(postalAddressLine2);

                LogAction($"Entering Suburb: {suburb}");
                SuburbTextBox.EnterText(suburb);

                LogAction($"Entering Postal Code: {postalCode}");
                PostalCodeTextBox.EnterText(postalCode);

                LogAction($"Entering City: {city}");
                CityTextBox.EnterText(city);

                LogAction("Clicking Save button");
                SaveButton.Click();  // Save the form using the reusable click method

                LogSuccess("Setup form completed and saved successfully");
            }
            catch (Exception ex)
            {
                LogError($"Failed to complete setup form: {ex.Message}");
                throw;
            }
        }

        // Click the Save button using the reusable method
        public void ClickSaveButton()
        {
            try
            {
                LogAction("Clicking Save button");
                SaveButton.Click();
                LogSuccess("Successfully clicked Save button");
            }
            catch (Exception ex)
            {
                LogError($"Failed to click Save button: {ex.Message}");
                throw;
            }
        }

        // Click the Cancel button using the reusable method
        public void ClickCancelButton()
        {
            try
            {
                LogAction("Clicking Cancel button");
                CancelButton.Click();
                LogSuccess("Successfully clicked Cancel button");
            }
            catch (Exception ex)
            {
                LogError($"Failed to click Cancel button: {ex.Message}");
                throw;
            }
        }

        #region Logging Methods
        /// <summary>
        /// Logs an action to the ExtentReport
        /// </summary>
        private void LogAction(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Info, $"[SetupPage] {message}");
            }
        }

        /// <summary>
        /// Logs a success message to the ExtentReport
        /// </summary>
        private void LogSuccess(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Pass, $"[SetupPage] {message}");
            }
        }

        /// <summary>
        /// Logs an error message to the ExtentReport
        /// </summary>
        private void LogError(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Fail, $"[SetupPage] {message}");
            }
        }
        #endregion
    }
}




