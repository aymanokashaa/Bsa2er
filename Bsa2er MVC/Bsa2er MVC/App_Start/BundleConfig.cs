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
                     "~/Content/carouselStyle.css",
                     "~/Content/News.css",
                      "~/Content/Library.css",
                      "~/Content/Program.css",
                      "~/Content/Track.css",
                      "~/Content/LoadingGIF.css"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/slide.js",
                "~/Scripts/date2.js",
                "~/Scripts/date.js",
                "~/Scripts/JQuery-3.5.1.min.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/show.js",
                "~/Scripts/show2.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
<<<<<<< HEAD
                "~/Scripts/show.js"
=======
                "~/Scripts/LoadingGIF.js"

>>>>>>> e0abc7c2adf31cd335a69456af0cfb6d4c5da870
                ));
        }
    }
}
