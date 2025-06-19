using Cancellations_Tests.BasePage;

using SAHL_Cancellations.Pages;
using SAHL_Cancellations.Utilities;
using System;
using System.Threading;
using NUnit.Framework;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;
using OpenQA.Selenium;


namespace SAHL_Cancellations.Tests
{
    [TestFixture]
    public class SetupPageTest : BaseClass
    {
        public LoginPage LoginPage;
        public LandingPage LandingPage;
        public HomePage HomePage;
        public SetupPage SetupPage;
        private readonly string testClassName = "Setup Page Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Initialize page objects
            LandingPage = new LandingPage(driver);
            HomePage = new HomePage(driver);
            SetupPage = new SetupPage(driver);
        }

        // Test method to complete the setup form
        [Test, Order(6), Category("Regression Test")]
        public void CompleteForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteForm test");

                test.Log(Status.Info, $"[{testClassName}] Selecting the product from the dropdown: {TestData.SAHL_Cancellations}");
                Console.WriteLine("Selecting the product from the dropdown: " + TestData.SAHL_Cancellations);

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000); // Wait for the page to load

                test.Log(Status.Info, $"[{testClassName}] Clicking product dropdown and selecting option");
                LandingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000); // Wait for the page to load

                test.Log(Status.Info, $"[{testClassName}] Clicking Setup menu");
                HomePage.ClickSetup();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated to Setup page");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000); // Wait for the page to load

                test.Log(Status.Info, $"[{testClassName}] Completing setup form");
                // Fill out the setup form
                SetupPage.CompleteSetupForm(
                    TestData.Branch,
                    TestData.Telephone,
                    TestData.Fax,
                    TestData.Email,
                    TestData.Tax_Number,
                    TestData.Docex,
                    TestData.Physical_AddressLine1,
                    TestData.Postal_AddressLine1,
                    TestData.Physical_AddressLine2,
                    TestData.Postal_AddressLine2,
                    TestData.Suburb,
                    TestData.Postal_Code,
                    TestData.City
                );
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed setup form");

                // Capture screenshot after completing the form
                CaptureScreenshot($"{testClassName}_CompleteForm_Success");

                test.Log(Status.Pass, $"[{testClassName}] CompleteForm test completed successfully");

                // Add any additional validations or assertions if needed
                // Example: Assert.IsTrue(someConditionToCheckProductPageIsLoaded);
            }
            catch (Exception ex)
            {
                // Handle the exception (for logging, rethrowing, etc.)
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteForm_Failure");
                Console.WriteLine("Test failed with exception: " + ex.Message);
                throw;  // Re-throw the exception after logging it to ensure the test fails
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


