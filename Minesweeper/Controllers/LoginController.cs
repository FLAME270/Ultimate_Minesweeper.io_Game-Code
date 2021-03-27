/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using Minesweeper.Models;
using Minesweeper.Services.Business;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    //Cool auto logging feature
    [CustomLogging]
    public class LoginController : Controller
    {
        // Get: Login
        [HttpGet]
        public ActionResult Login()
        {
            //gets the login modal class
            LoginModel user = new LoginModel();

            // Check if user is already logged in
            if (Session["login"] != null)
            {
                user = (LoginModel)Session["login"];
                return View("LoginSuccess", user);
            }
            //Return the login page
            return View("Login", user);
        }

        // Get: Logout
        [HttpGet]
        //Logout method to logout a user
        public ActionResult Logout()
        {
            // Clear the Session
            if (Session["login"] != null)
            {
                Session.Clear();
            }
            //Returns the login page
            return Redirect("Login");
        }

        // Post: Login
        [HttpPost]
        //Verifys the users username and password
        public ActionResult Login(LoginModel user)
        {
            // Data verification for the user model
            if (!ModelState.IsValid)
            {
                return View("Login", user);
            }

            // Gets the SecurityService class and returns user validation
            SecurityService securityService = new SecurityService();

            // Search for valid User in database. Returns true for success false for fail.
            bool userValid = securityService.Authenticate(user);

            //if the user is valid, return the LoginSuccess page else return the LoginError page.
            if (userValid)
            {
                Session["login"] = user;
                return View("LoginSuccess", user);
            }
            else
            {
                Session.Clear();
                return View("LoginError", user);
            }
        }
    }
}