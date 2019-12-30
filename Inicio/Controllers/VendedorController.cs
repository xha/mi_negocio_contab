using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using static Inicio.Controllers.GlobalController;

namespace Inicio.Controllers
{
    public class VendedorController : Controller
    {
        private VendedorModel Modelo = new VendedorModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        /**************************************************************************************************************/
        //Listado de Vendedores
        [HttpGet]
        public ActionResult Vendedores(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Vendedores");
        }
        /**************************************************************************************************************/
        // GET: Vendedor
        [NoDirectAccess]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Vendedor
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View(Modelo);
        }

        // GET: Vendedor
        [NoDirectAccess]
        public ActionResult Edit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // GET: Vendedor
        [NoDirectAccess]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridVendedores()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<VendedorModel> Listado = new List<VendedorModel>()
            {
                new VendedorModel { Codigo = "01", Ruc = "12345678", Descripcion = "Juan Perez".ToUpper() },
                new VendedorModel { Codigo = "02", Ruc = "87654321", Descripcion = "Jose Gonzalez".ToUpper() },
                new VendedorModel { Codigo = "03", Ruc = "56514156", Descripcion = "Carlos Leon".ToUpper() },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.Ruc });
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
