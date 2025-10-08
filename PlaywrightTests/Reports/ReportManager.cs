using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace PlaywrightTests.Reports
{
    public static class ReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;

        public static void InitReport()
        {
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "TestReport.html");
            var spark = new ExtentSparkReporter(reportPath);
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            _extent = new ExtentReports();
            _extent.AttachReporter(spark);
        }

        public static void CreateTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void Log(Status status, string message)
        {
            _test.Log(status, message);
        }

        public static void AttachScreenshot(string screenshotPath)
        {
            if (_test != null && File.Exists(screenshotPath))
            {
                _test.AddScreenCaptureFromPath(screenshotPath);
            }
        }

        public static void Flush()
        {
            _extent?.Flush();
        }
    }
}