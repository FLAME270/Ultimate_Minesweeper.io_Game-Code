/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

namespace Minesweeper.Services.Utility
{
    // Interface for implementing a logger
    public interface ILogger
    {
        void Debug(string message);

        void Info(string message);

        void Warning(string message);

        void Error(string message);
    }
}