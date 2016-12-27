using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;
using XH.Infrastructure.Extensions;

namespace XH.Presentation.Admin
{
    public class BundleConfig
    {
        private static readonly string AssetsPath = "~/assets";

        /// <summary>
        /// Register bundles
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            List<string> cssPaths = new List<string>()
            {
                "~/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                "~/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css",
                "~/assets/global/css/components.min.css",
                "~/assets/global/css/plugins.min.css",
                "~/assets/layouts/layout/css/layout.min.css",
                "~/assets/layouts/layout/css/themes/darkblue.min.css",
                "~/assets/layouts/layout/css/custom.min.css",
                "~/assets/custom/custom.css"
            };

            var styleBundle = new StyleBundle("~/css/main");
            foreach (string cssPath in cssPaths)
            {
                styleBundle.Include(cssPath, new CssRewriteUrlTransform());
            }

            bundles.Add(styleBundle);

            bundles.Add(new ScriptBundle("~/scripts/core").Include(
                "~/assets/global/plugins/jquery.min.js",
                "~/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                "~/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                "~/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/assets/global/plugins/jquery.blockui.min.js",
                "~/assets/global/plugins/js.cookie.min.js",
                "~/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                "~/assets/global/plugins/angularjs/angular.min.js",
                "~/assets/global/plugins/angularjs/angular-sanitize.min.js",
                "~/assets/global/plugins/angularjs/angular-touch.min.js",
                "~/assets/global/plugins/angularjs/plugins/angular-ui-router.min.js",
                "~/assets/global/plugins/angularjs/plugins/ocLazyLoad.min.js",
                "~/assets/global/plugins/angularjs/plugins/ui-bootstrap-tpls.min.js",
                "~/assets/global/plugins/angularjs/plugins/angular-resource.js",
                "~/assets/global/scripts/app.min.js",
                "~/assets/layouts/layout/scripts/layout.min.js",
                "~/assets/layouts/global/scripts/quick-sidebar.min.js",
                "~/assets/layouts/global/scripts/quick-nav.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/angularjs/app").IncludeDirectory("~/scripts/app", "*.js", true));

            // Disable optimizations
            BundleTable.EnableOptimizations = false;
        }
    }
}
