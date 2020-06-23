using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bsa2er_MVC.Models;

namespace Bsa2er_MVC.Controllers
{
    public class BooksectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Booksections
        public ActionResult Index()
        {
            return View(db.Booksections.ToList());
        }

        // GET: Booksections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booksection booksection = db.Booksections.Find(id);
            if (booksection == null)
            {
                return HttpNotFound();
            }
            return View(booksection);
        }

        // GET: Booksections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booksections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Booksection booksection)
        {
            if (ModelState.IsValid)
            {

      
                String[] array = booksection.Image.FileName.Split('.');
                String filename = Guid.NewGuid() + "." + array[array.Length - 1];
                booksection.Image.SaveAs(Server.MapPath("~/images/") + filename);
                booksection.imagepath = filename;
                db.Booksections.Add(booksection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booksection);
        }

        // GET: Booksections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booksection booksection = db.Booksections.Find(id);
            if (booksection == null)
            {
                return HttpNotFound();
            }
            return View(booksection);
        }

        // POST: Booksections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Booksection booksection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booksection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booksection);
        }

        // GET: Booksections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booksection booksection = db.Booksections.Find(id);
            if (booksection == null)
            {
                return HttpNotFound();
            }
            return View(booksection);
        }

        // POST: Booksections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booksection booksection = db.Booksections.Include(a=>a.Books).FirstOrDefault(a=>a.id==id);
            db.Booksections.Remove(booksection);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
