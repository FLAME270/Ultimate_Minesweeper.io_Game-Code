/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using Minesweeper.Models;
using Minesweeper.Services.Data;
using MineSweeperClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

namespace Minesweeper.Services.Game
{
    public class GameService
    {
        //Gets the Board class
        public Board gameBoard = new Board(5, 1);

        // High Score list
        public List<PlayerStats> highScoreList = new List<PlayerStats>();

        // Boolean for if game is over
        public bool gameOver = false;

        // Boolean for if the player won
        public bool isWinner = false;

        // Board size in cells x cells
        public int Size { get; set; }

        // variable to store the difficulty of the game
        public double Difficulty { get; set; }

        // Variable to save the time saved for the game
        public int Timer { get; set; }

        // Turns count for saved game
        public int Turns { get; set; }

        // Method for starting a new game
        public void StartGame()
        {
            // method places bombs in grid
            gameBoard.SetupLiveNeighbors();
            // Calculate live neighbor count for cells
            gameBoard.CalculateLiveNeighbors();
        }

        /// <summary>
        /// Method that resets the board and starts the game
        /// </summary>
        /// <param name="size"></param>
        /// <param name="difficulty"></param>
        public void StartGame(int size, double difficulty)
        {
            // Set variables
            gameOver = false;
            isWinner = false;
            Timer = 0;
            Turns = 0;
            Size = size;
            Difficulty = difficulty;

            // Setup a new game board with the chosen size and difficulty
            gameBoard = new Board(size, difficulty);
            // Place bombs in grid
            gameBoard.SetupLiveNeighbors();
            // Calculate live neighbor count for cells
            gameBoard.CalculateLiveNeighbors();
        }

        /// <summary>
        /// Method for handling each turn
        /// </summary>
        /// <param name="cell"></param>
        public void TakeTurn(string cell)
        {
            // Get row and column from input and set to integers
            string[] strArr = cell.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            // If the cell is not flagged proceed with turn
            if (!gameBoard.Grid[r, c].IsFlagged)
            {
                // Flood fill the game board
                gameBoard.FloodFill(r, c);

                // Check if the player cleared the game board and all All Cells are visited
                if (gameBoard.Grid[r, c].Live || AllCellsVisited())
                {
                    gameOver = true;
                }

                // Check if the payer won the game through clearing the game board
                if (AllCellsVisited())
                {
                    isWinner = true;
                }
            }
        }

        /// <summary>
        /// This method handle all the flagging functionality for the cells
        /// </summary>
        /// <param name="mine"></param>
        public void FlagCell(string mine)
        {
            // Get row and column and set to integers
            string[] strArr = mine.ToString().Split('|');
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            //if player decides to remove a flag, this will flag and unflag cells
            gameBoard.Grid[r, c].IsFlagged = !gameBoard.Grid[r, c].IsFlagged;
        }

        /// <summary>
        /// Method to check if all of the cells are visited
        /// </summary>
        /// <returns></returns>
        private bool AllCellsVisited()
        {
            // Boolean to check if all the cells/Tiles are visited
            bool allVisited = true;

            for (int row = 0; row < gameBoard.Size; row++)
            {
                for (int col = 0; col < gameBoard.Size; col++)
                {
                    // Step through all cells. If cell is not a bomb and not visited, allVisited is false.
                    if (!gameBoard.Grid[row, col].Visited && !gameBoard.Grid[row, col].Live)
                    {
                        allVisited = false;
                    }
                }
            }
            //return if all the cells are visited
            return allVisited;
        }

        // Method that resets the game.
        public void ResetGame()
        {
            gameBoard = new Board(Size, Difficulty);
            gameOver = false;
            isWinner = false;
            Timer = 0;
            Turns = 0;
        }
        //////////Coming Soon//////////
        /// <summary>
        ///
        // Method for adding player's score results to the database table. score = Takes string of time in "00:00:00" format
        /// </summary>
        /// <param name="time"></param>
        public void SaveScore(string time)
        {
            // Get Username from Session
            string user = HttpContext.Current.Session["UserInfo"].ToString();
            // Parse time into TimeSpan
            TimeSpan ts = TimeSpan.Parse(time);
            long timeAsTicks = ts.Ticks;
            // Create PlayerStats instance for new results
            PlayerStats newPlayerStats = new PlayerStats(user, timeAsTicks, Difficulty, Size);
            // Create instance of HighScoreDAO for accessing database
            HighScoreDAO highScore = new HighScoreDAO();
            // Add new result to database
            highScore.AddScore(newPlayerStats);
            // Update current Top Ten Scores
            GetTopTenScoresREST();
        }

        // Method to get top 10 high scores for current board size and difficulty
        private void GetTopTenScores()
        {
            // Create instance of HighScoreDAO for accessing database
            HighScoreDAO highScore = new HighScoreDAO();
            // Retrieve the top ten scores for current board and difficulty to List<PlayerStats>
            highScoreList = highScore.GetTopTenScores(Size, Difficulty);
        }

        /// <summary>
        /// Method that saves the game state and passes it to the gamevDAO
        /// </summary>
        /// <param name="time"></param>
        /// <param name="turnsCount"></param>
        /// <returns></returns>
        public bool SaveGame(int time, int turnsCount)
        {
            //gets the GamesDAO class to insert game into database
            GamesDAO gamesDAO = new GamesDAO();

            // GameData for holding the current games data
            GameData gameData = new GameData
            {
                // Loads the gameData with the current game's data
                UserId = int.Parse((String)HttpContext.Current.Session["UserId"]),
                Turns = turnsCount,
                Timer = time,
                Size = this.Size,
                Difficulty = (int)this.Difficulty,
                // Convert current game Board to JSON format for storage in database
                JSONData = JsonConvert.SerializeObject(this.gameBoard)
            };

            // Call SaveGame() method with current the gameData to save the game
            bool success = gamesDAO.SaveGame(gameData);
            //returns if the game was saved successfully
            return success;
        }

        /// <summary>
        /// this method Loads the last saved game
        /// </summary>
        /// <returns></returns>
        public bool LoadGame()
        {
            //gets the GameDAO class for database connection
            GamesDAO gamesDAO = new GamesDAO();

            //loads a priviously saved game of the same size and difficult
            GameData gameData = gamesDAO.LoadGame(this.Size, this.Difficulty);

            try
            {
                // converts the saved game data from JSON back to Board object and load to current game board
                this.gameBoard = JsonConvert.DeserializeObject<Board>(gameData.JSONData);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            // Get timer and turn data from results
            this.Turns = gameData.Turns;
            this.Timer = gameData.Timer;

            //returns true if bord loaded
            return true;
        }

        /// <summary>
        /// Method to get the top 10 high scores for the current board size and difficulty through REST service
        /// </summary>
        private void GetTopTenScoresREST()
        {
            //url of REST service providing the High Score data
            string url = "http://localhost:55058/ScoreService.svc/GetTopTenScores/" + Size + "/" + Difficulty;

            //WebRequest to obtain JSON high scores from REST service
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                // Get response from REST service
                WebResponse response = request.GetResponse();
                // get the RESTHighScoresDTO class and pull the top 10 scores
                RESTHighScoresDTO restDTO = new RESTHighScoresDTO();
                // Stream the response and deserialize to a DTO object
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    restDTO = JsonConvert.DeserializeObject<RESTHighScoresDTO>(reader.ReadToEnd());
                    // Set results to the high score list
                    highScoreList = restDTO.Scores;
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}