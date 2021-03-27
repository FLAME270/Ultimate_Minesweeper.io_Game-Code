/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/
using Minesweeper.Models;
using Minesweeper.Services.Data;
using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace Minesweeper
{
    public class ServiceAuth : UserNamePasswordValidator
    {
        /// <summary>
        /// Validate method to make sure player/user already exist in the db
        /// and validates to make sure textbox is not empty
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public override void Validate(string username, string password)
        {
            System.Diagnostics.Debug.Write("username => " + username + " password => " + password);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username or Password is empty");
            }

            SecurityDAO service = new SecurityDAO();
            LoginModel user = new LoginModel
            {
                Username = username,
                Password = password
            };
            if (!service.FindByUser(user))
            {
                throw new SecurityTokenException("unknown user");
            }
        }
    }
}