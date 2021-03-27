/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using Minesweeper.Models;
using System;
using System.Data.SqlClient;
using System.Web;

namespace Minesweeper.Services.Data
{
    public class GamesDAO
    {
        //This method saves the game state/data
        public bool SaveGame(GameData gameData)
        {
            bool GameSaved;

            // checks if board size and difficulty is saved for player in the game. if its saved in the database it will update it. Else it will save the current game.
            if (LookForSave(gameData.Size, gameData.Difficulty))
            {
                GameSaved = UpdateSaveGame(gameData);
            }
            else
            {
                GameSaved = SaveNewGame(gameData);
            }

            return GameSaved;
        }

        //This method saves all the new games
        public bool SaveNewGame(GameData gameData)
        {
            bool success = false;

            // sql query to insert the game data into the database
            string queryString = "INSERT INTO savedGames VALUES(@UserID, @Turns, @Size, @Difficulty, @Timer, @JSONData)";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Adds the game data values
                command.Parameters.AddWithValue("@UserID", gameData.UserId);
                command.Parameters.AddWithValue("@Turns", gameData.Turns);
                command.Parameters.AddWithValue("@Size", gameData.Size);
                command.Parameters.AddWithValue("@Difficulty", gameData.Difficulty);
                command.Parameters.AddWithValue("@Timer", gameData.Timer);
                command.Parameters.AddWithValue("@JSONData", gameData.JSONData);

                // Try catch to access database, return true if successful, false if not successfull
                try
                {
                    connection.Open();

                    int test = command.ExecuteNonQuery();

                    if (test > 0)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return success;
        }

        // Method to update the GameData in the database
        public bool UpdateSaveGame(GameData gameData)
        {
            bool success = false;
            // sql query to update game data into the database and save it as JSONData
            string queryString = "UPDATE dbo.savedGames SET turns = @Turns, timer = @Timer, jsonData = @JSONData WHERE userid = @UserId AND size = @Size AND difficulty = @Difficulty";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Add game data to INSERT statement
                command.Parameters.AddWithValue("@UserID", gameData.UserId);
                command.Parameters.AddWithValue("@Turns", gameData.Turns);
                command.Parameters.AddWithValue("@Size", gameData.Size);
                command.Parameters.AddWithValue("@Difficulty", gameData.Difficulty);
                command.Parameters.AddWithValue("@Timer", gameData.Timer);
                command.Parameters.AddWithValue("@JSONData", gameData.JSONData);

                // Try to access database and update save game
                try
                {
                    connection.Open();

                    int test = command.ExecuteNonQuery();
                    if (test > 0)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return success;
        }

        /// <summary>
        /// Checks to see if the user has an existing game in that specific board size and difficulty.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        public bool LookForSave(int size, double difficulty)
        {
            bool exists = false;

            int userID = int.Parse((String)HttpContext.Current.Session["UserId"]);

            // Query string to check for current user's saved games
            string queryString = "SELECT * FROM dbo.savedGames WHERE userid = @UserId AND size = @Size AND difficulty = @Difficulty";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                //pulls the userID, size and difficulty from the database
                command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = userID;
                command.Parameters.Add("@Size", System.Data.SqlDbType.Int).Value = size;
                command.Parameters.Add("@Difficulty", System.Data.SqlDbType.Int).Value = difficulty;

                // Try connecting to database and retuns the results of if the bord exist for that user
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        exists = true;
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            return exists;
        }

        /// <summary>
        /// Method to load a previously saved game based off of saved items in the database
        /// </summary>
        /// <param name="size"></param>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        public GameData LoadGame(int size, double difficulty)
        {
            int userID = int.Parse((String)HttpContext.Current.Session["UserId"]);

            GameData gameData = new GameData();

            string queryString = "SELECT * FROM dbo.savedGames WHERE userid = @UserId AND size = @Size AND difficulty = @Difficulty";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Set parameters for prepared statement to check if the game exists
                command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = userID;
                command.Parameters.Add("@Size", System.Data.SqlDbType.Int).Value = size;
                command.Parameters.Add("@Difficulty", System.Data.SqlDbType.Int).Value = difficulty;

                // Try  catch to access database and retrieve results
                try
                {
                    //open a connection
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if the query results are returned.
                    while (reader.Read())
                    {
                        //If there are any results, load the gameData pulled from the database
                        gameData.UserId = (int)reader["userid"];
                        gameData.Size = (int)reader["size"];
                        gameData.Difficulty = (int)reader["difficulty"];
                        gameData.Timer = (int)reader["timer"];
                        gameData.Turns = (int)reader["turns"];
                        gameData.JSONData = (string)reader["jsonData"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            // Return results
            return gameData;
        }
    }
}