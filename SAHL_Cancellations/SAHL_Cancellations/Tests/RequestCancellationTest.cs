using Cancellations_Tests.BasePage;

using SAHL_Cancellations.Pages; // Use the original namespace for your pages
using Cancellations_Tests.Utilities;
using NUnit.Framework;
using System;
using System.Threading;
using AventStack.ExtentReports;
using SAHL_Cancellations.Utilities;

namespace Cancellations_Tests.Tests
{
    [TestFixture]
    public class RequestCancellationTest : BaseClass
    {
        public LoginPage LoginPage;
        public LandingPage LandingPage;
        public HomePage HomePage;
        public RequestCancellationPage RequestCancellationPage;
        private readonly string testClassName = "Request Cancellation Test"; // Class name for reporting

        [Test, Order(5), Category("Regression Test")]
        public void CompleteForm()
        {
            // Start the test in ExtentReports with class name prefix
            test = extent.CreateTest($"{testClassName}: {TestContext.CurrentContext.Test.Name}");

            try
            {
                test.Log(Status.Info, $"[{testClassName}] Initializing page objects");
                LandingPage = new LandingPage(driver);
                HomePage = new HomePage(driver);
                RequestCancellationPage = new RequestCancellationPage(driver);

                test.Log(Status.Info, $"[{testClassName}] Selecting the product from the dropdown: {TestData.SAHL_Cancellations}");
                Thread.Sleep(2000);
                LandingPage.ClickProductDropDownAndSelectOption(TestData.SAHL_Cancellations);
                test.Log(Status.Pass, $"[{testClassName}] Successfully selected product from dropdown");

                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Clicking on Request Cancellation");
                //HomePage.ClickRequestCancellation();
                test.Log(Status.Pass, $"[{testClassName}] Successfully clicked on Request Cancellation");

                Thread.Sleep(2000);

                test.Log(Status.Info, $"[{testClassName}] Completing the cancellation form");
                RequestCancellationPage.CompleteForm(
                    TestData.Account_Number,
                    TestData.Cancellation_Type_Switch,
                    TestData.Title_Mr,
                    TestData.Initials,
                    TestData.Full_Name,
                    TestData.Region_Free_State,
                    TestData.Cancellation_Reason_EarlySettlementOfBond
                );
                test.Log(Status.Pass, $"[{testClassName}] Successfully completed the cancellation form");

                // Capture a screenshot of the completed form
                CaptureScreenshot($"{testClassName}_CompletedCancellationForm");

                test.Log(Status.Pass, $"[{testClassName}] Test completed successfully");
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"[{testClassName}] Test failed with exception: {ex.Message}");
                CaptureScreenshot($"{testClassName}_CompleteForm_Failure");
                throw;
            }
        }
    }
}


