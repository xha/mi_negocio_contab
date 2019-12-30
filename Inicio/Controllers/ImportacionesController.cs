using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;

namespace Inicio.Controllers
{
    public class ImportacionesController : Controller
    {
        private ImportacionesModel Modelo = new ImportacionesModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        /**************************************************************************************************************/
        //MODAL DE Ordenes DE IMPORTACION
        public ActionResult OrdenesImportacion()
        {
            return PartialView("_OrdenesImportacion");
        }

        /**************************************************************************************************************/
        //MODAL DE GASTOS Ordenes DE IMPORTACION
        public ActionResult GastosOrdenesImportacion()
        {
            return PartialView("_OrdenesImportacion");
        }

        /**************************************************************************************************************/
        // GET: Importaciones
        public ActionResult Index()
        {
            Session["MenuColor"] = "brown";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_importado = 150200;
            ViewBag.total_efectivo = 25405;
            ViewBag.total_faltante = 1220;

            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
            ViewData["productos_importados"] = new int[] { 958,976,937,891,899,908,882,871,944,830,759,790 };
            ViewData["entregas_perfectas"] = new int[] { 95,93,94,96,95,96,94,93,92,94,95,97 };
            ViewData["entregas_tiempo"] = new int[] { 96,97,96,94,96,97,96,95,95,94,95,97 };
            ViewData["entregas_completo"] = new int[] { 93,91,92,93,94,95,93,92,94,95,95,94 };

            return View();
        }

        [HttpPost]
        public JsonResult GridCostoCodigoUnidad()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ImportacionesModel> Listado = new List<ImportacionesModel>()
            {
                new ImportacionesModel { Codigo = "1", FechaEmision = "ENE", Precio = 11500000, Total = 12000, ImporteBruto = 958 },
                new ImportacionesModel { Codigo = "2", FechaEmision = "FEB", Precio = 12000000, Total = 12300, ImporteBruto = 976 },
                new ImportacionesModel { Codigo = "3", FechaEmision = "MAR", Precio = 12600000, Total = 12000, ImporteBruto = 937 },
                new ImportacionesModel { Codigo = "4", FechaEmision = "ABR", Precio = 13100000, Total = 13500, ImporteBruto = 891 },
                new ImportacionesModel { Codigo = "5", FechaEmision = "MAY", Precio = 12400000, Total = 14700, ImporteBruto = 899 },
                new ImportacionesModel { Codigo = "6", FechaEmision = "JUN", Precio = 11900000, Total = 13800, ImporteBruto = 908 },
                new ImportacionesModel { Codigo = "7", FechaEmision = "JUL", Precio = 12000000, Total = 13100, ImporteBruto = 882 },
                new ImportacionesModel { Codigo = "8", FechaEmision = "AGO", Precio = 11500000, Total = 13600, ImporteBruto = 871 },
                new ImportacionesModel { Codigo = "9", FechaEmision = "SEP", Precio = 11800000, Total = 13200, ImporteBruto = 944 },
                new ImportacionesModel { Codigo = "10", FechaEmision = "OCT", Precio = 12450000, Total = 12500, ImporteBruto = 830 },
                new ImportacionesModel { Codigo = "11", FechaEmision = "NOV", Precio = 12900000, Total = 15000, ImporteBruto = 759 },
                new ImportacionesModel { Codigo = "12", FechaEmision = "DIC", Precio = 12250000, Total = 17000, ImporteBruto = 790 },
            };

