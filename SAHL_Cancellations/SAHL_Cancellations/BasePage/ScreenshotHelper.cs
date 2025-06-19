using Cancellations_Tests.BasePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;  // To use extension methods for capturing screenshots
using NUnit.Framework;
using System;
using System.IO;

namespace SAHL_Cancellations.Utilities
{
    public static class ScreenshotHelper
    {
        // Method to capture and save screenshots with a unique filename in PNG format
        public static void CaptureScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                // Generate a timestamp to make the screenshot filename unique
                string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");

                // Define the root directory where screenshots will be saved
                string rootDirectory = @"C:\Users\tbodibe\Source\Repos\CancellationsAutomation\Cancellations_Tests\Screenshots\";

                // **New Logic**: Dynamically get the **test page name** for folder creation
                // Extract the class name from the test context and remove the "Test" suffix.
                string testPageName = TestContext.CurrentContext.Test.ClassName;
                testPageName = testPageName.Substring(testPageName.LastIndexOf('.') + 1);  // Extract the class name without the namespace
                testPageName = testPageName.Replace("Test", "Page");  // Convert "Test" suffix to "Page" for folder name

                // Combine the root directory with the page name to create a folder for each test page
                string pageDirectory = Path.Combine(rootDirectory, testPageName);

                // Check if the page folder exists, and create it if not
                if (!Directory.Exists(pageDirectory))
                {
                    Directory.CreateDirectory(pageDirectory);
                }

                // Capture the screenshot using WebDriver's ITakesScreenshot interface
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();

                // Generate the full file path for the screenshot with test name and timestamp, ensuring it's a PNG
                string filePath = Path.Combine(pageDirectory, $"{testName}_{timestamp}.png");

                // Save the captured screenshot as PNG to the specified path
                screenshot.SaveAsFile(filePath);

                // Log the screenshot file path to the console
                Console.WriteLine($"Screenshot saved: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturing screenshot: " + ex.Message);
            }
        }
    }
}




