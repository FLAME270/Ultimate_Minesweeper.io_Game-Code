/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using Minesweeper.Services.Game;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    //Makes application more secure
    [CustomAuthorization]
    //Adds cool auto logging feature
    [CustomLogging]
    public class GameController : Controller
    {
        //Gets the GameService class
        private static readonly GameService gameService = new GameService();

        // Action method for starting up the game page
        // POST: Game
        [HttpPost]
        public ActionResult Game()
        {
            // Gets the size and difficulty of the game board
            int size = int.Parse(Request["size"].ToString());
            int difficulty = int.Parse(Request["difficulty"].ToString());
            //Starts the game with correct size and difficulty
            gameService.StartGame(size, difficulty);
            //return the game bord view
            return View("Game", gameService);
        }

        // Action method for responding to a player's left mouse click using Ajax.
        // POST: OnLeftMouesClick
        [HttpPost]
        //Whenever left mouse is clicked, check for a mine
        public ActionResult OnLeftMouseClick(string mine)
        {
            /*    if (turns == 0)
                {
                    LiveNeighbors = 0;
                }*/

            //Tells the gameService the cell that was clicked and retuns a partial view of tuns results
            gameService.TakeTurn(mine);

            // Returns partial view for Ajax of game results
            return PartialView("_GameBoard", gameService);
        }

        // POST: OnRightMouseClick
        [HttpPost]
        // Action method that responds to a player's right moues click using Ajax.
        public ActionResult OnRightMouseClick(string mine)
        {
            // Send clicked cell's grid coordinates to flag cell
            gameService.FlagCell(mine);

            // Returns partial view for Ajax of placed or unplaced flags
            return PartialView("_GameBoard", gameService);
        }

        // Method to reset the entire the game
        public ActionResult ResetGame()
        {
            gameService.ResetGame();
            gameService.StartGame();

            return View("Game", gameService);
        }

        //////Coming Soon//////
        // Method for adding the players score to a highScore table
        public ActionResult PlayerStats(string time)
        {
            gameService.SaveScore(time);

            // Returns partial view for Ajax of new score
            return PartialView("_GameBoard", gameService);
        }

        //Handler to save the game
        public ActionResult OnSave(int time, int turnsCount)
        {
            //Saves the time and turn count in the database
            gameService.SaveGame(time, turnsCount);

            // Returns partial view for Ajax
            return PartialView("_GameBoard", gameService);
        }

        // Load a game handler
        public ActionResult OnLoad()
        {
            gameService.LoadGame();
            // Returns partial view for Ajax of the previously saved game
            return PartialView("_GameBoard", gameService);
        }
    }
}