            var Resultado = (from N in Listado
                             where N.FechaEmision.Contains(searchValue)
                             select new { N.Codigo, N.FechaEmision, N.Precio, N.Total, N.Bruto });
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
        public JsonResult GridEntregasPerfectas()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ImportacionesModel> Listado = new List<ImportacionesModel>()
            {
                new ImportacionesModel { Codigo = "1", FechaEmision = "ENE", Precio = 24200, Total = 25500, ImporteBruto = 958, Descripcion = "95%" },
                new ImportacionesModel { Codigo = "2", FechaEmision = "FEB", Precio = 23300, Total = 25100, ImporteBruto = 976, Descripcion = "93%" },
                new ImportacionesModel { Codigo = "3", FechaEmision = "MAR", Precio = 23700, Total = 25200, ImporteBruto = 937, Descripcion = "94%" },
                new ImportacionesModel { Codigo = "4", FechaEmision = "ABR", Precio = 24800, Total = 25900, ImporteBruto = 891, Descripcion = "96%" },
                new ImportacionesModel { Codigo = "5", FechaEmision = "MAY", Precio = 24900, Total = 26200, ImporteBruto = 899, Descripcion = "95%" },
                new ImportacionesModel { Codigo = "6", FechaEmision = "JUN", Precio = 25000, Total = 26000, ImporteBruto = 908, Descripcion = "96%" },
                new ImportacionesModel { Codigo = "7", FechaEmision = "JUL", Precio = 24000, Total = 25500, ImporteBruto = 882, Descripcion = "94%" },
                new ImportacionesModel { Codigo = "8", FechaEmision = "AGO", Precio = 24600, Total = 26500, ImporteBruto = 871, Descripcion = "93%" },
                new ImportacionesModel { Codigo = "9", FechaEmision = "SEP", Precio = 24800, Total = 27000, ImporteBruto = 944, Descripcion = "92%" },
                new ImportacionesModel { Codigo = "10", FechaEmision = "OCT", Precio = 26200, Total = 27900, ImporteBruto = 830, Descripcion = "94%" },
                new ImportacionesModel { Codigo = "11", FechaEmision = "NOV", Precio = 26000, Total = 27300, ImporteBruto = 759, Descripcion = "95%" },
                new ImportacionesModel { Codigo = "12", FechaEmision = "DIC", Precio = 26000, Total = 26900, ImporteBruto = 790, Descripcion = "97%" },
            };

            var Resultado = (from N in Listado
                             where N.FechaEmision.Contains(searchValue)
                             select new { N.Codigo, N.FechaEmision, N.Precio, N.Total, N.Bruto, N.Descripcion });
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
        //CRUD DE Ordenes de Importacion
        // GET: Importaciones/OrdenIndex
        public ActionResult OrdenIndex()
        {
            return View();
        }

        // GET: Importaciones/OrdenCreate
        public ActionResult OrdenCreate()
        {
            return View();
        }

