using System.Web;
using System.Web.Optimization;

namespace Bsa2er_MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap-rtl.min.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/font-awesome.css",
                     "~/Content/headerfooter.css",
                     "~/Content/Gallery.css",
                     "~/Content/News.css",
                      "~/Content/Library.css"
));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/slide.js",
                "~/Scripts/date2.js",
                "~/Scripts/date.js",
                "~/Scripts/JQuery-3.5.1.min.js",
                "~/Scripts/popper.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.nicescroll.min.js",
                "~/Scripts/scroll.js",
                "~/Scripts/show2.js"
                ));
        }
    }
}
