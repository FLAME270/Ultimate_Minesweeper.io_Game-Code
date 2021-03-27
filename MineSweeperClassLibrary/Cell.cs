/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

namespace MineSweeperClassLibrary
{
    public class Cell
    {
        //variable that stores the Row location of Cell
        public int Row { get; set; } = -1;
        //variable that stores Column location of Cell
        public int Col { get; set; } = -1;
        // variable that stores if the Cell been visited
        public bool Visited { get; set; } = false;
        //variable that stores if the Cell a Mine
        public bool Live { get; set; } = false;
        //variable that stores Quantity of neighbors that are Mines
        public int LiveNeighbors { get; set; } = 0;
        //variable that stores a bool of it the cell is flagged
        public bool IsFlagged { get; set; } = false;
    }
}