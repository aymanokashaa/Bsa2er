﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bsa2er_MVC.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Library()
        {
            return View();
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
