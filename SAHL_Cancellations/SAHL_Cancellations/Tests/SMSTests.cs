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
	public class SMSTests : BaseClass
	{
		// Declare page objects
		public LandingPage LandingPage;
		public HomePage HomePage;
		public SMSPage SMSPage;
		public New_InstructionPage New_InstructionPage;
		private readonly string testClassName = "Correspondents Tests"; // Class name for reporting

		[SetUp]
		public void SetUp()
		{
			// Initialize page objects
			LandingPage = new LandingPage(driver);
			HomePage = new HomePage(driver);
			SMSPage = new SMSPage(driver);
			New_InstructionPage = new New_InstructionPage(driver);
		}

		[Test, Order(1), Category("Regression Test")]
		public void SendSMS()
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
				SMSPage.SendSMS(
					TestData.ToCell,
					TestData.Message);

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

	}
}


