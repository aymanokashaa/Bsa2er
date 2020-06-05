﻿using System.Web;
using System.Web.Optimization;

namespace Bsa2er_MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                     "~/Content/headerfooter.css",
                     "~/Content/font-awesome.css",
                     "~/Content/bootstrap-rtl.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/date.js",
                "~/Scripts/date2.js",
                "~/Scripts/scroll.js",
                "~/Scripts/show.js",
                "~/Scripts/slide.js", 
                "~/Scripts/show2.js",
                 "~/Scripts/popper.js",
            "~/Scripts/jquery.nicescroll.min.js"
                ));
        }
    }
}
