using Bsa2er_MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bsa2er_MVC.Controllers
{
    public class ExamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        public ActionResult Create(int id)
        {
            ViewBag.Program_Id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Exam exam)
        {
            if (ModelState.IsValid)
            {
                int grade = 0;
                foreach (var item in exam.Questions)
                {
                    grade += item.Q_Marks;
                }
                exam.grads = grade;
                exam.NumberOfQuestions = exam.Questions.Count();
                db.Exams.Add(exam);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(exam);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Exam exam)
        {
            if (ModelState.IsValid)
            {
                int grade = 0;
                foreach (var item in exam.Questions)
                {
                    grade += item.Q_Marks;
                }
                exam.grads = grade;
                exam.NumberOfQuestions = exam.Questions.Count();

                Exam oldE = await db.Exams.FindAsync(exam.Exam_Id);
                oldE.grads = exam.grads;
                oldE.Title = exam.Title;
                oldE.NumberOfQuestions = exam.NumberOfQuestions;
                db.Questions.RemoveRange(oldE.Questions);
                db.Questions.AddRange(exam.Questions);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(exam);
        }

        public async Task<ActionResult> TakeExam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TakeExam(int id, Dictionary<string, string> answers)
        {
            int grade = 0;
            foreach (var item in answers)
            {
                try
                {
                    Question q = await db.Questions.FindAsync(int.Parse(item.Key));
                    if (q.Q_Answer == item.Value) grade += q.Q_Marks;
                }
                catch
                {
                    return RedirectToAction("StudentDashboard", "Account", null);
                }
            }
            var stdId = User.Identity.GetUserId();
            var exam = await db.Exams.FindAsync(id);
            var stdprog = db.StudentsPrograms.FirstOrDefault(sp => sp.Program_Id == exam.Program_Id && sp.Std_Id == stdId);
            stdprog.ProgramGrade = grade;
            stdprog.EndDateTime = DateTime.Now;
            await db.SaveChangesAsync();
            return RedirectToAction("StudentDashboard", "Account", null);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            db.Exams.Remove(exam);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
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
