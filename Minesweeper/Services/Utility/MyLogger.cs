/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using NLog;

namespace Minesweeper.Services.Utility
{
    /// <summary>
    /// Logger class that implements NLog and ILogger for dependency injection
    /// </summary>
    public class MyLogger : ILogger
    {
        // makes an Instance of NLog logger
        private Logger logger;

        // Return Instance of the Logger
        public Logger GetLogger()
        {
            if (logger == null)
            {
                logger = LogManager.GetLogger("myAppLoggerRules");
            }

            return logger;
        }

        // Log any Debug message
        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        // Log any Error message
        public void Error(string message)
        {
            GetLogger().Error(message);
        }

        // Log any of the Info message
        public void Info(string message)
        {
            GetLogger().Info(message);
        }

        // Log any Warning message
        public void Warning(string message)
        {
            GetLogger().Warn(message);
        }
    }
}