using NUnit.Framework;
using Cancellations_Tests.BasePage;
using SAHL_Cancellations.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;

namespace SAHL_Cancellations.Pages
{
    public class LandingPage
    {
        public static IWebDriver driver;
        private readonly WebDriverWait wait;

        public LandingPage(IWebDriver driver)
        {
            LandingPage.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Locators for the page elements
        IWebElement products_drop_down => wait.Until(d => d.FindElement(By.XPath("//a[@id='productMenu']")));
        IWebElement SAHL_Cancellations => wait.Until(d => d.FindElement(By.XPath("//a[normalize-space()='Absa Cancellations Attorney - Test']")));

        // Click the product dropdown and select an option by text
        public void ClickProductDropDownAndSelectOption(string optionText)
        {
            try
            {
                LogAction($"Clicking on products dropdown");
                // Open the dropdown menu
                products_drop_down.Click();
                LogAction($"Products dropdown clicked successfully");

                LogAction($"Selecting option: {optionText}");
                // Find the dropdown options by XPath (adjust the XPath based on your dropdown structure)
                IWebElement option = wait.Until(d => d.FindElement(By.XPath($"//a[normalize-space(text())='{optionText}']")));

                // Select the option by clicking on it
                option.Click();
                LogSuccess($"Successfully selected option: {optionText}");
            }
            catch (Exception ex)
            {
                LogError($"Failed to select product option: {ex.Message}");
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
                ExtentReport._scenario.Log(Status.Info, $"[LandingPage] {message}");
            }
        }

        /// <summary>
        /// Logs a success message to the ExtentReport
        /// </summary>
        private void LogSuccess(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Pass, $"[LandingPage] {message}");
            }
        }

        /// <summary>
        /// Logs an error message to the ExtentReport
        /// </summary>
        private void LogError(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Fail, $"[LandingPage] {message}");
            }
        }
        #endregion
    }
}




