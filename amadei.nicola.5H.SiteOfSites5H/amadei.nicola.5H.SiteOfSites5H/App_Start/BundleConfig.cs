using System.Web;
using System.Web.Optimization;

namespace amadei.nicola._5H.SiteOfSites5H
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css",
                    "~/Content/bootstrap.min.css",
                    "~/Content/font-awesome.min.css",
                    "~/Content/font-awesome.css",
                    "~/Content/animate.css",
                    "~/Content/owl.carousel.css",
                    "~/Content/owl.theme.css",
                    "~/Content/prettyPhoto.css",
                    "~/Content/flexslider.css",
                    "~/Content/red.css",
                    "~/Content/custom.css",
                    "~/Content/responsive.css",
                    "~/Content/jquery.fancybox.css?v=2.1.5"));            
        }
    }
}
