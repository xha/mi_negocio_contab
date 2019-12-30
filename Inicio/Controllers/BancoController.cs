using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Inicio.Controllers
{
    public class BancoController : Controller
    {
        private BancoModel Modelo = new BancoModel();
        private ConexionModel cn = new ConexionModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        
        /**************************************************************************************************************/
        // GET: Banco
        public ActionResult Index()
        {
            Session["MenuColor"] = "indigo";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_compensado = "1.800,00";
            ViewBag.total_vencido = "3.600,00";
            ViewBag.total = "5.400,00";

            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
            ViewData["compensado"] = new int[] { 300, 0, 0, 800, 500, 0, 200, 0, 0, 0, 0, 0 };
            ViewData["vencido"] = new int[] { 300, 200, 600, 0, 0, 300, 200, 100, 300, 500, 700, 400 };
            ViewData["bancos"] = new string[] { "Banco A", "Banco B", "Banco C", "Banco D", "Banco E", "Banco F", "Banco G", "Banco H", "Banco I", "Banco J", "Banco K", "Banco L" };
            ViewData["recaudado"] = new int[] { 5030, 1569, 1957, 3779, 3224, 2838, 0058, 1219, 555, 1000, 3389, 1209 };
            ViewData["pendiente"] = new int[] { 230, 169, 957, 379, 324, 283, 258, 219, 555, 100, 389, 109 };

            return View();
        }
        
        //MODAL DE Transacciones DE Banco
        // GET: Banco/Transacciones
        public ActionResult Transacciones(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Transacciones");
        }

        [HttpPost]
        public JsonResult GridTransacciones()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<BancoModel> Listado = new List<BancoModel>()
            {
                new BancoModel { BAN_CODIGO = "01", BAN_DESCRIPCION = "Cheque".ToUpper() },
                new BancoModel { BAN_CODIGO = "02", BAN_DESCRIPCION = "Depósito".ToUpper() },
                new BancoModel { BAN_CODIGO = "03", BAN_DESCRIPCION = "Interés Ganado".ToUpper() },
                new BancoModel { BAN_CODIGO = "04", BAN_DESCRIPCION = "Saldo Inicial".ToUpper() },
                new BancoModel { BAN_CODIGO = "05", BAN_DESCRIPCION = "Transferencia".ToUpper() },
            };

            var Resultado = (from N in Listado
                             where N.BAN_DESCRIPCION.Contains(searchValue)
                             select new { N.BAN_CODIGO, N.BAN_DESCRIPCION });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************************************/
        //TRANSACCIONES
        /**************************************************************************************************************/
        // Transacciones, Se Abrevia <T>
        // GET: Banco/TIndex
        public ActionResult TIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridT()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<BancoModel> Listado = new List<BancoModel>()
            {
                new BancoModel { BAN_CODIGO = "01", NroCuenta = "1231231231", BAN_DESCRIPCION = "BANCO A".ToUpper(), Moneda = "MN", TipoDeCuenta = "Corriente" },
                new BancoModel { BAN_CODIGO = "02", NroCuenta = "3242332423", BAN_DESCRIPCION = "BANCO B".ToUpper(), Moneda = "MN", TipoDeCuenta = "Corriente" },
                new BancoModel { BAN_CODIGO = "03", NroCuenta = "6453523453", BAN_DESCRIPCION = "BANCO C".ToUpper(), Moneda = "MN", TipoDeCuenta = "Ahorro" },
            };

            var Resultado = (from N in Listado
                             where N.NroCuenta.Contains(searchValue)
                             select new { N.BAN_CODIGO, N.BAN_DESCRIPCION, N.TipoDeCuenta, N.Moneda, N.NroCuenta });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // GET: Banco/TTransaccion
        public ActionResult TTransaccion(string BAN_CODIGO)
        {
            Modelo.BAN_CODIGO = BAN_CODIGO;
            return View(Modelo);
        }
        
        [HttpPost]
        public JsonResult GridTTransacciones()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<BancoModel> Listado = new List<BancoModel>()
            {
                new BancoModel { BAN_CODIGO = "01", FechaOperacion = "10-04-2019", FechaDocumento = "12-04-2019", TipoDocumento = "T1", Documento = "XXXX1", Ingreso = 3222.00, Salida = 1111.00, Glosa = "AAA1", NroTransaccion = "121432" },
                new BancoModel { BAN_CODIGO = "02", FechaOperacion = "11-04-2019", FechaDocumento = "13-04-2019", TipoDocumento = "T2", Documento = "TTXX1", Ingreso = 2222.00, Salida = 3111.00, Glosa = "BBB", NroTransaccion = "121432" },
                new BancoModel { BAN_CODIGO = "03", FechaOperacion = "12-04-2019", FechaDocumento = "14-04-2019", TipoDocumento = "T3", Documento = "XZZX1", Ingreso = 4222.00, Salida = 2111.00, Glosa = "CCC", NroTransaccion = "121432" },
            };

            var Resultado = (from N in Listado
                             where N.Documento.Contains(searchValue)
                             select new { N.BAN_CODIGO, N.Documento, N.FechaOperacion, N.FechaDocumento, N.TipoDocumento, N.Ingreso, N.Salida, N.Glosa, N.NroTransaccion });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //MODAL DE Digitacion
        // GET: Banco/Digitacion
        public ActionResult Digitacion(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Digitacion");
        }

        // GET: Banco/TConciliar
        public ActionResult TConciliar(string BAN_CODIGO)
        {
            Modelo.BAN_CODIGO = BAN_CODIGO;
            return View(Modelo);
        }

        /**************************************************************************************************************/
        //CONSULTA
        /**************************************************************************************************************/
        // Consultas / Consolidado de Saldo, Se Abrevia <CCS>
        // GET: Banco/CCSIndex
        public ActionResult CCSIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridConsolidado()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<BancoModel> Listado = new List<BancoModel>()
            {
                new BancoModel { BAN_CODIGO = "01", NroCuenta = "231234234", BAN_DESCRIPCION = "BANCO A", Saldo = 3222.00, SaldoConsolidado = 1111.00, Moneda = "MN" },
                new BancoModel { BAN_CODIGO = "02", NroCuenta = "432423423", BAN_DESCRIPCION = "BANCO B", Saldo = 3222.00, SaldoConsolidado = 1111.00, Moneda = "MN" },
                new BancoModel { BAN_CODIGO = "03", NroCuenta = "234234234", BAN_DESCRIPCION = "BANCO C", Saldo = 3222.00, SaldoConsolidado = 1111.00, Moneda = "MN" },
            };

            var Resultado = (from N in Listado
                             where N.NroCuenta.Contains(searchValue)
                             select new { N.BAN_CODIGO, N.NroCuenta, N.BAN_DESCRIPCION, N.Saldo, N.SaldoConsolidado, N.Moneda });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //MODAL DE Estado de Cuenta
        // GET: Banco/EstadoCuenta
        public ActionResult EstadoCuenta(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_EstadoCuenta");
        }

        [HttpPost]
        public JsonResult GridEstadoCuenta()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<BancoModel> Listado = new List<BancoModel>()
            {
                new BancoModel { BAN_CODIGO = "01", FechaOperacion = "10-04-2019", Documento = "XXX1", FechaDocumento = "12-04-2019", BAN_DESCRIPCION = "DEPOSITO", Saldo = 3222.00, SaldoConsolidado = 1111.00, Moneda = "MN" },
                new BancoModel { BAN_CODIGO = "02", FechaOperacion = "11-04-2019", Documento = "YYY2", FechaDocumento = "13-04-2019", BAN_DESCRIPCION = "DEPOSITO", Saldo = 2222.00, SaldoConsolidado = 3111.00, Moneda = "ME" },
                new BancoModel { BAN_CODIGO = "03", FechaOperacion = "12-04-2019", Documento = "ZZZ3", FechaDocumento = "14-04-2019", BAN_DESCRIPCION = "DEPOSITO", Saldo = 4222.00, SaldoConsolidado = 2111.00, Moneda = "MN" },
            };

            var Resultado = (from N in Listado
                             where N.Documento.Contains(searchValue)
                             select new { N.BAN_CODIGO, N.BAN_DESCRIPCION, N.FechaOperacion, N.FechaDocumento, N.Saldo, N.SaldoConsolidado, N.Moneda, N.Documento });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************************************/
        //REPORTE
        /**************************************************************************************************************/
        // Reportes / Mensual de Movimientos, Se Abrevia <RMM>
        // GET: Banco/RMMIndex
        public ActionResult RMMIndex()
        {
            return View();
        }

        // Reportes / Diario de Movimientos, Se Abrevia <RDM>
        // GET: Banco/RDMIndex
        public ActionResult RDMIndex()
        {
            return View();
        }

        // Reportes / Mov. por Tipo de Operación, Se Abrevia <RTO>
        // GET: Banco/RMTOIndex
        public ActionResult RMTOIndex()
        {
            return View();
        }

        // Reportes / Resumen Consolidado de Saldos, Se Abrevia <RRCS>
        // GET: Banco/RRCSIndex
        public ActionResult RRCSIndex()
        {
            return View();
        }

        // Reportes / Cobranza por Bancos, Se Abrevia <RCB>
        // GET: Banco/RCBIndex
        public ActionResult RCBIndex()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GridCuentasCorrientes()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<BancoModel> Listado = new List<BancoModel>()
            {
                new BancoModel { BAN_CODIGO = "01", NroCuenta  = "1122334455", BAN_DESCRIPCION = "BANCO A", TipoDeCuenta = "Corriente" },
                new BancoModel { BAN_CODIGO ="02", NroCuenta  = "4455667788", BAN_DESCRIPCION = "BANCO A", TipoDeCuenta = "Ahorro" },
                new BancoModel { BAN_CODIGO ="03", NroCuenta  = "9911223344", BAN_DESCRIPCION = "BANCO B", TipoDeCuenta = "Corriente" },
                new BancoModel { BAN_CODIGO ="04", NroCuenta  = "5566778899", BAN_DESCRIPCION = "BANCO B", TipoDeCuenta = "Corriente" },
                new BancoModel { BAN_CODIGO ="05", NroCuenta  = "3344556677", BAN_DESCRIPCION = "BANCO B", TipoDeCuenta = "Corriente" },
                new BancoModel { BAN_CODIGO ="06", NroCuenta  = "8899001122", BAN_DESCRIPCION = "BANCO C", TipoDeCuenta = "Ahorro" },
                new BancoModel { BAN_CODIGO ="07", NroCuenta  = "4514864152", BAN_DESCRIPCION = "BANCO C", TipoDeCuenta = "Corriente" },
                new BancoModel { BAN_CODIGO ="08", NroCuenta  = "9152312512", BAN_DESCRIPCION = "BANCO C", TipoDeCuenta = "Ahorro" },
                new BancoModel { BAN_CODIGO ="09", NroCuenta  = "8564165665", BAN_DESCRIPCION = "BANCO C", TipoDeCuenta = "Corriente" },
            };

            var Resultado = (from N in Listado
                             where N.NroCuenta.Contains(searchValue)
                             select new { N.BAN_CODIGO, N.BAN_DESCRIPCION, N.NroCuenta, N.TipoDeCuenta });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************************************/
        //PROCESOS
        /**************************************************************************************************************/
        // PROCESOS / Reapertura de Mes Cerrado, Se Abrevia <PRMC>
        // GET: Banco/PRMCIndex
        public ActionResult PRMCIndex()
        {
            return View();
        }

        // PROCESOS / Actualiza Cta. Corriente desde Bancos, Se Abrevia <PACCDB>
        // GET: Banco/PACCDBIndex
        public ActionResult PACCDBIndex()
        {
            return View();
        }
    }
}
