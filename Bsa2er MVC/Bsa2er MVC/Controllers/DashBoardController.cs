using Bsa2er_MVC.Models;
using Bsa2er_MVC.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bsa2er_MVC.Controllers
{
    [Authorize(Roles ="Admin,Owner")]
    public class DashBoardController : Controller
    {
        private readonly ApplicationDbContext db;// = new ApplicationDbContext();
        private readonly IRepository<Visitor> vistorRepository;

        public DashBoardController(ApplicationDbContext _db,IRepository<Visitor> _visitorRepository)
        {
            db = _db;
            vistorRepository = _visitorRepository;
        }
        public ActionResult DashBoardPage()
        {
            var listOfS = db.Users.Where(u => u.Roles.Any(r => r.RoleId == "4"));
            ViewBag.NumOfStudents = listOfS.ToList().Count();
            ViewBag.NumOfNewStudents =listOfS.AsEnumerable().Where(u=> (DateTime.Now-u.dataOfRegister).Days <= 7).ToList().Count();
            ViewBag.NumOfProgram = db.Programs.ToList().Count();
             int[] visitorsInfo = vistorRepository.getInfo();
            ViewBag.NumOfTodayVisitors = visitorsInfo[0];
            ViewBag.NumOfAllVisitors = visitorsInfo[1];

           var id = User.Identity.GetUserId();
            var user = db.Users.SingleOrDefault(u => u.Id ==id );
            if (user.pathofimage == null)
            {
                ViewBag.img = "/images/DashBoard/user.png";
            }
            else
            {
                ViewBag.img = user.pathofimage;
            }
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
        public ActionResult ProgramsPage(ProgramType type)
        {
            ViewBag.type = type;
            return PartialView(db.Programs.Where(p=>p.Program_Type==type).ToList());
        }
        //GET: Pictures
        public ActionResult PicturesPage()
        {
            return PartialView(db.Galleries.ToList());
        }
    }
}