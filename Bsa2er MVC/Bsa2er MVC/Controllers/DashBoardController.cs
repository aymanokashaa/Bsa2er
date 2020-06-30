using Bsa2er_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bsa2er_MVC.Controllers
{
    public class DashBoardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult DashBoardPage()
        {
            return View();
        }
        // GET: News
        public ActionResult News()
        {
            return PartialView(db.News.ToList());
        }
        //GET: Book Section
        public ActionResult BookSectionPage()
        {
            return PartialView(db.Booksections.ToList());
        }
        //GET: Programs
        public ActionResult ProgramsPage()
        {
            return PartialView(db.Programs.ToList());
        }
        //GET: Pictures
        public ActionResult PicturesPage()
        {
            return PartialView();
        }
    }
}