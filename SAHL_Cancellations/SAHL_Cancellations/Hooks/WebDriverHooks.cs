using BoDi;
using Cancellations_Tests.Utilities;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Cancellations_Tests.Hooks
{
	[Binding]
	public class WebDriverHooks
	{
		private readonly IObjectContainer container;
		private IWebDriver driver;

		public WebDriverHooks(IObjectContainer container)
		{
			this.container = container;
		}

		[BeforeScenario(Order = 0)] // Order ensures this runs before other BeforeScenario methods
		public void BeforeScenario()
		{
			Console.WriteLine("Initializing WebDriver...");
			try
			{
				driver = DriverSetup.InitializeDriver();
				container.RegisterInstanceAs<IWebDriver>(driver);
				Console.WriteLine("WebDriver initialized successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error initializing WebDriver: {ex.Message}");
				throw;
			}
		}

		[AfterScenario]
		public void AfterScenario()
		{
			Console.WriteLine("Disposing WebDriver...");
			try
			{
				if (driver != null)
				{
					driver.Quit();
					driver.Dispose();
					Console.WriteLine("WebDriver disposed successfully.");
				}
				else
				{
					Console.WriteLine("WebDriver was null, nothing to dispose.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error disposing WebDriver: {ex.Message}");
			}
		}
	}
}
