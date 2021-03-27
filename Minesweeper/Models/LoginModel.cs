/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/
using System.ComponentModel.DataAnnotations;

namespace Minesweeper.Models
{
    // variables for login
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}