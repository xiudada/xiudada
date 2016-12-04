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
                "{0}/global/plugins/font-awesome/css/font-awesome.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/simple-line-icons/simple-line-icons.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/icheck-1.x/skins/square/blue.css".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap/css/bootstrap.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-tagsinput/bootstrap-tagsinput.css".FormatWith(AssetsPath),
                "{0}/global/plugins/uniform/css/uniform.default.css".FormatWith(AssetsPath),
                "{0}/pages/css/login-3.css".FormatWith(AssetsPath),
                "{0}/pages/css/error.min.css".FormatWith(AssetsPath),
                "{0}/pages/css/search.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-toastr/toastr.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/jstree/themes/default/style.min.css".FormatWith(AssetsPath),
                "{0}/global/css/components.min.css".FormatWith(AssetsPath),
                "{0}/global/css/realNextGlobal.css".FormatWith(AssetsPath),
                "{0}/global/css/plugins.min.css".FormatWith(AssetsPath),
                "{0}/layouts/layout/css/layout.min.css".FormatWith(AssetsPath),
                "{0}/layouts/layout/css/themes/light2.min.css".FormatWith(AssetsPath),
                "{0}/layouts/layout/css/custom.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-datepicker/angular-datepicker.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/ui-select/select.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-multi-select-tree/angular-multi-select-tree-0.1.0.css".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/ngSweetAlert/sweetalert.css".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/textAngular-1.4.6/textAngular.min.css".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-blockui-ui/angular-block-ui.min.css".FormatWith(AssetsPath),
                "{0}/global/css/animate.css".FormatWith(AssetsPath),
                "{0}/pages/css/profile.css".FormatWith(AssetsPath)
            };

            var styleBundle = new StyleBundle("~/css/main");
            foreach (string cssPath in cssPaths)
            {
                styleBundle.Include(cssPath, new CssRewriteUrlTransform());
            }

            bundles.Add(styleBundle);

            bundles.Add(new ScriptBundle("~/scripts/core").Include(
                "{0}/global/plugins/jquery.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/icheck-1.x/icheck.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/underscore/underscore-min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/FileSaver/FileSaver.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap/js/bootstrap.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/jquery.blockui.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/jquery-json/jquery.json.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/jquery.cokie.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/uniform/jquery.uniform.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-moment/moment-with-locales.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-tagsinput/bootstrap-tagsinput.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-maxlength/bootstrap-maxlength.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/input-mask/jquery.inputmask.bundle.js".FormatWith(AssetsPath),
                "{0}/global/plugins/highcharts/highcharts.js".FormatWith(AssetsPath)));

            // Special plugins,we can't use bundle optimize for these plugins(may cause some errors when reference to other resources)
            bundles.Add(new ScriptBundle("~/scripts/jquery/plugins/special").Include(
               "{0}/global/plugins/bootstrap-toastr/toastr.min.js".FormatWith(AssetsPath),
               "{0}/global/plugins/angularjs/plugins/ui-tinymce/tinymce/tinymce.min.js".FormatWith(AssetsPath),
               "{0}/global/plugins/jstree/jstree.min.js".FormatWith(AssetsPath)));

            bundles.Add(new ScriptBundle("~/scripts/angularjs/core").Include(
                "{0}/global/plugins/angularjs/angular.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/angular-cookies.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/angular-sanitize.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/angular-touch.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-uuid2.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-translate.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-translate-loader-static-files.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-ui-router.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/ocLazyLoad.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-tagsinput/bootstrap-tagsinput.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/ngMask/ngMask.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/ui-select/select.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/ui-bootstrap-tpls-1.3.1.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-resource.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-bootstrap-switch/angular-bootstrap-switch.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootbox/bootbox.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/ngSweetAlert/sweetalert.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/ngSweetAlert/ngSweetAlert.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-multi-select-tree/angular-multi-select-tree-0.1.0.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-multi-select-tree/angular-multi-select-tree-0.1.0.tpl.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-tagsinput/bootstrap-tagsinput-angular.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-file-upload/angular-file-upload.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-moment/moment.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-moment/angular-moment.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-moment/angular-moment.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-moment/moment-with-locales.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/bootstrap-datepicker/angularjs/angular-bootstrap-datetimepicker-directive.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/ui-tinymce/tinymce.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/ngJsTree/ngJsTree.min.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/angular-blockui-ui/angular-block-ui.min.js".FormatWith(AssetsPath)));


            bundles.Add(new ScriptBundle("~/scripts/angularjs/realNextSharedDirective").Include(
                "{0}/global/plugins/angularjs/plugins/realnext-shared-directive/realNext.sharedDirectiveModule.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/realnext-shared-directive/realNextValidation.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/realnext-shared-directive/tm.pagination.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/realnext-shared-directive/i-check.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/realnext-shared-directive/urlService.js".FormatWith(AssetsPath),
                "{0}/global/plugins/angularjs/plugins/realnext-shared-directive/rn-datepicker.js".FormatWith(AssetsPath)
            ));

            bundles.Add(new ScriptBundle("~/scripts/angularjs/app").Include(
                "{0}/global/scripts/app.min.js".FormatWith(AssetsPath),
                "{0}/layouts/layout/scripts/layout.js".FormatWith(AssetsPath),
                "{0}/layouts/global/scripts/quick-sidebar.min.js".FormatWith(AssetsPath))
                .IncludeDirectory("~/scripts/app", "*.js", true));

            // Disable optimizations
            BundleTable.EnableOptimizations = false;
        }
    }
}
