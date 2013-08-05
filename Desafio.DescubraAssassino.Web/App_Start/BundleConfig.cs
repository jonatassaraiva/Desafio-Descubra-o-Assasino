using System.Web;
using System.Web.Optimization;

namespace Desafio.DescubraAssassino.Web
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/Content/bootstrap/js")
				.Include("~/Content/bootstrap/js/bootstrap.js"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new StyleBundle("~/Content/bootstrap/css")
				.Include("~/Content/bootstrap/css/bootstrap.css")
				.Include("~/Content/bootstrap/css/jumbotron.css"));

			bundles.Add(new StyleBundle("~/Content")
				.Include("~/Content/site.css"));
		}
	}
}