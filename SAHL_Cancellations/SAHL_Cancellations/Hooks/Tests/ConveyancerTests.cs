using Cancellations_Tests.BasePage;

using SAHL_Cancellations.Pages;
using SAHL_Cancellations.Utilities;
using NUnit.Framework;
using System;
using AventStack.ExtentReports;


namespace SAHL_Cancellations.Tests
{
    [TestFixture]
    public class ConveyancerTestsHook : BaseClass
    {
        // Declare page objects
        private LandingPage landingPage;
        private HomePage homePage;
        private CorrespondentsPage correspondentsPage;
        private New_InstructionPage newInstructionPage;
        private ConveyancerPage conveyancerPage;
        private readonly string testClassName = "Conveyancer Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Initialize all page objects before each test
            landingPage = new LandingPage(driver);
            homePage = new HomePage(driver);
            correspondentsPage = new CorrespondentsPage(driver);
            newInstructionPage = new New_InstructionPage(driver);
            conveyancerPage = new ConveyancerPage(driver);
        }

        [Test, Order(1), Category("Regression Test")]
        public void SaveMyBranchDetails()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting SaveMyBranchDetails test");
                Console.WriteLine("Starting test: SaveMyBranchDetails");

                // Navigate to product
                test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
                Console.WriteLine($"Selecting product: {TestData.SAHL_Cancellations}");
                landingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                // Select the main cancellations tab
                test.Log(Status.Info, $"[{testClassName}] Navigating to Main Cancellations tab");
                homePage.SelectMainCancellationsTab();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated to Main Cancellations tab");

                // Navigate to New Instruction page
                test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction page");
                newInstructionPage = homePage.RedirectToNewInstructionPage();
                test.Log(Status.Pass, $"[{testClassName}] Successfully redirected to New Instruction page");

                // Save branch details on the conveyancer page
                test.Log(Status.Info, $"[{testClassName}] Saving branch details");
                conveyancerPage.SaveMyBranchDetails(
                    TestData.DateOfSignature,
                    TestData.PlaceOfSignature,
                    TestData.LodgementNumber,
                    TestData.Conveyancer,
                    TestData.CommisionerOfOaths
                );
                test.Log(Status.Pass, $"[{testClassName}] Successfully saved branch details");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_SaveMyBranchDetails_Success");

                test.Log(Status.Pass, $"[{testClassName}] SaveMyBranchDetails test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                Console.WriteLine($"Test failed: {ex.Message}");
                CaptureScreenshot($"{testClassName}_SaveMyBranchDetails_Failure");
                throw;
            }
        }

        [Test, Order(2), Category("Regression Test")]
        public void SaveCorrespondentDetails()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting SaveCorrespondentDetails test");

                // Save correspondent details on the conveyancer page
                test.Log(Status.Info, $"[{testClassName}] Saving correspondent details");
                conveyancerPage.SaveCorrespondentDetails(
                    TestData.PlaceOfSignature,
                    TestData.CorrespondentName,
                    TestData.CorrespondentBranch,
                    TestData.LodgementNumber,
                    TestData.CommisionerOfOaths
                );
                test.Log(Status.Pass, $"[{testClassName}] Successfully saved correspondent details");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_SaveCorrespondentDetails_Success");

                test.Log(Status.Pass, $"[{testClassName}] SaveCorrespondentDetails test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                Console.WriteLine($"Test failed: {ex.Message}");
                CaptureScreenshot($"{testClassName}_SaveCorrespondentDetails_Failure");
                throw;
            }
        }

        // Add additional tests here if needed...
    }
}



