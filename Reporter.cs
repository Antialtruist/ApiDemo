using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace ApiDemo
{
    public static class Reporter
    {
        public static ExtentReports extentReport;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest testCase;

        public static void SetupExtentReport(string reportName, string documentTitle, dynamic path)
        {
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = documentTitle;
            htmlReporter.Config.ReportName = reportName;

            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReporter);
        }

        public static void CreateTest(string testName)
        {
            testCase = extentReport.CreateTest(testName);
        }

        public static void LogToReport(Status status, string message)
        {
            testCase.Log(status, message);
        }

        public static void FlushReport()
        {
            extentReport.Flush();
        }

        public static void TestStatus(string status)
        {
            if(status.Equals("Pass"))
            {
                testCase.Pass("Test is passed");
            }
            else
            {
                testCase.Pass("Test is failed");
                //screenshot in case of ui selenium tests
            }
        }
    }
}
