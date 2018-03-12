using System.Web.Mvc;

namespace JeffCoUniversity.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowRegistrationPartial()
        {
            ViewBag.PartialType = "_Register";
            return View("Index");
        }

        public ActionResult ShowLoginPartial()
        {
            ViewBag.PartialType = "_Login";
            return View("Index");
        }
    }
}