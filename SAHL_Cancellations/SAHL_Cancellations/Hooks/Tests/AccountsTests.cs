using Cancellations_Tests.BasePage;

using SAHL_Cancellations.Pages;
using SAHL_Cancellations.Utilities;
using NUnit.Framework;
using System;
using System.Threading;
using AventStack.ExtentReports;

namespace Cancellations_Tests.Tests
{
    [TestFixture]
    public class AccountsTestsHook : BaseClass
    {
        // Page Object Declarations
        private LandingPage LandingPage;
        private HomePage HomePage;
        private CorrespondentsPage CorrespondentsPage;
        private New_InstructionPage New_InstructionPage;
        private AccountsPage AccountsPage;
        private readonly string testClassName = "Accounts Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            // Instantiate all page objects before each test
            LandingPage = new LandingPage(driver);
            HomePage = new HomePage(driver);
            CorrespondentsPage = new CorrespondentsPage(driver);
            New_InstructionPage = new New_InstructionPage(driver);
            AccountsPage = new AccountsPage(driver);

            test.Log(Status.Info, $"[{testClassName}] Page objects initialized");
        }

        [Test, Order(1), Category("Regression Test")]
        public void CompleteAddItemForm()
        {
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteAddItemForm test");

                test.Log(Status.Info, $"[{testClassName}] Selecting the product from the dropdown: {TestData.SAHL_Cancellations}");
                LandingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Product selected successfully");

                // Navigate to Main Cancellations
                test.Log(Status.Info, $"[{testClassName}] Navigating to Main Cancellations tab");
                HomePage.SelectMainCancellationsTab();
                test.Log(Status.Pass, $"[{testClassName}] Navigated to Main Cancellations tab");

                // Navigate to New Instruction Page
                test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction Page");
                New_InstructionPage = HomePage.RedirectToNewInstructionPage();
                test.Log(Status.Pass, $"[{testClassName}] Redirected to New Instruction Page");

                // Complete Add Item form on Accounts Page
                test.Log(Status.Info, $"[{testClassName}] Completing Add Item form");
                AccountsPage.CompleteAddItemForm(
                    TestData.Item,
                    TestData.Debit,
                    TestData.Credit,
                    TestData.PaymentMethod
                );
                test.Log(Status.Pass, $"[{testClassName}] Add Item form completed successfully");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteAddItemForm_Success");

                test.Log(Status.Pass, $"[{testClassName}] CompleteAddItemForm test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteAddItemForm_Failure");
                throw;
            }
        }

        [Test, Order(2), Category("Regression Test")]
        public void ExportToExcel()
        {
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting ExportToExcel test");

                // Action on Accounts Page
                test.Log(Status.Info, $"[{testClassName}] Waiting before clicking Export button");
                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Clicking Export button");
                AccountsPage.ClickExportBtn();
                test.Log(Status.Pass, $"[{testClassName}] Export button clicked successfully");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_ExportToExcel_Success");

                test.Log(Status.Pass, $"[{testClassName}] ExportToExcel test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] ExportToExcel test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_ExportToExcel_Failure");
                throw;
            }
        }

        [Test, Order(3), Category("Regression Test")]
        public void RefreshAccounts()
        {
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting RefreshAccounts test");

                // Action on Accounts Page
                test.Log(Status.Info, $"[{testClassName}] Waiting before clicking Refresh button");
                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Clicking Reset button");
                AccountsPage.ClickResetBtn();
                test.Log(Status.Pass, $"[{testClassName}] Reset button clicked successfully");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_RefreshAccounts_Success");

                test.Log(Status.Pass, $"[{testClassName}] RefreshAccounts test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] RefreshAccounts test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_RefreshAccounts_Failure");
                throw;
            }
        }
    }
}



