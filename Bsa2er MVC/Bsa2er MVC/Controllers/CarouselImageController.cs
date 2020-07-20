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
    public class CarouselImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarouselImage
       /* public async Task<ActionResult> Index()
        {
            return View(await db.CarouselImages.ToListAsync());
        }*/

        // GET: CarouselImage/Details/5
       /* public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselImage carouselImage = await db.CarouselImages.FindAsync(id);
            if (carouselImage == null)
            {
                return HttpNotFound();
            }
            return View(carouselImage);
        }*/

        // GET: CarouselImage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarouselImage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CarouselImage carouselImage)
        {
            if (ModelState.IsValid)
            {
                carouselImage.ImagePath = "default.jpg";
                if (carouselImage.ImageFile != null)
                {
                    string[] arr = carouselImage.ImageFile.FileName.Split('.');
                    string imageName = Guid.NewGuid().ToString() + "." + arr[arr.Length - 1];
                    carouselImage.ImageFile.SaveAs(Server.MapPath("~/images/CarouselImages/") + imageName);
                    carouselImage.ImagePath = imageName;
                }
                db.CarouselImages.Add(carouselImage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(carouselImage);
        }

        // GET: CarouselImage/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselImage carouselImage = await db.CarouselImages.FindAsync(id);
            if (carouselImage == null)
            {
                return HttpNotFound();
            }
            return View(carouselImage);
        }

        // POST: CarouselImage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( CarouselImage carouselImage)
        {
            if (ModelState.IsValid)
            {
                if (carouselImage.ImageFile != null)
                {
                    string[] arr = carouselImage.ImageFile.FileName.Split('.');
                    string imageName = Guid.NewGuid().ToString() + "." + arr[arr.Length - 1];

                    if (carouselImage.ImagePath != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/images/CarouselImages/") + carouselImage.ImagePath);
                    }
                    carouselImage.ImageFile.SaveAs(Server.MapPath("~/images/CarouselImages/") + imageName);
                    carouselImage.ImagePath = imageName;
                }
                db.Entry(carouselImage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(carouselImage);
        }

        // GET: CarouselImage/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselImage carouselImage = await db.CarouselImages.FindAsync(id);
            if (carouselImage == null)
            {
                return HttpNotFound();
            }
            return View(carouselImage);
        }

        // POST: CarouselImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CarouselImage carouselImage = await db.CarouselImages.FindAsync(id);
            db.CarouselImages.Remove(carouselImage);
            await db.SaveChangesAsync();
            return RedirectToAction("Index","Home");
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
