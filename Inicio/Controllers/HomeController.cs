using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inicio.Controllers
{
    public class HomeController : Controller
    {
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }

        [HttpGet]
        public ActionResult AyudaPrincipal()
        {
            return PartialView("AyudaPrincipal");
        }
        /**************************************************************************************************************/
        public ActionResult Index()
        {
            Session["MenuId"] = 0;
            Session["MenuColor"] = "#0058dd"; //#4e73df
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}