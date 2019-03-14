using System.Web;
using System.Web.Optimization;

namespace EM.Portal
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

            bundles.Add(new ScriptBundle("~/bundles/semantic").Include(
                       "~/Scripts/Semantic-Modules/*.js"
                      , "~/Views/Dashboard/Report.js"
                      //, "~/Scripts/Semantic-Modules/search.js"
                      //, "~/Scripts/Semantic-Modules/label.css"
                      //, "~/Scripts/Semantic-Modules/icon.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                      "~/Views/Dashboard/Report.cshtml.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css"
                      , "~/Content/Semantic-Modules/*.css"
                      , "~/Content/site.css"
                      ,"~/Content/dashboard.css"
                      ));

            //bundles.Add(new StyleBundle("~/Content/semantic").Include(
            //    "~/Content/semantic.css",
            //    "~/Content/dropdown.css"
            //    ));
        }
    }
}
