using System;
using System.IO;
using System.Threading;
using NUnit.Framework;

namespace SAHL_Cancellations.Utilities
{
	public class ReportingDirectories
	{
		public string ReportingPath = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\Reports\\";
		readonly string ScreenshotsPath = "Screenshots\\";
		public string ExtentReportFile = "Report.html";
		public string CreatedReportDirectory { get; set; }
		[ThreadStatic]
		public static string CreatedReportWithScreenshotsDirectory;
		public bool ReportHasScreenshots { get; set; }

		string ReportingTestFolderPath(string testName = null) =>
			testName != null ?
			$"{testName}_Results_{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss-fff")}\\" : $"TestResults_{DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss-fff")}\\";

		bool CreateDirectory(string path) => !Directory.Exists(path) ? CreateNewDirectory(path) : true;

		bool CreateNewDirectory(string path)
		{
			Directory.CreateDirectory(path);
			return true;
		}

		bool CreateScreenshotsDirectory(string directory)
		{
			Assert.IsNotNull(directory, "The parent directory specified for the Screenshots folder is null. Please ensure that the folder is an existing folder and is retrievable.");
			CreatedReportWithScreenshotsDirectory = directory + ScreenshotsPath;
			Console.WriteLine("Screenshot Report: " + CreatedReportWithScreenshotsDirectory);
			Directory.CreateDirectory(CreatedReportWithScreenshotsDirectory);
			Thread.Sleep(1500);
			return Directory.Exists(CreatedReportWithScreenshotsDirectory);
		}

		public void CreateMainReportingDirectory() => Assert.IsTrue(CreateDirectory(ReportingPath), "Failed to create a new reporting directory");

		public bool CreateTestResultsDirectory(string testName = null, bool hasScreenshots = true)
		{
			CreateMainReportingDirectory();
			ReportHasScreenshots = hasScreenshots;
			CreatedReportDirectory = ReportingPath + ReportingTestFolderPath(testName);
			testName = testName == null ? "TestResults" : testName;
			if (ReportHasScreenshots)
			{
				Assert.IsTrue(CreateDirectory(CreatedReportDirectory), "Failed to create a folder for the test: " + testName);
				Assert.IsTrue(CreateScreenshotsDirectory(CreatedReportDirectory));
			}
			else { Assert.IsTrue(CreateDirectory(CreatedReportDirectory)); }
			return ReportHasScreenshots ? Directory.Exists(CreatedReportDirectory) && Directory.Exists(CreatedReportWithScreenshotsDirectory) : Directory.Exists(CreatedReportDirectory);
		}

		public string FullExtentReportPath()
		{
			Assert.IsNotNull(CreatedReportDirectory, "There is no created report directory. Please create a report to get an extent report html path. A report can be created by calling the CreateTestResultsDirectory() method before the FullExtentReportPath() method.");
			return CreatedReportDirectory + ExtentReportFile;
		}

		public string GetZippedReportFilePath()
		{
			Assert.IsNotNull(CreatedReportDirectory, "There is no created report directory. Please create a report to get an extent report html path. A report can be created by calling the CreateTestResultsDirectory() method before the GetZippedReportFile() method.");
			return $"{CreatedReportDirectory.Substring(0, CreatedReportDirectory.Length - 1)}.zip";
		}
	}
}
