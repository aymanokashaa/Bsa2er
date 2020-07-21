using Bsa2er_MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Net.Mail;
using System.Net;
using System.Web.Services.Description;
using Bsa2er_MVC;
namespace Bsa2er_MVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.CarouselImages.ToList());
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
        [HttpPost]
        public ActionResult Contact(message Message)
        {
            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("basaersite@gmail.com", "basaer123")
            };
            MailMessage m = new MailMessage("basaersite@gmail.com", "ammar.omega1@gmail.com")
            {
                Body = Message.body,
                Subject = Message.subject
            };
            client.Send(m);

            return RedirectToAction("Index");
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
            var progs = db.Programs.Where(p => p.Program_Type == ProgramType.PublicProgram);
            return View(progs);
        }
        public ActionResult Program(int id)
        {
            var prog = db.Programs.FirstOrDefault(p => p.ProgramId == id);
            return View(prog);
        }

        public ActionResult Tracks()
        {
            var progs = db.Programs.Where(p => p.Program_Type == ProgramType.Track);
            return View(progs);
        }
        public ActionResult Track(int id)
        {
            var prog = db.Programs.FirstOrDefault(p => p.ProgramId == id);
            return View(prog);
        }
        public ActionResult Progs()
        {
            var progs = db.Programs.Where(p => p.Program_Type == ProgramType.Program);
            return View(progs);
        }
        public ActionResult Prog(int id)
        {
            var prog = db.Programs.FirstOrDefault(p => p.ProgramId == id);
            return View(prog);
        }
        public ActionResult BookSection()
        {
            return View(db.Booksections.ToList());
        }

    }

 
}
