/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    //Cool auto logging feature to log enter or exiting of controllers
    [CustomLogging]
    public class HomeController : Controller
    {
        // GET: Home
        [CustomAuthorization]
        //return home view if user is logged in
        public ActionResult Index()
        {
            return View();
        }
    }
}