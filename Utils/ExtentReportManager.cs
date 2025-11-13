using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace OrangeHRMFramework.Utils
{
    public static class ExtentReportManager
    {
        private static ExtentReports extent; // main report object
        private static ExtentTest test;      // current test

        // 🔹 Initialize the report
        public static void InitReport()
        {
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            // 🔹 Reports folder path
            string reportsFolder = Path.Combine(projectRoot, "Reports");
            if (!Directory.Exists(reportsFolder))
                Directory.CreateDirectory(reportsFolder);

            string reportPath = Path.Combine(reportsFolder, "TestReport.html");

            // 🔹 Correct reporter for AventStack v5+
            var sparkReporter = new ExtentSparkReporter(reportPath);
            sparkReporter.Config.DocumentTitle = "OrangeHRM Automation Report";
            sparkReporter.Config.ReportName = "Login Tests";

            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);
        }

        // 🔹 Create a test in the report
        public static void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }

        // 🔹 Log success
        public static void LogPass(string message)
        {
            test.Pass(string.IsNullOrEmpty(message) ? "Test passed" : message);
        }

        // 🔹 Log failure
        public static void LogFail(string message)
        {
            test.Fail(string.IsNullOrEmpty(message) ? "Test failed" : message);
        }

        // 🔹 Write everything to the HTML file
        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
