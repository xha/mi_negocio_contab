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
using IronPdf;
using System.IO;

namespace Inicio.Controllers
{
    public class PProcesoController : Controller
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
        // GET: PProceso
        public ActionResult Index()
        {
            return View();
        }
        /**************************************************************************************************************/
        //CRONOGRAMA
        [HttpGet]
        public ActionResult Cronograma(string parametro1)
        {
            return PartialView("_Cronograma");
        }

        //Selector de Trabajadores
        [HttpGet]
        public ActionResult SelectorTrabajadores(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_SelectorTrabajadores");
        }

        //Selector de Trabajadores
        [HttpGet]
        public ActionResult CCCAdelanto(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CCCAdelanto");
        }
        
        /**************************************************************************************************************/
        //APERTURA
        /**************************************************************************************************************/
        // Apertura \ Mes de Trabajo, Se Abrevia <PAMT>
        public ActionResult PAMTIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridMesesActivos()
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
                new PMaestraModel { CODIGO = "01", NOMBRE= "ENERO 2019", FECHA = "31/01/2019", MES = 1, ANIO = 2019, DESCRIPCION = "Enero".ToUpper(), ESTATUS = "A" },
                new PMaestraModel { CODIGO = "02", NOMBRE= "FEBRERO 2019", FECHA = "28/02/2019", MES = 2, ANIO = 2019, DESCRIPCION = "Febrero".ToUpper(), ESTATUS = "C" },
                new PMaestraModel { CODIGO = "03", NOMBRE= "MARZO 2019", FECHA = "31/03/2019", MES = 3, ANIO = 2019, DESCRIPCION = "Mazo".ToUpper(), ESTATUS = "C" },
                new PMaestraModel { CODIGO = "04", NOMBRE= "ABRIL 2019", FECHA = "30/04/2019", MES = 4, ANIO = 2019, DESCRIPCION = "abril".ToUpper(), ESTATUS = "A" },
                new PMaestraModel { CODIGO = "05", NOMBRE= "NOVIEMBRE 2019", FECHA = "30/11/2019", MES = 11, ANIO = 2019, DESCRIPCION = "noviembre".ToUpper(), ESTATUS = "A" },
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
                new PMaestraModel { CODIGO="1", CODIGO_TRABAJADOR = "AAJ001", NOMBRE = "AGUILAR ABANTO JUAN MAXIMILIANO", NOMBRE_AREA = "Administración", DEPARTAMENTO = "02 :  Administración", CARGO = "Auxiliar de Administración", BASICO = 1000.00, DOCUMENTO = "43459099", FECHA_INGRESO = "01/02/2013", CENTRO_COSTO = "Administración", CODIGO_CENTRO = "001", CODIGO_AREA = "02", NUMERO_FICHA = "", CARNET_SEGURO = "8602171AIANJ001", FONDO_PENSION = "PM", ASIGNACION_FAM = 0, FECHA_CESE = "", CODIGO_ALTERNO = "", CODIGO_TIPO = "21", SITUACION = 1, CODIGO_SCTR = "NONE", RUC_EPS = "", AFP = "PRIMA", BANCO = "BCP", CUENTA_BANCO = "19345699978955", TIPO_DOCUMENTO = "01", NO_DECLARA = "NO", NO_CALCULA = "NO", DIRECCION = "JR. ALAMOS 925", SEXO = "MASCULINO", MONEDA = "$" },
                new PMaestraModel { CODIGO="2", CODIGO_TRABAJADOR = "BAJ001", NOMBRE = "JOSE MOTA", NOMBRE_AREA = "Sistemas", DEPARTAMENTO = "01 :  Soporte Técnico", CARGO = "Soporte", BASICO = 5000.00, DOCUMENTO = "12345678", FECHA_INGRESO = "10/11/2015", CENTRO_COSTO = "Administración", CODIGO_CENTRO = "002", CODIGO_AREA = "03", NUMERO_FICHA = "", CARNET_SEGURO = "9603171BIABJ002", FONDO_PENSION = "PM", ASIGNACION_FAM = 0, FECHA_CESE = "", CODIGO_ALTERNO = "", CODIGO_TIPO = "21", SITUACION = 1, CODIGO_SCTR = "NONE", RUC_EPS = "", AFP = "PRIMA", BANCO = "BCP", CUENTA_BANCO = "19345699978955", TIPO_DOCUMENTO = "01", NO_DECLARA = "NO", NO_CALCULA = "NO", DIRECCION = "AV PRINCIPAL", SEXO = "MASCULINO", MONEDA = "S/." },
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

        // Apertura \ Cronogramas de Pago, Se Abrevia <PACP>
        public ActionResult PACPIndex()
        {
            return View();
        }

        // Apertura \ Adelanto de Remuneraciones, Se Abrevia <PAAQ>
        public ActionResult PAAQIndex()
        {
            return View();
        }

        // Apertura \ Cerrrar y abrir cronogramas, Se Abrevia <PACA>
        public ActionResult PACAIndex()
        {
            return View();
        }

