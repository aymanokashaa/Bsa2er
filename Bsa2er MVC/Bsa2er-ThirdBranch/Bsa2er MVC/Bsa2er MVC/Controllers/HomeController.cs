using Bsa2er_MVC.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Net.Mail;
using System.Net;

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
            return View();
        }
        public ActionResult News()
        {
            return View(db.News.ToList());
        }

        public ActionResult PublicProgarms()
        {
            return View();
        }
        public ActionResult Program()
        {
            return View();
        }

        public ActionResult Tracks()
        {
            return View();
        }
        public ActionResult Track()
        {
            return View();
        }
        public ActionResult Progs()
        {
            return View();
        }
        public ActionResult Prog()
        {
            return View();
        }

    }
}
