using System.Web.Optimization;

namespace HomeCinema.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/Vendors/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/Vendors/jquery.js",
                "~/Scripts/Vendors/bootstrap.js",
                "~/Scripts/Vendors/toastr.js",
                "~/Scripts/Vendors/jquery.raty.js",
                "~/Scripts/plugins/fileinput/sortable.min.js",
                "~/Scripts/plugins/fileinput/purify.min.js",
                "~/Scripts/plugins/fileinput/fileinput.js",
                "~/Scripts/Vendors/respond.src.js",
                "~/Scripts/Vendors/angular.js",
                "~/Scripts/Vendors/angular-route.js",
                "~/Scripts/Vendors/angular-cookies.js",
                "~/Scripts/Vendors/angular-validator.js",
                "~/Scripts/Vendors/angular-base64.js",
                "~/Scripts/Vendors/angular-file-upload.js",
                "~/Scripts/Vendors/angucomplete-alt.min.js",
                "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js",
                "~/Scripts/Vendors/underscore.js",
                "~/Scripts/Vendors/raphael.js",
                "~/Scripts/Vendors/morris.js",
                "~/Scripts/Vendors/jquery.fancybox.js",
                "~/Scripts/Vendors/jquery.fancybox-media.js",
                "~/Scripts/Vendors/loading-bar.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/modules/common.ui.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/services/apiService.js",
                "~/Scripts/spa/services/notificationService.js",
                "~/Scripts/spa/services/membershipService.js",
                "~/Scripts/spa/services/fileUploadService.js",
                "~/Scripts/spa/layout/topBar.directive.js",
                "~/Scripts/spa/layout/sideBar.directive.js",
                "~/Scripts/spa/layout/customPager.directive.js",
                "~/Scripts/spa/directives/rating.directive.js",
                "~/Scripts/spa/directives/availableMovie.directive.js",
                "~/Scripts/spa/account/loginCtrl.js",
                "~/Scripts/spa/account/registerCtrl.js"
                ));
            //const string ANGULAR_APP_ROOT = "~/Scripts/spa/";
            //const string VIRTUAL_BUNDLE_PATH = ANGULAR_APP_ROOT + "main.js";

            //var scriptBundle = new ScriptBundle(VIRTUAL_BUNDLE_PATH)
            //    .IncludeDirectory(ANGULAR_APP_ROOT, "*.js", searchSubdirectories: true);

          
            bundles.Add(new ScriptBundle("~/Scripts/spa/home/home.js")
               .IncludeDirectory("~/Scripts/spa/home/", "*.js", searchSubdirectories: true));
            bundles.Add(new ScriptBundle("~/Scripts/spa/movies/movies.js")
              .IncludeDirectory("~/Scripts/spa/movies/", "*.js", searchSubdirectories: true));

            bundles.Add(new ScriptBundle("~/Scripts/spa/customers/customers.js")
              .IncludeDirectory("~/Scripts/spa/customers/", "*.js", searchSubdirectories: true));

            bundles.Add(new ScriptBundle("~/Scripts/spa/rental/rental.js")
              .IncludeDirectory("~/Scripts/spa/rental/", "*.js", searchSubdirectories: true));

            bundles.Add(new ScriptBundle("~/Scripts/spa/profileUser/profileUser.js")
             .IncludeDirectory("~/Scripts/spa/profileUser/", "*.js", searchSubdirectories: true));

            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/content/css/site.css",
                "~/content/css/bootstrap.css",
                "~/content/css/bootstrap-theme.css",
                 "~/content/css/font-awesome.css",
                "~/content/css/morris.css",
                "~/content/css/toastr.css",
                "~/content/css/jquery.fancybox.css",
                "~/content/css/loading-bar.css"
  
                ));
            BundleTable.EnableOptimizations = false;
        }
    }
}