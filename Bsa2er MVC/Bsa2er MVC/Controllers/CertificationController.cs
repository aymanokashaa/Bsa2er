using Bsa2er_MVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace Bsa2er_MVC.Controllers
{
    public class CertificationController : Controller
    {
        ApplicationDbContext db;
        ApplicationUserManager _UserManager;
        public CertificationController(ApplicationUserManager UserManager)
        {
            db = new ApplicationDbContext();
            _UserManager = UserManager;

        }

        public ActionResult Create(string StdId, int progId)
        {
            var studentprogramInformation = db.StudentsPrograms.SingleOrDefault(s => s.Program_Id == progId && s.Std_Id == StdId);
            ViewBag.studentName = studentprogramInformation.Student.ApplicationUser.UserName;
            ViewBag.programName = studentprogramInformation.Program.Program_Title;
            ViewBag.grad = studentprogramInformation.ProgramGrade;
            return View();
        }
    }
}