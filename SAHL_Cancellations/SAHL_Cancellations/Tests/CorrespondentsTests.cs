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
    public class CorrespondentsTests : BaseClass
    {
        // Declare page objects
        public LandingPage LandingPage;
        public HomePage HomePage;
        public CorrespondentsPage CorrespondentsPage;
        public New_InstructionPage New_InstructionPage;
        private readonly string testClassName = "Correspondents Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Initialize page objects
            LandingPage = new LandingPage(driver);
            HomePage = new HomePage(driver);
            CorrespondentsPage = new CorrespondentsPage(driver);
            New_InstructionPage = new New_InstructionPage(driver);
        }

        [Test, Order(1), Category("Regression Test")]
        public void CompleteAddressDetails()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteAddressDetails test");

                // Navigate to product
                test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
                LandingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                // Select the main cancellations tab
                test.Log(Status.Info, $"[{testClassName}] Navigating to Main Cancellations tab");
                HomePage.SelectMainCancellationsTab();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated to Main Cancellations tab");

                // Navigate to New Instruction page
                test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction page");
                New_InstructionPage = HomePage.RedirectToNewInstructionPage();
                test.Log(Status.Pass, $"[{testClassName}] Successfully redirected to New Instruction page");

                // Fill Contact Details tab on Correspondents
                test.Log(Status.Info, $"[{testClassName}] Completing contact details");
                CorrespondentsPage.CompleteContactDetails(
                    TestData.EntityType,
                    TestData.Contact_Person,
                    TestData.Contact_IDNo,
                    TestData.Tel_Work,
                    TestData.Tel_Cell,
                    TestData.Tel_home,
                    TestData.Fax2,
                    TestData.Email2,
                    TestData.Letter_Caption,
                    TestData.Company,
                    TestData.Company_RegNo,
                    TestData.Branch2,
                    TestData.Docex2
                );
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed contact details");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteAddressDetails_Success");

                test.Log(Status.Pass, $"[{testClassName}] CompleteAddressDetails test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteAddressDetails_Failure");
                throw;
            }
        }

        [Test, Order(2), Category("Regression Test")]
        public void CompleteContactDetails()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteContactDetails test");

                // Fill Address Details tab on Correspondents
                test.Log(Status.Info, $"[{testClassName}] Completing address details form");
                CorrespondentsPage.CompleteAddressDetailsForm(
                    TestData.EntityType,
                    TestData.PhysicalAddressLine1,
                    TestData.PhysicalAddressLine2,
                    TestData.PhysicalAddressLine3,
                    TestData.City2,
                    TestData.PhysicalAddressCode,
                    TestData.Province2,
                    TestData.Country2,
                    TestData.POBoxLine1,
                    TestData.POBoxLine2,
                    TestData.POBoxLine3,
                    TestData.PostalCode
                );
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed address details form");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteContactDetails_Success");

                test.Log(Status.Pass, $"[{testClassName}] CompleteContactDetails test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteContactDetails_Failure");
                throw;
            }
        }

        [Test, Order(3), Category("Regression Test")]
        public void SendEmail()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting SendEmail test");

                // Send Email
                test.Log(Status.Info, $"[{testClassName}] Sending email with subject: {TestData.EntityType}");
                CorrespondentsPage.SendEmail(TestData.EntityType);
                test.Log(Status.Pass, $"[{testClassName}] Successfully sent email");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_SendEmail_Success");

                test.Log(Status.Pass, $"[{testClassName}] SendEmail test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_SendEmail_Failure");
                throw;
            }
        }

        [Test, Order(4), Category("Regression Test")]
        public void SendMultipleEmails()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting SendMultipleEmails test");

                // Send Multiple Emails
                test.Log(Status.Info, $"[{testClassName}] Sending multiple emails with subject: {TestData.EntityType}");
                CorrespondentsPage.SendMultipleEmails(TestData.EntityType);
                test.Log(Status.Pass, $"[{testClassName}] Successfully sent multiple emails");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_SendMultipleEmails_Success");

                test.Log(Status.Pass, $"[{testClassName}] SendMultipleEmails test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_SendMultipleEmails_Failure");
                throw;
            }
        }

        [Test, Order(5), Category("Regression Test")]
        public void SendSMS()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting SendSMS test");

                // Send SMS
                test.Log(Status.Info, $"[{testClassName}] Sending SMS with message: {TestData.EntityType}");
                CorrespondentsPage.SendSMS(TestData.EntityType);
                test.Log(Status.Pass, $"[{testClassName}] Successfully sent SMS");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_SendSMS_Success");

                test.Log(Status.Pass, $"[{testClassName}] SendSMS test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_SendSMS_Failure");
                throw;
            }
        }

        [Test, Order(6), Category("Regression Test")]
        public void SendMultipleSMS()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting SendMultipleSMS test");

                // Send Multiple SMS
                test.Log(Status.Info, $"[{testClassName}] Sending multiple SMS with message: {TestData.EntityType}");
                CorrespondentsPage.SendMultipleSMS(TestData.EntityType);
                test.Log(Status.Pass, $"[{testClassName}] Successfully sent multiple SMS");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_SendMultipleSMS_Success");

                test.Log(Status.Pass, $"[{testClassName}] SendMultipleSMS test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_SendMultipleSMS_Failure");
                throw;
            }
        }
    }
}


