using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bsa2er_MVC.Models;

namespace Bsa2er_MVC.Controllers
{
    public class GalleryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gallery
       /* public async Task<ActionResult> Index()
        {
            return View(await db.Galleries.ToListAsync());
        }*/

        // GET: Gallery/Details/5
        /*public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = await db.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }*/

        // GET: Gallery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Gallery_path")] Gallery gallery,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                gallery.Gallery_path = Server.MapPath("~/images/Gallery/default.jpg");
                if (img != null)
                {
                    string[] arr = img.FileName.Split('.');
                    string imageName = Guid.NewGuid().ToString() + "." + arr[arr.Length - 1];
                    img.SaveAs(Server.MapPath("~/images/Gallery/") + imageName);
                    gallery.Gallery_path = imageName;
                }
                
                db.Galleries.Add(gallery);
                await db.SaveChangesAsync();
                return RedirectToAction("DashBoardPage","DashBoard");
            }

            return View(gallery);
        }

        // GET: Gallery/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = await db.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Gallery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "G_Id,Gallery_path")] Gallery gallery,HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    string[] arr = img.FileName.Split('.');
                    string imageName = Guid.NewGuid().ToString() + "." + arr[arr.Length - 1];

                    if (gallery.Gallery_path != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/images/News/") + gallery.Gallery_path);
                    }
                    img.SaveAs(Server.MapPath("~/images/News/") + imageName);
                    gallery.Gallery_path = imageName;
                }
                db.Entry(gallery).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("DashBoardPage", "DashBoard");
            }
            return View(gallery);
        }

        // GET: Gallery/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = await db.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Gallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Gallery gallery = await db.Galleries.FindAsync(id);
            db.Galleries.Remove(gallery);
            await db.SaveChangesAsync();
            return RedirectToAction("DashBoardPage", "DashBoard");
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
