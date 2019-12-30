using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using static Inicio.Controllers.GlobalController;

namespace Inicio.Controllers
{
    public class ComprasController : Controller
    {
        private ComprasModel Modelo = new ComprasModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        // GET: Compra
        public ActionResult Index()
        {
            Session["MenuColor"] = "darkcyan";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_compras = 20022.55;
            ViewBag.total_proveedores = 35;
            ViewBag.total_productos = 1535;
            ViewData["proveedores_certificados"] = new int[] { 5,5,7,7,8,8,10,10,11,12,14,14}; ;
            ViewData["pedidos_generados"] = new int[] { 89,91,87,87,91,88,92,95,89,95,97,96 };
            ViewData["meses"] = new string[] { "ENE","FEB","MAR","ABR","MAY","JUN","JUL","AGO","SEP","OCT","NOV","DIC"};
            ViewData["valor_compra"] = new int[] { 17,16,19,20,19,18,17,18,19,20,18,21 };
            ViewData["pedidos_rechazados"] = new int[] { 9, 13, 7, 7, 8, 10, 10, 12, 7, 10, 9, 9 };
            return View();
        }

        [HttpPost]
        public JsonResult GridPrincipal()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ComprasModel> Listado = new List<ComprasModel>()
            {
                new ComprasModel { Codigo = "01", CodigoProveedor = "001", DescripcionProveedor = "Proveedor A", Documento = "112233", FechaEmision = "01-02-2019", IGV = 12, ImporteNeto = 200.44, Monto = 500.00, Moneda = "MN", ImporteBruto = 2222.22, ImporteIGV = 333.33, Glosa = "aaa", Origen = "", Descuento = 0, PrecioVenta = 3000.00, ValorVenta = 1000.00 },
                new ComprasModel { Codigo = "02", CodigoProveedor = "002", DescripcionProveedor = "Proveedor B", Documento = "445566", FechaEmision = "02-02-2019", IGV = 16, ImporteNeto = 300.44, Monto = 700.00, Moneda = "MN", ImporteBruto = 3222.22, ImporteIGV = 533.33, Glosa = "bbb", Origen = "", Descuento = 0, PrecioVenta = 3000.00, ValorVenta = 1000.00 },
                new ComprasModel { Codigo = "03", CodigoProveedor = "003", DescripcionProveedor = "Proveedor C", Documento = "778899", FechaEmision = "03-02-2019", IGV = 12, ImporteNeto = 400.44, Monto = 900.00, Moneda = "MN", ImporteBruto = 4222.22, ImporteIGV = 433.33, Glosa = "ccc", Origen = "", Descuento = 0, PrecioVenta = 3000.00, ValorVenta = 1000.00 },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProveedor.Contains(searchValue)
                             select new { N.Codigo, N.CodigoProveedor, N.DescripcionProveedor, N.FechaEmision, N.IGV, N.ImporteNeto, N.Monto, N.Documento, N.ImporteIGV, N.ImporteBruto, N.Moneda, N.Glosa, N.Origen, N.Descuento, N.PrecioVenta, N.ValorVenta });
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
        public JsonResult GridHonorario()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ComprasModel> Listado = new List<ComprasModel>()
            {
                new ComprasModel { Codigo = "01", CodigoProveedor = "001", DescripcionProveedor = "Proveedor A", Documento = "112233", FechaEmision = "01-02-2019", TipoHonorario = "01", IR = 200.44, IES = 200.44, ImporteNeto = 200.44, Monto = 500.00 },
                new ComprasModel { Codigo = "02", CodigoProveedor = "002", DescripcionProveedor = "Proveedor B", Documento = "445566", FechaEmision = "02-02-2019", TipoHonorario = "16", IR = 200.44, IES = 200.44, ImporteNeto = 300.44, Monto = 700.00 },
                new ComprasModel { Codigo = "03", CodigoProveedor = "003", DescripcionProveedor = "Proveedor C", Documento = "778899", FechaEmision = "03-02-2019", TipoHonorario = "12", IR = 200.44, IES = 200.44, ImporteNeto = 400.44, Monto = 900.00 },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProveedor.Contains(searchValue)
                             select new { N.Codigo, N.CodigoProveedor, N.DescripcionProveedor, N.FechaEmision, N.TipoHonorario, N.IES, N.IR, N.ImporteNeto, N.Monto, N.Documento });
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
        //CRUD DE Registro de Ordenes de Compra, Se Abrevia OC
        // GET: Compra/OCIndex
        public ActionResult OCIndex()
        {
            return View();
        }

        // GET: Compra/OCCreate
        public ActionResult OCCreate()
        {
            return View(Modelo);
        }

