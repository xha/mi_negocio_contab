using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.PlanillaModels;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
namespace Inicio.Controllers
{
    public class PMaestraController : Controller
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
        //Listado de Fórmulas
        [HttpGet]
        public ActionResult Formulas(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Formulas");
        }

        //Funciones
        [HttpGet]
        public ActionResult Funciones(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Funciones");
        }

        [HttpPost]
        public JsonResult GridFormulas()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            List<PMaestraModel> Listado = new List<PMaestraModel>()
            {
                new PMaestraModel { CODIGO = "@BASICO", DESCRIPCION = "sueldo básico".ToUpper() },
                new PMaestraModel { CODIGO = "@FECHAING", DESCRIPCION = "Fecha de Ingreso".ToUpper() },
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

        //Listado de Referencias
        [HttpGet]
        public ActionResult Referencias(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Referencias");
        }
        /**************************************************************************************************************/
        // GET: Maestro Index
        public ActionResult Index()
        {
            Session["MenuColor"] = "sienna";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_bancos = 8;
            ViewBag.total_cuentas = 20;
            ViewBag.total_usuarios = 36;
            ViewBag.total_roles = 6;

            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
            ViewData["total_ventas"] = new double[] { 1005.00, 142651.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50, 166681.50 };
            ViewData["total_compras"] = new int[] { 5030, 1569, 1957, 3779, 3224, 2838, 0058, 1219, 555, 1000, 3389, 1209 };
            ViewData["productos_salida"] = new int[] { 212, 532, 432, 765, 921, 985, 221, 345, 523, 122, 462, 342 };
            ViewData["productos_entrada"] = new int[] { 12, 32, 32, 65, 21, 85, 21, 45, 23, 22, 62, 42 };

            return View();
        }
        /**************************************************************************************************************/
        //BASE DE DATOS
        /**************************************************************************************************************/
        // Tabla Maestra \ Listado de Centros de  Costo, Se Abrevia <PTMLCC>
        public ActionResult PTMLCCIndex()
        {
            return View();
        }

        public ActionResult PTMLCCCreate()
        {
            return View();
        }

        public ActionResult PTMLCCEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridPTMLCC()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            List<PMaestraModel> Listado = new List<PMaestraModel>()
            {
                new PMaestraModel { CODIGO = "001", DESCRIPCION = "Registro XXX".ToUpper(), CUENTA_CONTABLE = "123456789", ESCALA_MAXIMA = 10000.00, ESCALA_MINIMA = 0.00, NIVEL = 1, APORTE = 0.00, SEGURO = 0.00, SIMBOLO = "$", FECHA = "01/10/2019" },
                new PMaestraModel { CODIGO = "002", DESCRIPCION = "Registro YYY".ToUpper(), CUENTA_CONTABLE = "987654321", ESCALA_MAXIMA = 20000.00, ESCALA_MINIMA = 1000.00, NIVEL = 3, APORTE = 0.00, SEGURO = 0.00, SIMBOLO = "S/", FECHA = "30/10/2019" },
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

        // Tabla Maestra \ Listado de Áreas de Trabajo, Se Abrevia <PTMLAT>
        public ActionResult PTMLATIndex()
        {
            return View();
        }

        public ActionResult PTMLATCreate()
        {
            return View();
        }

        public ActionResult PTMLATEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tabla Maestra \ Listado de Categorias, Se Abrevia <PTMLC>
        public ActionResult PTMLCIndex()
        {
            return View();
        }

        public ActionResult PTMLCCreate()
        {
            return View();
        }

        public ActionResult PTMLCEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tabla Maestra \ Listado de Cargos /    Puestos de Trabajo, Se Abrevia <PTMLCPT>
        public ActionResult PTMLCPTIndex()
        {
            return View();
        }

        public ActionResult PTMLCPTCreate()
        {
            return View();
        }

        public ActionResult PTMLCPTEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tabla Maestra \ Listado de Fondos de Penciones, Se Abrevia <PTMLFP>
        public ActionResult PTMLFPIndex()
        {
            return View();
        }

        public ActionResult PTMLFPCreate()
        {
            return View();
        }

        public ActionResult PTMLFPEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tabla Maestra \ Listado de SCTR, Se Abrevia <PTMLSCTR>
        public ActionResult PTMLSCTRIndex()
        {
            return View();
        }

        public ActionResult PTMLSCTRCreate()
        {
            return View();
        }

        public ActionResult PTMLSCTREdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tabla Maestra \ Listado de Entidades Bancarias, Se Abrevia <PTMLEB>
        public ActionResult PTMLEBIndex()
        {
            return View();
        }

        public ActionResult PTMLEBCreate()
        {
            return View();
        }

        public ActionResult PTMLEBEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tabla Maestra \ Tipos de Contratos, Se Abrevia <PTMTC>
        public ActionResult PTMTCIndex()
        {
            return View();
        }

        public ActionResult PTMTCCreate()
        {
            return View();
        }

        public ActionResult PTMTCEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tabla Maestra \ Tipos de Planes EPS, Se Abrevia <PTMTPEPS>
        public ActionResult PTMTPEPSIndex()
        {
            return View();
        }

        public ActionResult PTMTPEPSCreate()
        {
            return View();
        }

        public ActionResult PTMTPEPSEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }
        
        // Tabla Maestra \ Tipos de Planes EPS, Se Abrevia <PTMTD>
        public ActionResult PTMTDIndex()
        {
            return View();
        }

        public ActionResult PTMTDCreate()
        {
            return View();
        }

        public ActionResult PTMTDEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tabla Maestra \ Tipos de Trabajadores, Se Abrevia <PTMTT>
        public ActionResult PTMTTIndex()
        {
            return View();
        }

        public ActionResult PTMTTCreate()
        {
            return View();
        }

        public ActionResult PTMTTEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tabla Maestra \ Tipos de Moneda, Se Abrevia <PTMTM>
        public ActionResult PTMTMIndex()
        {
            return View();
        }

        public ActionResult PTMTMCreate()
        {
            return View();
        }

        public ActionResult PTMTMEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tabla Maestra \ Tipos de Cambio, Se Abrevia <PTMTCA>
        public ActionResult PTMTCAIndex()
        {
            return View();
        }

        public ActionResult PTMTCACreate()
        {
            return View();
        }

        public ActionResult PTMTCAEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de Personal \ Listado de Trabajadores, Se Abrevia <PTPLT>
        public ActionResult PTPLTIndex()
        {
            return View();
        }

        public ActionResult PTPLTCreate()
        {
            return View();
        }

        public ActionResult PTPLTEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridListadoTrabajadores()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            List<PMaestraModel> Listado = new List<PMaestraModel>()
            {
                new PMaestraModel { CODIGO_TRABAJADOR = "AAJ001", NOMBRE = "AGUILAR ABANTO JUAN MAXIMILIANO", NOMBRE_AREA = "Administración", DEPARTAMENTO = "02 :  Administración", CARGO = "Auxiliar de Administración", BASICO = 1000.00, DOCUMENTO = "43459099", FECHA_INGRESO = "01/02/2013", CENTRO_COSTO = "Administración", CODIGO_CENTRO = "001", CODIGO_AREA = "02", NUMERO_FICHA = "", CARNET_SEGURO = "8602171AIANJ001", FONDO_PENSION = "PM", ASIGNACION_FAM = 0, FECHA_CESE = "", CODIGO_ALTERNO = "", CODIGO_TIPO = "21", SITUACION = 1, CODIGO_SCTR = "NONE", RUC_EPS = "", AFP = "PRIMA", BANCO = "BCP", CUENTA_BANCO = "19345699978955", TIPO_DOCUMENTO = "01", NO_DECLARA = "NO", NO_CALCULA = "NO", DIRECCION = "JR. ALAMOS 925", SEXO = "MASCULINO" },
                new PMaestraModel { CODIGO_TRABAJADOR = "BAJ001", NOMBRE = "JOSE MOTA", NOMBRE_AREA = "Sistemas", DEPARTAMENTO = "01 :  Soporte Técnico", CARGO = "Soporte", BASICO = 5000.00, DOCUMENTO = "12345678", FECHA_INGRESO = "10/11/2015", CENTRO_COSTO = "Administración", CODIGO_CENTRO = "002", CODIGO_AREA = "03", NUMERO_FICHA = "", CARNET_SEGURO = "9603171BIABJ002", FONDO_PENSION = "PM", ASIGNACION_FAM = 0, FECHA_CESE = "", CODIGO_ALTERNO = "", CODIGO_TIPO = "21", SITUACION = 1, CODIGO_SCTR = "NONE", RUC_EPS = "", AFP = "PRIMA", BANCO = "BCP", CUENTA_BANCO = "19345699978955", TIPO_DOCUMENTO = "01", NO_DECLARA = "NO", NO_CALCULA = "NO", DIRECCION = "AV PRINCIPAL", SEXO = "MASCULINO" },
            };

            var Resultado = (from N in Listado
                             where N.NOMBRE.Contains(searchValue)
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

        [HttpGet]
        public ActionResult ReporteActivosBaja(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_ReporteActivosBaja");
        }

        [HttpGet]
        public ActionResult ReporteTrabajadoresExcel(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_ReporteTrabajadoresExcel");
        }

        [HttpGet]
        public ActionResult ReportePersonalizado(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_ReportePersonalizado");
        }

        [HttpGet]
        public ActionResult Direcciones(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Direcciones");
        }

        // Tablas de Personal \ Listado de Pensionados, Se Abrevia <PTPLP>
        public ActionResult PTPLPIndex()
        {
            return View();
        }

        public ActionResult PTPLPCreate()
        {
            return View();
        }

        public ActionResult PTPLPEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de Personal \ P.S. Cuarta Categoría, Se Abrevia <PTPCC>
        public ActionResult PTPCCIndex()
        {
            return View();
        }

        public ActionResult PTPCCCreate()
        {
            return View();
        }

        public ActionResult PTPCCEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de Personal \ P.S. Modalidad Formativa, Se Abrevia <PTPMF>
        public ActionResult PTPMFIndex()
        {
            return View();
        }

        public ActionResult PTPMFCreate()
        {
            return View();
        }

        public ActionResult PTPMFEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de Personal \ Personal de Terceros, Se Abrevia <PTPPT>
        public ActionResult PTPPTIndex()
        {
            return View();
        }

        public ActionResult PTPPTCreate()
        {
            return View();
        }

        public ActionResult PTPPTEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de Conceptos y Fórmulas \ Mantenimiento de Conceptos, Se Abrevia <PTCFMC>
        public ActionResult PTCFMCIndex()
        {
            return View();
        }

        public ActionResult PTCFMCCreate()
        {
            return View();
        }

        public ActionResult PTCFMCEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridConceptos()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            List<PMaestraModel> Listado = new List<PMaestraModel>()
            {
                new PMaestraModel { CODIGO_CONCEPTO = "001", TIPO = 2, DESCRIPCION_CONCEPTO = "Adel. Bono", FILA = 1, FORMULA = "", COLUMNA_PLANILLA = "001" },
                new PMaestraModel { CODIGO_CONCEPTO = "002", TIPO = 3, DESCRIPCION_CONCEPTO = "AFP. Aportación", FILA = 2, FORMULA = "CASE WHEN CODAFP='SR' THEN 0 ELSE 1", COLUMNA_PLANILLA = "002" },
                new PMaestraModel { CODIGO_CONCEPTO = "ASIGFAM", TIPO = 1, DESCRIPCION_CONCEPTO = "Asignación Familiar", FILA = 3, FORMULA = "CASE WHEN CODAFP='SR' THEN 0 ELSE 1", COLUMNA_PLANILLA = "003" },
                new PMaestraModel { CODIGO_CONCEPTO = "BI", TIPO = 0, DESCRIPCION_CONCEPTO = "Base Imponible", FILA = 4, FORMULA = "(BASICO+ASIGFAM)", COLUMNA_PLANILLA = "004" },
            };

            var Resultado = (from N in Listado
                             where N.DESCRIPCION_CONCEPTO.Contains(searchValue)
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

        // Tablas de de Conceptos y Fórmulas \ Concepto \ Formatos de Planillas, Se Abrevia <PTCFFP>
        public ActionResult PTCFFPIndex()
        {
            return View();
        }

        public ActionResult PTCFFPCreate()
        {
            return View();
        }

        public ActionResult PTCFFPEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de de Conceptos y Fórmulas \ Concepto \ Configuracion de afecciones 5ta Categoria, Se Abrevia <PTCFCA5>
        public ActionResult PTCFCA5Index()
        {
            return View();
        }

        // Tablas de de Conceptos y Fórmulas \ Concepto \ Columnas de Planilla, Se Abrevia <PTCCP>
        public ActionResult PTCCPIndex()
        {
            return View();
        }

        public ActionResult PTCCPCreate()
        {
            return View();
        }

        public ActionResult PTCCPEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de de Conceptos y Fórmulas \ Concepto \ Mantenimiento de Datos Informativos, Se Abrevia <PTCMDI>
        public ActionResult PTCMDIIndex()
        {
            return View();
        }

        public ActionResult PTCMDICreate()
        {
            return View();
        }

        public ActionResult PTCMDIEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de de Conceptos y Fórmulas \ Fórmulas \ Vacaciones, Se Abrevia <PTCV>
        public ActionResult PTCVIndex()
        {
            return View();
        }

        public ActionResult PTCVCreate()
        {
            return View();
        }

        public ActionResult PTCVEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de de Conceptos y Fórmulas \ Fórmulas \ Gratificaciones, Se Abrevia <PTCG>
        public ActionResult PTCGIndex()
        {
            return View();
        }

        public ActionResult PTCGCreate()
        {
            return View();
        }

        public ActionResult PTCGEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de de Conceptos y Fórmulas \ Fórmulas \ CTS / Liquidacion, Se Abrevia <PTCCL>
        public ActionResult PTCCLIndex()
        {
            return View();
        }

        public ActionResult PTCCLCreate()
        {
            return View();
        }

        public ActionResult PTCCLEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }

        // Tablas de de Conceptos y Fórmulas \ Fórmulas \ Utilidades, Se Abrevia <PTCU>
        public ActionResult PTCUIndex()
        {
            return View();
        }

        public ActionResult PTCUCreate()
        {
            return View();
        }

        public ActionResult PTCUEdit(string Codigo)
        {
            Modelo.CODIGO = Codigo;
            return View(Modelo);
        }
    }
}