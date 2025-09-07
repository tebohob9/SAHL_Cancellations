//using System;
//using System.Linq;
//using System.Threading;
//using FlaUI.Core;
//using FlaUI.Core.AutomationElements;
//using FlaUI.Core.Conditions;
//using FlaUI.Core.Definitions;
//using FlaUI.UIA3;

//namespace Cancellations_Tests.Utilities
//{
//	public static class CertificateSelector
//	{
//		public static void SelectCertificate(string certificateName, bool moveOneUp = false)
//		{
//			Console.WriteLine("Waiting for certificate popup...");

//			using (var automation = new UIA3Automation())
//			{
//				var app = FlaUI.Core.Application.Attach("chrome");
//				var desktop = automation.GetDesktop();

//				// Wait up to 10 seconds for the popup
//				for (int i = 0; i < 20; i++)
//				{
//					var popup = desktop.FindFirstDescendant(cf =>
//						cf.ByControlType(ControlType.Window)
//						  .And(cf.ByName("Select a Certificate")));

//					if (popup != null)
//					{
//						Console.WriteLine("Certificate popup found.");

//						// Try to find the certificate list
//						var certList = popup.FindFirstDescendant(cf =>
//							cf.ByControlType(ControlType.List));

//						if (certList != null)
//						{
//							var items = certList.FindAllChildren();
//							foreach (var item in items)
//							{
//								Console.WriteLine("Found item: " + item.Name);
//								if (item.Name.Contains(certificateName, StringComparison.OrdinalIgnoreCase))
//								{
//									item.Click();
//									Console.WriteLine($"Clicked certificate: {item.Name}");
//									break;
//								}
//							}
//						}

//						// Click OK or Confirm button
//						var okButton = popup.FindFirstDescendant(cf =>
//							cf.ByControlType(ControlType.Button)
//							  .And(cf.ByName("OK")));

//						if (okButton != null)
//						{
//							okButton.AsButton().Invoke();
//							Console.WriteLine("Clicked OK button.");
//						}
//						else
//						{
//							Console.WriteLine("OK button not found.");
//						}

//						return;
//					}

//					Thread.Sleep(500);
//				}

//				Console.WriteLine("Certificate popup not found after waiting.");
//			}
//		}
//	}
//}
