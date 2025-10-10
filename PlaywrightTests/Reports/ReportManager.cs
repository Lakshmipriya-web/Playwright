using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace PlaywrightTests.Reports
{
    public static class ReportManager
    {
        private static ExtentReports _extent;
        private static readonly AsyncLocal<ExtentTest> _test = new();

        public static void InitReport()
        {
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "TestReport.html");
            var spark = new ExtentSparkReporter(reportPath);
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            _extent = new ExtentReports();
            _extent.AttachReporter(spark);
        }

        public static ExtentTest CreateTest(string testName)
        {
            _test.Value = _extent.CreateTest(testName);
            return _test.Value;
        }

        public static void Log(Status status, string message)
        {
            _test.Value?.Log(status, message);
        }

        public static void AttachScreenshot(string screenshotPath)
        {
            if (_test.Value != null && File.Exists(screenshotPath))
            {
                _test.Value.AddScreenCaptureFromPath(screenshotPath);
            }
        }

        public static void Flush()
        {
            _extent?.Flush();
        }
    }
}