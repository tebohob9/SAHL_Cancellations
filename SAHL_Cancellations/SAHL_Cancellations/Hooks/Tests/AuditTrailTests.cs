using Cancellations_Tests.BasePage;  // Changed from SAHL_Cancellations.BasePage
using SAHL_Cancellations.Pages;
using SAHL_Cancellations.Utilities;
using NUnit.Framework;
using System;
using System.Threading;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;

namespace SAHL_Cancellations.Tests
{
    [TestFixture]
    public class AuditTrailTestsHook : BaseClass
    {
        // Declare page objects
        public LandingPage LandingPage;
        public HomePage HomePage;
        public CorrespondentsPage CorrespondentsPage;
        public New_InstructionPage New_InstructionPage;
        public AuditTrailPage AuditTrailPage;
        private readonly string testClassName = "Audit Trail Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Initialize page objects
            LandingPage = new LandingPage(driver);
            HomePage = new HomePage(driver);
            CorrespondentsPage = new CorrespondentsPage(driver);
            New_InstructionPage = new New_InstructionPage(driver);
            AuditTrailPage = new AuditTrailPage(driver);
        }

        [Test, Category("Regression Test")]
        public void AddComment_Search_Download()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting AddComment_Search_Download test");

                // Perform actions on the HomePage
                test.Log(Status.Info, $"[{testClassName}] Selecting the product from the dropdown: {TestData.SAHL_Cancellations}");
                LandingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product from dropdown");

                Thread.Sleep(2000); // Wait for the page to load

                // Navigate to the "Main Cancellations" tab
                test.Log(Status.Info, $"[{testClassName}] Navigating to Main Cancellations tab");
                HomePage.SelectMainCancellationsTab();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated to Main Cancellations tab");

                Thread.Sleep(2000);  // Wait for the page to load

                // Navigate to the "New Instruction" page
                test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction page");
                New_InstructionPage = HomePage.RedirectToNewInstructionPage();
                test.Log(Status.Pass, $"[{testClassName}] Successfully redirected to New Instruction page");

                // Add comment, search, and download on the Audit Trail page
                test.Log(Status.Info, $"[{testClassName}] Adding comment, searching, and downloading");
                AuditTrailPage.AddComment(TestData.Comment, TestData.Search2);
                test.Log(Status.Pass, $"[{testClassName}] Successfully added comment, searched, and downloaded");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_AddComment_Search_Download_Success");

                test.Log(Status.Pass, $"[{testClassName}] AddComment_Search_Download test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_AddComment_Search_Download_Failure");
                throw;
            }
        }
    }
}



