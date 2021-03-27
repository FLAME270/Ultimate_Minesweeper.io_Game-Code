/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using Minesweeper.Models;
using Minesweeper.Services.Data;

namespace Minesweeper.Services.Business
{
    public class SecurityService
    {
        // use database to authenticate all users
        public bool Authenticate(LoginModel user)
        {
            //gets the SecurityDAO class
            SecurityDAO securityDAO = new SecurityDAO();

            // find user by getting the users object
            return securityDAO.FindByUser(user);
        }
    }
}