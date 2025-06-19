using Cancellations_Tests.BasePage;
//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
//using System;
//using System.Diagnostics;
//using System.IO;

//namespace SAHL_Cancellations.Utilities
//{
//    public static class ExtentReportsManager
//    {
//        private static ExtentReports _extent;
//        private static string _reportPath;

//        public static ExtentReports GetInstance()
//        {
//            if (_extent == null)
//            {
//                // Define the custom path for the reports
//                string reportsFolderPath = @"C:\Users\tbodibe\Source\Repos\CancellationsAutomation\Cancellations_Tests\Reports";

//                // Ensure the directory exists
//                if (!Directory.Exists(reportsFolderPath))
//                {
//                    Directory.CreateDirectory(reportsFolderPath);  // Create the folder if it doesn't exist
//                    Console.WriteLine($"Created directory for reports: {reportsFolderPath}");
//                }
//                else
//                {
//                    Console.WriteLine($"Using existing directory for reports: {reportsFolderPath}");
//                }

//                // Generate a unique report name based on timestamp
//                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
//                _reportPath = Path.Combine(reportsFolderPath, $"Report_{timestamp}.html");

//                Console.WriteLine($"Report will be generated at: {_reportPath}");

//                // Initialize HTML Reporter with proper configuration
//                var htmlReporter = new ExtentHtmlReporter(_reportPath);

//                // Set configuration options for the report
//                htmlReporter.Configuration().DocumentTitle = "Absa Test Report";  // Report title
//                htmlReporter.Configuration().ReportName = "Test Results";         // Report name
//                htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

//                // Initialize ExtentReports and attach the reporter
//                _extent = new ExtentReports();
//                _extent.AttachReporter(htmlReporter);

//                // Add system information for additional context
//                _extent.AddSystemInfo("Environment", "QA");

//                Console.WriteLine("ExtentReports instance successfully created.");
//            }
//            return _extent;
//        }

//        public static void FlushReports()
//        {
//            if (_extent != null)
//            {
//                // Write the report to the file
//                _extent.Flush();

//                // Check if the report file exists and log the result
//                if (File.Exists(_reportPath))
//                {
//                    Console.WriteLine($"SUCCESS: Report generated at {_reportPath}");
//                    try
//                    {
//                        // Attempt to open the report in the default browser
//                        Process.Start(_reportPath);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine($"Could not open report: {ex.Message}");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine($"ERROR: Report not found at {_reportPath}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("ERROR: ExtentReports instance is null. Report not generated.");
//            }
//        }
//    }
//}


