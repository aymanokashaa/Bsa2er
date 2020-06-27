using Bsa2er_MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace Bsa2er_MVC.Controllers
{
    public class CertificationController : Controller
    {
        ApplicationDbContext db;
        ApplicationUserManager _userManager;
        public CertificationController()
        {
            db = new ApplicationDbContext();
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

        }
       
        public ActionResult Create(/*string progId,int stdId*/)
        {
            /* var studentprogramInformation = db.StudentsPrograms.SingleOrDefault(s => s.Program_Id == progId && s.Std_Id == StdId);
             ViewBag.studentName = studentprogramInformation.Student.ApplicationUser.UserName;
             ViewBag.programName = studentprogramInformation.Program.Program_Title;
             ViewBag.grad = studentprogramInformation.ProgramGrade;*/
            ViewBag.studentName = "Ahmed";
            ViewBag.programName = "Full stack";
            ViewBag.grad = 100;
         
            return View();
        }
    }
}