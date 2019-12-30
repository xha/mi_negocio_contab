using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;

namespace Inicio.Controllers
{
    public class PuntoVentaController : Controller
    {
        private FacturacionModel Modelo = new FacturacionModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult DatosCliente()
        {
            return PartialView("_DatosCliente");
        }
        /**************************************************************************************************************/
        //Listado de Puntos de Venta
        [HttpGet]
        public ActionResult PuntosVenta(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_PuntosVenta");
        }

        [HttpPost]
        public JsonResult GridPuntosVenta()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<FacturacionModel> Listado = new List<FacturacionModel>()
            {
                new FacturacionModel { Codigo = "001", Descripcion = "OFICINA PRINCIPAL".ToUpper()  },
                new FacturacionModel { Codigo = "003", Descripcion = "OFICINA B".ToUpper() },
                new FacturacionModel { Codigo = "002", Descripcion = "OFICINA C".ToUpper() },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.Codigo });
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
        //Listado de Articulos en Otros Almacenes
        [HttpGet]
        public ActionResult ArticulosOtroAlmacen(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_ArticulosOtroAlmacen");
        }

        [HttpGet]
        public ActionResult TransferenciaAlmacen(string CodigoProducto)
        {
            ViewBag.accion = CodigoProducto;
            return PartialView("_TransferenciaAlmacen");
        }

        [HttpPost]
        public JsonResult GridArticulosOtroAlmacen()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<FacturacionModel> Listado = new List<FacturacionModel>()
            {
                new FacturacionModel { Codigo = "001", CodigoAlmacen = "Almacen a".ToUpper(), Descripcion = "Artículo A", Stock = 5, CodigoUnidadMedida = "Unid" },
                new FacturacionModel { Codigo = "003", CodigoAlmacen = "Almacen B".ToUpper(), Descripcion = "Artículo A", Stock = 5, CodigoUnidadMedida = "Unid" },
                new FacturacionModel { Codigo = "002", CodigoAlmacen = "Almacen C".ToUpper(), Descripcion = "Artículo A", Stock = 5, CodigoUnidadMedida = "Unid" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.Codigo, N.CodigoAlmacen, N.Stock, N.CodigoUnidadMedida });

            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //Listado de Articulos para la Venta
        [HttpGet]
        public ActionResult ArticulosVenta(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_ArticulosVenta");
        }

        //Detalle de Articulos para la Venta
        [HttpGet]
        public ActionResult DetalleArticulosVenta(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_DetalleArticulosVenta");
        }

        //Datos del Cliente para la venta
        [HttpGet]
        public ActionResult FacturaDatosCliente(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_FacturaDatosCliente");
        }

        //Detalle de Facturacion para la Venta
        [HttpGet]
        public ActionResult DetalleFacturacion(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_DetalleFacturacion");
        }
        /**************************************************************************************************************/
        // GET: PuntoVenta
        public ActionResult Index()
        {
            Session["MenuColor"] = "PaleVioletRed";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_transferencia = "1.250.240,00";
            ViewBag.total_efectivo = "150.240,00";
            ViewBag.total_deposito = "3.150.310,00";
            ViewBag.total_cheque = "50.000,00";
            ViewBag.total_punto = "2.500.000,00";
            ViewBag.total= "7.100.790,00";

            return View();
        }

        /**************************************************************************************************************/
        //Ventas, Se Abrevia <PVV>
        // GET: Punto de Venta/PVVIndex
        public ActionResult PVVIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridPVVDetalle()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<FacturacionModel> Listado = new List<FacturacionModel>()
            {
                new FacturacionModel { Codigo = "001", Descripcion = "Producto A".ToUpper(), Lote = "1010", CodigoUnidadMedida = "Und", Precio = 200.44, Cantidad = 50, Total = 550.00, ImporteIGV = 20.00, DescuentoUnitario = 0.00, IGV = 16.00, PrecioVenta = 100.00, Marca = "", Familia = "Familia A" },
                new FacturacionModel { Codigo = "002", Descripcion = "Producto B".ToUpper(), Lote = "2010", CodigoUnidadMedida = "Und", Precio = 220.44, Cantidad = 10, Total = 650.00, ImporteIGV = 20.00, DescuentoUnitario = 0.00, IGV = 16.00, PrecioVenta = 100.00, Marca = "", Familia = "Familia A" },
                new FacturacionModel { Codigo = "003", Descripcion = "Producto C".ToUpper(), Lote = "1310", CodigoUnidadMedida = "Und", Precio = 203.44, Cantidad = 20, Total = 570.00, ImporteIGV = 20.00, DescuentoUnitario = 0.00, IGV = 16.00, PrecioVenta = 100.00, Marca = "", Familia = "Familia A" },
                new FacturacionModel { Codigo = "004", Descripcion = "Producto D".ToUpper(), Lote = "1040", CodigoUnidadMedida = "Und", Precio = 400.44, Cantidad = 30, Total = 558.00, ImporteIGV = 20.00, DescuentoUnitario = 0.00, IGV = 16.00, PrecioVenta = 100.00, Marca = "", Familia = "Familia A" },
                new FacturacionModel { Codigo = "005", Descripcion = "Producto E".ToUpper(), Lote = "1016", CodigoUnidadMedida = "Und", Precio = 250.44, Cantidad = 40, Total = 950.00, ImporteIGV = 20.00, DescuentoUnitario = 0.00, IGV = 16.00, PrecioVenta = 100.00, Marca = "", Familia = "Familia A" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.CodigoUnidadMedida, N.Codigo, N.Precio, N.Cantidad, N.Total, N.ImporteIGV, N.DescuentoUnitario, N.IGV, N.PrecioVenta, N.Lote, N.Marca, N.Familia });
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
        //Ventas Multiples, Se Abrevia <PVVM>
        // GET: Punto de Venta/PVVMIndex
        public ActionResult PVVMIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Consulta de Ventas, Se Abrevia <PVCV>
        // GET: Punto de Venta/PVCVIndex
        public ActionResult PVCVIndex()
        {
            return View();
        }

        // GET: Punto de Venta/PVCVDetalle/5
        public ActionResult PVCVDetalle(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }
        /**************************************************************************************************************/
        //Cuadre de Punto de Venta, Se Abrevia <PVCPV>
        // GET: Punto de Venta/PVCPVIndex
        public ActionResult PVCPVIndex()
        {
            return View();
        }
    }
}
