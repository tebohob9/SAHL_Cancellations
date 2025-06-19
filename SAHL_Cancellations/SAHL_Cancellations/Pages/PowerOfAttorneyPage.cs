using NUnit.Framework;
using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using SAHL_Cancellations.Utilities;  // Make sure to include this for reusable methods
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;

namespace SAHL_Cancellations.Pages
{
    public class PowerOfAttorneyPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser
        private readonly WebDriverWait wait;

        // Constructor to initialize the WebDriver
        public PowerOfAttorneyPage(IWebDriver driver)
        {
            this.driver = driver;  // Assigning the driver to the class variable
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // UI Elements - Identifiers for elements used in the Power of Attorney workflow
        public IWebElement CloseSetupPage => wait.Until(d => d.FindElement(By.XPath("//i[@class='fa fa-times fa-2x']")));
        public IWebElement CloseThisBranch => wait.Until(d => d.FindElement(By.XPath("//i[@class='fa fa-times-circle ']")));
        public IWebElement PowerOfAttorneyTab => wait.Until(d => d.FindElement(By.XPath("//ul[@class='nav nav-tabs hidden-xs']//a[contains(text(),'Power of Attorney')]")));
        public IWebElement AddBankBtn => wait.Until(d => d.FindElement(By.XPath("//button[normalize-space()='Add a Bank']")));
        public IWebElement CancellationBankDrpDwn => wait.Until(d => d.FindElement(By.XPath("(//select[contains(@class,'form-control')])[13]")));
        public IWebElement BankLegalDescriptionTxtBox => wait.Until(d => d.FindElement(By.XPath("(//textarea[contains(@data-bind,'value: legalBankName')])[7]")));
        public IWebElement DeedsOfficeDrpDwn => wait.Until(d => d.FindElement(By.XPath("(//select[contains(@class,'form-control')])[14]")));
        public IWebElement POANumberTxtBox => wait.Until(d => d.FindElement(By.XPath("(//input[contains(@data-bind,'value: poanumber')])[7]")));
        public IWebElement DateRegistered => wait.Until(d => d.FindElement(By.XPath("(//input[contains(@type,'text')])[7]")));
        public IWebElement SignatoryNamesAddBtn => wait.Until(d => d.FindElement(By.XPath("(//span)[32]")));
        public IWebElement SignatoryNamesTxtBox => wait.Until(d => d.FindElement(By.XPath("(//input[@data-bind='value: Name'])[7]")));
        public IWebElement DeleteBankBtn => wait.Until(d => d.FindElement(By.XPath("(//span[@title='Delete Bank'])[7]")));
        public IWebElement SaveAllBtn => wait.Until(d => d.FindElement(By.XPath("//button[normalize-space()='Save All']")));

        // Clicks the "Close" icon to exit the Setup page
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
        public void AddBank(string Cancellation_Bank, string BankLegalDescription, string DeedsOffice, string POANumber,
            string Date_Registered, string SignatoryNames)
        {
            try
            {
                LogAction("Clicking on Power of Attorney tab");
                PowerOfAttorneyTab.Click();
                LogSuccess("Successfully clicked on Power of Attorney tab");
                Thread.Sleep(2000);

                LogAction("Clicking Add Bank button");
                AddBankBtn.Click();
                LogSuccess("Successfully clicked Add Bank button");
                Thread.Sleep(2000);

                LogAction($"Selecting Cancellation Bank: {Cancellation_Bank}");
                CancellationBankDrpDwn.SelectDropDownText(Cancellation_Bank);
                LogSuccess($"Successfully selected Cancellation Bank: {Cancellation_Bank}");
                Thread.Sleep(2000);

                LogAction($"Entering Bank Legal Description: {BankLegalDescription}");
                BankLegalDescriptionTxtBox.EnterText(BankLegalDescription);
                LogSuccess($"Successfully entered Bank Legal Description");
                Thread.Sleep(2000);

                LogAction($"Selecting Deeds Office: {DeedsOffice}");
                DeedsOfficeDrpDwn.SelectDropDownText(DeedsOffice);
                LogSuccess($"Successfully selected Deeds Office: {DeedsOffice}");
                Thread.Sleep(2000);

                LogAction($"Entering POA Number: {POANumber}");
                POANumberTxtBox.EnterText(POANumber);
                LogSuccess($"Successfully entered POA Number: {POANumber}");

                LogAction($"Entering Date Registered: {Date_Registered}");
                DateRegistered.EnterText(Date_Registered);
                LogSuccess($"Successfully entered Date Registered: {Date_Registered}");

                LogAction("Clicking Signatory Names Add button");
                SignatoryNamesAddBtn.Click();
                LogSuccess("Successfully clicked Signatory Names Add button");

                LogAction($"Entering Signatory Names: {SignatoryNames}");
                SignatoryNamesTxtBox.EnterText(SignatoryNames);
                LogSuccess($"Successfully entered Signatory Names: {SignatoryNames}");
                Thread.Sleep(2000);

                LogAction("Clicking Save All button");
                SaveAllBtn.Click();  // Save the form using the reusable click method
                LogSuccess("Successfully clicked Save All button");
            }
            catch (Exception ex)
            {
                LogError($"Failed to add bank: {ex.Message}");
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
                ExtentReport._scenario.Log(Status.Info, $"[PowerOfAttorneyPage] {message}");
            }
        }

        /// <summary>
        /// Logs a success message to the ExtentReport
        /// </summary>
        private void LogSuccess(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Pass, $"[PowerOfAttorneyPage] {message}");
            }
        }

        /// <summary>
        /// Logs an error message to the ExtentReport
        /// </summary>
        private void LogError(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Fail, $"[PowerOfAttorneyPage] {message}");
            }
        }
        #endregion
    }
}




