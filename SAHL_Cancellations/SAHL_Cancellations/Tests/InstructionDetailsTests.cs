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
    public class InstructionDetailsTests : BaseClass
    {
        // Declare page objects
        private LandingPage LandingPage;
        private HomePage HomePage;
        private CorrespondentsPage CorrespondentsPage;
        private New_InstructionPage New_InstructionPage;
        private InstructionDetailsPage InstructionDetailsPage;
        private readonly string testClassName = "Instruction Details Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            // Initialize page objects
            LandingPage = new LandingPage(driver);
            HomePage = new HomePage(driver);
            CorrespondentsPage = new CorrespondentsPage(driver);
            InstructionDetailsPage = new InstructionDetailsPage(driver);

            test.Log(Status.Info, $"[{testClassName}] Page objects initialized");
        }

        [Test, Category("Regression Test")]
        public void AddInstructionDetails()
        {
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting AddInstructionDetails test");

                // Select the product from the dropdown
                test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
                LandingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                Thread.Sleep(2000); // Wait for the page to load

                // Navigate to the "Main Cancellations" tab
                test.Log(Status.Info, $"[{testClassName}] Navigating to Main Cancellations tab");
                HomePage.SelectMainCancellationsTab();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated to Main Cancellations tab");

                Thread.Sleep(2000);  // Wait for the page to load

                // Navigate to the "New Instruction" page
                test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction Page");
                New_InstructionPage = HomePage.RedirectToNewInstructionPage();
                test.Log(Status.Pass, $"[{testClassName}] Redirected to New Instruction Page");

                Thread.Sleep(2000);  // Wait for the page to load

                InstructionDetailsPage.CompleteInstructionDetails(
                    TestData.TitleDeedNumber,
                    TestData.TypeOfReason,
                    TestData.DeedsOffice2,
                    TestData.Party,
                    TestData.Property2);

                test.Log(Status.Pass, $"[{testClassName}] Successfully completed instruction details");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_AddInstructionDetails_Success");

                test.Log(Status.Pass, $"[{testClassName}] AddInstructionDetails test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_AddInstructionDetails_Failure");
                throw;
            }
        }

        /// <summary>
        /// Helper method to capture screenshots
        /// </summary>
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


