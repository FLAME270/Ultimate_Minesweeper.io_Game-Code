/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using Minesweeper.Models;
using Minesweeper.Services.Data;

namespace Minesweeper.Services.Business
{
    public class RegistrationService
    {
        // Method to register a new user
        public bool RegisterUser(UserModel user)
        {
            //Gets the UserDAO class that manages the database connection
            UserDAO userDAO = new UserDAO();

            // Add user to the database
            return userDAO.AddUser(user);
        }
    }
}