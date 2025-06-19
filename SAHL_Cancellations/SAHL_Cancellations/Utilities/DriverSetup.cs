using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Cancellations_Tests.Utilities
{
    public class DriverSetup
    {
        public static IWebDriver InitializeDriver()
        {
            // Set up Chrome options
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            // For debugging, disable headless mode
            // options.AddArgument("--headless");

            // Create Chrome driver
            ChromeDriver driver = new ChromeDriver(options);

            // Set implicit wait time
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }
    }
}

