/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using Minesweeper.Services.Utility;
using System.Web.Mvc;
using Unity;

namespace Minesweeper.Controllers
{
    // Attribute that can be added to logging entry and exit from all controllers.
    public class CustomLoggingAttribute : FilterAttribute, IActionFilter
    {
        // Dependency injection that provides an instance of ILogger
        [Dependency]
        public ILogger Logger { get; set; }

        /// <summary>
        /// Logs everytime user enters the contoller
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = (string)filterContext.RouteData.Values["Controller"];
            string actionName = (string)filterContext.RouteData.Values["Action"];

            Logger.Info("Entering " + controllerName + "Controller." + actionName + "()");
        }

        /// <summary>
        /// Loges the exit from all controllers
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string controllerName = (string)filterContext.RouteData.Values["Controller"];
            string actionName = (string)filterContext.RouteData.Values["Action"];
            //logs everytime user exits the controller
            Logger.Info("Exiting " + controllerName + "Controller." + actionName + "()");
        }
    }
}