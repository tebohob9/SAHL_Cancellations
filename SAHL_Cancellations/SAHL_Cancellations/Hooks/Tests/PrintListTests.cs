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
    public class PrintListTestsHook : BaseClass
    {
        // Page objects
        public LandingPage landingPage;
        public HomePage homePage;
        public CorrespondentsPage correspondentsPage;
        public New_InstructionPage newInstructionPage;
        public PrintListPage printListPage;
        private readonly string testClassName = "Print List Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Initialize page objects before each test
            landingPage = new LandingPage(driver);
            homePage = new HomePage(driver);
            correspondentsPage = new CorrespondentsPage(driver);
            printListPage = new PrintListPage(driver);
            newInstructionPage = new New_InstructionPage(driver);
        }

        [Test, Order(1), Category("Regression Test")]
        public void DownloadPdf()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting DownloadPdf test");

                // Select the product from the dropdown
                test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
                landingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                Thread.Sleep(2000); // Wait for the page to load

                // Navigate to the "Main Cancellations" tab
                test.Log(Status.Info, $"[{testClassName}] Navigating to Main Cancellations tab");
                homePage.SelectMainCancellationsTab();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated to Main Cancellations tab");

                Thread.Sleep(2000);  // Wait for the page to load

                // Navigate to the "New Instruction" page
                test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction Page");
                newInstructionPage = homePage.RedirectToNewInstructionPage();
                test.Log(Status.Pass, $"[{testClassName}] Redirected to New Instruction Page");

                Thread.Sleep(2000);  // Wait for the page to load

                // Navigate to Print List tab
                test.Log(Status.Info, $"[{testClassName}] Navigating to Print List tab");
                printListPage.PrintListTab.Click();
                test.Log(Status.Pass, $"[{testClassName}] Navigated to Print List tab");

                Thread.Sleep(2000);  // Wait for the page to load

                // Generate selected documents
                test.Log(Status.Info, $"[{testClassName}] Generating selected documents");
                printListPage.GenerateSelected();
                test.Log(Status.Pass, $"[{testClassName}] Successfully generated selected documents");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_DownloadPdf_Success");

                test.Log(Status.Pass, $"[{testClassName}] DownloadPdf test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_DownloadPdf_Failure");
                throw;
            }
        }

        [Test, Order(2), Category("Regression Test")]
        public void GenerateProForma()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting GenerateProForma test");

                // Generate Pro Forma directly without navigating to Print List tab
                // This assumes we're already on the Print List tab from the previous test
                test.Log(Status.Info, $"[{testClassName}] Generating Pro Forma");
                printListPage.GenerateProForma();
                test.Log(Status.Pass, $"[{testClassName}] Successfully generated Pro Forma");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_GenerateProForma_Success");

                test.Log(Status.Pass, $"[{testClassName}] GenerateProForma test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_GenerateProForma_Failure");
                throw;
            }
        }

        [Test, Order(3), Category("Regression Test")]
        public void GenerateAllDocuments()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting GenerateAllDocuments test");

                // Generate all documents directly without navigating to Print List tab
                // This assumes we're already on the Print List tab from the previous tests
                test.Log(Status.Info, $"[{testClassName}] Generating all documents");
                printListPage.GenerateSelected();
                test.Log(Status.Pass, $"[{testClassName}] Successfully generated all documents");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_GenerateAllDocuments_Success");

                test.Log(Status.Pass, $"[{testClassName}] GenerateAllDocuments test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_GenerateAllDocuments_Failure");
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



