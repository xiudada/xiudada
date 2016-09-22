using System.Web;
using System.Web.Optimization;

namespace XH.Presentation.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/scripts/core")
                .IncludeDirectory("~/scripts/extensions", "*.js", true)
                .Include("~/scripts/utility.js"));

            bundles.Add(
                new ScriptBundle("~/scripts/jquery").Include(
                    "~/assets/plugins/jquery.min.js"
                    ));

            bundles.Add(
                new ScriptBundle("~/scripts/angularjs").Include(
                    "~/assets/plugins/angularjs/angular.js",
                    "~/assets/plugins/angularjs/angular-animate.js",
                    "~/assets/plugins/angularjs/angular-cookies.js",
                    "~/assets/plugins/angularjs/angular-loader.js",
                    "~/assets/plugins/angularjs/angular-resource.js",
                    "~/assets/plugins/angularjs/angular-route.js",
                    "~/assets/plugins/angularjs/plugins/angular-ui-router.js")
                    .IncludeDirectory("~/scripts/app", "*.js", true));

            BundleTable.EnableOptimizations = false;
        }
    }
}
