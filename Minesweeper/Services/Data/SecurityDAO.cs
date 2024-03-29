﻿/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using Minesweeper.Models;
using System;
using System.Data.SqlClient;
using System.Web;

namespace Minesweeper.Services.Data
{
    public class SecurityDAO
    {
        /// <summary>
        /// Checks to see if user exists in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool FindByUser(LoginModel user)
        {
            // Boolean to track success of user insertion
            bool success = false;

            // Query string to check for specific user using prepared statement
            string queryString = "SELECT * FROM dbo.users WHERE username = @Username AND password = @Password";

            // Set connection with connection string
            using (SqlConnection connection = new SqlConnection(GlobalVAR.CONNECTIONSTRING))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Set parameters for prepared statement
                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;

                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                // Try to access database and retrieve results
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if query returned results. If results, return true else return false.
                    if (reader.HasRows)
                    {
                        success = true;
                        //while loop that reads through the database table and tries to find the player/user
                        while (reader.Read())
                        {
                            HttpContext.Current.Session["UserInfo"] = reader["username"].ToString();
                            HttpContext.Current.Session["UserId"] = reader["Id"].ToString();
                        }
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
            }
            //return if successfull or not
            return success;
        }
    }
}