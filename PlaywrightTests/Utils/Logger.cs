using NLog;

namespace PlaywrightTests.Utils
{
    public static class Logger
    {
        private static readonly NLog.Logger log = LogManager.GetCurrentClassLogger();

        public static void Info(string message) => log.Info(message);
        public static void Error(string message) => log.Error(message);
        public static void Warn(string message) => log.Warn(message);
        public static void Debug(string message) => log.Debug(message);
    }
}