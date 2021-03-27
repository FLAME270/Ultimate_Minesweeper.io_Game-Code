/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using System.Web.Mvc;
using System.Web.Routing;

namespace Minesweeper
{
    public class RouteConfig
    {
        /// <summary>
        /// Configues all the routes throughout the application
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Game",
                url: "Game/",
                defaults: new { controller = "Game", action = "Game", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "Login/",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Registration",
                url: "Registration/",
                defaults: new { controller = "Registration", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}