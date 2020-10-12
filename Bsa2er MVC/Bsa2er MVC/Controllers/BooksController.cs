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
    [Authorize]
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index(int ? id)
        {
            if (id == null)
                return View(db.Books.ToList());
            else
            {
                return View(db.Booksections.Include(a => a.Books).FirstOrDefault(a => a.id == id).Books);
                        }
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Book book)
        {
         if(System.IO.Path.HasExtension(book.PdfFile.FileName)== false)
            {
                ModelState.AddModelError("", "قم بادخال الملف بصيغة بي دي اف ");
            }
            if (ModelState.IsValid)
            {
                String[] array = book.ImageFile.FileName.Split('.');
                String filename = Guid.NewGuid() + "." + array[array.Length - 1];
                String[] array1 = book.PdfFile.FileName.Split('.');
                String filename1 = Guid.NewGuid() + "." + array1[array1.Length - 1];

                if (array[array.Length - 1].ToLower() != "jpg"  &&  array[array.Length - 1].ToLower() !="jpeg" )

                {
                    ModelState.AddModelError("", "من فضلك قم بادخال الصورة  بصيغة جي بي جي او جي بي اي جي ");

                    return View();
                }
                else if (array1[array1.Length-1].ToLower()!="pdf" )
                {
                    ModelState.AddModelError("","قم بادخال الملف بصيغة بي دي اف ");
                    return View();

                }

                book.ImageFile.SaveAs(Server.MapPath("~/images/Books/") + filename);
                book.imageFilePath = filename;
             
                book.PdfFile.SaveAs(Server.MapPath("~/texts/") + filename1);
                book.PdfFilepath = filename1;
              Booksection b =db.Booksections.Include(a=>a.Books).FirstOrDefault(a => a.id == id);
                b.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Book book)
        {
            if (ModelState.IsValid)
            {
                String[] array = book.ImageFile.FileName.Split('.');
                String filename = Guid.NewGuid() + "." + array[array.Length - 1];
                book.ImageFile.SaveAs(Server.MapPath("~/images/Books/") + filename);
                book.imageFilePath = filename;
                String[] array1 = book.PdfFile.FileName.Split('.');
                String filename1 = Guid.NewGuid() + "." + array1[array1.Length - 1];
                book.PdfFile.SaveAs(Server.MapPath("~/texts/") + filename1);
                book.PdfFilepath = filename1;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
