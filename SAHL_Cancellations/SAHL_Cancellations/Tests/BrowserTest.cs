using Cancellations_Tests.BasePage;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Cancellations_Tests.Tests
{
    [TestFixture]
    public class BrowserTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Setting up browser test...");
            _driver = Utilities.DriverSetup.InitializeDriver();
        }

        [Test]
        public void OpenBrowser()
        {
            Console.WriteLine("Opening Google...");
            _driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine("Page title: " + _driver.Title);
            //Assert.IsTrue(_driver.Title.Contains("Google"), "Browser did not open Google correctly");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Tearing down browser test...");
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}

