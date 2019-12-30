using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;

namespace Inicio.Controllers
{
    public class GerenteController : Controller
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
        // GET: Gerente/Index
        public ActionResult Index()
        {
            Session["MenuColor"] = "lightseagreen";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.t_compras = "522.800,00";
            ViewBag.total_facturas = 150;
            ViewBag.t_ventas = "1.447.083,00";
            ViewBag.total_documentos = 25;

            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
            ViewData["total_ventas"] = new double[] { 1005.00, 142651.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50 };
            ViewData["total_compras"] = new int[] { 5030, 1569, 1957, 3779, 3224, 2838, 0058, 1219, 555, 1000, 3389, 1209 };
            ViewData["productos_salida"] = new int[] { 212,532,432,765,921,985,221,345,523,122,462,342 };
            ViewData["productos_entrada"] = new int[] { 12, 32, 32, 65, 21, 85, 21, 45, 23, 22, 62, 42 };

            return View();
        }
        /**************************************************************************************************************/
        //REPORTES
        /**************************************************************************************************************/
        // Reportes de Movimiento / Compras, Se Abrevia <RMC>
        // GET: Gerente/RMCIndex
        public ActionResult RMCIndex()
        {
            return View();
        }

        // Reportes de Movimiento / Gastos, Se Abrevia <RMG>
        // GET: Gerente/RMGIndex
        public ActionResult RMGIndex()
        {
            return View();
        }

        // Reportes de Movimiento / Ventas, Se Abrevia <RMV>
        // GET: Gerente/RMVIndex
        public ActionResult RMVIndex()
        {
            return View();
        }

        // Reportes de Movimiento / Ventas Rápidas, Se Abrevia <RMVR>
        // GET: Gerente/RMVRIndex
        public ActionResult RMVRIndex()
        {
            return View();
        }

        // Reportes de Movimiento / Movimiento de Almacén, Se Abrevia <RMMA>
        // GET: Gerente/Reportes de Movimiento /RMMAIndex
        public ActionResult RMMAIndex()
        {
            return View();
        }

        // Reportes de Movimiento / Cobranzas efectuadas, Se Abrevia <RMCE>
        // GET: Gerente/Reportes de Movimiento /RMCEIndex
        public ActionResult RMCEIndex()
        {
            return View();
        }

        // Reportes de Movimiento / Pagos efectuados, Se Abrevia <RMPE>
        // GET: Gerente/Reportes de Movimiento /RMPEIndex
        public ActionResult RMPEIndex()
        {
            return View();
        }

        // Reportes de Auditoría / Documentos de ventas anulados, Se Abrevia <RADVA>
        // GET: Gerente/Reportes de Auditoría/RADVAIndex
        public ActionResult RADVAIndex()
        {
            return View();
        }

        // Reportes de Auditoría / Artículos vendidos bajo el costo, Se Abrevia <RAAVBC>
        // GET: Gerente/Reportes de Auditoría/RAAVBCIndex
        public ActionResult RAAVBCIndex()
        {
            return View();
        }

        // Reportes de Auditoría / Artículos en alerta logístico, Se Abrevia <RAAAL>
        // GET: Gerente/Reportes de Auditoría/RAAALIndex
        public ActionResult RAAALIndex()
        {
            return View();
        }

        // Reportes de Auditoría / Artículos sin movimiento, Se Abrevia <RAASM>
        // GET: Gerente/Reportes de Auditoría/RAASMIndex
        public ActionResult RAASMIndex()
        {
            return View();
        }

        // Reportes de Auditoría / Artículos en negativo, Se Abrevia <RAAN>
        // GET: Gerente/Reportes de Auditoría/RAANIndex
        public ActionResult RAANIndex()
        {
            return View();
        }

        // Reportes de Auditoría / Análisis de Variación de Precios, Se Abrevia <RAAVP>
        // GET: Gerente/Reportes de Auditoría/RAAVPIndex
        public ActionResult RAAVPIndex()
        {
            return View();
        }

        // Reportes de Tributación / Registro de Ventas, Se Abrevia <RTRV>
        // GET: Gerente/Reportes de Tributación/RTRVIndex
        public ActionResult RTRVIndex()
        {
            return View();
        }

        // Reportes de Tributación / Registro de Compras, Se Abrevia <RTRC>
        // GET: Gerente/Reportes de Tributación/RTRCIndex
        public ActionResult RTRCIndex()
        {
            return View();
        }

        // Reportes de Tributación / Cálculo de Impuestos, Se Abrevia <RTCI>
        // GET: Gerente/Reportes de Tributación/RTCIIndex
        public ActionResult RTCIIndex()
        {
            return View();
        }

        // Reportes de Rentabilidad de Ventas / Rentabilidad de Ventas, Se Abrevia <RRVRV>
        // GET: Gerente/Reportes de Rentabilidad de Ventas/RRVRVIndex
        public ActionResult RRVRVIndex()
        {
            return View();
        }

