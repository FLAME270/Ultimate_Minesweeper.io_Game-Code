/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using MineSweeperClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace Minesweeper.Services.Data
{
    public class HighScoreDAO
    {
        /// <summary>
        /// Function to add a new HighScore to the database
        /// </summary>
        /// <param name="playerStats"></param>
        public void AddScore(PlayerStats playerStats)
        {
            // Get the userID and thier session fo that thier username can be added next to thier highscore
            int userID = int.Parse((String)HttpContext.Current.Session["UserId"]);

            // Query string to insert the players new high score into the database using the prepared statement
            string queryString = "INSERT INTO highScores VALUES(@UserID, @Timespan, @Difficulty, @BoardSize, @Username)";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Add players high score data to the INSERT statement
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@Timespan", playerStats.TimeAsTicks);
                command.Parameters.AddWithValue("@Difficulty", playerStats.DifficultyLevel);
                command.Parameters.AddWithValue("@BoardSize", playerStats.BoardSize);
                command.Parameters.AddWithValue("@Username", playerStats.PlayerInitials);

                // Try to access database and insert the score
                try
                {
                    connection.Open();

                    // Returns number of rows affected
                    int test = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Gets to top 10 scores for that difficulty and board size
        /// </summary>
        /// <param name="size"></param>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        public List<PlayerStats> GetTopTenScores(int size, double difficulty)
        {
            // List to hold results of the top 10 high scores
            List<PlayerStats> highScoreList = new List<PlayerStats>();

            // Query string to retrieve top 10 scores using a prepared statement
            string queryString = "SELECT TOP 10 * FROM dbo.highScores WHERE difficulty = @Difficulty AND boardsize = @Boardsize ORDER BY timespan";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Set the parameters for prepared statement
                command.Parameters.Add("@Difficulty", System.Data.SqlDbType.Int).Value = difficulty;
                command.Parameters.Add("@Boardsize", System.Data.SqlDbType.Int).Value = size;

                // Try to access the database and retrieve all the results results
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if query returned results. If there is results return them to the highScoreList
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Handles all the timer related functions
                            TimeSpan ts = new TimeSpan();
                            long timespan;
                            timespan = (long)reader["timespan"];
                            ts = TimeSpan.FromTicks(timespan);

                            // Create PlayerStats instance and populate with users time difficulty, and boardsize
                            PlayerStats playerStats = new PlayerStats
                            {
                                TimeSpanString = ts.ToString(),
                                TimeAsTicks = timespan,
                                PlayerInitials = reader["username"].ToString(),
                                DifficultyLevel = (int)reader["difficulty"],
                                BoardSize = (int)reader["boardsize"]
                            };

                            // Adds a new player status to the highScoreList
                            highScoreList.Add(playerStats);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            //Return the fully updated list
            return highScoreList;
        }

        /// <summary>
        /// Gets all the high scores for that specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<PlayerStats> GetScoresForUser(int userId)
        {
            // List to hold the player's results
            List<PlayerStats> scores = new List<PlayerStats>();

            //sql query Statement that serches for users highScore
            string queryString = "SELECT * FROM dbo.highScores WHERE \"user\" = @userId";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Set parameters for prepared statement
                command.Parameters.Add("@userId", System.Data.SqlDbType.Int).Value = userId;

                // Try to access database and retrieve results
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if query returned results. If results added to highScoreList
                    if (reader.HasRows)
                    {
                        //while loop that reads out the player's score for that size and difficulty
                        while (reader.Read())
                        {
                            // Get time as ticks from database and convert to a timespan
                            TimeSpan ts = new TimeSpan();
                            long timespan;
                            timespan = (long)reader["timespan"];
                            ts = TimeSpan.FromTicks(timespan);

                            // Create PlayerStats instance and populate
                            PlayerStats playerStats = new PlayerStats
                            {
                                TimeSpanString = ts.ToString(),
                                TimeAsTicks = timespan,
                                PlayerInitials = reader["username"].ToString(),
                                DifficultyLevel = (int)reader["difficulty"],
                                BoardSize = (int)reader["boardsize"]
                            };

                            // Add PlayerStats to highScoreList
                            scores.Add(playerStats);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            //returns all the scores
            return scores;
        }

        /// <summary>
        /// this function retrieves high scores by the username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<PlayerStats> GetScoresByUsername(string username)
        {
            // List to hold the score results
            List<PlayerStats> scores = new List<PlayerStats>();

            //sql query to select a players highscore
            string queryString = "SELECT * FROM dbo.highScores WHERE username LIKE @Username";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Set parameters for prepared statement
                command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = username;

                // Try to access database and retrieve results
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if query returned results. If results add to highScoreList
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Get time as ticks from database and convert to timespan
                            TimeSpan ts = new TimeSpan();
                            long timespan;
                            timespan = (long)reader["timespan"];
                            ts = TimeSpan.FromTicks(timespan);

                            // Create PlayerStats instance and populate
                            PlayerStats playerStats = new PlayerStats
                            {
                                TimeSpanString = ts.ToString(),
                                TimeAsTicks = timespan,
                                PlayerInitials = reader["username"].ToString(),
                                DifficultyLevel = (int)reader["difficulty"],
                                BoardSize = (int)reader["boardsize"]
                            };

                            // Add PlayerStats to highScoreList
                            scores.Add(playerStats);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            //returns players high score
            return scores;
        }
    }
}