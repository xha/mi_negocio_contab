using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;

namespace Inicio.Controllers
{
    public class CuentasPorCobrarController : Controller
    {
        private CuentasPorCobrarModel Modelo = new CuentasPorCobrarModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        // GET: CuentasPorCobrar
        public ActionResult Index()
        {
            Session["MenuColor"] = "darkorange";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_cobrado = "359.225.451,00";
            ViewBag.total_pendientes = "165.365.944,00";
            ViewBag.total_atrasados = "57.195.123,00";

            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
            ViewData["cobrado"] = new int[] { 20030,12369,19607,37079,9224,2538,1008,1289,1551,4034,1369,1709 };
            ViewData["region1"] = new int[] { 2030, 1369, 1907, 3779,2224, 2838, 0058, 1889, 1555, 1034, 1389, 1009 };
            ViewData["region2"] = new int[] { 3030, 1269, 2907, 3769, 2214, 2738, 2058, 1289, 3555, 1134, 1989, 5009 };
            ViewData["region3"] = new int[] { 5030, 1569, 1957, 3779, 3224, 2838, 0058, 1219, 555, 1000, 3389, 1209 };

            return View();
        }
        /**************************************************************************************************************/
        //TRANSACCIONES
        /**************************************************************************************************************/
        //CRUD DE Transacciones / Dctos x Cobrar y Cobranzas, Se Abrevia <TDCC>
        // GET: Facturacion/TDCCIndex
        public ActionResult TDCCIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridTDCC()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorCobrarModel> Listado = new List<CuentasPorCobrarModel>()
            {
                new CuentasPorCobrarModel { Codigo = "001", Descripcion = "Cliente A".ToUpper(), SaldoMinimo = 250.00, SaldoMaximo = 50000.00  },
                new CuentasPorCobrarModel { Codigo = "002", Descripcion = "Cliente B".ToUpper(), SaldoMinimo = 450.00, SaldoMaximo = 50000.00 },
                new CuentasPorCobrarModel { Codigo = "003", Descripcion = "Cliente C".ToUpper(), SaldoMinimo = 300.00, SaldoMaximo = 50000.00 },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.SaldoMinimo, N.SaldoMaximo });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // GET: Facturacion/TDCCMantenimiento/5
        public ActionResult TDCCMantenimiento(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTDCCMantenimiento()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorCobrarModel> Listado = new List<CuentasPorCobrarModel>()
            {
                new CuentasPorCobrarModel { Codigo = "001", Descripcion = "Cliente A".ToUpper(), Documento = "XXX1".ToUpper() },
                new CuentasPorCobrarModel { Codigo = "002", Descripcion = "Cliente B".ToUpper(), Documento = "YYY2".ToUpper() },
                new CuentasPorCobrarModel { Codigo = "003", Descripcion = "Cliente C".ToUpper(), Documento = "ZZZ3".ToUpper() },
            };

            var Resultado = (from N in Listado
                             where N.Documento.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.Documento });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // GET: Facturacion/TDCCCanje/5
        public ActionResult TDCCCanje(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTDCCCanje()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorCobrarModel> Listado = new List<CuentasPorCobrarModel>()
            {
                new CuentasPorCobrarModel { Codigo = "1", TipoDocumento = "NC", Documento = "XX1".ToUpper(), FechaEmision = "01-03-2019", FechaVencimiento = "01-03-2019", Moneda = "ME", ImporteBruto = 1000.00, SaldoActual = 20000.00 },
                new CuentasPorCobrarModel { Codigo = "2", TipoDocumento = "ND", Documento = "YY2".ToUpper(), FechaEmision = "01-03-2019", FechaVencimiento = "01-03-2019", Moneda = "ME", ImporteBruto = 3000.00, SaldoActual = 15000.00 },
                new CuentasPorCobrarModel { Codigo = "3", TipoDocumento = "FC", Documento = "ZZ3".ToUpper(), FechaEmision = "01-03-2019", FechaVencimiento = "01-03-2019", Moneda = "ME", ImporteBruto = 5000.00, SaldoActual = 30000.00 },
            };

            var Resultado = (from N in Listado
                             where N.Documento.Contains(searchValue)
                             select new { N.Codigo, N.TipoDocumento, N.Documento, N.FechaEmision, N.FechaVencimiento, N.Moneda, N.ImporteBruto, N.SaldoActual });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //MODAL DE DESCUENTOS POR COBRAR
        // GET: Facturacion/DescuentosCobrar
        public ActionResult DescuentosPorCobrar(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_DescuentosPorCobrar");
        }

        //MODAL DE COBRANZAS REALIZADAS
        // GET: Facturacion/CobranzasRealizadas/5
        public ActionResult CobranzasRealizadas(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CobranzasRealizadas");
        }

        //MODAL DETALLE DE COBRANZAS REALIZADAS
        // GET: Facturacion/DetalleCobranzasRealizadas/5
        public ActionResult DetalleCobranzasRealizadas(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_DetalleCobranzasRealizadas");
        }

        [HttpPost]
        public JsonResult GridCobranzasRealizadas()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorCobrarModel> Listado = new List<CuentasPorCobrarModel>()
            {
                new CuentasPorCobrarModel { Codigo = "1", FechaEmision = "01-03-2019", Moneda = "ME", MontoMN = 1000.00, MontoME = 20000.00, TipoCambio = 2333.00 },
                new CuentasPorCobrarModel { Codigo = "2",  FechaEmision = "01-03-2019", Moneda = "MN", MontoMN = 3000.00, MontoME = 15000.00, TipoCambio = 4333.00 },
                new CuentasPorCobrarModel { Codigo = "2",  FechaEmision = "01-03-2019", Moneda = "MN", MontoMN = 5000.00, MontoME = 30000.00, TipoCambio = 6333.00 },
            };

            var Resultado = (from N in Listado
                             where N.FechaEmision.Contains(searchValue)
                             select new { N.Codigo, N.MontoMN, N.MontoME, N.FechaEmision, N.TipoCambio, N.Moneda });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //MODAL DE Letras
        // GET: Facturacion/Letras/5
        public ActionResult Letras(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Letras");
        }

        [HttpPost]
        public JsonResult GridLetras()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorCobrarModel> Listado = new List<CuentasPorCobrarModel>()
            {
                new CuentasPorCobrarModel { Codigo = "01", FechaVencimiento = "01-03-2019", Moneda = "ME", Plazo = "", CanjeMN = 20000.00, CanjeME = 2333.00 },
                new CuentasPorCobrarModel { Codigo = "02", FechaVencimiento = "01-03-2019", Moneda = "MN", Plazo = "", CanjeMN = 15000.00, CanjeME = 4333.00 },
                new CuentasPorCobrarModel { Codigo = "03", FechaVencimiento = "01-03-2019", Moneda = "MN", Plazo = "", CanjeMN = 30000.00, CanjeME = 6333.00 },
            };

            var Resultado = (from N in Listado
                             where N.FechaVencimiento.Contains(searchValue)
                             select new { N.Codigo, N.FechaVencimiento, N.Moneda, N.Plazo, N.CanjeMN, N.CanjeME });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        // GET: Facturacion/TDCCTransaccion/5
        public ActionResult TDCCTransaccion(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTDCCTransaccion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorCobrarModel> Listado = new List<CuentasPorCobrarModel>()
            {
                new CuentasPorCobrarModel { Codigo = "01", Estatus = "", FechaEmision = "01-03-2019", Documento = "XA", Moneda = "ME", ImporteBruto = 1000.00, TotalCredito = 20000.00, SaldoActual = 2333.00, Dias = "20" },
                new CuentasPorCobrarModel { Codigo = "02", Estatus = "", FechaEmision = "01-03-2019", Documento = "BA", Moneda = "MN", ImporteBruto = 3000.00, TotalCredito = 15000.00, SaldoActual = 4333.00, Dias = "20" },
                new CuentasPorCobrarModel { Codigo = "03", Estatus = "", FechaEmision = "01-03-2019", Documento = "ZA", Moneda = "MN", ImporteBruto = 5000.00, TotalCredito = 30000.00, SaldoActual = 6333.00, Dias = "20" },
            };

            var Resultado = (from N in Listado
                             where N.Documento.Contains(searchValue)
                             select new { N.Codigo, N.Estatus, N.Documento, N.FechaEmision, N.ImporteBruto, N.Moneda, N.TotalCredito, N.SaldoActual, N.Dias });
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
        //CRUD DE Transacciones / Ingreso de Cobranzas Diversas, Se Abrevia <TICD>
        // GET: CuentasPorCobrar/TICDIndex
        public ActionResult TICDIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridTICD()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorCobrarModel> Listado = new List<CuentasPorCobrarModel>()
            {
                new CuentasPorCobrarModel { Codigo = "01", Documento = "001", FechaEmision = "15-01-2019", Descripcion = "Cliente A".ToUpper(), ImporteNeto = 1000.00, Moneda = "ME" },
                new CuentasPorCobrarModel { Codigo = "02", Documento = "002", FechaEmision = "16-02-2019", Descripcion = "Cliente B".ToUpper(), ImporteNeto = 2000.00, Moneda = "ME" },
                new CuentasPorCobrarModel { Codigo = "03", Documento = "003", FechaEmision = "18-03-2019", Descripcion = "Cliente C".ToUpper(), ImporteNeto = 3000.00, Moneda = "MN" },
            };

            var Resultado = (from N in Listado
                             where N.Documento.Contains(searchValue)
                             select new { N.Codigo, N.Documento, N.FechaEmision, N.Descripcion, N.ImporteNeto, N.Moneda });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // GET: CuentasPorCobrar/TICDCreate
        public ActionResult TICDCreate()
        {
            return View();
        }

        // GET: CuentasPorCobrar/TICDEdit/5
        public ActionResult TICDEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        //MODAL DE SITUACION DE LA LETRA
        // GET: Facturacion/SituacionLetra
        public ActionResult SituacionLetra(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_SituacionLetra");
        }

        [HttpPost]
        public JsonResult GridSituacionLetra()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorCobrarModel> Listado = new List<CuentasPorCobrarModel>()
            {
                new CuentasPorCobrarModel { Codigo = "01", Descripcion = "Situación A".ToUpper() },
                new CuentasPorCobrarModel { Codigo = "02", Descripcion = "Situación B".ToUpper() },
                new CuentasPorCobrarModel { Codigo = "03",Descripcion = "Situación C".ToUpper() },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion });
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
        //CONSULTAS
        /**************************************************************************************************************/
        //CONSULTA / Saldos x Cobrar por Cliente, Se abrevia <CSCC>
        // GET: CuentasPorCobrar/CSCCIndex
        public ActionResult CSCCIndex()
        {
            return View();
        }

        // GET: CuentasPorCobrar/CSCCDetalle/5
        public ActionResult CSCCDetalle(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }
        /**************************************************************************************************************/
        //REPORTES
        /**************************************************************************************************************/
        //REPORTES / Estado de Cuenta por Cliente, Se abrevia <RECC>
        // GET: CuentasPorCobrar/RECCIndex
        public ActionResult RECCIndex()
        {
            return View();
        }

        //REPORTES / Cobranzas por Cliente, Se abrevia <RCC>
        // GET: CuentasPorCobrar/RCCIndex
        public ActionResult RCCIndex()
        {
            return View();
        }

        //REPORTES / Letras por Cobrar, Se abrevia <RLC>
        // GET: CuentasPorCobrar/RLCIndex
        public ActionResult RLCIndex()
        {
            return View();
        }

        //REPORTES / Resumen CtasxCob por Cliente, Se abrevia <RRCCC>
        // GET: CuentasPorCobrar/RRCCCIndex
        public ActionResult RRCCCIndex()
        {
            return View();
        }

        //REPORTES / Cobranzas Proyectadas por Meses, Se abrevia <RCPM>
        // GET: CuentasPorCobrar/RCPMIndex
        public ActionResult RCPMIndex()
        {
            return View();
        }

        //REPORTES / Reporte de Saldos x Vendedor, Se abrevia <RSV>
        // GET: CuentasPorCobrar/RSVIndex
        public ActionResult RSVIndex()
        {
            return View();
        }

        //REPORTES / Pendientes de Cobro / Canje de Letras, Se abrevia <RPC>
        // GET: CuentasPorCobrar/RPCIndex
        public ActionResult RPCIndex()
        {
            return View();
        }

        //REPORTES / Aviso de Pago de Letras, Se abrevia <RAPL>
        // GET: CuentasPorCobrar/RAPLIndex
        public ActionResult RAPLIndex()
        {
            return View();
        }

        /**************************************************************************************************************/
        //PROCESO
        /**************************************************************************************************************/
        //PROCESO / Actualiza Saldos Clientes, Se abrevia <PASC>
        // GET: CuentasPorCobrar/PASCIndex
        public ActionResult PASCIndex()
        {
            return View();
        }
    }
}
