/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using System;

namespace MineSweeperClassLibrary
{
    public class Board
    {
        //variable that stores the grid size
        public int Size { get; set; }
        // Array of Cells for the game board
        public Cell[,] Grid { get; set; }
        //stores the games difficulty
        public double Difficulty { get; set; } 

       /// <summary>
       /// methodto make the grid size bassed of of the difficulty selected
       /// </summary>
       /// <param name="size"></param>
       /// <param name="difficulty"></param>
        public Board(int size, double difficulty)
        {
            this.Size = size;
            this.Grid = new Cell[Size, Size]; 

            // sets the number of bombs bassed off of the difficulty
            //CHANGE THE NUMBERS BELOW TO MAKE THE GAME EASIER/HARDER
            if (difficulty == 1) { Difficulty = .16; }
            if (difficulty == 2) { Difficulty = .18; }
            if (difficulty == 3) { Difficulty = .25; }

            //makes a new array of cells with row's and col's 
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = new Cell
                    {
                        Row = row,
                        Col = col
                    };
                }
            }
        }

       /// <summary>
       /// Places all the mines on the game board
       /// </summary>
        public void SetupLiveNeighbors()
        {
            // Find's the number of cells in the game board
            int cells = Size * Size; 

            // Multiply the number of cells by the difficultly percentage
            // then round up that number for the mine count
            int bombs = (int)Math.Ceiling(cells * Difficulty);
            // Creates a new random number generator
            var rand = new Random();
            // Counter for the number of mines
            int count = 0; 

            // Randomly generate (x,y) coordinates and place mines on the game
            // board if there's not already a mine.
            while (count < bombs)
            {
                int randRow = rand.Next(Size);
                int randCol = rand.Next(Size);
                if (Grid[randRow, randCol].Live != true)
                {
                    Grid[randRow, randCol].Live = true;
                    count++;
                }
            }
        }

        /// <summary>
        /// Find all the mines that is touching that cell
        /// </summary>
        public void CalculateLiveNeighbors()
        {
            // Step through each Cell in Grid and check valid neighbors for mines
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (IsValid(row - 1, col - 1) && Grid[row - 1, col - 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row - 1, col) && Grid[row - 1, col].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row - 1, col + 1) && Grid[row - 1, col + 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row, col - 1) && Grid[row, col - 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row, col + 1) && Grid[row, col + 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row + 1, col - 1) && Grid[row + 1, col - 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row + 1, col) && Grid[row + 1, col].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                    if (IsValid(row + 1, col + 1) && Grid[row + 1, col + 1].Live)
                    {
                        Grid[row, col].LiveNeighbors++;
                    }
                }
            }
        }

       /// <summary>
       /// Checks if the mine location is a valid location
       /// </summary>
       /// <param name="row"></param>
       /// <param name="col"></param>
       /// <returns></returns>
        public bool IsValid(int row, int col)
        {
            // Check if cell is within the array
            if (row >= 0 && row < Size && col >= 0 && col < Size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       /// <summary>
       /// A recursive function that opens up all the 0's/blank cells
       /// </summary>
       /// <param name="row"></param>
       /// <param name="col"></param>
        public void FloodFill(int row, int col)
        {
            // Check Cell, if valid, not visited, and no live neighbors mark as visited and check neighbors
            if (IsValid(row, col) && Grid[row, col].Visited != true && Grid[row, col].LiveNeighbors == 0)
            {
                Grid[row, col].Visited = true;
            // Check surrounding eight cells
            /*XXX
              XMX
              XXX */
                FloodFill(row + 1, col);
                FloodFill(row, col + 1);
                FloodFill(row - 1, col);
                FloodFill(row, col - 1);

                FloodFill(row + 1, col + 1);
                FloodFill(row - 1, col + 1);
                FloodFill(row + 1, col - 1);
                FloodFill(row - 1, col - 1);
            }
            // If live neighbors, mark as visited
            else if (IsValid(row, col) && Grid[row, col].Visited != true)
            {
                Grid[row, col].Visited = true;
            }
        }
    }
}