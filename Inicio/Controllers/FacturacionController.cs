using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;

namespace Inicio.Controllers
{
    public class FacturacionController : Controller
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
        //MODAL DE LOS ARTICULOS DETALLANDO SUS PRECIOS
        // GET: Facturacion/ArticulosVenta/5
        public ActionResult ArticulosVenta(FacturacionModel Modelo)
        {
            return PartialView("_ArticulosVenta");
        }

        [HttpPost]
        public JsonResult GridArticulosVenta()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<FacturacionModel> Listado = new List<FacturacionModel>()
            {
                new FacturacionModel { CodigoProducto = "01", CodigoUnidadMedida = "Und", DescripcionProducto = "Producto 1", Stock = 50, CodigoAlmacen = "Almacen A"  },
                new FacturacionModel { CodigoProducto = "02", CodigoUnidadMedida = "Lts", DescripcionProducto = "Producto 2", Stock = 1, CodigoAlmacen = "Almacen A" },
                new FacturacionModel { CodigoProducto = "03", CodigoUnidadMedida = "Und", DescripcionProducto = "Producto 3", Stock = 5, CodigoAlmacen = "Almacen A" },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProducto.Contains(searchValue)
                             select new { N.CodigoProducto, N.DescripcionProducto, N.CodigoUnidadMedida, N.Stock, N.CodigoAlmacen });
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
        // GET: Facturacion
        public ActionResult Index()
        {
            Session["MenuColor"] = "darkgreen";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_ventas = 240000;
            ViewBag.total_ImporteIGV = 205;
            ViewBag.total_ticket = 1200; 
            ViewBag.nro_ventas = 53;
            ViewBag.nro_devoluciones = 9;
            ViewBag.nro_notas_entrega = 5;
            ViewBag.nro_presupuestos = 12;
            ViewBag.total_vendedores = 5;
            ViewBag.total_CodigoUnidadMedidaes = 3;
            ViewBag.regiones = 3;

            ViewData["vendedor_1"] = new double[] { 2000.00,5000.00,7000.00,11000.00,14000.00,15000.00, 7000.00, 11000.00, 14000.00, 15000.00, 14000.00, 15000.00 };
            ViewData["vendedor_2"] = new double[] { 3000.00, 4000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 15000.00, 14000.00, 25000.00, 10000.00, 21000.00 };
            ViewData["vendedor_3"] = new double[] { 4000.00, 3000.00, 8000.00, 15000.00, 14000.00, 5000.00, 17000.00, 8000.00, 14000.00, 35000.00, 34000.00, 1000.00 };
            ViewData["vendedor_4"] = new double[] { 5000.00, 2000.00, 7500.00, 12000.00, 12000.00, 35000.00, 27000.00, 1000.00, 14000.00, 5000.00, 24000.00, 15900.00 };
            ViewData["vendedor_5"] = new double[] { 6000.00, 1000.00, 7900.00, 12000.00, 12000.00, 25000.00, 5000.00, 12000.00, 14000.00, 5500.00, 4000.00, 18000.00 };
            ViewData["unidad_1"] = new double[] { 2000.00, 5000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 11000.00, 14000.00, 15000.00, 14000.00, 15000.00 };
            ViewData["unidad_2"] = new double[] { 3000.00, 4000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 15000.00, 14000.00, 25000.00, 10000.00, 21000.00 };
            ViewData["unidad_3"] = new double[] { 4000.00, 3000.00, 8000.00, 15000.00, 14000.00, 5000.00, 17000.00, 8000.00, 14000.00, 35000.00, 34000.00, 1000.00 };
            ViewData["region_1"] = new double[] { 2000.00, 5000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 11000.00, 14000.00, 15000.00, 14000.00, 15000.00 };
            ViewData["region_2"] = new double[] { 3000.00, 4000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 15000.00, 14000.00, 25000.00, 10000.00, 21000.00 };
            ViewData["region_3"] = new double[] { 4000.00, 3000.00, 8000.00, 15000.00, 14000.00, 5000.00, 17000.00, 8000.00, 14000.00, 35000.00, 34000.00, 1000.00 };

            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
            return View();
        }
        /**************************************************************************************************************/
        //TRANSACCIONES
        /**************************************************************************************************************/
        //CRUD DE Transacciones / Comprobantes de Venta, Se Abrevia <TCV>
        // GET: Facturacion/TCVIndex
        public ActionResult TCVIndex()
        {
            return View();
        }

        // GET: Facturacion/TCVCreate
        public ActionResult TCVCreate()
        {
            return View();
        }

