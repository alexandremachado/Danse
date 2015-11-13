using System.Web.Mvc;

namespace Danse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Data.Data MyData = new Data.Data();
            MyData.ExecuterRequete("ma requete");
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}