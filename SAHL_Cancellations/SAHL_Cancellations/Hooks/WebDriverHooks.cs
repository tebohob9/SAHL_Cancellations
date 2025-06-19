using Cancellations_Tests.BasePage;
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
        private readonly IObjectContainer _container;
        private IWebDriver _driver;

        public WebDriverHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("Initializing WebDriver...");
            _driver = DriverSetup.InitializeDriver();
            _container.RegisterInstanceAs<IWebDriver>(_driver);
            Console.WriteLine("WebDriver initialized successfully.");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Disposing WebDriver...");
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
            Console.WriteLine("WebDriver disposed successfully.");
        }
    }
}