        // POST: Compra/OCCreate
        [HttpPost]
        public ActionResult OCCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("OCIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/OCEdit/5
        public ActionResult OCEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // POST: Compra/OCEdit/5
        [HttpPost]
        public ActionResult OCEdit(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("OCIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/OCDelete/5
        public ActionResult OCDelete(string Codigo)
        {
            return View();
        }

        // POST: Compra/OCDelete/5
        [HttpPost]
        public ActionResult OCDelete(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("OCIndex");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult OCAgregar()
        {
            return PartialView("_OCAgregar");
        }

        [HttpPost]
        public JsonResult GridProductos()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ComprasModel> Listado = new List<ComprasModel>()
            {
                new ComprasModel { Codigo = "01", CodigoProducto = "001", DescripcionProducto = "Producto A", Lote = "123", Cantidad = 10, CodigoUnidad = "Und", Precio = 200.44, Bruto = 500.00, Descuento = 50.00, TotalVta = 550.00, IGV = 20.00, ValorVta = 470.00, DescuentoDetalle = 10.00, FechaEmision = "01-01-2011", DescripcionProveedor = "Texto A" },
                new ComprasModel { Codigo = "01", CodigoProducto = "002", DescripcionProducto = "Producto B", Lote = "456", Cantidad = 20, CodigoUnidad = "Und", Precio = 300.44, Bruto = 600.00, Descuento = 0.00, TotalVta = 650.00, IGV = 30.00, ValorVta = 470.00, DescuentoDetalle = 10.00, FechaEmision = "01-01-2011", DescripcionProveedor = "Texto A" },
                new ComprasModel { Codigo = "01", CodigoProducto = "003", DescripcionProducto = "Producto C", Lote = "789", Cantidad = 30, CodigoUnidad = "Und", Precio = 400.44, Bruto = 700.00, Descuento = 50.00, TotalVta = 750.00, IGV = 40.00, ValorVta = 470.00, DescuentoDetalle = 10.00, FechaEmision = "01-01-2011", DescripcionProveedor = "Texto A" },
                new ComprasModel { Codigo = "01", CodigoProducto = "004", DescripcionProducto = "Producto D", Lote = "012", Cantidad = 40, CodigoUnidad = "Und", Precio = 500.44, Bruto = 800.00, Descuento = 0.00, TotalVta = 850.00, IGV = 50.00, ValorVta = 470.00, DescuentoDetalle = 0.00, FechaEmision = "01-01-2011", DescripcionProveedor = "Texto A" },
                new ComprasModel { Codigo = "01", CodigoProducto = "001", DescripcionProducto = "Producto A", Lote = "345", Cantidad = 50, CodigoUnidad = "Und", Precio = 600.44, Bruto = 900.00, Descuento = 50.00, TotalVta = 550.00, IGV = 60.00, ValorVta = 470.00, DescuentoDetalle = 10.00, FechaEmision = "01-01-2011", DescripcionProveedor = "Texto A" },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProducto.Contains(searchValue)
                             select new { N.Codigo, N.CodigoProducto, N.DescripcionProducto, N.Lote, N.Cantidad, N.CodigoUnidad, N.Precio, N.Bruto, N.Descuento, N.TotalVta, N.IGV, N.ValorVta, N.DescuentoDetalle, N.FechaEmision, N.DescripcionProveedor });
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
        //CRUD DE Registro de Factura con Orden de Compra, Se Abrevia FOC
        // GET: Compra/OCIndex
        public ActionResult FOCIndex()
        {
            return View();
        }

        // GET: Compra/FOCCreate
        public ActionResult FOCCreate()
        {
            return View(Modelo);
        }

        // POST: Compra/FOCCreate
        [HttpPost]
        public ActionResult FOCCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("FOCIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/FOCEdit/5
        public ActionResult FOCEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // POST: Compra/FOCEdit/5
        [HttpPost]
        public ActionResult FOCEdit(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("FOCIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/FOCDelete/5
        public ActionResult FOCDelete(string Codigo)
        {
            return View();
        }

        // POST: Compra/FOCDelete/5
        [HttpPost]
        public ActionResult FOCDelete(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("FOCIndex");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FOCAgregar()
        {
            return PartialView("_FOCAgregar");
        }

        /**************************************************************************************************************/
        //CRUD DE Cambio de Estado de Orden de Compra, Se Abrevia CEOC
        // GET: Compra/CEOCIndex
        public ActionResult CEOCIndex()
        {
            return View();
        }

        public ActionResult CEOCAgregar(string Documento)
        {
            ViewBag.Documento = Documento;
            return PartialView("_CEOCAgregar");
        }
        /**************************************************************************************************************/
        //CRUD DE Consulta de Orden de Compra, Se Abrevia COC
        // GET: Compra/COCIndex
        public ActionResult COCIndex()
        {
            return View();
        }

        //GET: Compra/COCDetalle/1
        public ActionResult COCDetalle(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }
        /**************************************************************************************************************/
        //CRUD DE Reporte de Orden de Compra, Se Abrevia ROC
        // GET: Compra/ROCIndex
        public ActionResult ROCIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //CRUD DE Comprobante de Compra para Stock, Se Abrevia CC
        // GET: Compra/CCIndex
        public ActionResult CCIndex()
        {
            return View();
        }

        // GET: Compra/CCCreate
        public ActionResult CCCreate()
        {
            return View(Modelo);
        }

        // POST: Compra/CCCreate
        [HttpPost]
        public ActionResult CCCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("CCIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/CCEdit/5
        public ActionResult CCEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // POST: Compra/CCEdit/5
        /*[HttpPost]
        public ActionResult CCEdit(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("CCIndex");
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Compra/CCDelete/5
        public ActionResult CCDelete(string Codigo)
        {
            return View();
        }

        // POST: Compra/CCDelete/5
        [HttpPost]
        public ActionResult CCDelete(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("CCIndex");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CCAgregar()
        {
            return PartialView("_CCAgregar");
        }
        /**************************************************************************************************************/
        //CRUD DE Comprobante De Liquidaciones de Compra, Se Abrevia CL
        // GET: Compra/CLIndex
        public ActionResult CLIndex()
        {
            return View();
        }

        // GET: Compra/Create
        public ActionResult CLCreate()
        {
            return View(Modelo);
        }

        // POST: Compra/CLCreate
        [HttpPost]
        public ActionResult CLCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("CLIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/ComprobanteCompraEdit/5
        public ActionResult CLEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // POST: Compra/CLEdit/5
        [HttpPost]
        public ActionResult CLEdit(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("CLIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/CLDelete/5
        public ActionResult CLDelete(string Codigo)
        {
            return View();
        }

        // POST: Compra/CLDelete/5
        [HttpPost]
        public ActionResult CLDelete(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("CLIndex");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CLAgregar()
        {
            return PartialView("_CLAgregar");
        }
        /**************************************************************************************************************/
        //CRUD DE Comprobante de Compra de Servicios y Otros, Se Abrevia CS
        // GET: Compra/CSIndex
        public ActionResult CSIndex()
        {
            return View();
        }

        // GET: Compra/CSCreate
        public ActionResult CSCreate()
        {
            return View(Modelo);
        }

        // POST: Compra/CSCreate
        [HttpPost]
        public ActionResult CSCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("CSIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/CSEdit/5
        public ActionResult CSEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // POST: Compra/CSEdit/5
        [HttpPost]
        public ActionResult CSEdit(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("CSIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Compra/CSDelete/5
        public ActionResult CSDelete(string Codigo)
        {
            return View();
        }

        // POST: Compra/CSDelete/5
        [HttpPost]
        public ActionResult CSDelete(string Codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("CSIndex");
            }
            catch
            {
                return View();
            }
        }
        /**************************************************************************************************************/
        //MENU CONSULTAS
        //Listado DE Consulta de Documentos de Compra
        // GET: Compra/ConsultaDocumentoIndex
        public ActionResult ConsultaDocumentoIndex()
        {
            return View();
        }

        public ActionResult ConsultaDocumentoDetalle(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }
        /**************************************************************************************************************/
        //Listado De Compras por Proveedor
        // GET: Compra/ProveedorIndex
        public ActionResult ProveedorIndex()
        {
            return View();
        }

        public ActionResult ProveedorDetalle(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        public ActionResult Proveedor()
        {
            return PartialView("_Proveedor");
        }
        /**************************************************************************************************************/
        //Listado De Compras por Articulo
        // GET: Compra/ArticuloIndex
        public ActionResult ArticuloIndex()
        {
            return View();
        }

        public ActionResult ArticuloDetalle(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }
        /**************************************************************************************************************/
        //REPORTES
        /**************************************************************************************************************/
        //Historico de Precios de Compra, Se abrevia RHistoricoPrecio
        // GET: Compra/RHistoricoPrecioIndex
        public ActionResult RHistoricoPrecioIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Articulos con Ultimo Precio de Compra, Se Abrevia RAUP
        // GET: Compra/RAUPIndex
        public ActionResult RAUPIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Compras por Documento, Se Abrevia RDocumento
        // GET: Compra/ArticuloIndex
        public ActionResult RDocumentoIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Listado De Compras por Articulo
        // GET: Compra/RArticuloIndex
        public ActionResult RArticuloIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Compras por Articulo, Se abrevia RProveedor
        // GET: Compra/RProveedorIndex
        public ActionResult RProveedorIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Compras por Meses, Se abrevia RMeses
        // GET: Compra/RMesesIndex
        public ActionResult RMesesIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Artículos en Alera Logística, Se abrevia RAAL
        // GET: Compra/RAALIndex
        public ActionResult RAALIndex()
        {
            return View();
        }
    }
}
