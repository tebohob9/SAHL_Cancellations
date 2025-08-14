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
    public class DiaryTests : BaseClass
    {
        // Declare page objects
        public LandingPage LandingPage;
        public HomePage HomePage;
        public DiaryPage DiaryPage;
        public New_InstructionPage New_InstructionPage;
        private readonly string testClassName = "Diary Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Initialize page objects before each test
            LandingPage = new LandingPage(driver);
            HomePage = new HomePage(driver);
            DiaryPage = new DiaryPage(driver);
            New_InstructionPage = new New_InstructionPage(driver);
        }

        [Test, Order(1), Category("Regression Test")]
        public void AddCustomDiaryItem()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting AddCustomDiaryItem test");

                // Perform actions on the HomePage
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
                test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction page");
                New_InstructionPage = HomePage.RedirectToNewInstructionPage();
                test.Log(Status.Pass, $"[{testClassName}] Successfully redirected to New Instruction page");

                // Calculate the date 5 days from today for the Due Date
                string dueDate = DateTime.Now.AddDays(5).ToString("yyyy/MM/dd");  // Format as needed
                test.Log(Status.Info, $"[{testClassName}] Calculated due date: {dueDate}");

                // Call the AddCustomDiaryItem method with dynamic due date
                test.Log(Status.Info, $"[{testClassName}] Adding custom diary item");
                DiaryPage.AddCustomDiaryItem(TestData.Description, dueDate, TestData.DiaryNotes);
                test.Log(Status.Pass, $"[{testClassName}] Successfully added custom diary item");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_AddCustomDiaryItem_Success");

                test.Log(Status.Pass, $"[{testClassName}] AddCustomDiaryItem test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_AddCustomDiaryItem_Failure");
            }
        }

        [Test, Order(2), Category("Regression Test")]
        public void SaveWithoutCompulsoryfields()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting SaveWithoutCompulsoryfields test");

                // Call the SaveWithoutCompulsoryfields method
                test.Log(Status.Info, $"[{testClassName}] Testing save without compulsory fields");
                DiaryPage.SaveWithoutCompulsoryfields();
                test.Log(Status.Pass, $"[{testClassName}] Successfully tested save without compulsory fields");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_SaveWithoutCompulsoryfields_Success");

                test.Log(Status.Pass, $"[{testClassName}] SaveWithoutCompulsoryfields test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_SaveWithoutCompulsoryfields_Failure");
            }
        }

        [Test, Order(3), Category("Regression Test")]
        public void EditDiary()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting EditDiary test");

                // Calculate the date 5 days from today for the Due Date
                string dueDate = DateTime.Now.AddDays(5).ToString("yyyy/MM/dd");  // Format as needed
                test.Log(Status.Info, $"[{testClassName}] Calculated due date: {dueDate}");

                // Call the EditDiary method with dynamic due date
                test.Log(Status.Info, $"[{testClassName}] Editing diary item");
                DiaryPage.EditDiary(TestData.DescriptionEdit);
                test.Log(Status.Pass, $"[{testClassName}] Successfully edited diary item");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_EditDiary_Success");

                test.Log(Status.Pass, $"[{testClassName}] EditDiary test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_EditDiary_Failure");
            }
        }

        [Test, Order(4), Category("Regression Test")]
        public void DownloadDiary()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting DownloadDiary test");

                // Call the DownloadDiary method
                test.Log(Status.Info, $"[{testClassName}] Downloading diary");
                DiaryPage.DownloadDiary();
                test.Log(Status.Pass, $"[{testClassName}] Successfully downloaded diary");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_DownloadDiary_Success");

                test.Log(Status.Pass, $"[{testClassName}] DownloadDiary test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_DownloadDiary_Failure");
            }
        }

        [Test, Order(5), Category("Regression Test")]
        public void AddEditRemoveNote()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting AddEditRemoveNote test");

                // Call the AddEditRemoveNote method
                test.Log(Status.Info, $"[{testClassName}] Adding, editing, and removing note");
                DiaryPage.AddEditRemoveNote(TestData.DiaryNotes);
                test.Log(Status.Pass, $"[{testClassName}] Successfully added, edited, and removed note");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_AddEditRemoveNote_Success");

                test.Log(Status.Pass, $"[{testClassName}] AddEditRemoveNote test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_AddEditRemoveNote_Failure");
            }
        }

        [Test, Order(6), Category("Regression Test")]
        public void DiaryReminderMilestones()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting DiaryReminderMilestones test");

                // Calculate the date 5 days from today for the Due Date
                string dueDate = DateTime.Now.AddDays(5).ToString("yyyy/MM/dd");
                test.Log(Status.Info, $"[{testClassName}] Calculated due date: {dueDate}");

                // Call the DiaryReminderMilestones method with dynamic due date
                test.Log(Status.Info, $"[{testClassName}] Testing diary reminder and milestones");
                DiaryPage.DiaryReminderMilestones(TestData.Description, dueDate, TestData.DiaryNotes);
                test.Log(Status.Pass, $"[{testClassName}] Successfully tested diary reminder and milestones");

                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_DiaryReminderMilestones_Success");

                test.Log(Status.Pass, $"[{testClassName}] DiaryReminderMilestones test completed successfully");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_DiaryReminderMilestones_Failure");
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


