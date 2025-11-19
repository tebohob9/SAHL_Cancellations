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
    /// <summary>
    /// Regression test suite for Home Page functionality.
    /// </summary>
    [TestFixture]
    public class HomePageTestHook : BaseClass
    {
        // Page object instances
        private LandingPage landingPage;
        private HomePage homePage;
        private RequestFiguresPage requestCancellationPage;
        private readonly string testClassName = "Home Page Tests"; // Class name for reporting

        /// <summary>
        /// Runs before each test. Initializes required page objects.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            landingPage = new LandingPage(driver);
            homePage = new HomePage(driver);
        }

        /// <summary>
        /// Tests opening and closing Setup, Assistance, and Reports links.
        /// </summary>
        [Test, Order(1), Category("Regression Test")]
        public void OpenAndCloseLinks()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting OpenAndCloseLinks test");

                // Select the product from the dropdown (only in first test)
                test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
                landingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                // Open and close various links
                test.Log(Status.Info, $"[{testClassName}] Opening and closing navigation links");
                homePage.OpenAndCloseLinks();
                test.Log(Status.Pass, $"[{testClassName}] Successfully opened and closed navigation links");

                Thread.Sleep(2000);

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_OpenAndCloseLinks_Success");

                test.Log(Status.Pass, $"[{testClassName}] OpenAndCloseLinks test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_OpenAndCloseLinks_Failure");
                throw;
            }
        }

        /// <summary>
        /// Navigates through all tabs under "My User" context.
        /// </summary>
        [Test, Order(2), Category("Regression Test")]
        public void SelectMyUserTabsInOrder()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting SelectMyUserTabsInOrder test");

                // Navigate through My User tabs
                test.Log(Status.Info, $"[{testClassName}] Navigating through My User tabs in order");
                homePage.SelectUserTabsInOrder();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated through My User tabs");

                Thread.Sleep(2000);

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_SelectMyUserTabsInOrder_Success");

                test.Log(Status.Pass, $"[{testClassName}] SelectMyUserTabsInOrder test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_SelectMyUserTabsInOrder_Failure");
                throw;
            }
        }

        /// <summary>
        /// Navigates through all tabs under "My Branch" context.
        /// </summary>
        [Test, Order(3), Category("Regression Test")]
        public void SelectMyBranchTabsInOrder()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting SelectMyBranchTabsInOrder test");

                // Navigate through My Branch tabs
                test.Log(Status.Info, $"[{testClassName}] Navigating through My Branch tabs in order");
                homePage.SelectBranchTabsInOrder();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated through My Branch tabs");

                Thread.Sleep(2000);

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_SelectMyBranchTabsInOrder_Success");

                test.Log(Status.Pass, $"[{testClassName}] SelectMyBranchTabsInOrder test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_SelectMyBranchTabsInOrder_Failure");
                throw;
            }
        }

        /// <summary>
        /// Performs multiple search operations in "My Branch" context using different criteria.
        /// </summary>
        [Test, Order(4), Category("Regression Test")]
        public void MyBranch_Search()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting MyBranch_Search test");

                // Perform search operations
                test.Log(Status.Info, $"[{testClassName}] Performing search operations with multiple criteria");
                test.Log(Status.Info, $"[{testClassName}] Search criteria - ID: {TestData.Search_ID}, Account: {TestData.Account}, Property: {TestData.Property}, Mortgagor: {TestData.Parties}");

                homePage.ComapnySearch(
                    TestData.Search_ID,
                    TestData.Account,
                    TestData.Property,
                    TestData.Parties,
                    TestData.Blank
                );

                test.Log(Status.Pass, $"[{testClassName}] Successfully performed all search operations");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_MyBranch_Search_Success");

                test.Log(Status.Pass, $"[{testClassName}] MyBranch_Search test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_MyBranch_Search_Failure");
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



