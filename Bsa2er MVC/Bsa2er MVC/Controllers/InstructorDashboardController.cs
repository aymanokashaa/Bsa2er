using Bsa2er_MVC.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bsa2er_MVC.Controllers
{
    public class InstructorDashboardController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: InstructorDashboard
        public ActionResult Index(string id)
        {
            var ins = db.Instructors.SingleOrDefault(i => i.InsId == id);
            return View(ins);
        }
    }
}