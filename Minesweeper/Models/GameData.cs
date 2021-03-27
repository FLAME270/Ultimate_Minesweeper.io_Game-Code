/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/
namespace Minesweeper.Models
{
    public class GameData
    {
        // variables with getters and setters
        public int UserId { get; set; }
        public int Turns { get; set; }
        public int Size { get; set; }
        public int Difficulty { get; set; }
        public int Timer { get; set; }
        public string JSONData { get; set; }
    }
}