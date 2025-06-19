using NUnit.Framework;
using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAHL_Cancellations.Pages
{
    public class CancellationsPage
    {
        public readonly IWebDriver driver;  // WebDriver to interact with the browser

        // Constructor to initialize the WebDriver
        public CancellationsPage(IWebDriver driver)
        {
            this.driver = driver;  // Assigning the driver to the class variable
        }

        // UI Elements - All elements on the HomePage
        public IWebElement RequestCancellationButton => driver.FindElement(By.XPath("//a[normalize-space()='Request Cancellation']"));
        public IWebElement CancellationsTab => driver.FindElement(By.XPath("//div[normalize-space()='Cancellations']"));
        public IWebElement AccountNumberTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_C_txtAccountNumber']"));
        public IWebElement CancellationsTypeDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_C_ddlCancellationType']"));
        public IWebElement TitleDropDown => driver.FindElement(By.XPath("//select[@id='ctl00_C_ddlCancellationType']"));
        public IWebElement InitialsTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_C_txtInitials']"));
        public IWebElement FullNameTextBox => driver.FindElement(By.XPath("//input[@id='ctl00_C_txtFullName']"));
        public IWebElement RegionDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_C_ddlRegion']"));

        public IWebElement CancellationReasonDrpDwn => driver.FindElement(By.XPath("//select[@id='ctl00_C_ddlRegion']"));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("//input[@id='ctl00_C_btnSubmit']"));
        public IWebElement GoButton => driver.FindElement(By.XPath("//input[@id='btnSearch']"));

    }
}




