using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inicio.Controllers
{
    public class UtilitariosController : Controller
    {
        private UtilitariosModel Modelo = new UtilitariosModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        /********************************************************************************************************************************/
        // GET: Utilitarios/Color
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult Color(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Colores");
        }

        [HttpPost]
        public JsonResult GridColor()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<UtilitariosModel> Listado = new List<UtilitariosModel>()
            {
                new UtilitariosModel { CodigoColor = "01", DescripcionColor = "azul".ToUpper() },
                new UtilitariosModel { CodigoColor = "02", DescripcionColor = "rojo".ToUpper() },
                new UtilitariosModel { CodigoColor = "03", DescripcionColor = "amarillo".ToUpper() },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionColor.Contains(searchValue)
                             select new { N.CodigoColor, N.DescripcionColor });
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
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        // GET: Utilitarios/TipoDocumento
        [HttpGet]
        public ActionResult TipoDocumento(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_TipoDocumento");
        }

        [HttpPost]
        public JsonResult GridTipoDocumento()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<UtilitariosModel> Listado = new List<UtilitariosModel>()
            {
                new UtilitariosModel {Codigo="AB", Descripcion="Nota de Abono".ToUpper() },
                new UtilitariosModel {Codigo="BD", Descripcion="Boleta de Depósito".ToUpper() },
                new UtilitariosModel {Codigo="BV", Descripcion="Boleta de Venta".ToUpper() },
                new UtilitariosModel {Codigo="CA", Descripcion="Nota de Cargo".ToUpper() },
                new UtilitariosModel {Codigo="CH", Descripcion="Cheque".ToUpper() },
                new UtilitariosModel {Codigo="CT", Descripcion="Cotización".ToUpper() },
                new UtilitariosModel {Codigo="FT", Descripcion="Factura".ToUpper() },
                new UtilitariosModel {Codigo="GS", Descripcion="Guía de Remisión".ToUpper() },
                new UtilitariosModel {Codigo="LI", Descripcion="Liquidaciones".ToUpper() },
                new UtilitariosModel {Codigo="LT", Descripcion="Letra".ToUpper() },
                new UtilitariosModel {Codigo="NA", Descripcion="Nota de Abono".ToUpper() },
                new UtilitariosModel {Codigo="NC", Descripcion="Nota de Crédito".ToUpper() },
                new UtilitariosModel {Codigo="ND", Descripcion="Nota de Débito".ToUpper() },
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
        // GET: Utilitarios/TipoDescuento
        [HttpGet]
        public ActionResult TipoDescuento(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_TipoDescuento");
        }

        [HttpPost]
        public JsonResult GridTipoDescuento()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<UtilitariosModel> Listado = new List<UtilitariosModel>()
            {
                new UtilitariosModel {Codigo="D1", Descripcion="Descuento 1".ToUpper() },
                new UtilitariosModel {Codigo="D2", Descripcion="Descuento 2".ToUpper() },
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
        // GET: Utilitarios/Prefijo
        [HttpGet]
        public ActionResult Prefijo(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Prefijo");
        }

        [HttpPost]
        public JsonResult GridPrefijo()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<UtilitariosModel> Listado = new List<UtilitariosModel>()
            {
                new UtilitariosModel {Codigo="A", Descripcion="Prefijo A".ToUpper() },
                new UtilitariosModel {Codigo="B", Descripcion="Prefijo B".ToUpper() },
                new UtilitariosModel {Codigo="C", Descripcion="Prefijo C".ToUpper() },
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
        // GET: Utilitarios/Notas de Ingreso
        [HttpGet]
        public ActionResult NotasIngreso(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_NotasIngreso");
        }

        [HttpPost]
        public JsonResult GridNotasIngreso()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<UtilitariosModel> Listado = new List<UtilitariosModel>()
                {
                    new UtilitariosModel { Codigo = "001", Descripcion = "Nota A".ToUpper() },
                    new UtilitariosModel { Codigo = "002", Descripcion = "Nota B".ToUpper() },
                    new UtilitariosModel { Codigo = "003", Descripcion = "Nota C".ToUpper() },
                    new UtilitariosModel { Codigo = "004", Descripcion = "Nota D".ToUpper() },
                    new UtilitariosModel { Codigo = "005", Descripcion = "Nota E".ToUpper() },
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
        // GET: Utilitarios/TipoMoneda
        [HttpGet]
        public ActionResult TipoMoneda(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_TipoMoneda");
        }

        [HttpPost]
        public JsonResult GridTipoMoneda()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "ME", Descripcion = "Moneda Extranjera".ToUpper() });
            Results.Add(new { Codigo = "MN", Descripcion = "Moneda Nacional".ToUpper() });

            int totalRecords = Results.Count();

            var jsonData = new
            {
                data = Results,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************************************/
        // GET: Utilitarios/TipoPrecio
        [HttpGet]
        public ActionResult TipoPrecio(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_TipoPrecio");
        }

        [HttpPost]
        public JsonResult GridTipoPrecio()
        {
            List<object> Results = new List<object>();

            Results.Add(new { CodigoTipoPrecio = "01", DescripcionTipoPrecio = "Al Mayor".ToUpper() });
            Results.Add(new { CodigoTipoPrecio = "02", DescripcionTipoPrecio = "Al detal".ToUpper() });

            int totalRecords = Results.Count();

            var jsonData = new
            {
                data = Results,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************************************/
        // GET: Utilitarios/TipoTransaccion
        [HttpGet]
        public ActionResult TipoTransaccion(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_TipoTransaccion");
        }

        [HttpPost]
        public JsonResult GridTipoTransaccion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<UtilitariosModel> Listado = new List<UtilitariosModel>()
            {
                new UtilitariosModel {Codigo="AE", Descripcion="articulo ensamblado".ToUpper() },
                new UtilitariosModel {Codigo="AK", Descripcion="n/i x armado de kits".ToUpper() },
                new UtilitariosModel {Codigo="CC", Descripcion="ingreso por cambio de codigo".ToUpper() },
                new UtilitariosModel {Codigo="CI", Descripcion="compra productos importados".ToUpper() },
                new UtilitariosModel {Codigo="CL", Descripcion="compras locales".ToUpper() },
                new UtilitariosModel {Codigo="DK", Descripcion="n/i x desarmado de kits".ToUpper() },
                new UtilitariosModel {Codigo="DV", Descripcion="devolucion del cliente".ToUpper() },
                new UtilitariosModel {Codigo="EP", Descripcion="elaboracion de producto terminado".ToUpper() },
                new UtilitariosModel {Codigo="FC", Descripcion="transacciones de compras".ToUpper() },
                new UtilitariosModel {Codigo="II", Descripcion="inventario inicial".ToUpper() },
                new UtilitariosModel {Codigo="IN", Descripcion="ingreso por inventario inicial".ToUpper() },
                new UtilitariosModel {Codigo="IT", Descripcion="ingreso a tienda".ToUpper() },
                new UtilitariosModel {Codigo="MI", Descripcion="ingreso por mermas".ToUpper() },
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
        // GET: Utilitarios/TipoGastos
        [HttpGet]
        public ActionResult TipoGastos(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_TipoGastos");
        }

        [HttpPost]
        public JsonResult GridTipoGastos()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<UtilitariosModel> Listado = new List<UtilitariosModel>()
                {
                    new UtilitariosModel { Codigo = "001", Descripcion = "Gasto A".ToUpper() },
                    new UtilitariosModel { Codigo = "002", Descripcion = "Gasto B".ToUpper() },
                    new UtilitariosModel { Codigo = "003", Descripcion = "Gasto C".ToUpper() },
                    new UtilitariosModel { Codigo = "004", Descripcion = "Gasto D".ToUpper() },
                    new UtilitariosModel { Codigo = "005", Descripcion = "Gasto E".ToUpper() },
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
        // GET: Utilitarios/Bancos
        [HttpGet]
        public ActionResult Bancos(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Bancos");
        }

        [HttpPost]
        public JsonResult GridBancos()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<UtilitariosModel> Listado = new List<UtilitariosModel>()
                {
                    new UtilitariosModel { Codigo = "001", Descripcion = "Banco A".ToUpper() },
                    new UtilitariosModel { Codigo = "002", Descripcion = "Banco B".ToUpper() },
                    new UtilitariosModel { Codigo = "003", Descripcion = "Banco C".ToUpper() },
                    new UtilitariosModel { Codigo = "004", Descripcion = "Banco D".ToUpper() },
                    new UtilitariosModel { Codigo = "005", Descripcion = "Banco E".ToUpper() },
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
        // GET: Utilitarios/Bancos
        [HttpGet]
        public ActionResult TipoTarjetas(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_TipoTarjetas");
        }

        [HttpPost]
        public JsonResult GridTipoTarjetas()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<UtilitariosModel> Listado = new List<UtilitariosModel>()
                {
                    new UtilitariosModel { Codigo = "001", Descripcion = "DINNERS".ToUpper() },
                    new UtilitariosModel { Codigo = "002", Descripcion = "Master Cards".ToUpper() },
                    new UtilitariosModel { Codigo = "003", Descripcion = "Visa".ToUpper() },
                    new UtilitariosModel { Codigo = "004", Descripcion = "American Express".ToUpper() },
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
        // GET: Utilitarios Index
        public ActionResult Index()
        {
            Session["MenuColor"] = "darkgrey";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_almacenes = 3;
            ViewBag.total_empresas = 5;
            ViewBag.tasa_cambio = 250.00;
            ViewBag.almacen_1 = 25;
            ViewBag.almacen_2 = 10;
            ViewBag.almacen_3 = 15;

            int i;
            int[] dias = new int[31];
            double[] tasa_diaria = new double[31];

            for (i = 1; i < 31; i++) dias[i] = i;
            ViewData["dias"] = dias;

            for (i = 1; i < 31; i++)
            {
                if (i < 10) tasa_diaria[i] = (i * 100) / 5;
                if ((i > 9) & (i<20)) tasa_diaria[i] = (i * 100) / 10;
                if (i > 19) tasa_diaria[i] = (i * 100) / 15;
            }
            ViewData["tasa_diaria"] = tasa_diaria;

            return View();
        }

        // Administración de Empresa, Se Abrevia <AE>
        public ActionResult AEIndex()
        {
            return View();
        }

        // GET: Empresa
        public ActionResult AECreate()
        {
            return View();
        }

        // GET: Empresa
        public ActionResult AEEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
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

            List<UtilitariosModel> Listado = new List<UtilitariosModel>()
            {
                new UtilitariosModel { Codigo = "01", RUCEmpresa = "12345678", Descripcion = "Letra A".ToUpper(), DescripcionComercial = "Empresa Letra A", Telefono = "111-112233" },
                new UtilitariosModel { Codigo = "02", RUCEmpresa = "87654321", Descripcion = "Letra B".ToUpper(), DescripcionComercial = "Empresa Letra B", Telefono = "222-112233" },
                new UtilitariosModel { Codigo = "03", RUCEmpresa = "56514156", Descripcion = "Letra C".ToUpper(), DescripcionComercial = "Empresa Letra C", Telefono = "333-112233" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.DescripcionComercial, N.Descripcion, N.RUCEmpresa, N.Telefono });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Interface con Software Contable\ Ubicación de Datos de Contabilidad, Se Abrevia <ISCUDC>
        public ActionResult ISCUDCIndex()
        {
            return View();
        }

        // Cambiar Empresa Activa, Se Abrevia <CEA>
        public ActionResult CEAIndex()
        {
            return View();
        }

        // Cambiar Almacén Activo, Se Abrevia <CAA>
        public ActionResult CAAIndex()
        {
            return View();
        }

        // Cambiar Fecha de Trabajo, Se Abrevia <CFT>
        public ActionResult CFTIndex()
        {
            return View();
        }

        // Cambiar Fondo de Pantalla, Se Abrevia <CFP>
        public ActionResult CFPIndex()
        {
            return View();
        }

        // Declaración Jurada Informativa, Se Abrevia <DJI>
        public ActionResult DJIIndex()
        {
            return View();
        }

        // Resumen de Comprobantes Impresos, Se Abrevia <RCI>
        public ActionResult RCIIndexIndex()
        {
            return View();
        }

        // Sincronización de Tipo de Cambio\Sincroniza Tipo de Cambio de Almacenes, Se Abrevia <STCA>
        public ActionResult STCAIndex()
        {
            return View();
        }

        // Sincronización de Tipo de Cambio\Sincroniza Tipo de Cambio de Compras / Ventas, Se Abrevia <STCCV>
        public ActionResult STCCVIndex()
        {
            return View();
        }

        // UUtilidad de Base de Datos, Se Abrevia <BD>
        public ActionResult BDIndex()
        {
            return View();
        }
    }
}
