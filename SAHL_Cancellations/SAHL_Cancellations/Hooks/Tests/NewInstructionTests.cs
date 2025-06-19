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
    public class NewInstructionTestsHook : BaseClass
    {
        // Page object declarations
        private LandingPage _landingPage;
        private HomePage _homePage;
        private New_InstructionPage _newInstructionPage;
        private readonly string testClassName = "New Instruction Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Instantiate all page objects
            _landingPage = new LandingPage(driver);
            _homePage = new HomePage(driver);
            _newInstructionPage = new New_InstructionPage(driver);
        }

        /// <summary>
        /// Test: Navigate and click tabs in the New Instruction page.
        /// </summary>
        [Test, Order(1), Category("Regression Test")]
        public void OpenNewInstructionsPage()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting OpenNewInstructionsPage test");

                test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
                _landingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction Page");
                _newInstructionPage = _homePage.RedirectToNewInstructionPage();
                test.Log(Status.Pass, $"[{testClassName}] Successfully redirected to New Instruction Page");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

                // Capture screenshot of the New Instructions page
                CaptureScreenshot($"{testClassName}_OpenNewInstructionsPage_Success");

                test.Log(Status.Pass, $"[{testClassName}] Successfully opened New Instructions Page");
                // TODO: Assert tabs are visible/active, e.g.
                // Assert.IsTrue(_newInstructionPage.IsPropertyTabDisplayed(), "Property tab is not displayed.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_OpenNewInstructionsPage_Failure");
                //Console.WriteLine("Test 'NavigateAndSelectTabsInOrder' failed: " + ex.Message);
                //throw;
            }
        }

        /// <summary>
        /// Test: Verify Mortgagee, Mortgagor, and Property link navigations on New Instruction page.
        /// </summary>
        [Test, Order(2), Category("Regression Test")]
        public void Select_Mortgagee_Mortgagor_Property()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting Select_Mortgagee_Mortgagor_Property test");

                // Uncomment if needed
                // test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
                // _landingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                // test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                // test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction Page");
                // _newInstructionPage = _homePage.RedirectToNewInstructionPage();
                // test.Log(Status.Pass, $"[{testClassName}] Successfully redirected to New Instruction Page");

                test.Log(Status.Info, $"[{testClassName}] Selecting Mortgagee, Mortgagor, and Property links");
                _newInstructionPage.Select_Mortgagee_Mortgagor_Property();
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected Mortgagee, Mortgagor, and Property links");

                // Capture screenshot after selecting links
                CaptureScreenshot($"{testClassName}_Select_Mortgagee_Mortgagor_Property_Success");

                test.Log(Status.Pass, $"[{testClassName}] Select_Mortgagee_Mortgagor_Property test completed successfully");
                // TODO: Add verification like:
                // Assert.IsTrue(_newInstructionPage.IsMortgageeSectionLoaded(), "Mortgagee section failed to load.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_Select_Mortgagee_Mortgagor_Property_Failure");
                Console.WriteLine("Test 'VerifyNavigationLinks' failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(3), Category("Regression Test")]
        public void EnterFileNote()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting EnterFileNote test");

                // Uncomment if needed
                // test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
                // _landingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                // test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                // test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction Page");
                // _newInstructionPage = _homePage.RedirectToNewInstructionPage();
                // test.Log(Status.Pass, $"[{testClassName}] Successfully redirected to New Instruction Page");

                test.Log(Status.Info, $"[{testClassName}] Entering file note: {TestData.FileNote}");
                _newInstructionPage.EnterFileNote(TestData.FileNote);
                test.Log(Status.Pass, $"[{testClassName}] Successfully entered file note");

                // Capture screenshot after entering file note
                CaptureScreenshot($"{testClassName}_EnterFileNote_Success");

                test.Log(Status.Pass, $"[{testClassName}] EnterFileNote test completed successfully");
                // TODO: Add verification like:
                // Assert.IsTrue(_newInstructionPage.IsMortgageeSectionLoaded(), "Mortgagee section failed to load.");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_EnterFileNote_Failure");
                Console.WriteLine("Test 'VerifyNavigationLinks' failed: " + ex.Message);
                throw;
            }
            // Additional test stubs for further expansion (optional)
            /*
            [Test, Order(3), Category("Regression Test")]
            public void AddNewInstruction_WithValidData()
            {
                // TODO: Add method to complete form and submit
            }
            */
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



