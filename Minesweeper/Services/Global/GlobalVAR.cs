/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

namespace Minesweeper.Services
{
    /// <summary>
    /// Makes a global string that can be accessed from all DAO classes
    /// </summary>
    public static class GlobalVAR
    {
        public const string CONNECTIONSTRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MinesweeperTester;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}