﻿using System.Web;
using System.Web.Optimization;

namespace Inicio
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/popper.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/bower_components/bootstrap4/css/bootstrap.css",
                      "~/bower_components/bootstrap/dist/css/bootstrap-datetimepicker.css",
                      "~/Content/Site.css"));
        }
    }
}
