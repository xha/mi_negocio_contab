using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.ContabilidadModels;
using static Inicio.Controllers.GlobalController;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Inicio.Controllers
{
    public class ContabilidadController : Controller
    {
        private ContabilidadModel Modelo = new ContabilidadModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        // CONTABILIDAD
        public ActionResult Index()
        {
            Session["MenuColor"] = "darkblue";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_ingreso = "1.000.000,00";
            ViewBag.total_egreso = "350.000,00";
            ViewBag.total = "650.000,00";

            ViewData["ingreso_1"] = new double[] { 2000.00, 5000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 11000.00, 14000.00, 15000.00, 14000.00, 15000.00 };
            ViewData["ingreso_2"] = new double[] { 3000.00, 4000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 15000.00, 14000.00, 25000.00, 10000.00, 21000.00 };
            ViewData["ingreso_3"] = new double[] { 4000.00, 3000.00, 8000.00, 15000.00, 14000.00, 5000.00, 17000.00, 8000.00, 14000.00, 35000.00, 34000.00, 1000.00 };
            ViewData["egreso_1"] = new double[] { 5000.00, 2000.00, 7500.00, 12000.00, 12000.00, 35000.00, 27000.00, 1000.00, 14000.00, 5000.00, 24000.00, 15900.00 };
            ViewData["egreso_2"] = new double[] { 6000.00, 1000.00, 7900.00, 12000.00, 12000.00, 25000.00, 5000.00, 12000.00, 14000.00, 5500.00, 4000.00, 18000.00 };
            ViewData["egreso_3"] = new double[] { 2000.00, 5000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 11000.00, 14000.00, 15000.00, 14000.00, 15000.00 };
            ViewData["egreso_4"] = new double[] { 3000.00, 4000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 15000.00, 14000.00, 25000.00, 10000.00, 21000.00 };
            ViewData["ingresos"] = new double[] { 14000.00, 23000.00, 38000.00, 415000.00, 514000.00, 65000.00, 517000.00, 68000.00, 714000.00, 535000.00, 634000.00, 71000.00 };
            ViewData["egresos"] = new double[] { 32000.00, 45000.00, 47000.00, 311000.00, 214000.00, 215000.00, 37000.00, 411000.00, 514000.00, 615000.00, 714000.00, 81500.00 };

            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };

            return View();
        }

        [HttpPost]
        public JsonResult GridPlanCuentas()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            List<ContabilidadModel> Listado = new List<ContabilidadModel>()
            {
                new ContabilidadModel { CODIGO = "001", NIVEL = 2, DESCRIPCION = "Registro X".ToUpper(), CENTRO_COSTO = "NO", CLASE = "ORD", ESTANDAR = "" },
                new ContabilidadModel { CODIGO = "011", NIVEL = 3, DESCRIPCION = "REGISTro xx".ToUpper(), CENTRO_COSTO = "NO", CLASE = "ORD", ESTANDAR = "" },
                new ContabilidadModel { CODIGO = "0111", NIVEL = 1, DESCRIPCION = "Registro xxx".ToUpper(), CENTRO_COSTO = "NO", CLASE = "ORD", ESTANDAR = "" },
                new ContabilidadModel { CODIGO = "012", NIVEL = 0, DESCRIPCION = "Registro xy".ToUpper(), CENTRO_COSTO = "NO", CLASE = "ORD", ESTANDAR = "" },
            };

            var Resultado = (from N in Listado
                             where N.DESCRIPCION.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();
        

            var jsonData = new
            {
              draw = draw,
              data = Resultado,
              recordsTotal = totalRecords,
              recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        } 
        /**************************************************************************************************************/
        //BASE DE DATOS
        /**************************************************************************************************************/
        //Plan de Cuentas / Plan de Cuentas Nacional, Se Abrevia <CPCN>
        public ActionResult CPCNIndex()
        {
            return View();
        }

        public ActionResult CPCNCreate()
        {
           return View();
        }

        public ActionResult CPCNEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        //Plan de Cuentas / Plan de Cuentas Extranjero, Se Abrevia <CPCE>
        public ActionResult CPCEIndex()
        {
          return View();
        }

        public ActionResult CPCECreate()
        {
          return View();
        }

        public ActionResult CPCEEdit(string Codigo)
        {
          Modelo.CODIGO = Codigo;
          return View(Modelo);
        }

        //Plan de Cuentas / Configuración Rápida    de Estados Financieros, Se Abrevia <CCREF>
        public ActionResult CCREFIndex()
        {
          return View();
        }

        //Costo y Rentabilidad / Centros de Costos y     Transferencias, Se Abrevia <CCCT>
        public ActionResult CCCTIndex()
        {
          return View();
        }

        public ActionResult CCCTCreate()
        {
          return View();
        }

        public ActionResult CCCTEdit(string Codigo)
        {
          Modelo.CODIGO = Codigo;
          return View(Modelo);
        }

        //Tabla de Transferencia de Costo
        [HttpGet]
        public ActionResult TablaTransferenciaCosto(string parametro1)
        {
          ViewBag.accion = parametro1;
          return PartialView("_TablaTransferenciaCosto");
        }

        //Costo y Rentabilidad / Conceptos de Ingresos   y Gastos, Se Abrevia <CCIG>
        public ActionResult CCIGIndex()
        {
          return View();
        }

        public ActionResult CCIGCreate()
        {
          return View();
        }

        public ActionResult CCIGEdit(string Codigo)
        {
          Modelo.CODIGO = Codigo;
          return View(Modelo);
        }

        //Costo y Rentabilidad / Presupuestos por Centro de Costo, Se Abrevia <CPCC>
        public ActionResult CPCCIndex()
        {
          return View();
        }

        public ActionResult CPCCCreate()
        {
          return View();
        }

        public ActionResult CPCCEdit(string Codigo)
        {
          Modelo.CODIGO = Codigo;
          return View(Modelo);
        }

        //Partidas Presupuesto, Se Abrevia <CPP>
        public ActionResult CPPIndex()
        {
          return View();
        }

        public ActionResult CPPCreate()
        {
          return View();
        }

        public ActionResult CPPEdit(string Codigo)
        {
          Modelo.CODIGO = Codigo;
          return View(Modelo);
        }

    }
}
