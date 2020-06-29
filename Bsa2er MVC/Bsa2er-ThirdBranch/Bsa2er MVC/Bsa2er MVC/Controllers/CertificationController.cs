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
       
        public ActionResult Create(int progId,string stdId)
        {
            var studentprogramInformation = db.StudentsPrograms.FirstOrDefault(s => s.Program_Id == progId && s.Std_Id == stdId);
            ViewBag.studentName = studentprogramInformation.Student.ApplicationUser.UserName;
            ViewBag.programName = studentprogramInformation.Program.Program_Title;
            ViewBag.grad = studentprogramInformation.ProgramGrade;
         
            return View();
        }
    }
}