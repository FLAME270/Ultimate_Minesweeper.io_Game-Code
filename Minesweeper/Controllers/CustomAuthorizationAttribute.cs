/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using Minesweeper.Models;
using Minesweeper.Services.Business;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    // This class provides extra security, by adding authenticationfilters before the user can log in
    internal class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // Calls the Security service class
            SecurityService securityService = new SecurityService();

            // Check for logged in user information in session
            LoginModel loginModel = (LoginModel)filterContext.HttpContext.Session["login"];

            bool success = false;

            // If user data is correct, set sucess to true
            if (loginModel != null)
            {
                success = securityService.Authenticate(loginModel);
            }

            // If success is true allow access to website, else reroute to the login page
            if (success)
            {
            }
            else
            {
                filterContext.Result = new RedirectResult("/Login");
            }
        }
    }
}