using Cancellations_Tests.BasePage;

using SAHL_Cancellations.Pages;
using SAHL_Cancellations.Utilities;
using NUnit.Framework;
using System;
using System.Threading;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;
using OpenQA.Selenium;


namespace SAHL_Cancellations.Tests
{
    [TestFixture]
    public class PowerOfAttorneyTest : BaseClass
    {
        // Page object references
        private LoginPage loginPage;
        private LandingPage landingPage;
        private HomePage homePage;
        private SetupPage setupPage;
        private PowerOfAttorneyPage powerOfAttorneyPage;
        private readonly string testClassName = "Power Of Attorney Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Initialize page objects
            landingPage = new LandingPage(driver);
            homePage = new HomePage(driver);
            setupPage = new SetupPage(driver);
            powerOfAttorneyPage = new PowerOfAttorneyPage(driver);
        }

        /// <summary>
        /// Test to complete the Power of Attorney form with given test data.
        /// </summary>
        [Test, Order(1), Category("Regression Test")]
        public void CompleteForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteForm test");

                test.Log(Status.Info, $"[{testClassName}] Selecting the product: {TestData.SAHL_Cancellations}");
                Console.WriteLine($"Selecting the product: {TestData.SAHL_Cancellations}");

                // Select the product from the dropdown
                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000); // Consider replacing with WebDriver explicit waits

                test.Log(Status.Info, $"[{testClassName}] Clicking product dropdown and selecting option");
                landingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                // Navigate to Setup section
                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Clicking Setup menu");
                homePage.ClickSetup();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated to Setup section");

                // Fill in Power of Attorney form
                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Adding bank details");
                powerOfAttorneyPage.AddBank(
                    TestData.CancellationBank,
                    TestData.BankLegalDescription,
                    TestData.DeedsOffice1,
                    TestData.POANumber,
                    TestData.DateRegistered,
                    TestData.SignatoryNames
                );
                test.Log(Status.Pass, $"[{testClassName}] Successfully added bank details");

                // Capture screenshot after completing the form
                CaptureScreenshot($"{testClassName}_CompleteForm_Success");

                test.Log(Status.Pass, $"[{testClassName}] CompleteForm test completed successfully");

                // Optional: Add assertions to validate successful form submission
                // Example:
                // Assert.IsTrue(powerOfAttorneyPage.IsConfirmationMessageDisplayed(), "Form submission failed.");
            }
            catch (Exception ex)
            {
                // Log and rethrow to ensure the test fails properly
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteForm_Failure");
                Console.WriteLine($"Test failed with exception: {ex.Message}");
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


