using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.PlanillaModels;
using static Inicio.Controllers.GlobalController;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Inicio.Controllers
{
    public class PlanillaController : Controller
    {
        private PMaestraModel Modelo = new PMaestraModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        // PLANILLA MAESTRA
        public ActionResult Index()
        {
            Session["MenuColor"] = "darkred";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_entrada = 5352;
            ViewBag.total_salida = 4325;
            ViewBag.total_inventario = 1535;
            ViewBag.total_notas = 53;

            ViewData["rotacion_mercancia"] = new double[] { 5.6, 5.9, 7.2, 6.8, 5.7, 6.5, 6.1, 6.8, 6.4, 5.5, 6.5, 6.1 };
            ViewData["duracion_inventario"] = new int[] { 6, 6, 5, 6, 6, 5, 6, 7, 6, 7, 5, 6, };
            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
            ViewData["vejez_inventario"] = new int[] { 6, 5, 5, 5, 5, 4, 4, 3, 4, 4, 3, 3 };
            ViewData["valor_economico"] = new int[] { 17, 13, 14, 17, 20, 19, 20, 21, 20, 22, 22, 23 };
            ViewData["exactitud_inventario"] = new int[] { 6, 4, 5, 6, 4, 3, 4, 4, 4, 5, 5, 4 };
            ViewData["unidad_almacenada"] = new int[] { 100, 104, 99, 96, 90, 88, 97, 106, 102, 96, 92, 91 };
            ViewData["unidad_despachada"] = new int[] { 536, 485, 494, 510, 509, 494, 529, 516, 546, 586, 561 };
            ViewData["unidad_por_empleado"] = new int[] { 2453, 2353, 2207, 1863, 2031, 1950, 1735, 1624, 1706, 1956, 2063, 2188 };
            ViewData["costo_metro"] = new int[] { 6000, 6373, 5933, 6133, 5907, 5993, 5833, 5933, 6067, 6167, 6133, 6333 };
            ViewData["costo_despacho"] = new int[] { 600000, 613333, 616667, 590625, 584375, 575000, 564706, 567647, 571765, 581250, 571875, 565625 };
            ViewData["cumplimiento_despacho"] = new int[] { 95, 94, 95, 94, 95, 96, 96, 95, 96, 95, 96, 95 };
            return View();
        }
    }
}