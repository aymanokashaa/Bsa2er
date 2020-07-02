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
        [HttpPost]
        public ActionResult Contact(message Message)
        {
            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("mvclect@gmail.com", "Eman2005$")
            };
            MailMessage m = new MailMessage("mvclect@gmail.com", "Youssefhatem270@gmail.com")
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
