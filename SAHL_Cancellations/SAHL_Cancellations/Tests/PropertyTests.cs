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
    public class PropertyTests : BaseClass
    {
        // Declare page objects
        public LandingPage LandingPage;
        public HomePage HomePage;
        public CorrespondentsPage CorrespondentsPage;
        public New_InstructionPage New_InstructionPage;
        public PropertyPage PropertyPage;
        private readonly string testClassName = "Property Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            LandingPage = new LandingPage(driver);
            HomePage = new HomePage(driver);
            CorrespondentsPage = new CorrespondentsPage(driver);
            PropertyPage = new PropertyPage(driver);
        }

        [Test, Order(1), Category("Regression Test")]
        public void ERFNoSubDivisionalType()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting ERFNoSubDivisionalType test");

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

                // Complete the ERF No SubDivisional Type form
                test.Log(Status.Info, $"[{testClassName}] Completing ERF No SubDivisional Type form");
                PropertyPage.CompleteERFNoSubDivisionalType(
                    TestData.DeedsOffice,
                    TestData.SubDivisionalTypeNA,
                    TestData.ErfNumber,
                    TestData.Township,
                    TestData.RegistrationDivision,
                    TestData.Province3,
                    TestData.Extent1,
                    TestData.Extent2,
                    TestData.Address3,
                    TestData.HeldBy
                );
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed ERF No SubDivisional Type form");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_ERFNoSubDivisionalType_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_ERFNoSubDivisionalType_Failure");
                throw;
            }
        }

        [Test, Order(2), Category("Regression Test")]
        public void CompleteERFPortionSubDivisionalType()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteERFPortionSubDivisionalType test");

                // Complete the ERF Portion SubDivisional Type form directly
                // This assumes we're already on the Property page from the previous test
                test.Log(Status.Info, $"[{testClassName}] Completing ERF Portion SubDivisional Type form");
                PropertyPage.CompleteERFPortionSubDivisionalType(
                    TestData.DeedsOffice,
                    TestData.SubDivisionalTypePortion,
                    TestData.PortionNumber,
                    TestData.ErfNumber,
                    TestData.Township,
                    TestData.RegistrationDivision,
                    TestData.Province3,
                    TestData.Extent1,
                    TestData.Extent2,
                    TestData.Address3,
                    TestData.LegalBankDescription,
                    TestData.HeldBy
                );
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed ERF Portion SubDivisional Type form");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteERFPortionSubDivisionalType_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteERFPortionSubDivisionalType_Failure");
                throw;
            }
        }

        //[Test, Order(3), Category("Regression Test")]
        //public void CompleteSectionalWithEUA()
        //{
        //    try
        //    {
        //        PropertyPage.CompleteSectionalWithEUA(TestData.DeedsOffice, TestData.PropertyType,
        //            TestData.SubDivisionalTypePortion, TestData.PortionNumber, TestData.ErfNumber, TestData.Township, TestData.RegistrationDivision,
        //            TestData.Province3, TestData.Extent1, TestData.Extent2, TestData.Address3,
        //            TestData.LegalBankDescription, TestData.HeldBy);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}

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


