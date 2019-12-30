using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;

namespace Inicio.Controllers
{
    public class CuentasPorPagarController : Controller
    {
        private CuentasPorPagarModel Modelo = new CuentasPorPagarModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        // GET: CuentasPorPagar
        public ActionResult Index()
        {
            Session["MenuColor"] = "deepskyblue";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.notas_cedito = "522.800,00";
            ViewBag.facturas_pagadas = "166.681,50";
            ViewBag.total = "1.447.083,00";
            ViewBag.deuda = "757.598,50";

            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
            ViewData["total_cuentas"] = new double[] { 1005.00, 142651.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50 };

            ViewData["tipo_indirectos"] = new string[] { "Productos", "Material", "Impuestos", "Alquileres","Embalaje", "Despacho", "Servicios", "Desplazamiento", "Informes", "comida", "Software servicios" };
            ViewData["gastos_indirectos"] = new int[] { 5030, 1569, 1957, 3779, 3224, 2838, 0058, 1219, 555, 1000, 3389, 1209 };

            ViewData["tipo_directos"] = new string[] { "RRHH", "Operacionales", "Comercialización", "No Operacionales", "Impuestos" };
            ViewData["gastos_directos"] = new int[] { 5000,4000,3000,2000,1000 };

            return View();
        }
        /**************************************************************************************************************/
        //TRANSACCIONES
        /**************************************************************************************************************/
        //CRUD DE Transacciones / Dctos x Pagar y Cobros, Se Abrevia <TDPP>
        // GET: CuentasPorPagar/TDPPIndex
        public ActionResult TDPPIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridTDPP()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorPagarModel> Listado = new List<CuentasPorPagarModel>()
            {
                new CuentasPorPagarModel { Codigo = "001", Descripcion = "Proveedor A".ToUpper(), SaldoMinimo = 250.00, SaldoMaximo = 50000.00  },
                new CuentasPorPagarModel { Codigo = "002", Descripcion = "Proveedor B".ToUpper(), SaldoMinimo = 450.00, SaldoMaximo = 50000.00 },
                new CuentasPorPagarModel { Codigo = "003", Descripcion = "Proveedor C".ToUpper(), SaldoMinimo = 300.00, SaldoMaximo = 50000.00 },
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

        // GET: CuentasPorPagar/TDPPMantenimiento/5
        public ActionResult TDPPMantenimiento(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTDPPMantenimiento()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorPagarModel> Listado = new List<CuentasPorPagarModel>()
            {
                new CuentasPorPagarModel { Codigo = "001", Descripcion = "Proveedor A".ToUpper(), Documento = "XXX1".ToUpper() },
                new CuentasPorPagarModel { Codigo = "002", Descripcion = "Proveedor B".ToUpper(), Documento = "YYY2".ToUpper() },
                new CuentasPorPagarModel { Codigo = "003", Descripcion = "Proveedor C".ToUpper(), Documento = "ZZZ3".ToUpper() },
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

        // GET: CuentasPorPagar/TDPPCanje/5
        public ActionResult TDPPCanje(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTDPPCanje()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorPagarModel> Listado = new List<CuentasPorPagarModel>()
            {
                new CuentasPorPagarModel { Codigo = "01", TipoDocumento = "NC", Documento = "XX1".ToUpper(), FechaEmision = "01-03-2019", FechaVencimiento = "01-03-2019", Moneda = "ME", ImporteNeto = 1000.00, SaldoActual = 20000.00 },
                new CuentasPorPagarModel { Codigo = "02", TipoDocumento = "ND", Documento = "YY2".ToUpper(), FechaEmision = "01-03-2019", FechaVencimiento = "01-03-2019", Moneda = "ME", ImporteNeto = 3000.00, SaldoActual = 15000.00 },
                new CuentasPorPagarModel { Codigo = "03", TipoDocumento = "FC", Documento = "ZZ3".ToUpper(), FechaEmision = "01-03-2019", FechaVencimiento = "01-03-2019", Moneda = "ME", ImporteNeto = 5000.00, SaldoActual = 30000.00 },
            };

            var Resultado = (from N in Listado
                             where N.Documento.Contains(searchValue)
                             select new { N.Codigo, N.TipoDocumento, N.Documento, N.FechaEmision, N.FechaVencimiento, N.Moneda, N.ImporteNeto, N.SaldoActual });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //MODAL DE DESCUENTOS POR Pagar
        // GET: CuentasPorPagar/DescuentosPorPagar
        public ActionResult DescuentosPorPagar(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_DescuentosPorPagar");
        }

        //MODAL DE Pagos REALIZADoS
        // GET: CuentasPorPagar/PagosRealizados/5
        public ActionResult PagosRealizados(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_PagosRealizados");
        }

        //MODAL DETALLE DE Pagos REALIZADoS
        // GET: CuentasPorPagar/DetallePagosRealizados/5
        public ActionResult DetallePagosRealizados(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_DetallePagosRealizados");
        }

        [HttpPost]
        public JsonResult GridPagosRealizados()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorPagarModel> Listado = new List<CuentasPorPagarModel>()
            {
                new CuentasPorPagarModel { Codigo = "01", FechaEmision = "01-03-2019", Moneda = "ME", MontoMN = 1000.00, MontoME = 20000.00, SaldoActual = 2333.00 },
                new CuentasPorPagarModel { Codigo = "02", FechaEmision = "01-03-2019", Moneda = "MN", MontoMN = 3000.00, MontoME = 15000.00, SaldoActual = 4333.00 },
                new CuentasPorPagarModel { Codigo = "03", FechaEmision = "01-03-2019", Moneda = "MN", MontoMN = 5000.00, MontoME = 30000.00, SaldoActual = 6333.00 },
            };

            var Resultado = (from N in Listado
                             where N.FechaEmision.Contains(searchValue)
                             select new { N.Codigo, N.MontoMN, N.MontoME, N.FechaEmision, N.SaldoActual, N.Moneda });
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
        // GET: CuentasPorPagar/Letras/5
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

            List<CuentasPorPagarModel> Listado = new List<CuentasPorPagarModel>()
            {
                new CuentasPorPagarModel { Codigo = "01", FechaVencimiento = "01-03-2019", Moneda = "ME", Plazo = "", CanjeMN = 20000.00, CanjeME = 2333.00 },
                new CuentasPorPagarModel { Codigo = "02", FechaVencimiento = "01-03-2019", Moneda = "MN", Plazo = "", CanjeMN = 15000.00, CanjeME = 4333.00 },
                new CuentasPorPagarModel { Codigo = "03", FechaVencimiento = "01-03-2019", Moneda = "MN", Plazo = "", CanjeMN = 30000.00, CanjeME = 6333.00 },
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
        // GET: CuentasPorPagar/TDPPTransaccion/5
        public ActionResult TDPPTransaccion(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTDPPTransaccion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorPagarModel> Listado = new List<CuentasPorPagarModel>()
            {
                new CuentasPorPagarModel { Codigo = "01", Estatus = "", FechaEmision = "01-03-2019", Documento = "XA", Moneda = "ME", ImporteNeto = 1000.00, TotalCredito = 20000.00, SaldoActual = 2333.00, Dias = "20", Glosa = "" },
                new CuentasPorPagarModel { Codigo = "02", Estatus = "", FechaEmision = "01-03-2019", Documento = "BA", Moneda = "MN", ImporteNeto = 3000.00, TotalCredito = 15000.00, SaldoActual = 4333.00, Dias = "20", Glosa = "" },
                new CuentasPorPagarModel { Codigo = "03", Estatus = "", FechaEmision = "01-03-2019", Documento = "ZA", Moneda = "MN", ImporteNeto = 5000.00, TotalCredito = 30000.00, SaldoActual = 6333.00, Dias = "20", Glosa = "" },
            };

            var Resultado = (from N in Listado
                             where N.Documento.Contains(searchValue)
                             select new { N.Codigo, N.Estatus, N.Documento, N.FechaEmision, N.ImporteNeto, N.Moneda, N.TotalCredito, N.SaldoActual, N.Dias, N.Glosa });
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
        //CRUD DE Transacciones / Ingreso de Pagos Diversos, Se Abrevia <TIPD>
        // GET: CuentasPorPagar/TIPDIndex
        public ActionResult TIPDIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridTIPD()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorPagarModel> Listado = new List<CuentasPorPagarModel>()
            {
                new CuentasPorPagarModel { Codigo = "01", Documento = "001", FechaEmision = "15-01-2019", Descripcion = "Proveedor A".ToUpper(), ImporteNeto = 1000.00, Moneda = "ME" },
                new CuentasPorPagarModel { Codigo = "02", Documento = "002", FechaEmision = "16-02-2019", Descripcion = "Proveedor B".ToUpper(), ImporteNeto = 2000.00, Moneda = "ME" },
                new CuentasPorPagarModel { Codigo = "03", Documento = "003", FechaEmision = "18-03-2019", Descripcion = "Proveedor C".ToUpper(), ImporteNeto = 3000.00, Moneda = "MN" },
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

        // GET: CuentasPorPagar/TIPDCreate
        public ActionResult TIPDCreate()
        {
            return View();
        }

        // GET: CuentasPorPagar/TIPDEdit/5
        public ActionResult TIPDEdit(string codigo)
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

            List<CuentasPorPagarModel> Listado = new List<CuentasPorPagarModel>()
            {
                new CuentasPorPagarModel { Codigo = "001", Descripcion = "Situación A".ToUpper() },
                new CuentasPorPagarModel { Codigo = "002", Descripcion = "Situación B".ToUpper() },
                new CuentasPorPagarModel { Codigo = "003", Descripcion = "Situación C".ToUpper() },
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
        //CONSULTA / Saldos x Pagar por Proveedor, Se abrevia <CSPP>
        // GET: CuentasPorPagar/CSPPIndex
        public ActionResult CSPPIndex()
        {
            return View();
        }

        // GET: CuentasPorPagar/CSPPDetalle/5
        public ActionResult CSPPDetalle(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }
        /**************************************************************************************************************/
        //REPORTES
        /**************************************************************************************************************/
        //REPORTES / Estado de Cuenta por Proveedor, Se abrevia <RECP>
        // GET: CuentasPorPagar/RECPIndex
        public ActionResult RECPIndex()
        {
            return View();
        }

        //REPORTES / Pagos por Proveedor, Se abrevia <RPP>
        // GET: CuentasPorPagar/RPPIndex
        public ActionResult RPPIndex()
        {
            return View();
        }

        //REPORTES / Letras por Pagar, Se abrevia <RLP>
        // GET: CuentasPorPagar/RPPIndex
        public ActionResult RLPIndex()
        {
            return View();
        }

        //REPORTES / Resumen de Cuentas por Pagar por Proveedor, Se abrevia <RRCPP>
        // GET: CuentasPorPagar/RRCPPIndex
        public ActionResult RRCPPIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //PROCESO
        /**************************************************************************************************************/
        //PROCESO / Actualiza Saldos Proveedors, Se abrevia <PASC>
        // GET: CuentasPorPagar/PASCIndex
        public ActionResult PASPIndex()
        {
            return View();
        }
    }
}