        // Reportes de Rentabilidad de Ventas / Ranking de Ventas por Artículo, Se Abrevia <RRVRVA>
        // GET: Gerente/Reportes de Rentabilidad de Ventas/RRVRVAIndex
        public ActionResult RRVRVAIndex()
        {
            return View();
        }

        // Reportes de Rentabilidad de Ventas / Ranking de Ventas por Cliente, Se Abrevia <RRVRVC>
        // GET: Gerente/Reportes de Rentabilidad de Ventas/RRVRVCIndex
        public ActionResult RRVRVCIndex()
        {
            return View();
        }

        // Reportes de Rentabilidad de Ventas / Listas de Precios con su Utilidad, Se Abrevia <RRVLPU>
        // GET: Gerente/Reportes de Rentabilidad de Ventas/RRVLPUIndex
        public ActionResult RRVLPUIndex()
        {
            return View();
        }

        // Cálculo de Utilidad Neta Mensual / Rentabilidad de Venta Mensual, Se Abrevia <CUNMRVM>
        // GET: Gerente/Cálculo de Utilidad Neta Mensual/CUNMRVMIndex
        public ActionResult CUNMRVMIndex()
        {
            return View();
        }

        // Cálculo de Utilidad Neta Mensual / Tabla de gastos generales del mes, Se Abrevia <CUNMTGGM>
        // GET: Gerente/Cálculo de Utilidad Neta Mensual/CUNMTGGMIndex
        public ActionResult CUNMTGGMIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridGastos()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CuentasPorPagarModel> Listado = new List<CuentasPorPagarModel>()
            {
                new CuentasPorPagarModel { Codigo = "01", Descripcion = "GASTO A", MontoMN = 1000.00, MontoME = 20000.00 },
                new CuentasPorPagarModel { Codigo = "02", Descripcion = "GASTO B", MontoMN = 3000.00, MontoME = 15000.00 },
                new CuentasPorPagarModel { Codigo = "03", Descripcion = "GASTO C", MontoMN = 5000.00, MontoME = 30000.00 },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.MontoMN, N.MontoME });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Cálculo de Utilidad Neta Mensual / Utilidad Neta Detallando Porcentajes, Se Abrevia <CUNMUNDP>
        // GET: Gerente/Cálculo de Utilidad Neta Mensual/CUNMUNDPIndex
        public ActionResult CUNMUNDPIndex()
        {
            return View();
        }

        // Cálculo de Utilidad Neta Mensual / Comparativo de Utilidades   Netas por Meses, Se Abrevia <CUNMCUNM>
        // GET: Gerente/Cálculo de Utilidad Neta Mensual/CUNMCUNMIndex
        public ActionResult CUNMCUNMIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Compras / Compras Mensuales, Se Abrevia <GAECCM>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Compras / GAECCMIndex
        public ActionResult GAECCMIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Compras / Por Proveedor, Se Abrevia <GAECPP>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Compras / GAECPPIndex
        public ActionResult GAECPPIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Compras / Por Artículo, Se Abrevia <GAECPA>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Compras / GAECPAIndex
        public ActionResult GAECPAIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Ventas / Ventas Totales, Se Abrevia <GAEVVT>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Ventas / GAEVVTIndex
        public ActionResult GAEVVTIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Ventas / Ventas por Cliente, Se Abrevia <GAEVVC>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Ventas / GAEVVCIndex
        public ActionResult GAEVVCIndex()
        {
            return View();
        }
        
        // Gráficos de Análisis   Estadísticos / Ventas / Ventas por Vendedor, Se Abrevia <GAEVVV>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Ventas / GAEVVVIndex
        public ActionResult GAEVVVIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Ventas / Ventas por Artículo, Se Abrevia <GAEVVA>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Ventas / GAEVVAIndex
        public ActionResult GAEVVAIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Ventas / Ventas por Familia, Se Abrevia <GAEVVF>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Ventas / GAEVVFIndex
        public ActionResult GAEVVFIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Almacenes / Ingresos por Meses, Se Abrevia <GAEAIM>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Almacenes / GAEAIMIndex
        public ActionResult GAEAIMIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Almacenes / Salidas por Meses, Se Abrevia <GAEASM>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Almacenes / GAEASMIndex
        public ActionResult GAEASMIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Almacenes / Saldos por Meses, Se Abrevia <GAEASSM>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Almacenes / GAEASSMIndex
        public ActionResult GAEASSMIndex()
        {
            return View();
        }

        // Gráficos de Análisis   Estadísticos / Almacenes / Movimiento Mensual, Se Abrevia <GAEAMM>
        // GET: Gerente/Gráficos de Análisis   Estadísticos / Almacenes / GAEAMMIndex
        public ActionResult GAEAMMIndex()
        {
            return View();
        }
    }
}
