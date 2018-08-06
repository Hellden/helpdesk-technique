using System.Web.Optimization;

namespace TT_MVC
{
	public class BundleConfig
	{
		// Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/js").Include(
						"~/Scripts/jquery-3.3.1.min.js",
						"~/Scripts/bootstrap.min.js",
						"~/Scripts/ckeditor/ckeditor.js",
						"~/Scripts/jquery.unobtrusive-ajax.min.js",
						"~/Scripts/gridmvc.lang.fr.js",
						"~/Scripts/gridmvc.min.js"
						));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/bootstrap-datetimepicker.min.css",
					  "~/Content/site.css",
					  "~/Content/print.css"
					  ));

			BundleTable.EnableOptimizations = false;
		}
	}
}
