using System.Web;
using System.Web.Optimization;

namespace CourseWork.ServiceCenter
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));


            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/typeahead.bundle.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTable").Include(
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap4.js"));


            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/layout.css",
                      "~/Content/DataTables/dataTables.bootstrap4.css",
                      "~/Content/typeahead.css",
                      "~/Content/main.css"
                      ));
        }
    }
}
