using OpenQA.Selenium;
using System.IO;
using System;
using System.IO.Compression;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;

namespace SAHL_Cancellations.Utilities
{
	public class FileOperations : ReportingDirectories
	{
		static int ScreenshotCount = 0;

		// Updated method to take and embed screenshot with test name
		public string TakeScreenshot(IWebDriver _driver, ExtentTest test = null, Status status = Status.Info, string stepDescription = "Screenshot")
		{
			try
			{
				ScreenshotCount++;

				// Get the test name from the test object if available
				string testName = "Unknown";
				if (test != null && test.Model != null)
				{
					testName = test.Model.Name.Replace(" ", "_").Replace(":", "_");
				}

				// Include test name in the screenshot filename
				var screenshotFileName = $"{testName}_{ScreenshotCount}_Screenshot.png";
				var screenshotPath = Path.Combine(CreatedReportWithScreenshotsDirectory, screenshotFileName);

				// Take screenshot
				Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
				screenshot.SaveAsFile(screenshotPath);

				// Get relative path for the report
				string relativePath = GetRelativePathForReport(screenshotPath);

				// If test is provided, embed the screenshot in the report
				if (test != null)
				{
					test.Log(status, stepDescription, MediaEntityBuilder.CreateScreenCaptureFromPath(relativePath).Build());
				}

				return screenshotPath;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error taking screenshot: {ex.Message}");
				if (test != null)
				{
					test.Log(Status.Error, $"Failed to capture screenshot: {ex.Message}");
				}
				return string.Empty;
			}
		}

		// Helper method to get relative path for the report
		private string GetRelativePathForReport(string fullPath)
		{
			// For Extent Reports to find the screenshot, we need a path relative to the HTML report
			string reportDirectory = Path.GetDirectoryName(FullExtentReportPath());
			if (reportDirectory != null && fullPath.StartsWith(reportDirectory))
			{
				// Get path relative to the report directory
				return "." + fullPath.Substring(reportDirectory.Length);
			}
			// If we can't determine relative path, return the filename only
			return Path.GetFileName(fullPath);
		}

		public string CompressFile()
		{
			Assert.IsNotNull(CreatedReportDirectory);
			if (ReportHasScreenshots) Assert.IsNotNull(CreatedReportWithScreenshotsDirectory);
			CreateZipFile(CreatedReportDirectory, GetZippedReportFilePath());
			return GetZippedReportFilePath();
		}

		private static void CreateZipFile(string sourceDirectory, string zipFilePath)
		{
			try
			{
				// Create a new ZIP file
				using (FileStream zipFileStream = new FileStream(zipFilePath, FileMode.Create))
				{
					using (ZipArchive archive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
					{
						// Recursively add all files and subdirectories in the source directory to the ZIP archive
						AddDirectoryToZip(archive, sourceDirectory);
					}
				}
				Console.WriteLine("ZIP file created successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to create ZIP file: {ex.Message}");
			}
		}

		private static void AddDirectoryToZip(ZipArchive archive, string sourceDirectory)
		{
			string[] files = Directory.GetFiles(sourceDirectory);
			string[] subDirectories = Directory.GetDirectories(sourceDirectory);
			// Add all files in the current directory to the ZIP archive
			foreach (string filePath in files)
			{
				string relativePath = filePath.Substring(sourceDirectory.Length + 1);
				archive.CreateEntryFromFile(filePath, relativePath);
			}
			// Recursively add all subdirectories and their files to the ZIP archive
			foreach (string subDirectory in subDirectories)
			{
				string directoryName = new DirectoryInfo(subDirectory).Name;
				string[] subFiles = Directory.GetFiles(subDirectory);
				foreach (string filePath in subFiles)
				{
					string fileName = Path.GetFileName(filePath);
					string entryName = Path.Combine(directoryName, fileName);
					archive.CreateEntryFromFile(filePath, entryName);
				}
				AddDirectoryToZip(archive, subDirectory);
			}
		}
	}
}
