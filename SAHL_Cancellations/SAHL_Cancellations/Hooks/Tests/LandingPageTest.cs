using Cancellations_Tests.BasePage;

using SAHL_Cancellations.Pages;
using SAHL_Cancellations.Utilities;
using System;
using NUnit.Framework;  // Importing NUnit to use [Test]
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;
using OpenQA.Selenium;


namespace SAHL_Cancellations.Tests
{
    // Test class forHook Landing Page actions
    [TestFixture]
    public class LandingPageTest : BaseClass
    {
        // Declare page objects
        public LoginPage LoginPage;
        public LandingPage LandingPage;
        private readonly string testClassName = "Landing Page Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Initialize page objects
            LandingPage = new LandingPage(driver);
        }

        // Test method to verify the product dropdown selection
        [Test, Category("Regression Test")]
        public void ClickProductDropDownAndSelectOption()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting ClickProductDropDownAndSelectOption test");

                // Print a caption/message for clarity on the action being performed
                test.Log(Status.Info, $"[{testClassName}] Selecting the product from the dropdown: {TestData.SAHL_Cancellations}");
                Console.WriteLine("Selecting the product from the dropdown: " + TestData.SAHL_Cancellations);

                // Example usage: Click on the product dropdown and select the option based on text
                LandingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product: {TestData.SAHL_Cancellations}");

                // Capture screenshot after selecting product
                CaptureScreenshot($"{testClassName}_ClickProductDropDownAndSelectOption_Success");

                test.Log(Status.Pass, $"[{testClassName}] ClickProductDropDownAndSelectOption test completed successfully");

                // Add additional validation or assertions if needed, like checking if the correct product page opens
                // For example: Assert.IsTrue(someConditionToCheckProductPageIsLoaded);
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_ClickProductDropDownAndSelectOption_Failure");
                Console.WriteLine($"Test failed: {ex.Message}");
                throw;
            }
        }

        // Helper method to capture screenshots
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
    }
}



