using System.Web;
using System.Web.Optimization;

namespace IVoice
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap-toggle/bootstrap-toggle.min.js",
                "~/Scripts/bootstrap-datepicker/bootstrap-datepicker.min.js",
                "~/Scripts/bootstrap-tagsinput/bootstrap-tagsinput.min.js",
                "~/Scripts/bootstrap-select/js/bootstrap-select.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/datatable/datatables.min.js",
                        "~/Scripts/pickr/pickr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/functions").Include(
                "~/Scripts/utils/functions.js",
                "~/Scripts/utils/ajaxEvents.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css",
                "~/Scripts/datatable/datatables.min.css",
                "~/Scripts/bootstrap-toggle/bootstrap-toggle.min.css",
                "~/Scripts/bootstrap-select/css/bootstrap-select.min.css",
                "~/Scripts/bootstrap-datepicker/bootstrap-datepicker.min.css",
                "~/Scripts/bootstrap-tagsinput/bootstrap-tagsinput.css",
                "~/Scripts/pickr/pickr.min.css"));
        }
    }
}