        // GET: Facturacion/TCVEdit/5
        public ActionResult TCVEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        //DETALLE DE LA COBRANZA PARA CONCLUIR LA VENTA
        // GET: Facturacion/TCVDetalle/5
        public ActionResult TCVDetalle(FacturacionModel Modelo)
        {
            return PartialView("_TCVDetalle");
        }

        //AGREGAR ARTICULOS AL GRID DE LA VENTA
        // GET: Facturacion/TCVNuevo/5
        public ActionResult TCVNuevo(FacturacionModel Modelo)
        {
            return PartialView("_TCVNuevo");
        }

        // POST: Facturacion/TCVDelete/5
        [HttpGet]
        public ActionResult TCVDelete(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("TCVIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridTCV()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<FacturacionModel> Listado = new List<FacturacionModel>()
            {
                new FacturacionModel { Codigo = "01", Documento = "001", FechaEmision = "15-01-2019", Descripcion = "Cliente A".ToUpper(), ImporteIGV = 1000.00, Moneda = "ME", Sit = "" },
                new FacturacionModel { Codigo = "02", Documento = "002", FechaEmision = "16-02-2019", Descripcion = "Cliente B".ToUpper(), ImporteIGV = 2000.00, Moneda = "ME", Sit = "" },
                new FacturacionModel { Codigo = "03", Documento = "003", FechaEmision = "18-03-2019", Descripcion = "Cliente C".ToUpper(), ImporteIGV = 3000.00, Moneda = "MN", Sit = "" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.Documento, N.ImporteIGV, N.FechaEmision, N.Moneda, N.Sit });
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
        public JsonResult GridTCVDetalle()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<FacturacionModel> Listado = new List<FacturacionModel>()
            {
                new FacturacionModel { CodigoProducto = "001", DescripcionProducto = "Producto A".ToUpper(), Lote = "1010", CodigoUnidadMedida = "Und", Precio = 200.44, Cantidad = 50, Total = 550.00, ImporteIGV = 20.00, DescuentoUnitario = 0.00, IGV = 16.00, PrecioVenta = 100.00, Marca = "", Familia = "Familia A" },
                new FacturacionModel { CodigoProducto = "002", DescripcionProducto = "Producto B".ToUpper(), Lote = "2010", CodigoUnidadMedida = "Und", Precio = 220.44, Cantidad = 10, Total = 650.00, ImporteIGV = 20.00, DescuentoUnitario = 0.00, IGV = 16.00, PrecioVenta = 100.00, Marca = "", Familia = "Familia A" },
                new FacturacionModel { CodigoProducto = "003", DescripcionProducto = "Producto C".ToUpper(), Lote = "1310", CodigoUnidadMedida = "Und", Precio = 203.44, Cantidad = 20, Total = 570.00, ImporteIGV = 20.00, DescuentoUnitario = 0.00, IGV = 16.00, PrecioVenta = 100.00, Marca = "", Familia = "Familia A" },
                new FacturacionModel { CodigoProducto = "004", DescripcionProducto = "Producto D".ToUpper(), Lote = "1040", CodigoUnidadMedida = "Und", Precio = 400.44, Cantidad = 30, Total = 558.00, ImporteIGV = 20.00, DescuentoUnitario = 0.00, IGV = 16.00, PrecioVenta = 100.00, Marca = "", Familia = "Familia A" },
                new FacturacionModel { CodigoProducto = "005", DescripcionProducto = "Producto E".ToUpper(), Lote = "1016", CodigoUnidadMedida = "Und", Precio = 250.44, Cantidad = 40, Total = 950.00, ImporteIGV = 20.00, DescuentoUnitario = 0.00, IGV = 16.00, PrecioVenta = 100.00, Marca = "", Familia = "Familia A" },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProducto.Contains(searchValue)
                             select new { N.DescripcionProducto, N.CodigoUnidadMedida, N.CodigoProducto, N.Precio, N.Cantidad, N.Total, N.ImporteIGV, N.DescuentoUnitario, N.IGV, N.PrecioVenta, N.Lote, N.Marca, N.Familia });
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
        //CRUD DE Transacciones / Digitación Rápida, Se Abrevia <TDR>
        // GET: Facturacion/TDRIndex
        public ActionResult TDRIndex()
        {
            return View();
        }

        // GET: Facturacion/TDRCreate
        public ActionResult TDRCreate()
        {
            return View();
        }

        // GET: Facturacion/TDREdit/5
        public ActionResult TDREdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // POST: Facturacion/TDRDelete/5
        [HttpGet]
        public ActionResult TDRDelete(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("TDRIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridTDR()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, Documento = "001", Fecha = "15-01-2019", Descripcion = "Cliente A", ImporteIGV = "1000.00", Moneda = "ME", Sit = "", Imprimir = "N" });
            Results.Add(new { Codigo = 2, Documento = "002", Fecha = "16-02-2019", Descripcion = "Cliente B", ImporteIGV = "2000.00", Moneda = "ME", Sit = "", Imprimir = "S" });
            Results.Add(new { Codigo = 3, Documento = "003", Fecha = "18-03-2019", Descripcion = "Cliente C", ImporteIGV = "3000.00", Moneda = "MN", Sit = "", Imprimir = "N" });

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
        //CRUD DE Transacciones / Notas de Pedido, Se Abrevia <TNP>
        // GET: Facturacion/TNPIndex
        public ActionResult TNPIndex()
        {
            return View();
        }

        // GET: Facturacion/TNPCreate
        public ActionResult TNPCreate()
        {
            return View();
        }

        // GET: Facturacion/TNPEdit/5
        public ActionResult TNPEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        //DETALLE DE LA COBRANZA PARA CONCLUIR LA NOTA DE PEDIDO
        // GET: Facturacion/TCVDetalle/5
        public ActionResult TNPDetalle(FacturacionModel Modelo)
        {
            return PartialView("_TNPDetalle");
        }

        //AGREGAR ARTICULOS AL GRID DE LA NOTA DE PEDIDO
        // GET: Facturacion/TNPNuevo/5
        public ActionResult TNPNuevo(FacturacionModel Modelo)
        {
            return PartialView("_TNPNuevo");
        }

        // POST: Facturacion/TNPDelete/5
        [HttpGet]
        public ActionResult TNPDelete(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("TNPIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridTNP()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, Documento = "001", Fecha = "15-01-2019", Descripcion = "Cliente A", ImporteIGV = "1000.00", Moneda = "ME", Sit = "" });
            Results.Add(new { Codigo = 2, Documento = "002", Fecha = "16-02-2019", Descripcion = "Cliente B", ImporteIGV = "2000.00", Moneda = "ME", Sit = "" });
            Results.Add(new { Codigo = 3, Documento = "003", Fecha = "18-03-2019", Descripcion = "Cliente C", ImporteIGV = "3000.00", Moneda = "MN", Sit = "" });

            int totalRecords = Results.Count();

            var jsonData = new
            {
                data = Results,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GridTNPDetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "001", Descripcion = "Producto A", Lote = "1010", Und = "Und", PUnitario = "200.44", Cantidad = "50", Total = "550.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "002", Descripcion = "Producto B", Lote = "2010", Und = "Und", PUnitario = "220.44", Cantidad = "10", Total = "650.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "003", Descripcion = "Producto C", Lote = "1310", Und = "Und", PUnitario = "203.44", Cantidad = "20", Total = "570.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "004", Descripcion = "Producto D", Lote = "1040", Und = "Und", PUnitario = "400.44", Cantidad = "30", Total = "558.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "005", Descripcion = "Producto E", Lote = "1016", Und = "Und", PUnitario = "250.44", Cantidad = "40", Total = "950.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });

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
        //CRUD DE Transacciones / Cotizaciones, Se Abrevia <TC>
        // GET: Facturacion/TCIndex
        public ActionResult TCIndex()
        {
            return View();
        }

        //MODAL DE LOS ARTICULOS DETALLANDO SUS PRECIOS
        // GET: Facturacion/ArticulosCotizacion/5
        public ActionResult ArticulosCotizacion(FacturacionModel Modelo)
        {
            return PartialView("_ArticulosCotizacion");
        }

        //MODAL DE COMENTARIO
        // GET: Facturacion/TCDetalle/5
        public ActionResult TCDetalle(FacturacionModel Modelo)
        {
            return PartialView("_TCDetalle");
        }

        // GET: Facturacion/TCDetalleArticulosCotizacion/5
        public ActionResult TCDetalleArticulosCotizacion(FacturacionModel Modelo)
        {
            return PartialView("_TCDetalleArticulosCotizacion");
        }

        // GET: Facturacion/TCCreateCotizacion
        public ActionResult TCCreateCotizacion()
        {
            return View();
        }

        [HttpGet]
        // GET: Facturacion/TCCreateFactura
        public ActionResult TCCreateFactura(string ruta)
        {
            ViewBag.ruta = ruta;
            //return View("TCCreateFactura", new { ruta = ruta });
            return View();
        }

        //AGREGAR DATOS DEL CLIENTE A LA COTIZACION
        // GET: Facturacion/TCDatosCliente/5
        public ActionResult TCDatosCliente(string parametro1)
        {
            ViewBag.bandera = parametro1;
            return PartialView("_TCDatosCliente");
        }

        //AGREGAR DATOS DEL CLIENTE A LA FACTURA
        // GET: Facturacion/TCFacturaDatosCliente/5
        public ActionResult TCFacturaDatosCliente(FacturacionModel Modelo)
        {
            return PartialView("_TCFacturaDatosCliente");
        }


        //DETALLE DE PAGO DE FACTURACION
        // GET: Facturacion/TCDetalleFacturacion/5
        public ActionResult TCDetalleFacturacion(FacturacionModel Modelo)
        {
            return PartialView("_TCDetalleFacturacion");
        }
        // GET: Facturacion/TCEditCotizacion/5
        public ActionResult TCEditCotizacion(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }
        // GET: Facturacion/TCCopiarCotizacion/5
        public ActionResult TCCopiarCotizacion(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // POST: Facturacion/TCDelete/5
        [HttpGet]
        public ActionResult TCDelete(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("TCIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridTC()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, Documento = "001", Fecha = "15-01-2019", Descripcion = "Cliente A", ImporteIGV = "1000.00", Moneda = "ME", Sit = "" });
            Results.Add(new { Codigo = 2, Documento = "002", Fecha = "16-02-2019", Descripcion = "Cliente B", ImporteIGV = "2000.00", Moneda = "ME", Sit = "" });
            Results.Add(new { Codigo = 3, Documento = "003", Fecha = "18-03-2019", Descripcion = "Cliente C", ImporteIGV = "3000.00", Moneda = "MN", Sit = "" });

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
        //CONSULTAS
        /**************************************************************************************************************/
        //CRUD DE Consulta / Consulta de Documentos, Se Abrevia <CCD>
        // GET: Facturacion/CCDIndex
        public ActionResult CCDIndex()
        {
            return View();
        }

        // GET: Facturacion/CCDDetalle/5
        public ActionResult CCDDetalle(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridCCD()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, Documento = "001", Fecha = "15-01-2019", Descripcion = "Cliente A", ImporteIGV = "1000.00", Moneda = "ME", Sit = "" });
            Results.Add(new { Codigo = 2, Documento = "002", Fecha = "16-02-2019", Descripcion = "Cliente B", ImporteIGV = "2000.00", Moneda = "ME", Sit = "" });
            Results.Add(new { Codigo = 3, Documento = "003", Fecha = "18-03-2019", Descripcion = "Cliente C", ImporteIGV = "3000.00", Moneda = "MN", Sit = "" });

            int totalRecords = Results.Count();

            var jsonData = new
            {
                data = Results,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GridCCDDetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "001", Descripcion = "Producto A", Lote = "1010", Und = "Und", PUnitario = "200.44", Cantidad = "50", Total = "550.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "002", Descripcion = "Producto B", Lote = "2010", Und = "Und", PUnitario = "220.44", Cantidad = "10", Total = "650.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "003", Descripcion = "Producto C", Lote = "1310", Und = "Und", PUnitario = "203.44", Cantidad = "20", Total = "570.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "004", Descripcion = "Producto D", Lote = "1040", Und = "Und", PUnitario = "400.44", Cantidad = "30", Total = "558.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "005", Descripcion = "Producto E", Lote = "1016", Und = "Und", PUnitario = "250.44", Cantidad = "40", Total = "950.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });

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
        //CRUD DE Consulta / Ventas por Artículo, Se Abrevia <CVA>
        // GET: Facturacion/CVAIndex
        public ActionResult CVAIndex()
        {
            return View();
        }

        // GET: Facturacion/CVADetalle/5
        public ActionResult CVADetalle(string Codigo)
        {
            Modelo.CodigoProducto = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridCVA()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "1", CodigoUnidadMedida = "Und", Descripcion = "Producto 1", Marca = "", Familia = "Familia A" });
            Results.Add(new { Codigo = "2", CodigoUnidadMedida = "Lts", Descripcion = "Producto 2", Marca = "", Familia = "Familia A" });
            Results.Add(new { Codigo = "3", CodigoUnidadMedida = "Und", Descripcion = "Producto 3", Marca = "", Familia = "Familia A" });

            int totalRecords = Results.Count();

            var jsonData = new
            {
                data = Results,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GridCVADetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "001", Descripcion = "Producto A", Lote = "1010", Und = "Und", PUnitario = "200.44", Cantidad = "50", Total = "550.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "002", Descripcion = "Producto B", Lote = "2010", Und = "Und", PUnitario = "220.44", Cantidad = "10", Total = "650.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "003", Descripcion = "Producto C", Lote = "1310", Und = "Und", PUnitario = "203.44", Cantidad = "20", Total = "570.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "004", Descripcion = "Producto D", Lote = "1040", Und = "Und", PUnitario = "400.44", Cantidad = "30", Total = "558.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "005", Descripcion = "Producto E", Lote = "1016", Und = "Und", PUnitario = "250.44", Cantidad = "40", Total = "950.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });

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
        //CRUD DE Consulta / Ventas por Cliente, Se Abrevia <CVC>
        // GET: Facturacion/CVCIndex
        public ActionResult CVCIndex()
        {
            return View();
        }

        // GET: Facturacion/CVCDetalle/5
        public ActionResult CVCDetalle(string CodigoCliente)
        {
            Modelo.CodigoCliente = CodigoCliente;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridCVC()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<FacturacionModel> Listado = new List<FacturacionModel>()
            {
                new FacturacionModel { CodigoCliente = "01", RUC = "XXX111", Descripcion = "Cliente 1", Telefono = "111-111" },
                new FacturacionModel { CodigoCliente = "02", RUC = "XXX222", Descripcion = "Cliente 2", Telefono = "222-222" },
                new FacturacionModel { CodigoCliente = "03", RUC = "YYY333", Descripcion = "Cliente 3", Telefono = "333-333" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.CodigoCliente, N.Descripcion, N.RUC, N.Telefono });
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
        public JsonResult GridCVCDetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "001", Descripcion = "Producto A", Lote = "1010", Und = "Und", PUnitario = "200.44", Cantidad = "50", Total = "550.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "002", Descripcion = "Producto B", Lote = "2010", Und = "Und", PUnitario = "220.44", Cantidad = "10", Total = "650.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "003", Descripcion = "Producto C", Lote = "1310", Und = "Und", PUnitario = "203.44", Cantidad = "20", Total = "570.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "004", Descripcion = "Producto D", Lote = "1040", Und = "Und", PUnitario = "400.44", Cantidad = "30", Total = "558.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });
            Results.Add(new { Codigo = "005", Descripcion = "Producto E", Lote = "1016", Und = "Und", PUnitario = "250.44", Cantidad = "40", Total = "950.00", ImporteIGV = "20.00", DescuentoUnitario = "0.00", IGV = "16.00", PrecioVta = "100.00" });

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
        //REPORTES
        /**************************************************************************************************************/
        //Informes Diarios\ Cuadre de Facturación, Se abrevia <RCF>
        // GET: Compra/RCFIndex
        public ActionResult RCFIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Informes Diarios\ Ventas por Forma de Pago, Se abrevia <RVFP>
        // GET: Compra/RVFPIndex
        public ActionResult RVFPIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Informes Diarios\ Ventas por Serie / Documentos, Se abrevia <RVSD>
        // GET: Compra/RVSDIndex
        public ActionResult RVSDIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Informes Diarios\ Ventas por Artículo, Se abrevia <RVA>
        // GET: Compra/RVAIndex
        public ActionResult RVAIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Informes Diarios\ Ventas por Vendedores, Se abrevia <RVV>
        // GET: Compra/RVVIndex
        public ActionResult RVVIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Informes Diarios\ Ventas por Clientes, Se abrevia <RVC>
        // GET: Compra/RVCIndex
        public ActionResult RVCIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Ventas Mensuales, Se abrevia <RVM>
        // GET: Compra/RVMIndex
        public ActionResult RVMIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Listas de Precios, Se abrevia <RLP>
        // GET: Compra/RLPIndex
        public ActionResult RLPIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Reporte de Comisiones, Se abrevia <RC>
        // GET: Compra/RCIndex
        public ActionResult RCIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Reporte de Promedio de Vtas. en Calidad, Se abrevia <RPVC>
        // GET: Compra/RPVCIndex
        public ActionResult RPVCIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //PROCESOS
        /**************************************************************************************************************/
        //Proceso de Generación de Ventas Mensuales, Se abrevia <PGVM>
        // GET: Compra/PGVMIndex
        public ActionResult PGVMIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Proceso de Reversión de Documentos Anulados, Se abrevia <PRDA>
        // GET: Compra/PRDAIndex
        public ActionResult PRDAIndex()
        {
            return View();
        }

        // GET: Facturacion/CVCDetalle/5
        public ActionResult PRDAConsultar(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }
    }
}
