using Bsa2er_MVC.Models;
using Microsoft.AspNet.Identity;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bsa2er_MVC.Controllers
{
    [Authorize]
    public class ExamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = "Instructor")]
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

        [Authorize(Roles = "Instructor")]
        public ActionResult Create(int id)
        {
            ViewBag.Program_Id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Instructor")]
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

        [Authorize(Roles = "Instructor")]
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
        [Authorize(Roles = "Instructor")]
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

        [Authorize(Roles = "Student")]
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
        [Authorize(Roles = "Student")]
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

        [Authorize(Roles = "Instructor")]
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

        [Authorize(Roles = "Student")]
        public ActionResult GradeList(string id)
        {
            var std = db.Students.Find(id);
            return View(std);
        }

        [Authorize(Roles = "Student")]
        public ActionResult PrintList(string id)
        {
            var pdf = new ActionAsPdf("GradeList", new { id = id });
            pdf.FileName = "بيان درجات الطالب" + ".pdf";
            pdf.Cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);
            return pdf;
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
