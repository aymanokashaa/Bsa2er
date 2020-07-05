using Bsa2er_MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Rotativa;
using System.Linq;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace Bsa2er_MVC.Controllers
{
    [Authorize]
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
            ViewBag.studentName = studentprogramInformation.Student.ApplicationUser.fullname;
            ViewBag.programName = studentprogramInformation.Program.Program_Title;
            ViewBag.grad = studentprogramInformation.ProgramGrade;
         
            return View();
        }
        public ActionResult getCertification(int progId, string stdId)
        {
            var studentprogramInformation = db.StudentsPrograms.FirstOrDefault(s => s.Program_Id == progId && s.Std_Id == stdId);
            ViewBag.studentName = studentprogramInformation.Student.ApplicationUser.fullname;
            ViewBag.programName = studentprogramInformation.Program.Program_Title;
            ViewBag.grad = studentprogramInformation.ProgramGrade;

            return View();
        }
        public ActionResult PrintPdf(int pId,string sId)
        {
            var pdf = new ActionAsPdf("getCertification", new {progId=pId,stdId=sId });
            pdf.FileName = "شهادة إتمام البرنامج" + ".pdf";
            pdf.Cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);
            return pdf;
        }

        public ActionResult getCertificationPartial(int progId, string stdId)
        {
            var studentprogramInformation = db.StudentsPrograms.FirstOrDefault(s => s.Program_Id == progId && s.Std_Id == stdId);
            var studentName = studentprogramInformation.Student.ApplicationUser.fullname;
            var programName = studentprogramInformation.Program.Program_Title;
            var grad = studentprogramInformation.ProgramGrade;
            var obj = new CertificationViewModel()
            {
                studentName = studentName,
                programName = programName,
                grad = grad
            };
            return new PartialViewAsPdf(obj);
        }
    }
}