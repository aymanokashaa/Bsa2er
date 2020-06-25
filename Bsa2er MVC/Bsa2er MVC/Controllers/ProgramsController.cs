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
    public class ProgramsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Programs
        public async Task<ActionResult> Index()
        {
            var programs = db.Programs.Include(p => p.Instructor);
            return View(await programs.ToListAsync());
        }
        // GET: Programs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Programs.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // GET: Programs/Create
        public ActionResult Create()
        {
            ViewBag.Ins_Id = new SelectList(db.Instructors, "InsId", "Degree");
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Program_Title,lectures,Program_MainImage,Program_Duration,Program_Body,Program_Advantages,Program_Goals,Program_ImagePath,Program_VideoLink,Program_TargetGroup,Program_Type,NumOfLecture")] Program program,HttpPostedFileBase imageFile, HttpPostedFileBase mainimageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    string[] arr = imageFile.FileName.Split('.');
                    string filename = Guid.NewGuid().ToString() + "." + arr[arr.Length - 1];
                    imageFile.SaveAs(Server.MapPath("~/images/Programs/") + filename);
                    program.Program_ImagePath = filename;
                    string[] arr2 = mainimageFile.FileName.Split('.');
                    string filename2 = Guid.NewGuid().ToString() + "." + arr2[arr2.Length - 1];
                    imageFile.SaveAs(Server.MapPath("~/images/Programs/") + filename2);
                    program.Program_MainImage = filename2;
                }

                db.Programs.Add(program);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Ins_Id = new SelectList(db.Instructors, "InsId", "Degree", program.Ins_Id);
            return View(program);
        }

        // GET: Programs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Programs.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ins_Id = new SelectList(db.Instructors, "InsId", "Degree", program.Ins_Id);
            return View(program);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Program_Id,Program_Title,Program_MainImage,Program_Body,Program_Duration,Program_Advantages,Program_Goals,Program_ImagePath,Program_VideoLink,Program_TargetGroup,Program_Type,NumOfLecture,Ins_Id")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Ins_Id = new SelectList(db.Instructors, "InsId", "Degree", program.Ins_Id);
            return View(program);
        }

        // GET: Programs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Programs.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Program program = await db.Programs.FindAsync(id);
            db.Programs.Remove(program);
            await db.SaveChangesAsync();
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
