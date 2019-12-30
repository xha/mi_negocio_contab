using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using static Inicio.Controllers.GlobalController;

namespace Inicio.Controllers
{
    public class OrdenTrabajoController : Controller
    {
        private OrdenTrabajoModel Modelo = new OrdenTrabajoModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        // GET: OrdenTrabajo
        [NoDirectAccess]
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrdenTrabajo
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View(Modelo);
        }

        // GET: OrdenTrabajo
        [NoDirectAccess]
        public ActionResult Edit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // GET: OrdenTrabajo
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridOrdenTrabajos()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<OrdenTrabajoModel> Listado = new List<OrdenTrabajoModel>()
            {
                new OrdenTrabajoModel { NroOrden = "01", Producto = "Producto 1", Cantidad = 5, DescripcionCliente = "Juan Perez".ToUpper(), FechaInicio = "21-01-2019", FechaFin = "21-02-2019" },
                new OrdenTrabajoModel { NroOrden = "02", Producto = "Producto 2", Cantidad = 10, DescripcionCliente = "Jose Gonzalez".ToUpper(), FechaInicio = "29-01-2019", FechaFin = "05-02-2019" },
                new OrdenTrabajoModel { NroOrden = "03", Producto = "Producto 3", Cantidad = 15, DescripcionCliente = "Carlos Leon".ToUpper(), FechaInicio = "07-02-2019", FechaFin = "25-02-2019" },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionCliente.Contains(searchValue)
                             select new { N.NroOrden, N.Producto, N.DescripcionCliente, N.Cantidad, N.FechaInicio, N.FechaFin });
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
