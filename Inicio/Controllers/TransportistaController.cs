using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using static Inicio.Controllers.GlobalController;

namespace Inicio.Controllers
{
    public class TransportistaController : Controller
    {
        private TransportistaModel Modelo = new TransportistaModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        // GET: Transportista/Transportistas
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult Transportistas(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Transportistas");
        }

        // GET: Transportista/Empresas
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult Empresas(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Empresas");
        }
        /**************************************************************************************************************/
        // GET: Transportista
        [NoDirectAccess]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transportista
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View(Modelo);
        }

        // GET: Transportista
        [NoDirectAccess]
        public ActionResult Edit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // GET: Transportista
        [NoDirectAccess]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridTransportistas()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<TransportistaModel> Listado = new List<TransportistaModel>()
            {
                new TransportistaModel { Codigo = "01", Ruc = "12345678", Descripcion = "Juan Perez".ToUpper(), NroInscripcion = "B32142342", ModeloVehiculo = "Corsa", Placa = "AAX-112" },
                new TransportistaModel { Codigo = "02", Ruc = "87654321", Descripcion = "Jose Gonzalez".ToUpper(), NroInscripcion = "A23123123", ModeloVehiculo = "Lanos", Placa = "BBX-223" },
                new TransportistaModel { Codigo = "03", Ruc = "56514156", Descripcion = "Carlos Leon".ToUpper(), NroInscripcion = "C23413123", ModeloVehiculo = "Fusion", Placa = "CXC-324" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.NroInscripcion, N.Descripcion, N.Ruc,N.ModeloVehiculo, N.Placa });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GridEmpresas()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<TransportistaModel> Listado = new List<TransportistaModel>()
            {
                new TransportistaModel { CodigoEmpresa = "01", RucEmpresa = "12345678", RazonEmpresa = "Empresa A".ToUpper(), DireccionEmpresa = "Dirección A", TelefonoEmpresa = "111-2222" },
                new TransportistaModel { CodigoEmpresa = "02", RucEmpresa = "97545645", RazonEmpresa = "Empresa B".ToUpper(), DireccionEmpresa = "Dirección B", TelefonoEmpresa = "222-3222" },
                new TransportistaModel { CodigoEmpresa = "03", RucEmpresa = "45645642", RazonEmpresa = "Empresa C".ToUpper(), DireccionEmpresa = "Dirección C", TelefonoEmpresa = "333-4222" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.CodigoEmpresa, N.RazonEmpresa, N.RucEmpresa, N.DireccionEmpresa, N.TelefonoEmpresa });
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
