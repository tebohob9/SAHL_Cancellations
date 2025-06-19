using NUnit.Framework;
using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SAHL_Cancellations.Utilities;
using AventStack.ExtentReports;
using Cancellations_Tests.Utilities;

namespace SAHL_Cancellations.Pages
{
    /// <summary>
    /// Represents the "New Instruction" page and encapsulates its elements and behaviors.
    /// </summary>
    public class New_InstructionPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public New_InstructionPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        #region Main Link Elements
        private IWebElement MortgageeLink => wait.Until(d => d.FindElement(By.XPath("//a[normalize-space()='ABSA Bank South Africa']")));
        private IWebElement MortgagorLink => wait.Until(d => d.FindElement(By.XPath("//a[normalize-space()='Teboho Bodibe']")));
        private IWebElement PropertyLink => wait.Until(d => d.FindElement(By.XPath("//a[normalize-space()='ERF 1420 ZWARTKOP EXT 18']")));
        #endregion

        #region File Note Elements
        private IWebElement FileNoteEditPen => wait.Until(d => d.FindElement(By.XPath("//img[@title='Edit File Note']")));
        private IWebElement FileNoteClickHere => wait.Until(d => d.FindElement(By.XPath("//span[normalize-space()='Click here to add']")));
        private IWebElement FileNoteComment => wait.Until(d => d.FindElement(By.XPath("//textarea[@id='txtGeneralComment']")));
        private IWebElement FileNoteSaveBtn => wait.Until(d => d.FindElement(By.XPath("//button[@id='saveGeneralComment']")));
        private IWebElement FileNoteCancelBtn => wait.Until(d => d.FindElement(By.XPath("//button[@id='reloadDataBttn']")));
        #endregion

        #region Tab Elements
        private IWebElement CommunicationsTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Communications')]")));
        private IWebElement MilestonesTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Milestones')]")));
        private IWebElement DiaryTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Diary')]")));
        private IWebElement CorrespondentsTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Correspondents')]")));
        private IWebElement InfoSheetTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Info Sheet')]")));
        private IWebElement InboxTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Inbox')]")));
        private IWebElement DeedSearchTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Deed Search')]")));
        private IWebElement InstructionDetailsTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Instruction Details')]")));
        private IWebElement PropertyTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Property')]")));
        private IWebElement PartiesTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Parties')]")));
        private IWebElement RefundDetailsTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Refund Details')]")));
        private IWebElement AccountsTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Accounts')]")));
        private IWebElement ConveyancerTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Conveyancer')]")));
        private IWebElement PrintListTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Print List')]")));
        private IWebElement AuditTrailTab => wait.Until(d => d.FindElement(By.XPath("//div[contains(text(),'Audit Trail')]")));
        #endregion

        #region Actions
        /// <summary>
        /// Clicks the Mortgagee, Mortgagor, and Property links in order.
        /// </summary>
        public void Select_Mortgagee_Mortgagor_Property()
        {
            LogAction("Clicking Mortgagee link");
            ClickWhenClickable(MortgageeLink);

            LogAction("Clicking Mortgagor link");
            ClickWhenClickable(MortgagorLink);

            LogAction("Clicking Property link");
            ClickWhenClickable(PropertyLink);

            LogAction("Clicking Communications tab");
            ClickWhenClickable(CommunicationsTab);

            LogSuccess("Successfully selected Mortgagee, Mortgagor, and Property links");
        }

        /// <summary>
        /// Adds a general file note.
        /// </summary>
        /// <param name="fileNote">The note to enter.</param>
        public void EnterFileNote(string fileNote)
        {
            LogAction("Clicking File Note edit pen");
            ClickWhenClickable(FileNoteEditPen);

            LogAction("Waiting for File Note comment field to be visible");
            WaitForElementToBeVisible(FileNoteComment);

            LogAction("Clearing File Note comment field");
            FileNoteComment.Clear();

            LogAction($"Entering file note: {fileNote}");
            FileNoteComment.SendKeys(fileNote);

            LogAction("Clicking Save button");
            ClickWhenClickable(FileNoteSaveBtn);

            LogSuccess("Successfully entered file note");
        }

        /// <summary>
        /// Sequentially clicks through all functional tabs on the page.
        /// </summary>
        public void SelectTabsInOrder()
        {
            LogAction("Clicking Correspondents tab");
            ClickWhenClickable(CorrespondentsTab);

            LogAction("Clicking Info Sheet tab");
            ClickWhenClickable(InfoSheetTab);

            LogAction("Clicking Inbox tab");
            ClickWhenClickable(InboxTab);

            LogAction("Clicking Deed Search tab");
            ClickWhenClickable(DeedSearchTab);

            LogAction("Clicking Instruction Details tab");
            ClickWhenClickable(InstructionDetailsTab);

            LogAction("Clicking Property tab");
            ClickWhenClickable(PropertyTab);

            LogAction("Clicking Parties tab");
            ClickWhenClickable(PartiesTab);

            LogAction("Clicking Refund Details tab");
            ClickWhenClickable(RefundDetailsTab);

            LogAction("Clicking Accounts tab");
            ClickWhenClickable(AccountsTab);

            LogAction("Clicking Conveyancer tab");
            ClickWhenClickable(ConveyancerTab);

            LogAction("Clicking Print List tab");
            ClickWhenClickable(PrintListTab);

            LogAction("Clicking Audit Trail tab");
            ClickWhenClickable(AuditTrailTab);

            LogAction("Clicking Communications tab");
            ClickWhenClickable(CommunicationsTab); // Returning to the first tab for consistency

            LogSuccess("Successfully clicked through all tabs in order");
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Waits for an element to be clickable and clicks it.
        /// </summary>
        private void ClickWhenClickable(IWebElement element)
        {
            try
            {
                wait.Until(d => element.Enabled && element.Displayed);
                element.Click();
            }
            catch (Exception ex)
            {
                LogError($"Failed to click element: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Waits for an element to be visible.
        /// </summary>
        private void WaitForElementToBeVisible(IWebElement element)
        {
            try
            {
                wait.Until(d => element.Displayed);
            }
            catch (Exception ex)
            {
                LogError($"Element not visible: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Logs an action to the ExtentReport
        /// </summary>
        private void LogAction(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Info, $"[New_InstructionPage] {message}");
            }
        }

        /// <summary>
        /// Logs a success message to the ExtentReport
        /// </summary>
        private void LogSuccess(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Pass, $"[New_InstructionPage] {message}");
            }
        }

        /// <summary>
        /// Logs an error message to the ExtentReport
        /// </summary>
        private void LogError(string message)
        {
            if (ExtentReport._scenario != null)
            {
                ExtentReport._scenario.Log(Status.Fail, $"[New_InstructionPage] {message}");
            }
        }
        #endregion
    }
}




