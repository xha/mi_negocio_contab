using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using static Inicio.Controllers.GlobalController;

namespace Inicio.Controllers
{
    public class TipoCambioController : Controller
    {
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        // GET: TipoCambio
        [NoDirectAccess]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GridTipoCambios()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<TipoCambioModel> Listado = new List<TipoCambioModel>()
            {
                new TipoCambioModel { Fecha = "03-02-2019", Compra = 3400.00, Venta = 3600.00 },
                new TipoCambioModel { Fecha = "04-02-2019", Compra = 3400.00, Venta = 3600.00 },
                new TipoCambioModel { Fecha = "05-02-2019", Compra = 3400.00, Venta = 3600.00 },
            };

            var Resultado = (from N in Listado
                             where N.Fecha.Contains(searchValue)
                             select new { N.Fecha, N.Compra, N.Venta});
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
