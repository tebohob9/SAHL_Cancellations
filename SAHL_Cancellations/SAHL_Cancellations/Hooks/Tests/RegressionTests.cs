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
    public class RegressionTestsHook : BaseClass
    {
        // Declare page objects for reuse across all tests
        public LandingPage LandingPage;
        public HomePage HomePage;
        public RequestFiguresPage RequestCancellationPage;
        public DiaryPage DiaryPage;
        public New_InstructionPage New_InstructionPage;
        public CorrespondentsPage CorrespondentsPage;
        public InfoSheetPage InfoSheetPage;
        public InboxPage InboxPage;
        public DeedSearchPage DeedSearchPage;
        public InstructionDetailsPage InstructionDetailsPage;
        public PropertyPage PropertyPage;
        public PartiesPage PartiesPage;
        public RefundDetailsPage RefundDetailsPage;
        public AccountsPage AccountsPage;
        public ConveyancerPage ConveyancerPage;
        public PrintListPage PrintListPage;
        public AuditTrailPage AuditTrailPage;
        private readonly string testClassName = "Regression Tests"; // Class name for reporting

        [SetUp]
        public void SetUp()
        {
            // Initialize all page objects before each test
            LandingPage = new LandingPage(driver);
            HomePage = new HomePage(driver);
            RequestCancellationPage = new RequestFiguresPage(driver);
            DiaryPage = new DiaryPage(driver);
            CorrespondentsPage = new CorrespondentsPage(driver);
            InfoSheetPage = new InfoSheetPage(driver);
            InboxPage = new InboxPage(driver);
            DeedSearchPage = new DeedSearchPage(driver);
            InstructionDetailsPage = new InstructionDetailsPage(driver);
            PropertyPage = new PropertyPage(driver);
            PartiesPage = new PartiesPage(driver);
            RefundDetailsPage = new RefundDetailsPage(driver);
            AccountsPage = new AccountsPage(driver);
            ConveyancerPage = new ConveyancerPage(driver);
            PrintListPage = new PrintListPage(driver);
            AuditTrailPage = new AuditTrailPage(driver);
        }

        // Test 1: Validate product dropdown selection and link navigation
        [Test, Order(1), Category("Regression Test")]
        public void ClickProductDropDownAndSelectOption()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting ClickProductDropDownAndSelectOption test");

                test.Log(Status.Info, $"[{testClassName}] Selecting product: {TestData.SAHL_Cancellations}");
                LandingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product");

                test.Log(Status.Info, $"[{testClassName}] Opening and closing links");
                HomePage.OpenAndCloseLinks();
                test.Log(Status.Pass, $"[{testClassName}] Successfully opened and closed links");

                // Capture screenshot after completing the actions
                CaptureScreenshot($"{testClassName}_ClickProductDropDownAndSelectOption_Success");

                test.Log(Status.Pass, $"[{testClassName}] ClickProductDropDownAndSelectOption test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_ClickProductDropDownAndSelectOption_Failure");
                Console.WriteLine($"Test failed with exception: {ex.Message}");
                throw;
            }
        }

        // Test 2: Validate "My User" tab navigation
        //[Test, Order(2), Category("Regression Test")]
        //public void SelectMyUserTabsInOrder()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting SelectMyUserTabsInOrder test");

        //        test.Log(Status.Info, $"[{testClassName}] Selecting My User tabs in order");
        //        HomePage.SelectMyUserTabsInOrder();
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully selected My User tabs");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        // Capture screenshot after completing the actions
        //        CaptureScreenshot($"{testClassName}_SelectMyUserTabsInOrder_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] SelectMyUserTabsInOrder test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_SelectMyUserTabsInOrder_Failure");
        //        Console.WriteLine($"Test failed with exception: {ex.Message}");
        //        throw;
        //    }
        //}

        //// Test 3: Validate "My Branch" tab navigation
        //[Test, Order(3), Category("Regression Test")]
        //public void SelectMyBranchTabsInOrder()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting SelectMyBranchTabsInOrder test");

        //        test.Log(Status.Info, $"[{testClassName}] Selecting My Branch tabs in order");
        //        HomePage.SelectMyBranchTabsInOrder();
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully selected My Branch tabs");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        // Capture screenshot after completing the actions
        //        CaptureScreenshot($"{testClassName}_SelectMyBranchTabsInOrder_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] SelectMyBranchTabsInOrder test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_SelectMyBranchTabsInOrder_Failure");
        //        Console.WriteLine($"Test failed with exception: {ex.Message}");
        //        throw;
        //    }
        //}

        // Test 4: Perform search from "My Branch" page
        [Test, Order(4), Category("Regression Test")]
        public void MyBranchSearch()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting MyBranchSearch test");

                test.Log(Status.Info, $"[{testClassName}] Performing My Branch search with criteria");
                HomePage.ComapnySearch(TestData.Search_ID, TestData.Account, TestData.Property,
                    TestData.Parties, TestData.Blank);
                test.Log(Status.Pass, $"[{testClassName}] Successfully performed My Branch search");

                // Capture screenshot after completing the search
                CaptureScreenshot($"{testClassName}_MyBranchSearch_Success");

                test.Log(Status.Pass, $"[{testClassName}] MyBranchSearch test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_MyBranchSearch_Failure");
                Console.WriteLine($"Test failed with exception: {ex.Message}");
                throw;
            }
        }

        // Test 5: Complete request cancellation form with provided data
        [Test, Order(5), Category("Regression Test")]
        public void CompleteRequestCancellationsForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting CompleteRequestCancellationsForm test");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Clicking Request Cancellation button");
                //HomePage.ClickRequestCancellation();
                test.Log(Status.Pass, $"[{testClassName}] Successfully clicked Request Cancellation button");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

                //test.Log(Status.Info, $"[{testClassName}] Completing Request Cancellation form");
                //RequestCancellationPage.CompleteForm(
                //    TestData.Account_Number,
                //    TestData.Cancellation_Type_Switch,
                //    TestData.Title_Mr,
                //    TestData.Initials,
                //    TestData.Full_Name,
                //    TestData.Region_Free_State,
                //    TestData.Cancellation_Reason_EarlySettlementOfBond
                //);
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed Request Cancellation form");

                // Capture screenshot after completing the form
                CaptureScreenshot($"{testClassName}_CompleteRequestCancellationsForm_Success");

                test.Log(Status.Pass, $"[{testClassName}] CompleteRequestCancellationsForm test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteRequestCancellationsForm_Failure");
                Console.WriteLine("Test failed with exception: " + ex.Message);
                throw;
            }
        }

        // Test 6: Select links (Mortgagee, Mortgagor, Property) on New Instruction page
        [Test, Order(6), Category("Regression Test")]
        public void SelectLinks()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting SelectLinks test");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Redirecting to New Instruction page");
                New_InstructionPage = HomePage.RedirectToNewInstructionPage();
                test.Log(Status.Pass, $"[{testClassName}] Successfully redirected to New Instruction page");

                test.Log(Status.Info, $"[{testClassName}] Selecting Mortgagee, Mortgagor, and Property links");
                New_InstructionPage.Select_Mortgagee_Mortgagor_Property();
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected links");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Entering file note: {TestData.FileNote}");
                New_InstructionPage.EnterFileNote(TestData.FileNote);
                test.Log(Status.Pass, $"[{testClassName}] Successfully entered file note");

                // Capture screenshot after completing the actions
                CaptureScreenshot($"{testClassName}_SelectLinks_Success");

                test.Log(Status.Pass, $"[{testClassName}] SelectLinks test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_SelectLinks_Failure");
                Console.WriteLine("Test failed with exception: " + ex.Message);
                throw;
            }
        }

        // Test 7: Add custom diary item with calculated due date
        [Test, Order(7), Category("Regression Test")]
        public void Diary_AddCustomDiaryItem()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting Diary_AddCustomDiaryItem test");

                string dueDate = DateTime.Now.AddDays(5).ToString("yyyy/MM/dd");
                test.Log(Status.Info, $"[{testClassName}] Calculated due date: {dueDate}");

                test.Log(Status.Info, $"[{testClassName}] Adding custom diary item");
                DiaryPage.AddCustomDiaryItem(TestData.Description, dueDate, TestData.DiaryNotes);
                test.Log(Status.Pass, $"[{testClassName}] Successfully added custom diary item");

                test.Log(Status.Info, $"[{testClassName}] Saving without compulsory fields");
                DiaryPage.SaveWithoutCompulsoryfields();
                test.Log(Status.Pass, $"[{testClassName}] Successfully saved without compulsory fields");

                test.Log(Status.Info, $"[{testClassName}] Editing diary");
                DiaryPage.EditDiary(TestData.DescriptionEdit);
                test.Log(Status.Pass, $"[{testClassName}] Successfully edited diary");

                test.Log(Status.Info, $"[{testClassName}] Downloading diary");
                DiaryPage.DownloadDiary();
                test.Log(Status.Pass, $"[{testClassName}] Successfully downloaded diary");

                test.Log(Status.Info, $"[{testClassName}] Adding, editing, and removing note");
                DiaryPage.AddEditRemoveNote(TestData.DiaryNotes);
                test.Log(Status.Pass, $"[{testClassName}] Successfully added, edited, and removed note");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Setting diary reminder milestones");
                DiaryPage.DiaryReminderMilestones(TestData.Description, dueDate, TestData.DiaryNotes);
                test.Log(Status.Pass, $"[{testClassName}] Successfully set diary reminder milestones");

                // Capture screenshot after completing the actions
                CaptureScreenshot($"{testClassName}_Diary_AddCustomDiaryItem_Success");

                test.Log(Status.Pass, $"[{testClassName}] Diary_AddCustomDiaryItem test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_Diary_AddCustomDiaryItem_Failure");
                Console.WriteLine("Test failed with exception: " + ex.Message);
                throw;
            }
        }

        // Test 8: Complete address details on Correspondents page
        [Test, Order(8), Category("Regression Test")]
        public void Correspondents_CompleteAddressDetails()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting Correspondents_CompleteAddressDetails test");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

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
                    TestData.Contact_IDNo,
                    TestData.Branch2,
                    TestData.Docex2
                );
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed contact details");

                // Capture screenshot after completing the form
                CaptureScreenshot($"{testClassName}_Correspondents_CompleteAddressDetails_Success");

                test.Log(Status.Pass, $"[{testClassName}] Correspondents_CompleteAddressDetails test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_Correspondents_CompleteAddressDetails_Failure");
                Console.WriteLine("Test failed with exception: " + ex.Message);
                throw;
            }
        }

        // Test 9: Complete contact details for a correspondent
        [Test, Order(9), Category("Regression Test")]
        public void Correspondents_CompleteContactDetails()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
            ExtentReport._scenario = test; // Set the current test for page objects to use

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Starting Correspondents_CompleteContactDetails test");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

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

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

                //test.Log(Status.Info, $"[{testClassName}] Sending email");
                //CorrespondentsPage.SendEmail(TestData.EntityType);
                //test.Log(Status.Pass, $"[{testClassName}] Successfully sent email");

                //test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                //Thread.Sleep(2000);

                //test.Log(Status.Info, $"[{testClassName}] Sending multiple emails");
                //CorrespondentsPage.SendMultipleEmails(TestData.EntityType);
                //test.Log(Status.Pass, $"[{testClassName}] Successfully sent multiple emails");

                //test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                //Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Sending SMS");
                CorrespondentsPage.SendSMS(TestData.EntityType);
                test.Log(Status.Pass, $"[{testClassName}] Successfully sent SMS");

                test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Sending multiple SMS");
                CorrespondentsPage.SendMultipleSMS(TestData.EntityType);
                test.Log(Status.Pass, $"[{testClassName}] Successfully sent multiple SMS");

                // Capture screenshot after completing the actions
                CaptureScreenshot($"{testClassName}_Correspondents_CompleteContactDetails_Success");

                test.Log(Status.Pass, $"[{testClassName}] Correspondents_CompleteContactDetails test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_Correspondents_CompleteContactDetails_Failure");
                Console.WriteLine("Test failed with exception: " + ex.Message);
                throw;
            }
        }

        // Test 10: Edit secretary and file reference in the Info Sheet
        //[Test, Order(10), Category("Regression Test")]
        //public void InfoSheet_EditSecretaryAndFileRef()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting InfoSheet_EditSecretaryAndFileRef test");

        //        test.Log(Status.Info, $"[{testClassName}] Editing secretary");
        //        InfoSheetPage.EditSecretary();
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully edited secretary");

        //        test.Log(Status.Info, $"[{testClassName}] Editing file reference: {TestData.EditFileRef}");
        //        InfoSheetPage.EditFileRef(TestData.EditFileRef);
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully edited file reference");

        //        // Capture screenshot after completing the actions
        //        CaptureScreenshot($"{testClassName}_InfoSheet_EditSecretaryAndFileRef_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] InfoSheet_EditSecretaryAndFileRef test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_InfoSheet_EditSecretaryAndFileRef_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}

        //// Test 11: Read inbox message
        //[Test, Order(11), Category("Regression Test")]
        //public void Inbox_ReadMessage()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting Inbox_ReadMessage test");

        //        test.Log(Status.Info, $"[{testClassName}] Reading inbox message");
        //        InboxPage.ReadInboxMessage();
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully read inbox message");

        //        // Capture screenshot after reading the message
        //        CaptureScreenshot($"{testClassName}_Inbox_ReadMessage_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] Inbox_ReadMessage test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_Inbox_ReadMessage_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}

        //// Test 12: Perform deed search and download PDF
        //[Test, Order(12), Category("Regression Test")]
        //public void DeedSearch_SearchDownload()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting DeedSearch_SearchDownload test");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Downloading PDF for deed search: {TestData.DeedSearch}");
        //        DeedSearchPage.DownlaodPdf(TestData.DeedSearch);
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully downloaded PDF");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Clicking New Search button");
        //        DeedSearchPage.ClickNewSearch();
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully clicked New Search button");

        //        // Capture screenshot after completing the actions
        //        CaptureScreenshot($"{testClassName}_DeedSearch_SearchDownload_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] DeedSearch_SearchDownload test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_DeedSearch_SearchDownload_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}

        //// Test 13: Complete instruction details
        //[Test, Order(13), Category("Regression Test")]
        //public void InstructionDetails_Complete()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting InstructionDetails_Complete test");

        //        test.Log(Status.Info, $"[{testClassName}] Completing instruction details");
        //        InstructionDetailsPage.CompleteInstructionDetails(
        //            TestData.TitleDeedNumber,
        //            TestData.LegalBankDescription,
        //            TestData.PANumber,
        //            TestData.Signatories,
        //            TestData.BondNumber,
        //            TestData.BondAmount
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed instruction details");

        //        // Capture screenshot after completing the form
        //        CaptureScreenshot($"{testClassName}_InstructionDetails_Complete_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] InstructionDetails_Complete test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_InstructionDetails_Complete_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}

        //// Test 14: Add property details on Property page
        //[Test, Order(14), Category("Regression Test")]
        //public void Property_AddProperty()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting Property_AddProperty test");

        //        test.Log(Status.Info, $"[{testClassName}] Completing property form");
        //        PropertyPage.CompletePropertyForm(
        //            TestData.DeedsOffice,
        //            TestData.PropertyType,
        //            TestData.SubDivisionalTypeNA,
        //            TestData.ErfNumber,
        //            TestData.Township,
        //            TestData.RegistrationDivision,
        //            TestData.Province3,
        //            TestData.Extent1,
        //            TestData.Extent2,
        //            TestData.Address3,
        //            TestData.LegalBankDescription
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed property form");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Completing ERF Portion Subdivional Type");
        //        PropertyPage.CompleteERFPortionSubDivisionalType(
        //            TestData.DeedsOffice,
        //            TestData.PropertyType,
        //            TestData.SubDivisionalTypePortion,
        //            TestData.PortionNumber,
        //            TestData.ErfNumber,
        //            TestData.Township,
        //            TestData.RegistrationDivision,
        //            TestData.Province3,
        //            TestData.Extent1,
        //            TestData.Extent2,
        //            TestData.Address3,
        //            TestData.LegalBankDescription,
        //            TestData.HeldBy
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed ERF Portion Subdivional Type");

        //        // Capture screenshot after completing the forms
        //        // Capture screenshot after completing the forms
        //        CaptureScreenshot($"{testClassName}_Property_AddProperty_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] Property_AddProperty test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_Property_AddProperty_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}

        //// Test 15: Complete entity details for a company
        //[Test, Order(15), Category("Regression Test")]
        //public void Parties_CompleteEntityForm()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting Parties_CompleteEntityForm test");

        //        test.Log(Status.Info, $"[{testClassName}] Completing Natural Person Unmarried Form");
        //        PartiesPage.CompleteNaturalPersonUnmariedForm(
        //            TestData.SelectPartyTypeNaturalPerson,
        //            TestData.FirstName,
        //            TestData.Surname,
        //            TestData.Gender,
        //            TestData.MethodOfIdentification,
        //            TestData.IdentityNumber1,
        //            TestData.MaritalStatus
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed Natural Person Unmarried Form");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Completing Entity Company Form");
        //        PartiesPage.CompleteEntityCompanyForm(
        //            TestData.SelectPartyTypeEntity,
        //            TestData.CompanyType,
        //            TestData.NameOfCompany,
        //            TestData.RegistrationNumber1,
        //            TestData.RegistrationNumber2,
        //            TestData.RegistrationNumber3
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed Entity Company Form");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Completing Entity Close Corporation Form");
        //        PartiesPage.CompleteEntityCloseCorporationForm(
        //            TestData.SelectPartyTypeEntity,
        //            TestData.EntityTypeCloseCorporation,
        //            TestData.NameOfCloseCorporation,
        //            TestData.RegistrationNumber1,
        //            TestData.RegistrationNumber2,
        //            TestData.RegistrationNumber3
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed Entity Close Corporation Form");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Completing Entity Trust Form");
        //        PartiesPage.CompleteEntityTrustForm(
        //            TestData.SelectPartyTypeEntity,
        //            TestData.EntityTypeTrust,
        //            TestData.TrustType,
        //            TestData.NameOfTrust,
        //            TestData.AuthorityNumber
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed Entity Trust Form");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Completing Partnership Form");
        //        PartiesPage.CompletePartnershipForm(
        //            TestData.SelectPartyTypePartnership,
        //            TestData.Name,
        //            TestData.FirstName,
        //            TestData.Surname,
        //            TestData.Gender,
        //            TestData.MethodOfIdentification,
        //            TestData.IdentityNumber1,
        //            TestData.MaritalStatus
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed Partnership Form");

        //        // Capture screenshot after completing the first set of forms
        //        CaptureScreenshot($"{testClassName}_Parties_CompleteEntityForm_Part1_Success");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Completing Natural Person Out Of Community Form");
        //        PartiesPage.CompleteNaturalPersonOutOfCommunityForm(
        //            TestData.SelectPartyTypeNaturalPerson,
        //            TestData.FirstName,
        //            TestData.Surname,
        //            TestData.Gender,
        //            TestData.MethodOfIdentification,
        //            TestData.IdentityNumber1,
        //            TestData.MaritalStatus2,
        //            TestData.ReasonForExclusion,
        //            TestData.Duedate
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed Natural Person Out Of Community Form");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Completing Institution Council Form");
        //        PartiesPage.CompleteInstitutionCouncilForm(
        //            TestData.PartyTypeInstitution,
        //            TestData.TypeCityTownCouncil,
        //            TestData.Council
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed Institution Council Form");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Completing Institution Statutory Body Form");
        //        PartiesPage.CompleteInstitutionStatutoryBodyForm(
        //            TestData.PartyTypeInstitution,
        //            TestData.TypeStatutoryBody,
        //            TestData.NameOfStatutoryBody,
        //            TestData.EstablishmentInTermsOf
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed Institution Statutory Body Form");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Completing Institution Provincial Administration Form");
        //        PartiesPage.CompleteInstitutionProvincialAdministrationForm(
        //            TestData.PartyTypeInstitution,
        //            TestData.TypeProvincialAdministration,
        //            TestData.Province4
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed Institution Provincial Administration Form");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Completing Institution National Government Form");
        //        PartiesPage.CompleteInstitutionNationalGovernmentForm(
        //           TestData.PartyTypeInstitution,
        //           TestData.TypeNationalGovernment,
        //           TestData.NationalGovernmentLegalDescription
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed Institution National Government Form");

        //        // Capture screenshot after completing the second set of forms
        //        CaptureScreenshot($"{testClassName}_Parties_CompleteEntityForm_Part2_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] Parties_CompleteEntityForm test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_Parties_CompleteEntityForm_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}

        //// Test 16: Fill in refund details
        //[Test, Order(16), Category("Regression Test")]
        //public void RefundDetails_CompleteRefundDetailsForm()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting RefundDetails_CompleteRefundDetailsForm test");

        //        test.Log(Status.Info, $"[{testClassName}] Completing refund details form");
        //        RefundDetailsPage.CompleteRefundDetailsForm(
        //            TestData.Bank,
        //            TestData.BranchName,
        //            TestData.BranchCode,
        //            TestData.AccountNumber,
        //            TestData.AccountType,
        //            TestData.AccountHolder
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed refund details form");

        //        // Capture screenshot after completing the form
        //        CaptureScreenshot($"{testClassName}_RefundDetails_CompleteRefundDetailsForm_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] RefundDetails_CompleteRefundDetailsForm test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_RefundDetails_CompleteRefundDetailsForm_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}

        //// Test 17: Add account item entry
        //[Test, Order(17), Category("Regression Test")]
        //public void Accounts_CompleteAddItemForm()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting Accounts_CompleteAddItemForm test");

        //        test.Log(Status.Info, $"[{testClassName}] Completing add item form");
        //        AccountsPage.CompleteAddItemForm(
        //            TestData.Item,
        //            TestData.Debit,
        //            TestData.Credit,
        //            TestData.PaymentMethod
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully completed add item form");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Clicking Export button");
        //        AccountsPage.ClickExportBtn();
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully clicked Export button");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Clicking Refresh button");
        //        AccountsPage.ClickRefreshBtn();
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully clicked Refresh button");

        //        // Capture screenshot after completing the actions
        //        CaptureScreenshot($"{testClassName}_Accounts_CompleteAddItemForm_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] Accounts_CompleteAddItemForm test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_Accounts_CompleteAddItemForm_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}

        //// Test 18: Complete conveyancer form details
        //[Test, Order(18), Category("Regression Test")]
        //public void Conveyancer_CompleteConveyencerForm()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting Conveyancer_CompleteConveyencerForm test");

        //        test.Log(Status.Info, $"[{testClassName}] Saving My Branch details");
        //        ConveyancerPage.SaveMyBranchDetails(
        //            TestData.DateOfSignature,
        //            TestData.PlaceOfSignature,
        //            TestData.Preparer,
        //            TestData.CommisionerOfOaths
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully saved My Branch details");

        //        test.Log(Status.Info, $"[{testClassName}] Waiting for 2 seconds");
        //        Thread.Sleep(2000);

        //        test.Log(Status.Info, $"[{testClassName}] Saving Correspondent details");
        //        ConveyancerPage.SaveCorrespondentDetails(
        //            TestData.PlaceOfSignature,
        //            TestData.CorrespondentName,
        //            TestData.CorrespondentBranch,
        //            TestData.LodgementNumber,
        //            TestData.CommisionerOfOaths
        //        );
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully saved Correspondent details");

        //        // Capture screenshot after completing the forms
        //        CaptureScreenshot($"{testClassName}_Conveyancer_CompleteConveyencerForm_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] Conveyancer_CompleteConveyencerForm test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_Conveyancer_CompleteConveyencerForm_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}


        //// Test 19: Add a comment in Audit Trail
        //[Test, Order(19), Category("Regression Test")]
        //public void AuditTrail_AddComment()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting AuditTrail_AddComment test");

        //        test.Log(Status.Info, $"[{testClassName}] Adding comment: {TestData.Comment}");
        //        AuditTrailPage.AddComment(TestData.Comment, TestData.Search2);
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully added comment");

        //        // Capture screenshot after adding the comment
        //        CaptureScreenshot($"{testClassName}_AuditTrail_AddComment_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] AuditTrail_AddComment test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_AuditTrail_AddComment_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}

        //// Test 20: Generate a print list report
        //[Test, Order(20), Category("Regression Test")]
        //public void PrintList_CompleteAddItemForm()
        //{
        //    // Start the test in ExtentReports with class name prefix
        //    test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");
        //    ExtentReport._scenario = test; // Set the current test for page objects to use

        //    try
        //    {
        //        test.Log(Status.Info, $"[{testClassName}] Starting PrintList_CompleteAddItemForm test");

        //        test.Log(Status.Info, $"[{testClassName}] Generating selected print list");
        //        PrintListPage.GenerateSelected();
        //        test.Log(Status.Pass, $"[{testClassName}] Successfully generated selected print list");

        //        // Capture screenshot after generating the print list
        //        CaptureScreenshot($"{testClassName}_PrintList_CompleteAddItemForm_Success");

        //        test.Log(Status.Pass, $"[{testClassName}] PrintList_CompleteAddItemForm test completed successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
        //        CaptureScreenshot($"{testClassName}_PrintList_CompleteAddItemForm_Failure");
        //        Console.WriteLine("Test failed with exception: " + ex.Message);
        //        throw;
        //    }
        //}



        //// Helper method to capture screenshots
        //private void CaptureScreenshot(string screenshotName)
        //{
        //    try
        //    {
        //        if (driver != null)
        //        {
        //            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
        //            Screenshot screenshot = takesScreenshot.GetScreenshot();
        //            string screenshotPath = System.IO.Path.Combine(ExtentReport.testResultPath, screenshotName + ".png");
        //            screenshot.SaveAsFile(screenshotPath);
        //            if (test != null)
        //            {
        //                test.AddScreenCaptureFromPath(screenshotPath);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
        //        if (test != null)
        //        {
        //            test.Log(Status.Warning, $"Failed to capture screenshot: {ex.Message}");
        //        }
        //    }
        //}
    }
}




