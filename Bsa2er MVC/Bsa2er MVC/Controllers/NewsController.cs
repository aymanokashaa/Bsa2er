using Bsa2er_MVC.Models;
using Bsa2er_MVC.Repositories;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Bsa2er_MVC.Controllers
{
    
    public class NewsController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        private IRepository<news> _newsRepository;
        public NewsController(IRepository<news> newsRepository)
        {
            _newsRepository = newsRepository;
        }

        // GET: news
       /* public ActionResult Index()
        {
            return View(db.News.ToList());
        }*/

        // GET: news/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = _newsRepository.FindById(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: news/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: news/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "title,body")] news news, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    string[] arr = imageFile.FileName.Split('.');
                    string filename = Guid.NewGuid().ToString() + "." + arr[arr.Length - 1];
                    imageFile.SaveAs(Server.MapPath("~/images/News/") + filename);
                    news.ImagePath = filename;
                }

                _newsRepository.AddItem(news);
                return RedirectToAction("Index","Home");
            }

            return View(news);
        }

        // GET: news/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = _newsRepository.FindById(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: news/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,body,ImagePath")] news news, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                if (imgFile != null)
                {
                    string[] arr = imgFile.FileName.Split('.');
                    string imageName = Guid.NewGuid().ToString() + "." + arr[arr.Length - 1];

                    if (news.ImagePath != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/images/News/") + news.ImagePath);
                    }
                    imgFile.SaveAs(Server.MapPath("~/images/News/") + imageName);
                    news.ImagePath = imageName;
                }
                _newsRepository.EditItem(news);
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: news/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = _newsRepository.FindById(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: news/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            news news = _newsRepository.FindById(id);
            _newsRepository.Remove(news);
            return RedirectToAction("Index");
        }

        public ActionResult NewsDetails(int id)
        {
            news news = _newsRepository.FindById(id);
            return PartialView(news);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _newsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