        // POST: Importaciones/OrdenCreate
        [HttpPost]
        public ActionResult OrdenCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("OrdenIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Importaciones/OrdenEdit/5
        public ActionResult OrdenEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Importaciones/OrdenEdit/5
        [HttpPost]
        public ActionResult OrdenEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("OrdenIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Importaciones/OrdenDelete/5
        public ActionResult OrdenDelete(string codigo)
        {
            Modelo.Codigo = codigo;
            return View();
        }

        // POST: Importaciones/OrdenDelete/5
        [HttpPost]
        public ActionResult OrdenDelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("OrdenIndex");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult OrdenAgregar()
        {
            return PartialView("_OrdenAgregar");
        }

        [HttpPost]
        public JsonResult GridOrdenImportacion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ImportacionesModel> Listado = new List<ImportacionesModel>()
            {
                new ImportacionesModel { Codigo = "1", NroOrden = "001", FechaEmision = "15-01-2019", CodigoProveedor = "112233", DescripcionProveedor = "Proveedor A", Importe = 16, TM = "", Sit = "", FechaEntrega = "25-02-2019", Precio = 2222.00, Total = 2323.33 },
                new ImportacionesModel { Codigo = "2", NroOrden = "002", FechaEmision = "21-01-2019", CodigoProveedor = "445566", DescripcionProveedor = "Proveedor B", Importe = 16, TM = "", Sit = "", FechaEntrega = "25-02-2019", Precio = 34222.00, Total = 4323.33 },
                new ImportacionesModel { Codigo = "3", NroOrden = "003", FechaEmision = "21-02-2019", CodigoProveedor = "778899", DescripcionProveedor = "Proveedor C", Importe = 16, TM = "", Sit = "", FechaEntrega = "25-02-2019", Precio = 12332.00, Total = 5323.33 },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProveedor.Contains(searchValue)
                             select new { N.Codigo, N.CodigoProveedor, N.DescripcionProveedor, N.NroOrden, N.FechaEmision, N.Importe, N.Sit, N.FechaEntrega, N.TM, N.Precio, N.Total });
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
        public JsonResult GridOrdenDetalleImportacion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ImportacionesModel> Listado = new List<ImportacionesModel>()
            {
                new ImportacionesModel { Codigo = "1", CodigoProducto = "001", DescripcionProducto = "Producto A", Cantidad = 10, CodigoUnidad = "Und", Precio = 200.44, ImporteBruto = 500.00, Descuento = 50.00, Total = 550.00 },
                new ImportacionesModel { Codigo = "2", CodigoProducto = "002", DescripcionProducto = "Producto B", Cantidad = 20, CodigoUnidad = "Und", Precio = 300.44, ImporteBruto = 600.00, Descuento = 0.00, Total = 650.00 },
                new ImportacionesModel { Codigo = "3", CodigoProducto = "003", DescripcionProducto = "Producto C", Cantidad = 30, CodigoUnidad = "Und", Precio = 400.44, ImporteBruto = 700.00, Descuento = 50.00, Total = 750.00 },
                new ImportacionesModel { Codigo = "4", CodigoProducto = "004", DescripcionProducto = "Producto D", Cantidad = 40, CodigoUnidad = "Und", Precio = 500.44, ImporteBruto = 800.00, Descuento = 0.00, Total = 850.00 },
                new ImportacionesModel { Codigo = "5", CodigoProducto = "005", DescripcionProducto = "Producto A", Cantidad = 50, CodigoUnidad = "Und", Precio = 600.44, ImporteBruto = 900.00, Descuento = 50.00, Total = 550.00 },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProducto.Contains(searchValue)
                             select new { N.Codigo, N.CodigoProducto, N.DescripcionProducto, N.Cantidad, N.CodigoUnidad, N.Precio, N.ImporteBruto, N.Descuento, N.Total });
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
        //CRUD DE Gastos por Orden de Importacion, Se abrevia GO
        // GET: Importaciones/OrdenIndex
        public ActionResult GOIndex()
        {
            return View();
        }

        // GET: Importaciones/GOCreate
        public ActionResult GOCreate()
        {
            return View();
        }

        // POST: Importaciones/GOCreate
        [HttpPost]
        public ActionResult GOCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("GOIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Importaciones/GOEdit/5
        public ActionResult GOEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Importaciones/GOEdit/5
        [HttpPost]
        public ActionResult GOEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("GOIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Importaciones/GODelete/5
        public ActionResult GODelete(string codigo)
        {
            return View();
        }

        // POST: Importaciones/GODelete/5
        [HttpPost]
        public ActionResult GODelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("GOIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridGOImportacion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ImportacionesModel> Listado = new List<ImportacionesModel>()
            {
                new ImportacionesModel { Codigo = "1", CodigoProveedor = "112233", DescripcionProveedor = "Proveedor A", Gastos = 16, Documento = "FAA 123 123456", FechaEmision = "25-01-2019", Importe = 100.00, TM = "MN", TotalCredito = 0.00, DUA = 0.00 },
                new ImportacionesModel { Codigo = "2", CodigoProveedor = "445566", DescripcionProveedor = "Proveedor B", Gastos = 32, Documento = "FAB 456 123456", FechaEmision = "25-02-2019", Importe = 200.00, TM = "MN", TotalCredito = 0.00, DUA = 0.00 },
                new ImportacionesModel { Codigo = "3", CodigoProveedor = "778899", DescripcionProveedor = "Proveedor C", Gastos = 48, Documento = "FAC 999 999999", FechaEmision = "25-03-2019", Importe = 300.00, TM = "MN", TotalCredito = 0.00, DUA = 0.00 },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProveedor.Contains(searchValue)
                             select new { N.Codigo, N.CodigoProveedor, N.DescripcionProveedor, N.Gastos, N.Documento, N.FechaEmision, N.TM, N.TotalCredito, N.DUA, N.Importe });
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
        //CRUD DE Nacionalización de Artículos, Se abrevia NA
        //MODAL DE NACIONALIZACION DE ARTICULOS IMPORTADOS
        public ActionResult NAIAgregar()
        {
            return PartialView("_NAIAgregar");
        }

        // GET: Importaciones/NAIndex
        public ActionResult NAIndex()
        {
            return View();
        }

        // GET: Importaciones/NACreate
        public ActionResult NACreate()
        {
            return View();
        }

        // POST: Importaciones/NACreate
        [HttpPost]
        public ActionResult NACreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("NAIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Importaciones/NAEdit/5
        public ActionResult NAEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Importaciones/NAEdit/5
        [HttpPost]
        public ActionResult NAEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("NAIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Importaciones/NAGastos/5
        public ActionResult NAGastos(string codigo)
        {
            return View();
        }

        //MODAL DE Ordenes DE IMPORTACION
        public ActionResult GastosImportacion()
        {
            return PartialView("_GastosImportacion");
        }

        // GET: Importaciones/NADelete/5
        public ActionResult NADelete(string codigo)
        {
            return View();
        }

        // POST: Importaciones/NADelete/5
        [HttpPost]
        public ActionResult NADelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("NAIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridNAImportacion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ImportacionesModel> Listado = new List<ImportacionesModel>()
            {
                new ImportacionesModel { Codigo = "1", Documento = "FAA 123 123456", FechaEmision = "25-01-2019", Importe = 100.00, TM = "MN", TotalCredito = 0.00, NroOrden = "YYZZAA", ValorAduana = 1110.00, ValorEm = 1234.00, IGV = 1234.00, Sit = "D", IPM = 1444.00 },
                new ImportacionesModel { Codigo = "2", Documento = "FAB 456 123456", FechaEmision = "25-02-2019", Importe = 200.00, TM = "MN", TotalCredito = 0.00, NroOrden = "YYZZAA", ValorAduana = 1110.00, ValorEm = 1234.00, IGV = 1234.00, Sit = "D", IPM = 1444.00 },
                new ImportacionesModel { Codigo = "3", Documento = "FAC 999 999999", FechaEmision = "25-03-2019", Importe = 300.00, TM = "MN", TotalCredito = 0.00, NroOrden = "YYZZAA", ValorAduana = 1110.00, ValorEm = 1234.00, IGV = 1234.00, Sit = "D", IPM = 1444.00 },
            };

            var Resultado = (from N in Listado
                             where N.Documento.Contains(searchValue)
                             select new { N.Codigo, N.Documento, N.FechaEmision, N.Importe, N.TotalCredito, N.NroOrden, N.ValorAduana, N.ValorEm, N.IGV, N.Sit, N.IPM, N.TM });
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
        public JsonResult GridNADetalleImportacion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ImportacionesModel> Listado = new List<ImportacionesModel>()
            {
                new ImportacionesModel { Codigo = "1", Documento = "112233", Descripcion = "Producto A", CodigoUnidad = "Und", CantidadRequerida = 100, CantidadRecepcionada = 100, CantidadPend = 0.00, CantidadNacionalizar = 10.00 },
                new ImportacionesModel { Codigo = "2", Documento = "445566", Descripcion = "Producto B", CodigoUnidad = "Und", CantidadRequerida = 200, CantidadRecepcionada = 100, CantidadPend = 100.00, CantidadNacionalizar = 100.00 },
                new ImportacionesModel { Codigo = "3", Documento = "778899", Descripcion = "Producto C", CodigoUnidad = "Und", CantidadRequerida = 300, CantidadRecepcionada = 400, CantidadPend = 0.00, CantidadNacionalizar = 300.00 },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Documento, N.Descripcion, N.CodigoUnidad, N.CantidadRequerida, N.CantidadRecepcionada, N.CantidadPend, N.CantidadNacionalizar });
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
        //CRUD DE Liquidacion de Costo de Importacion, Se abrevia LCI
        // GET: Importaciones/OrdenIndex
        public ActionResult LCIIndex()
        {
            return View();
        }

        // GET: Importaciones/OrdenEdit/5
        public ActionResult LCIEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Importaciones/OrdenEdit/5
        [HttpPost]
        public ActionResult LCIEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("LCIIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridLCIImportacion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ImportacionesModel> Listado = new List<ImportacionesModel>()
            {
                new ImportacionesModel { DUA = 1, FechaEmision = "15-01-2019", NroOrden="FFAA111", CodigoProveedor = "112233", DescripcionProveedor = "Proveedor A".ToUpper(), Sit = "D", Incoterms = "EXW" },
                new ImportacionesModel { DUA = 2, FechaEmision = "15-02-2019", NroOrden = "FFBB222", CodigoProveedor = "0001", DescripcionProveedor = "Proveedor B".ToUpper(), Sit = "A", Incoterms = "EXX" },
                new ImportacionesModel { DUA = 3, FechaEmision = "12-03-2019", NroOrden = "XXXAA222", CodigoProveedor = "233", DescripcionProveedor = "Proveedor C".ToUpper(), Sit = "B", Incoterms = "EXY" },
            };

            var Resultado = (from N in Listado
                             where N.NroOrden.Contains(searchValue)
                             select new { N.DescripcionProveedor, N.DUA, N.FechaEmision, N.NroOrden, N.CodigoProveedor, N.Sit, N.Incoterms });
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
        public JsonResult GridLCIGastoImportacion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<ImportacionesModel> Listado = new List<ImportacionesModel>()
            {
                new ImportacionesModel { Descripcion = "ASDASD", Total = 23232.22, DUA = 5500.00 },
                new ImportacionesModel { Descripcion = "BAASD", Total = 2000.22, DUA = 55.00 },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.Total, N.DUA });
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
        //CRUD DE Factura Comercial, Se Abrevia FC
        // GET: Importaciones/FCIndex
        public ActionResult FCIndex()
        {
            return View();
        }

        // GET: Importaciones/FCCreate
        public ActionResult FCCreate()
        {
            return View();
        }

        // POST: Importaciones/FCCreate
        [HttpPost]
        public ActionResult FCCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("FCIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Importaciones/FCEdit/5
        public ActionResult FCEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Importaciones/FCEdit/5
        [HttpPost]
        public ActionResult FCEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("FCIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Importaciones/FCDelete/5
        public ActionResult FCDelete(string codigo)
        {
            return View();
        }

        // POST: Importaciones/FCDelete/5
        [HttpPost]
        public ActionResult FCDelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("FCIndex");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult FCDetalle()
        {
            return PartialView("_FCDetalle");
        }

        public ActionResult FCArticulo()
        {
            return PartialView("_FCArticulo");
        }

        [HttpPost]
        public JsonResult GridFacturaComercial()
        {
            List<object> Results = new List<object>();

            Results.Add(new { FechaEmision = "15-01-2019", CodigoProveedor = "112233", Descripcion = "Proveedor A", Importe = "16", TM = "", Documento = "FF YY AAAA1" });
            Results.Add(new { FechaEmision = "21-01-2019", CodigoProveedor = "445566", Descripcion = "Proveedor B", Importe = "16", TM = "", Documento = "FF XX AASAA1" });
            Results.Add(new { FechaEmision = "21-02-2019", CodigoProveedor = "778899", Descripcion = "Proveedor C", Importe = "16", TM = "", Documento = "FF ZZZ BAAA1" });

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
        public JsonResult GridFCDetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "001", Descripcion = "Producto A", Cantidad = "10", UM = "Und", VUnitario = "200.44", VBruto = "500.00", VDescuento = "50.00", Total = "550.00" });
            Results.Add(new { Codigo = "002", Descripcion = "Producto B", Cantidad = "20", UM = "Und", VUnitario = "300.44", VBruto = "600.00", VDescuento = "0.00", Total = "650.00" });
            Results.Add(new { Codigo = "003", Descripcion = "Producto C", Cantidad = "30", UM = "Und", VUnitario = "400.44", VBruto = "700.00", VDescuento = "50.00", Total = "750.00" });
            Results.Add(new { Codigo = "004", Descripcion = "Producto D", Cantidad = "40", UM = "Und", VUnitario = "500.44", VBruto = "800.00", VDescuento = "0.00", Total = "850.00" });
            Results.Add(new { Codigo = "001", Descripcion = "Producto A", Cantidad = "50", UM = "Und", VUnitario = "600.44", VBruto = "900.00", VDescuento = "50.00", Total = "550.00" });

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
        //Definir el Estado de la Orden de Importación, Se abrevia DEOI por sus siglas
        // GET: Importaciones/DEOIIndex
        public ActionResult DEOIIndex()
        {
            return View();
        }

        public ActionResult DEOIEdit()
        {
            return PartialView("_DEOIEdit");
        }

        [HttpPost]
        public JsonResult AutoCompleteArticulos(string prefix)
        {
            List<ImportacionesModel> ObjList = new List<ImportacionesModel>()
            {
                new ImportacionesModel { Codigo = "1", Descripcion="Naranja" },
                new ImportacionesModel { Codigo = "2", Descripcion="Pera" },
                new ImportacionesModel { Codigo = "3", Descripcion="Uva" },
                new ImportacionesModel { Codigo = "4", Descripcion="Patilla" },
                new ImportacionesModel { Codigo = "5", Descripcion="Lechoza" },
                new ImportacionesModel { Codigo = "6", Descripcion="Cambur" },
                new ImportacionesModel { Codigo = "7", Descripcion="Otro" }
            };

            var Articulos = (from N in ObjList
                             where N.Descripcion.StartsWith(prefix)
                            select new { N.Descripcion, N.Codigo });
            return Json(Articulos, JsonRequestBehavior.AllowGet);
        }

        // POST: Importaciones/DEOIEdit/5
        [HttpPost]
        public ActionResult DEOIEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("DEOIIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridDEOI()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Importe = "100.00", FechaEmision = "15-01-2019", Orden = "FFAA111", CodigoProveedor = "112233", Descripcion = "Proveedor A", Sit = "D", TM = "ME", TPrecio = "EXW", FechaEntrega = "03-03-2019" });
            Results.Add(new { Importe = "200.00", FechaEmision = "15-02-2019", Orden = "FFBB222", CodigoProveedor = "0001", Descripcion = "Proveedor B", Sit = "A", TM = "ME", TPrecio = "EXW", FechaEntrega = "03-03-2019" });
            Results.Add(new { Importe = "300.00", FechaEmision = "12-03-2019", Orden = "XXXAA222", CodigoProveedor = "233", Descripcion = "Proveedor C", Sit = "B", TM = "ME", TPrecio = "EXW", FechaEntrega = "03-03-2019" });
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
        //CRUD DE Consulta Ordenes de Importacion
        // GET: Importaciones/ConsultaOrdenIndex
        public ActionResult ConsultaOrdenIndex()
        {
            return View();
        }
        // GET: Importaciones/ConsultaOrdenDetalle/5
        public ActionResult ConsultaOrdenDetalle(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Importaciones/ConsultaOrdenDetalle/5
        [HttpPost]
        public ActionResult ConsultaOrdenDetalle(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("ConsultaOrdenIndex");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ConsultaOrdenGastos()
        {
            return PartialView("_ConsultaOrdenGastos");
        }

        [HttpPost]
        public JsonResult GridConsultaOrden()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Documento = "001", FechaEmision = "15-01-2019", CodigoProveedor = "112233", Descripcion = "Proveedor A", Importe = "16", TM = "", Estado = "Entrega", FechaEntrega = "25-02-2019", Incoterm = "EXW" });
            Results.Add(new { Documento = "002", FechaEmision = "21-01-2019", CodigoProveedor = "445566", Descripcion = "Proveedor B", Importe = "16", TM = "", Estado = "Entrega", FechaEntrega = "25-02-2019", Incoterm = "EXW" });
            Results.Add(new { Documento = "003", FechaEmision = "21-02-2019", CodigoProveedor = "778899", Descripcion = "Proveedor C", Importe = "16", TM = "", Estado = "Entrega", FechaEntrega = "25-02-2019", Incoterm = "EXW" });

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
        public JsonResult GridConsultaOrdenDetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "001", Descripcion = "Producto A", Cantidad = "10", UM = "Und", VUnitario = "200.44", VBruto = "500.00", VDescuento = "50.00", Total = "550.00" });
            Results.Add(new { Codigo = "002", Descripcion = "Producto B", Cantidad = "20", UM = "Und", VUnitario = "300.44", VBruto = "600.00", VDescuento = "0.00", Total = "650.00" });
            Results.Add(new { Codigo = "003", Descripcion = "Producto C", Cantidad = "30", UM = "Und", VUnitario = "400.44", VBruto = "700.00", VDescuento = "50.00", Total = "750.00" });
            Results.Add(new { Codigo = "004", Descripcion = "Producto D", Cantidad = "40", UM = "Und", VUnitario = "500.44", VBruto = "800.00", VDescuento = "0.00", Total = "850.00" });
            Results.Add(new { Codigo = "001", Descripcion = "Producto A", Cantidad = "50", UM = "Und", VUnitario = "600.44", VBruto = "900.00", VDescuento = "50.00", Total = "550.00" });

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
        //Gastos de Importacion
        // GET: Importaciones/RGIIndex
        public ActionResult RGIIndex()
        {
            return View();
        }

        public ActionResult RGIOrden()
        {
            return PartialView("_RGIOrden");
        }

        public ActionResult RGITipoGasto()
        {
            return PartialView("_RGITipoGasto");
        }
    }
}
