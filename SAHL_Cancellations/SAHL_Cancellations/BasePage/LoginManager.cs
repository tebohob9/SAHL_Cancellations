using NUnit.Framework;
using Cancellations_Tests.BasePage;
using SAHL_Cancellations.Pages;
using OpenQA.Selenium;
using System;
using System.Threading;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;

namespace SAHL_Cancellations.Utilities
{
    public class LoginManager
    {
        private readonly IWebDriver driver;
        private ExtentTest test;

        public LoginManager(IWebDriver driver)
        {
            this.driver = driver;

            // Try to get the current test from ExtentReport if available
            try
            {
                if (ExtentReport._scenario != null)
                {
                    test = ExtentReport._scenario;
                }
            }
            catch (Exception)
            {
                // If ExtentReport._scenario is not available, test will remain null
            }
        }

        public void Login()
        {
            try
            {
                LogInfo("Navigating to login page");

                // Navigate to the login URL with explicit timeout
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                driver.Navigate().GoToUrl("https://uat.e4.co.za/Login/Auth?returnUrl=https%3A%2F%2Fuat.e4.co.za%2FLogin");

                // Wait for page to load
                Thread.Sleep(5000);

                LogInfo("Checking if page loaded correctly");

                // Check if we're on the login page
                if (driver.Title.Contains("Login") || driver.Url.Contains("Login"))
                {
                    LogSuccess("Login page loaded successfully");

                    // Perform login
                    LoginPage loginPage = new LoginPage(driver);
                    loginPage.Login(TestData.LUN);

                    // Wait for login to complete
                    Thread.Sleep(5000);

                    // Verify login was successful
                    if (driver.Url.Contains("Dashboard") || !driver.Url.Contains("Login"))
                    {
                        LogSuccess("Login successful");
                    }
                    else
                    {
                        LogFailure("Login may have failed - still on login page", null);
                    }
                }
                else
                {
                    LogFailure("Failed to load login page. Current URL: " + driver.Url, null);
                    CaptureScreenshot("LoginPage_Failed");
                }
            }
            catch (Exception ex)
            {
                LogFailure("Exception during login process", ex);
                CaptureScreenshot("Login_Exception");
                throw;
            }
        }

        // Helper methods for logging
        private void LogInfo(string message)
        {
            Console.WriteLine(message);
            if (test != null)
            {
                test.Log(Status.Info, message);
            }
        }

        private void LogSuccess(string message)
        {
            Console.WriteLine(message);
            if (test != null)
            {
                test.Log(Status.Pass, message);
            }
        }

        private void LogFailure(string message, Exception ex)
        {
            string errorMessage = message;
            if (ex != null)
            {
                errorMessage += ": " + ex.Message;
            }
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




