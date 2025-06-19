//using Cancellations_Tests.BasePage;
//using SAHL_Cancellations.Pages;
//using SAHL_Cancellations.Utilities;
//using System;
//using NUnit.Framework;
//using AventStack.ExtentReports;
//using Cancellations_Tests.Utilities;
//using OpenQA.Selenium;
//using Cancellations_Tests.BasePage;

//namespace SAHL_Cancellations.Tests
//{
//    [TestFixture]
//    public class LoginTest : BaseClass
//    {
//        public LoginPage LoginPage;
//        private readonly string testClassName = "Login Tests"; // Class name for reporting

//        [SetUp]
//        public void SetUp()
//        {
//            // Initialize page objects
//            LoginPage = new LoginPage(driver);
//        }

//        [Test, Category("Regression Test")]
//        public void VerifyLogin()
//        {
//            // Start the test in ExtentReports with class name prefix
//            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
//            ExtentReport._scenario = test; // Set the current test for page objects to use

//            try
//            {
//                test.Log(Status.Info, $"[{testClassName}] Starting VerifyLogin test");

//                // Optionally verify the page title
//                // string pageTitle = LoginPage.GetTitle();
//                // test.Log(Status.Info, $"[{testClassName}] Page title: {pageTitle}");
//                // Assert.That(Is.Equals(pageTitle, "Expected Title"));

//                test.Log(Status.Info, $"[{testClassName}] Attempting to login with LUN: {TestData.LUN}");
//                LoginPage.Login(TestData.LUN);

//                // Capture screenshot after login
//                CaptureScreenshot($"{testClassName}_VerifyLogin_Success");

//                test.Log(Status.Pass, $"[{testClassName}] Login successful");
//            }
//            catch (Exception ex)
//            {
//                test.Log(Status.Fail, $"[{testClassName}] Login failed with exception: {ex.Message}");
//                CaptureScreenshot($"{testClassName}_VerifyLogin_Failure");
//                Console.WriteLine($"Login test failed: {ex.Message}");
//                throw;
//            }
//        }

//        // Helper method to capture screenshots
//        private void CaptureScreenshot(string screenshotName)
//        {
//            try
//            {
//                if (driver != null)
//                {
//                    ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
//                    Screenshot screenshot = takesScreenshot.GetScreenshot();
//                    string screenshotPath = System.IO.Path.Combine(ExtentReport.testResultPath, screenshotName + ".png");
//                    screenshot.SaveAsFile(screenshotPath);
//                    if (test != null)
//                    {
//                        test.AddScreenCaptureFromPath(screenshotPath);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
//                if (test != null)
//                {
//                    test.Log(Status.Warning, $"Failed to capture screenshot: {ex.Message}");
//                }
//            }
//        }
//    }
//}


