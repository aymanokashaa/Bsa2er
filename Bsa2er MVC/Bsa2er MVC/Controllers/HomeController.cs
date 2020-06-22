using Bsa2er_MVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace Bsa2er_MVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult News()
        {
            return View(db.News.ToList());
        }
        public ActionResult Library()
        {
            return View();
        }
        public ActionResult PublicProgarms()
        {
            return View();
        }
        public ActionResult Program()
        {
            return View();
        }

        public ActionResult Tracks()
        {
            return View();
        }
        public ActionResult Track()
        {
            return View();
        }
        public ActionResult Progs()
        {
            return View();
        }
        public ActionResult Prog()
        {
            return View();
        }

    }
}
