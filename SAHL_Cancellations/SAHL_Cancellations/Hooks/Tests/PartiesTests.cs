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
    public class PartiesTestsHook : BaseClass
    {
        // Declare page objects
        public LandingPage LandingPage;
        public HomePage HomePage;
        public CorrespondentsPage CorrespondentsPage;
        public New_InstructionPage New_InstructionPage;
        public PartiesPage PartiesPage;
        private readonly string testClassName = "Parties Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            LandingPage = new LandingPage(driver);
            HomePage = new HomePage(driver);
            CorrespondentsPage = new CorrespondentsPage(driver);
            PartiesPage = new PartiesPage(driver);
        }

        /// <summary>
        /// Test to complete the Natural Person form on the Parties page.
        /// </summary>
        [Test, Order(1), Category("Regression Test")]
        public void CompleteNaturalPersonForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use
            
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteNaturalPersonForm test");
                
                // Navigate to Parties section
                test.Log(Status.Info, $"[{testClassName}] Navigating to Parties section");
                NavigateToPartiesSection();
                test.Log(Status.Pass, $"[{testClassName}] Successfully navigated to Parties section");
                
                // Complete the Natural Person form
                test.Log(Status.Info, $"[{testClassName}] Completing Natural Person form");
                PartiesPage.CompleteNaturalPersonUnmariedForm(
                    TestData.SelectPartyTypeNaturalPerson,
                    TestData.FirstName,
                    TestData.Surname,
                    TestData.Gender,
                    TestData.MethodOfIdentification,
                    TestData.IdentityNumber1,
                    TestData.MaritalStatus);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Natural Person form");
                
                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteNaturalPersonForm_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteNaturalPersonForm_Failure");
                Console.WriteLine("Test failed: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Test to complete the Entity Company form on the Parties page.
        /// </summary>
        [Test, Order(2), Category("Regression Test")]
        public void CompleteEntityCompanyForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use
            
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteEntityCompanyForm test");
                
                // Complete the Entity Company form directly
                // This assumes we're already on the Parties page from the previous test
                test.Log(Status.Info, $"[{testClassName}] Completing Entity Company form");
                PartiesPage.CompleteEntityCompanyForm(
                    TestData.SelectPartyTypeEntity,
                    TestData.CompanyType,
                    TestData.NameOfCompany,
                    TestData.RegistrationNumber1,
                    TestData.RegistrationNumber2,
                    TestData.RegistrationNumber3);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Entity Company form");
                
                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteEntityCompanyForm_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteEntityCompanyForm_Failure");
                Console.WriteLine("Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(3), Category("Regression Test")]
        public void CompleteEntityCloseCorporationForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use
            
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteEntityCloseCorporationForm test");
                
                // Complete the Entity Close Corporation form directly
                test.Log(Status.Info, $"[{testClassName}] Completing Entity Close Corporation form");
                PartiesPage.CompleteEntityCloseCorporationForm(
                    TestData.SelectPartyTypeEntity,
                    TestData.EntityTypeCloseCorporation,
                    TestData.NameOfCloseCorporation,
                    TestData.RegistrationNumber1,
                    TestData.RegistrationNumber2,
                    TestData.RegistrationNumber3);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Entity Close Corporation form");
                
                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteEntityCloseCorporationForm_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteEntityCloseCorporationForm_Failure");
                Console.WriteLine("Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(4), Category("Regression Test")]
        public void CompleteEntityTrustForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use
            
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteEntityTrustForm test");
                
                // Complete the Entity Trust form directly
                test.Log(Status.Info, $"[{testClassName}] Completing Entity Trust form");
                PartiesPage.CompleteEntityTrustForm(
                    TestData.SelectPartyTypeEntity,
                    TestData.EntityTypeTrust,
                    TestData.TrustType, 
                    TestData.NameOfTrust,
                    TestData.AuthorityNumber);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Entity Trust form");
                
                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteEntityTrustForm_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteEntityTrustForm_Failure");
                Console.WriteLine("Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(5), Category("Regression Test")]
        public void CompletePartnershipForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use
            
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompletePartnershipForm test");
                
                // Complete the Partnership form directly
                test.Log(Status.Info, $"[{testClassName}] Completing Partnership form");
                PartiesPage.CompletePartnershipForm(
                    TestData.SelectPartyTypePartnership,
                    TestData.Name,
                    TestData.FirstName,
                    TestData.Surname,
                    TestData.Gender,
                    TestData.MethodOfIdentification,
                    TestData.IdentityNumber1,
                    TestData.MaritalStatus);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Partnership form");
                
                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompletePartnershipForm_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompletePartnershipForm_Failure");
                Console.WriteLine("Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(6), Category("Regression Test")]
        public void CompleteNaturalPersonOutOfCommunityForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use
            
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteNaturalPersonOutOfCommunityForm test");
                
                // Complete the Natural Person Out Of Community form directly
                test.Log(Status.Info, $"[{testClassName}] Completing Natural Person Out Of Community form");
                PartiesPage.CompleteNaturalPersonOutOfCommunityForm(
                    TestData.SelectPartyTypeNaturalPerson,
                    TestData.FirstName,
                    TestData.Surname,
                    TestData.Gender,
                    TestData.MethodOfIdentification,
                    TestData.IdentityNumber1,
                    TestData.MaritalStatus2,
                    TestData.ReasonForExclusion, 
                    TestData.Duedate);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Natural Person Out Of Community form");
                
                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteNaturalPersonOutOfCommunityForm_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteNaturalPersonOutOfCommunityForm_Failure");
                Console.WriteLine("Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(7), Category("Regression Test")]
        public void CompleteInstitutionCouncilForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use
            
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteInstitutionCouncilForm test");
                
                // Complete the Institution Council form directly
                test.Log(Status.Info, $"[{testClassName}] Completing Institution Council form");
                PartiesPage.CompleteInstitutionCouncilForm(
                    TestData.PartyTypeInstitution,
                    TestData.TypeCityTownCouncil,
                    TestData.Council);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Institution Council form");
                
                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteInstitutionCouncilForm_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteInstitutionCouncilForm_Failure");
                Console.WriteLine("Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(8), Category("Regression Test")]
        public void CompleteInstitutionStatutoryBodyForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use
            
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteInstitutionStatutoryBodyForm test");
                
                // Wait for 2 seconds
                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);
                
                // Complete the Institution Statutory Body form directly
                test.Log(Status.Info, $"[{testClassName}] Completing Institution Statutory Body form");
                PartiesPage.CompleteInstitutionStatutoryBodyForm(
                    TestData.PartyTypeInstitution,
                    TestData.TypeStatutoryBody,
                    TestData.NameOfStatutoryBody,
                    TestData.EstablishmentInTermsOf);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Institution Statutory Body form");
                
                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteInstitutionStatutoryBodyForm_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteInstitutionStatutoryBodyForm_Failure");
                Console.WriteLine("Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(9), Category("Regression Test")]
        public void CompleteInstitutionProvincialAdministrationForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use
            
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteInstitutionProvincialAdministrationForm test");
                
                // Complete the Institution Provincial Administration form directly
                test.Log(Status.Info, $"[{testClassName}] Completing Institution Provincial Administration form");
                PartiesPage.CompleteInstitutionProvincialAdministrationForm(
                    TestData.PartyTypeInstitution,
                    TestData.TypeProvincialAdministration,
                    TestData.Province4);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Institution Provincial Administration form");
                
                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteInstitutionProvincialAdministrationForm_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteInstitutionProvincialAdministrationForm_Failure");
                Console.WriteLine("Test failed: " + ex.Message);
                throw;
            }
        }

        [Test, Order(10), Category("Regression Test")]
        public void CompleteInstitutionNationalGovernmentForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use
            
            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteInstitutionNationalGovernmentForm test");
                
                // Complete the Institution National Government form directly
                test.Log(Status.Info, $"[{testClassName}] Completing Institution National Government form");
                PartiesPage.CompleteInstitutionNationalGovernmentForm(
                    TestData.PartyTypeInstitution,
                    TestData.TypeNationalGovernment, 
                    TestData.NationalGovernmentLegalDescription);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Institution National Government form");
                
                // Capture final screenshot
                CaptureScreenshot($"{testClassName}_CompleteInstitutionNationalGovernmentForm_Success");
            }
            catch (Exception ex)
            {
                // Log the exception
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteInstitutionNationalGovernmentForm_Failure");
                Console.WriteLine("Test failed: " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Common navigation logic reused by both tests.
        /// </summary>
        private void NavigateToPartiesSection()
        {
            // Select the product from the dropdown
            test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
            Console.WriteLine("Selecting product: " + TestData.SAHL_Cancellations);
            LandingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
            test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");
            
            // Wait for the page to load
            test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
            Thread.Sleep(2000);
            
            // Navigate to the "Main Cancellations" tab
            test.Log(Status.Info, $"[{testClassName}] Navigating to Main Cancellations tab");
            HomePage.SelectMainCancellationsTab();
            test.Log(Status.Pass, $"[{testClassName}] Successfully navigated to Main Cancellations tab");
            
            // Wait for the page to load
            test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
            Thread.Sleep(2000);
            
            // Navigate to the "New Instruction" page
            test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction Page");
            New_InstructionPage = HomePage.RedirectToNewInstructionPage();
            test.Log(Status.Pass, $"[{testClassName}] Redirected to New Instruction Page");
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