        public string RenderRazorViewToString(string viewName)
        {
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public void AccionPdf(string url)
        {
            var Renderer = new HtmlToPdf();
            Renderer.PrintOptions.PrintHtmlBackgrounds = true;
            Renderer.PrintOptions.PaperSize = PdfPrintOptions.PdfPaperSize.A4;
            Renderer.PrintOptions.PaperOrientation = PdfPrintOptions.PdfPaperOrientation.Landscape;
            Renderer.PrintOptions.Header = new SimpleHeaderFooter() { CenterText = "{url}" };
            Renderer.PrintOptions.Footer = new HtmlHeaderFooter() { HtmlFragment = "<div style='text-align:right'><em style='color:pink'>page {page} of {total-pages}</em></div>" };

            //var PDF = Renderer.RenderUrlAsPdf("https://www.nuget.org/packages/IronPdf/");
            var pagina = RenderRazorViewToString(url);
            //var PDF = Renderer.RenderHTMLFileAsPdf("PDFAperturaMes");
            var PDF = Renderer.RenderHtmlAsPdf(pagina);
            //RenderRazorViewToString
            var OutputPath = url+".pdf";
            PDF.SaveAs(OutputPath);

            // This neat trick opens our PDF file so we can see the result
            System.Diagnostics.Process.Start(OutputPath);
        }

        /**************************************************************************************************************/
        //PDF
        /**************************************************************************************************************/
        public ActionResult __PDFAperturaMes()
        {
            return View();
        }

        /**************************************************************************************************************/
        // Ingresos y Egresos Programados (Ctas. corrientes) \ Mantenimiento Cuentas Corrientes, Se Abrevia <PIMCC>
        public ActionResult PIMCCIndex()
        {
            return View();
        }

        //EDITAR CUENTA CORRIENTE
        [HttpGet]
        public ActionResult EditarCuenta(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_EditarCuenta");
        }
        
        //CUENTAS CORRIENTES PROGRAMADAS
        [HttpGet]
        public ActionResult CtaCteProgramada(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CtaCteProgramada");
        }

        //Pagos por Banco
        [HttpGet]
        public ActionResult PagosPorBanco(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_PagosPorBanco");
        }

        // Ingresos y Egresos Programados (Ctas. corrientes) \ Registro de Bonos, Se Abrevia <PIRB>
        public ActionResult PIRBIndex()
        {
            return View();
        }
        
        //Editar Registro de Bonos
        [HttpGet]
        public ActionResult PIRBDetalle(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_PIRBDetalle");
        }

        // Ingresos y Egresos Adicionales (Movimientos) \ Registrar Ingresos de Movimientos, Se Abrevia <PIRIM>
        public ActionResult PIRIMIndex()
        {
            return View();
        }

        // Ingresos y Egresos Adicionales (Movimientos) \ Importación de Ingresos de  Movimiento (*.xls), Se Abrevia <PIIIM>
        public ActionResult PIIIMIndex()
        {
            return View();
        }

        /**************************************************************************************************************/
        //Quinta Categoría
        // Quinta Categoría \ Registrar Importes de 5ta Externa, Se Abrevia <PQRI>
        public ActionResult PQRIIndex()
        {
            return View();
        }

        // Quinta Categoría \ 5ta Categoría Manual, Se Abrevia <PQCM>
        public ActionResult PQCMIndex()
        {
            return View();
        }

        /**************************************************************************************************************/
        //Calcular Beneficios Sociales \ Vacaciones, Se Abrevia <PCBSV>
        public ActionResult PCBSVIndex()
        {
            return View();
        }

        //Editar Registro de Bonos
        [HttpGet]
        public ActionResult ProgramacionVacaciones(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_ProgramacionVacaciones");
        }

        //Calcular Beneficios Sociales \ Liquidación, Se Abrevia <PCBSL>
        public ActionResult PCBSLIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CTSDetalle(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CTSDetalle");
        }

        [HttpGet]
        public ActionResult LiquidacionTrabajadores(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_LiquidacionTrabajadores");
        }
        [HttpGet]
        public ActionResult CTSDDetalle(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CTSDDetalle");
        }

        [HttpGet]
        public ActionResult CTSDIExtraordinario(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CTSDIExtraordinario");
        }
        [HttpGet]
        public ActionResult CTSDetalleCTS(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CTSDetalleCTS");
        }
        [HttpGet]
        public ActionResult POBCLiquid(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_POBCLiquid");
        }
        // programacion \ Calcular Beneficios Sociales \ Gratificacion, Se Abrevia <PCBSGIndex>

        public ActionResult PCBSGIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CTSEditarCG(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CTSEditarCG");
        }
        [HttpGet]
        public ActionResult PCBGFormGrat(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_PCBGFormGrat");
        }
        [HttpGet]
        public ActionResult POBCAdelantL(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_POBCAdelantL");
        }

        // programacion \ Calcular Beneficios Sociales \ Calculo  y Deposito, Se Abrevia <PCBSGIndex>
        public ActionResult PCBSCDIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CTSCalSTC(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CTSCalSTC");
        }
        
        [HttpGet]
        public ActionResult CTSConfDias(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CTSConfDias");
        }



        // programacion \ Calcular Beneficios Sociales \ Calculo de Utilidades <PCBCalUtilindex>


        [HttpGet]
        public ActionResult PCBCalUtilindex(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("PCBCalUtilindex");
        }

        [HttpGet]
        public ActionResult CTSUtilidadesA(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CTSUtilidadesA");
        }


        // programacion \ Calcular Beneficios Sociales \ Calculo de plantilla de remuneracion <PCBCalUtilindex>
        [HttpGet]
        public ActionResult PCCalcuPlantRem(string parametro1)
        {
            return View();
        }


        [HttpGet]
        public ActionResult PCFormatPlan(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_PCFormTPLan");
        }

        [HttpGet]
        public ActionResult POCEditRemun(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_POCEditRemun");
        }

        [HttpGet]
        public ActionResult POCPlantREm(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_POCPlantREm");
        }
        // Planilla----------------------------------------------------------=========================






        

    }
}