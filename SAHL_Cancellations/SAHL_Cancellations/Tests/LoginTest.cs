//using Cancellations_Tests.Utilities;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using SAHL_Cancellations.Pages;
//using System;
//using TechTalk.SpecFlow;

//namespace SAHL_Cancellations.Tests
//{
//    [Binding]
//    public class LoginSteps
//    {
//        private IWebDriver driver;
//        private LoginPage loginPage;
//        private readonly ScenarioContext _scenarioContext;

//        public LoginSteps(ScenarioContext scenarioContext)
//        {
//            _scenarioContext = scenarioContext;
//        }

//        [BeforeScenario]
//        public void Setup()
//        {
//            ChromeOptions options = new ChromeOptions();
//            options.AddArgument("--start-maximized");
//            driver = new ChromeDriver(options);
//            _scenarioContext.Add("WebDriver", driver);
            
//            loginPage = new LoginPage(driver);
//        }

//        [AfterScenario]
//        public void TearDown()
//        {
//            if (driver != null)
//            {
//                driver.Quit();
//                driver.Dispose();
//            }
//        }

//        [Given(@"I am on the login page")]
//        public void GivenIAmOnTheLoginPage()
//        {
//            driver.Navigate().GoToUrl("https://your-application-url.com/login");
//            ExtentReport.LogInfo("Navigated to login page");
//        }

//        [When(@"I enter valid username and password")]
//        public void WhenIEnterValidUsernameAndPassword()
//        {
//            // Instead of calling EnterUsername and EnterPassword separately,
//            // call the Login method with both parameters
//            loginPage.Login("validUsername", "validPassword");
//        }

//        [When(@"I click the login button")]
//        public void WhenIClickTheLoginButton()
//        {
//            // This step is now redundant since Login method already clicks the button
//            // But we'll keep it for BDD clarity
//            ExtentReport.LogInfo("Login button already clicked in previous step");
//        }

//        [Then(@"I should be logged in successfully")]
//        public void ThenIShouldBeLoggedInSuccessfully()
//        {
//            // Add verification logic here
//            Assert.IsTrue(driver.Url.Contains("dashboard"), "User is not redirected to dashboard after login");
//            ExtentReport.LogPass("User logged in successfully and redirected to dashboard");
//        }
//    }
//}