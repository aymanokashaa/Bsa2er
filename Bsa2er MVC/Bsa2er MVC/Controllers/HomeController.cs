using Bsa2er_MVC.Models;
using Microsoft.AspNet.Identity;
using System;
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
            return View(db.Galleries.ToList());
        }
        public ActionResult News()
        {
            return View(db.News.ToList());
        }

        public ActionResult PublicProgarms()
        {
            return View(db.Programs.Where(p=>p.Program_Type==ProgramType.PublicProgram));
        }
        public ActionResult Program()
        {
            return View();
        }

        public ActionResult Tracks()
        {
            return View(db.Programs.Where(p => p.Program_Type == ProgramType.Track));
        }
        public ActionResult Track()
        {
            return View();
        }
        public ActionResult Progs()
        {
            return View(db.Programs.Where(p => p.Program_Type == ProgramType.Program));
        }
        public ActionResult Prog()
        {
            return View();
        }
        public ActionResult BookSection()
        {
            return View();
        }

    }
}
