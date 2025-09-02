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
    public class LoginPage
    {
        public readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        // Constructor to initialize WebDriver
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Locate the elements on the Login page
        public IWebElement TxtLUN => wait.Until(d => d.FindElement(By.XPath("//input[@id='LUN']")));
        public IWebElement BtnLogin => wait.Until(d => d.FindElement(By.XPath("//input[@value='LOGIN']")));
		public IWebElement RemindMeTomorrowBtn => wait.Until(d => d.FindElement(By.XPath("//input[@id='RE']")));

		// Method to perform login
		public void Login(string LUN)
        {
            try
            {
                LogAction("Waiting for LUN field to be clickable");
                // Wait for the LUN field to be visible and interactable
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(TxtLUN));

                LogAction($"Entering LUN: {LUN}");
                // Enter the LUN value
                TxtLUN.EnterText(LUN);  // Use SendKeys() to enter the LUN

                LogAction("Clicking Login button");
                // Click Login button
                BtnLogin.Click();  // Click the Login button

                LogSuccess("Login attempt completed");

                Thread.Sleep(5000);
                RemindMeTomorrowBtn.Click();
			}
            catch (Exception ex)
            {
                LogError($"Login failed: {ex.Message}");
                throw;
            }
        }

        // Method to get the page title
        public string GetTitle()
        {
            try
            {
                LogAction("Getting page title");
                string title = driver.Title;
                LogAction($"Page title: {title}");
                return title;
            }
            catch (Exception ex)
            {
                LogError($"Failed to get page title: {ex.Message}");
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
                ExtentReport._scenario.Log(Status.Info, $"[LoginPage] {message}");
            }
        }

        /// <summary>
        /// Logs a success message to the ExtentReport
        /// </summary>
        private void LogSuccess(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Pass, $"[LoginPage] {message}");
            }
        }

        /// <summary>
        /// Logs an error message to the ExtentReport
        /// </summary>
        private void LogError(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Fail, $"[LoginPage] {message}");
            }
        }
        #endregion
    }
}




