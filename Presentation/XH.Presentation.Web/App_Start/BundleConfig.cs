using System.Web;
using System.Web.Optimization;

namespace XH.Presentation.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/style/core")
                .Include("~/assets/plugins/bootstrap/css/bootstrap.min.css")
                .IncludeDirectory("~/assets/css", "*.css", true));

            bundles.Add(
                new ScriptBundle("~/scripts/core")
                .IncludeDirectory("~/scripts/extensions", "*.js", true)
                .Include("~/scripts/utility.js")
                .Include("~/assets/plugins/linq.min.js"));

            bundles.Add(
                new ScriptBundle("~/scripts/jquery").Include(
                    "~/assets/plugins/jquery.min.js",
                    "~/assets/plugins/bootstrap/js/bootstrap.min.js"
                    ));

            bundles.Add(
                new ScriptBundle("~/scripts/angularjs").Include(
                    "~/assets/plugins/angularjs/angular.js",
                    "~/assets/plugins/angularjs/angular-animate.js",
                    "~/assets/plugins/angularjs/angular-cookies.js",
                    "~/assets/plugins/angularjs/angular-loader.js",
                    "~/assets/plugins/angularjs/angular-resource.js",
                    "~/assets/plugins/angularjs/angular-route.js",
                    "~/assets/plugins/angularjs/plugins/angular-ui-router.js",
                    "~/assets/plugins/angularjs/plugins/ui-bootstrap-tpls-0.14.3.js")
                    .IncludeDirectory("~/scripts/app", "*.js", true));

            BundleTable.EnableOptimizations = false;
        }
    }
}
