using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inicio.Controllers
{
    public class PPlanillaController : Controller
    {
        // GET: PPlanilla
        [HttpGet]
        public ActionResult PPCronogindex(string parametro1)
        {
            ViewBag.accion = parametro1;
            return View();
        }





    }

}