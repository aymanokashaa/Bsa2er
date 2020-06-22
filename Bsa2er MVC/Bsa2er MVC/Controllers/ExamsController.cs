﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bsa2er_MVC.Models;
using Microsoft.Ajax.Utilities;

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
            Exam exam = await db.Exams.FindAsync(id);
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
                    return Content($"{grade} of {exam.grads}");
                }
            }
            string result = $"{grade} of {exam.grads}";
            return Content(result);
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
