using Cancellations_Tests.BasePage;

using SAHL_Cancellations.Pages;
using SAHL_Cancellations.Utilities;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;


namespace SAHL_Cancellations.Tests
{
    [TestFixture]
    public class DeedSearchTests : BaseClass
    {
        // Page object declarations
        private LandingPage landingPage;
        private HomePage homePage;
        private New_InstructionPage newInstructionPage;
        private DeedSearchPage deedSearchPage;
        private readonly string testClassName = "Deed Search Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Initialize page objects before each test
            landingPage = new LandingPage(driver);
            homePage = new HomePage(driver);
            newInstructionPage = new New_InstructionPage(driver);
            deedSearchPage = new DeedSearchPage(driver);
        }

        [Test, Category("Regression Test")]
        public void DownloadPdf_DeedSearchTest()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting DownloadPdf_DeedSearchTest");

                // Step 1: Select product
                test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
                Console.WriteLine($"Selecting product: {TestData.SAHL_Cancellations}");
                landingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                // Step 2: Navigate to Main Cancellations tab
                test.Log(Status.Info, $"[{testClassName}] Navigating to Main Cancellations tab");
                homePage.SelectMainCancellationsTab();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated to Main Cancellations tab");

                // Step 3: Navigate to New Instruction page
                test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction page");
                newInstructionPage = homePage.RedirectToNewInstructionPage();
                test.Log(Status.Pass, $"[{testClassName}] Successfully redirected to New Instruction page");

                // Step 4: Perform Deed Search & download PDF
                test.Log(Status.Info, $"[{testClassName}] Performing Deed Search for: {TestData.DeedSearch}");
                Console.WriteLine($"Performing Deed Search for: {TestData.DeedSearch}");
                deedSearchPage.DownlaodPdf(TestData.DeedSearch);
                test.Log(Status.Pass, $"[{testClassName}] Successfully performed Deed Search and downloaded PDF");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_DownloadPdf_DeedSearchTest_Success");

                test.Log(Status.Pass, $"[{testClassName}] DownloadPdf_DeedSearchTest completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                Console.WriteLine($"Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_DownloadPdf_DeedSearchTest_Failure");
                Assert.Fail("Deed Search PDF download failed due to exception.");
            }
        }

        // Other tests (if needed) can be added here...
    }
}


