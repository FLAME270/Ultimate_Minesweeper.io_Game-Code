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
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        // Action methodthat brings up the registration form
        public ActionResult Register()
        {
            //gets the user modal class
            UserModel user = new UserModel();

            return View("Registration", user);
        }

        // POST: Registration
        [HttpPost]
        //Registration method
        public ActionResult Register(UserModel user)
        {
            // Validatethe  UserModel data
            if (!ModelState.IsValid)
            {
                return View("RegistrationError", user);
            }

            //gets the RegistrationService class
            RegistrationService registrationService = new RegistrationService();

            // Returns if the user exist in the database and returns if register success or failure
            bool userRegistered = registrationService.RegisterUser(user);

            //returns RegistrationSucess if user is successfully registered, else return RegestrationError view
            if (userRegistered)
            {
                return View("RegistrationSuccess", user);
            }
            else
            {
                return View("RegistrationError", user);
            }
        }
    }
}