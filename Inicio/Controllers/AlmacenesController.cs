using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Inicio.Controllers
{
    public class AlmacenesController : Controller
    {
        private AlmacenesModel Modelo = new AlmacenesModel();
        private ConexionModel cn = new ConexionModel();
        private HttpClient client = new HttpClient(new HttpClientHandler());
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        //Listado de Almacenes
        [HttpGet]
        public ActionResult Almacenes(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Almacenes");
        }
        //Listado de Ordenes de Importación
        [HttpGet]
        public ActionResult OrdenesImportacion(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_OrdenesImportacion");
        }

        //Listado de Ordenes de Trabajo
        [HttpGet]
        public ActionResult OrdenesTrabajo(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_OrdenesTrabajo");
        }

        public JsonResult Listado(string ruta)
        {
            string _CREDENCIALES = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("EPISODE:123"));

            HttpClient client = new HttpClient(new HttpClientHandler());
            client.BaseAddress = new Uri("http://www.starsoftweb.com/ServicioMiNegocio/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _CREDENCIALES);

            var response = client.GetAsync(ruta + cn.Conexion()).Result;
            if (response.IsSuccessStatusCode)
            {
                //ALMACENES
                string data = response.Content.ReadAsStringAsync().Result;
                var listaAlmacen = JsonConvert.DeserializeObject<List<AlmacenesModel>>(data);
            }
            var jsonData = new
            {
                data = response,
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // GET: Almacenes
        public ActionResult Index()
        {
            //JsonResult listado = Listado("http://www.starsoftweb.com/ServicioMiNegocio/Api/ListarAlmacenes?jsonB64=");
            Session["MenuColor"] = "darkkhaki";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_entrada = 5352;
            ViewBag.total_salida = 4325;
            ViewBag.total_inventario = 1535;
            ViewBag.total_notas = 53;

            ViewData["rotacion_mercancia"] = new double[] { 5.6,5.9,7.2,6.8,5.7,6.5,6.1,6.8,6.4,5.5,6.5,6.1 };
            ViewData["duracion_inventario"] = new int[] { 6,6,5,6,6,5,6,7,6,7,5,6, };
            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };
            ViewData["vejez_inventario"] = new int[] { 6,5,5,5,5,4,4,3,4,4,3,3 };
            ViewData["valor_economico"] = new int[] { 17,13,14,17,20,19,20,21,20,22,22,23 };
            ViewData["exactitud_inventario"] = new int[] { 6,4,5,6,4,3,4,4,4,5,5,4 };
            ViewData["unidad_almacenada"] = new int[] { 100,104,99,96,90,88,97,106,102,96,92,91 };
            ViewData["unidad_despachada"] = new int[] { 536,485,494,510,509,494,529,516,546,586,561 };
            ViewData["unidad_por_empleado"] = new int[] { 2453,2353,2207,1863,2031,1950,1735,1624,1706,1956,2063,2188 };
            ViewData["costo_metro"] = new int[] { 6000,6373,5933,6133,5907,5993,5833,5933,6067,6167,6133,6333 };
            ViewData["costo_despacho"] = new int[] { 600000,613333,616667,590625,584375,575000,564706,567647,571765,581250,571875,565625 };
            ViewData["cumplimiento_despacho"] = new int[] { 95,94,95,94,95,96,96,95,96,95,96,95 };
            return View();
        }

        [HttpPost]
        public JsonResult GridAlmacenes()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { Codigo = "01", Descripcion = "Almacén A" },
                new AlmacenesModel { Codigo = "02", Descripcion = "Almacén B" },
                new AlmacenesModel { Codigo = "03", Descripcion = "Almacén C" },
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

        [HttpPost]
        public JsonResult GridOrdenesImportacion()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { Codigo = "01", Documento = "X-Y-001", FechaEmision = "02-03-2019", CodigoProveedor = "P01", DescripcionProveedor = "Proveedor A"  },
                new AlmacenesModel { Codigo = "02", Documento = "Z-Y-011", FechaEmision = "03-02-2019", CodigoProveedor = "P02", DescripcionProveedor = "Proveedor B" },
                new AlmacenesModel { Codigo = "03", Documento = "W-Z-101", FechaEmision = "12-03-2019", CodigoProveedor = "P03", DescripcionProveedor = "Proveedor C" },
            };

            var Resultado = (from N in Listado
                             where N.Documento.Contains(searchValue)
                             select new { N.Codigo, N.DescripcionProveedor, N.Documento, N.FechaEmision, N.CodigoProveedor });
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
        //CRUD DE Notas de Ingreso, Se Abrevia <NI>
        // GET: Almacenes/AgregarNI
        [HttpGet]
        public ActionResult AgregarNI(string parametro1)
        {
            return PartialView("_AgregarNI");
        }
        // GET: Almacenes/NIIndex
        public ActionResult NIIndex()
        {
            return View();
        }

        // GET: Almacenes/NICreate
        public ActionResult NICreate()
        {
            return View();
        }

        // POST: Almacenes/NICreate
        [HttpPost]
        public ActionResult NICreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("NIIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/NIEdit/5
        public ActionResult NIEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Almacenes/NIEdit/5
        [HttpPost]
        public ActionResult NIEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("NIIndex");
            }
            catch
            {
                return View();
            }
        }

        // POST: Almacenes/NIDelete/5
        [HttpGet]
        public ActionResult NIDelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("NIIndex");
            }
            catch
            {
                return View();
            }
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

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { Codigo = "01", Documento = "001", FechaEmision = "15-01-2019", Descripcion = "Documento A", Trans = "1", Sit = "", Moneda = "MN", PrecioVenta = 2000.00, Orden = "X1" },
                new AlmacenesModel { Codigo = "02", Documento = "002", FechaEmision = "15-02-2019", Descripcion = "Documento B", Trans = "2", Sit = "", Moneda = "MN", PrecioVenta = 4000.00, Orden = "Y1" },
                new AlmacenesModel { Codigo = "03", Documento = "003", FechaEmision = "15-03-2019", Descripcion = "Documento C", Trans = "3", Sit = "", Moneda = "MN", PrecioVenta = 3000.00, Orden = "Z1" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Documento, N.FechaEmision, N.Descripcion, N.Trans, N.Sit, N.Moneda, N.PrecioVenta, N.Orden });
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
        public JsonResult GridNIDetalle()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { Codigo = "01", CodigoProducto = "001", DescripcionProducto = "Producto A".ToUpper(), Lote = "1010", Unidad = "Und", Precio = 200.44, Cantidad = 50, Total = 550.00 },
                new AlmacenesModel { Codigo = "02", CodigoProducto = "002", DescripcionProducto = "Producto B".ToUpper(), Lote = "2010", Unidad = "Und", Precio = 220.44, Cantidad = 10, Total = 650.00 },
                new AlmacenesModel { Codigo = "03", CodigoProducto = "003", DescripcionProducto = "Producto C".ToUpper(), Lote = "1310", Unidad = "Und", Precio = 203.44, Cantidad = 20, Total = 570.00 },
                new AlmacenesModel { Codigo = "04", CodigoProducto = "004", DescripcionProducto = "Producto D".ToUpper(), Lote = "1040", Unidad = "Und", Precio = 400.44, Cantidad = 30, Total = 558.00 },
                new AlmacenesModel { Codigo = "05", CodigoProducto = "005", DescripcionProducto = "Producto E".ToUpper(), Lote = "1016", Unidad = "Und", Precio = 250.44, Cantidad = 40, Total = 950.00 },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProducto.Contains(searchValue)
                             select new { N.Codigo,N.CodigoProducto, N.DescripcionProducto, N.Lote, N.Unidad, N.Precio, N.Cantidad, N.Total });
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
        //CRUD DE Notas de Salida, Se Abrevia <NS>
        // GET: Almacenes/AgregarNS
        [HttpGet]
        public ActionResult AgregarNS(string parametro1)
        {
            return PartialView("_AgregarNS");
        }
        // GET: Almacenes/NSIndex
        public ActionResult NSIndex()
        {
            return View();
        }

        // GET: Almacenes/NSCreate
        public ActionResult NSCreate()
        {
            return View();
        }

        // POST: Almacenes/NSCreate
        [HttpPost]
        public ActionResult NSCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("NSIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/NSEdit/5
        public ActionResult NSEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Almacenes/NSEdit/5
        [HttpPost]
        public ActionResult NSEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("NSIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/NSDelete/5
        [HttpGet]
        public ActionResult NSDelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("NSIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridNotasSalida()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, Documento = "001", Fecha = "15-01-2019", Descripcion = "Nota Ingreso A", Trans = "1", Sit = "" });
            Results.Add(new { Codigo = 2, Documento = "002", Fecha = "15-02-2019", Descripcion = "Nota Ingreso B", Trans = "2", Sit = "" });
            Results.Add(new { Codigo = 3, Documento = "003", Fecha = "15-03-2019", Descripcion = "Nota Ingreso C", Trans = "3", Sit = "" });

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
        public JsonResult GridNSDetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "01", CodigoProducto = "001", Descripcion = "Producto A", Lote = "1010", Und = "Und", PUnitario = "200.44", Cantidad = "50", Total = "550.00" });
            Results.Add(new { Codigo = "02", CodigoProducto = "002", Descripcion = "Producto B", Lote = "2010", Und = "Und", PUnitario = "220.44", Cantidad = "10", Total = "650.00" });
            Results.Add(new { Codigo = "03", CodigoProducto = "003", Descripcion = "Producto C", Lote = "1310", Und = "Und", PUnitario = "203.44", Cantidad = "20", Total = "570.00" });
            Results.Add(new { Codigo = "04", CodigoProducto = "004", Descripcion = "Producto D", Lote = "1040", Und = "Und", PUnitario = "400.44", Cantidad = "30", Total = "558.00" });
            Results.Add(new { Codigo = "05", CodigoProducto = "005", Descripcion = "Producto E", Lote = "1016", Und = "Und", PUnitario = "250.44", Cantidad = "40", Total = "950.00" });

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
        //CRUD DE Generación de Guías, Se Abrevia <GG>
        // GET: Almacenes/AgregarGG
        [HttpGet]
        public ActionResult AgregarGG(string parametro1)
        {
            return PartialView("_AgregarGG");
        }
        // GET: Almacenes/GGIndex
        public ActionResult GGIndex()
        {
            return View();
        }

        // GET: Almacenes/GGCreate
        public ActionResult GGCreate()
        {
            return View();
        }

        // POST: Almacenes/GGCreate
        [HttpPost]
        public ActionResult GGCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("GGIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/GGEdit/5
        public ActionResult GGEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Almacenes/GGEdit/5
        [HttpPost]
        public ActionResult GGEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("GGIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/GGDelete/5
        [HttpGet]
        public ActionResult GGDelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("GGIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridGeneracionGuias()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "01", Documento = "001", Fecha = "15-01-2019", Descripcion = "Guía A", Trans = "1", Sit = "", PrecioVta = "2000.00", Mon = "ME" });
            Results.Add(new { Codigo = "02", Documento = "002", Fecha = "14-02-2019", Descripcion = "Guía B", Trans = "2", Sit = "", PrecioVta = "3000.00", Mon = "ME" });
            Results.Add(new { Codigo = "03", Documento = "003", Fecha = "16-03-2019", Descripcion = "Guía C", Trans = "3", Sit = "", PrecioVta = "4050.00", Mon = "ME" });

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
        public JsonResult GridGGDetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "01", CodigoProducto = "001", Descripcion = "Producto A", Lote = "1010", Und = "Und", PUnitario = "200.44", Cantidad = "50", Total = "550.00" });
            Results.Add(new { Codigo = "02", CodigoProducto = "002", Descripcion = "Producto B", Lote = "2010", Und = "Und", PUnitario = "220.44", Cantidad = "10", Total = "650.00" });
            Results.Add(new { Codigo = "03", CodigoProducto = "003", Descripcion = "Producto C", Lote = "1310", Und = "Und", PUnitario = "203.44", Cantidad = "20", Total = "570.00" });
            Results.Add(new { Codigo = "04", CodigoProducto = "004", Descripcion = "Producto D", Lote = "1040", Und = "Und", PUnitario = "400.44", Cantidad = "30", Total = "558.00" });
            Results.Add(new { Codigo = "05", CodigoProducto = "005", Descripcion = "Producto E", Lote = "1016", Und = "Und", PUnitario = "250.44", Cantidad = "40", Total = "950.00" });

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
        //CRUD DE Transferencia Automática, Se Abrevia <TA>
        // GET: Almacenes/AgregarTA
        [HttpGet]
        public ActionResult AgregarTA(string parametro1)
        {
            return PartialView("_AgregarTA");
        }
        // GET: Almacenes/TAIndex
        public ActionResult TAIndex()
        {
            return View();
        }

        // GET: Almacenes/TACreate
        public ActionResult TACreate()
        {
            return View();
        }

        // POST: Almacenes/TACreate
        [HttpPost]
        public ActionResult TACreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("TAIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/TAEdit/5
        public ActionResult TAEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Almacenes/TAEdit/5
        [HttpPost]
        public ActionResult TAEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("TAIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/TADelete/5
        [HttpGet]
        public ActionResult TADelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("TAIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridTransferenciaAutomatica()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { Codigo = "01", DocumentoOrigen = "001", FechaEmision = "15-01-2019", DocumentoDestino = "XX1", TransOrigen = "1", Sit = "", TransDestino = "11", AlmacenDestino = "A" },
                new AlmacenesModel { Codigo = "02", DocumentoOrigen = "002", FechaEmision = "14-02-2019", DocumentoDestino = "XX2", TransOrigen = "2", Sit = "", TransDestino = "12", AlmacenDestino = "B" },
                new AlmacenesModel { Codigo = "03", DocumentoOrigen = "003", FechaEmision = "16-03-2019", DocumentoDestino = "XX3", TransOrigen = "3", Sit = "", TransDestino = "13", AlmacenDestino = "C" },
            };

            var Resultado = (from N in Listado
                             where N.DocumentoOrigen.Contains(searchValue)
                             select new { N.Codigo, N.DocumentoOrigen, N.FechaEmision, N.DocumentoDestino, N.TransOrigen, N.Sit, N.TransDestino, N.AlmacenDestino });
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
        public JsonResult GridTADetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "01", CodigoProducto = "001", Descripcion = "Producto A", Lote = "1010", Und = "Und", PUnitario = "200.44", Cantidad = "50", Total = "550.00" });
            Results.Add(new { Codigo = "02", CodigoProducto = "002", Descripcion = "Producto B", Lote = "2010", Und = "Und", PUnitario = "220.44", Cantidad = "10", Total = "650.00" });
            Results.Add(new { Codigo = "03", CodigoProducto = "003", Descripcion = "Producto C", Lote = "1310", Und = "Und", PUnitario = "203.44", Cantidad = "20", Total = "570.00" });
            Results.Add(new { Codigo = "04", CodigoProducto = "004", Descripcion = "Producto D", Lote = "1040", Und = "Und", PUnitario = "400.44", Cantidad = "30", Total = "558.00" });
            Results.Add(new { Codigo = "05", CodigoProducto = "005", Descripcion = "Producto E", Lote = "1016", Und = "Und", PUnitario = "250.44", Cantidad = "40", Total = "950.00" });

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
        //CRUD DE Transferencia con Guía, Se Abrevia <TG>
        // GET: Almacenes/AgregarTG
        [HttpGet]
        public ActionResult AgregarTG(string parametro1)
        {
            return PartialView("_AgregarTG");
        }
        // GET: Almacenes/TGIndex
        public ActionResult TGIndex()
        {
            return View();
        }

        // GET: Almacenes/TGCreate
        public ActionResult TGCreate()
        {
            return View();
        }

        // POST: Almacenes/TGCreate
        [HttpPost]
        public ActionResult TGCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("TGIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/TGEdit/5
        public ActionResult TGEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Almacenes/TGEdit/5
        [HttpPost]
        public ActionResult TGEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("TGIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/TGDelete/5
        [HttpGet]
        public ActionResult TGDelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("TGIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridTransferenciaconGuia()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, DocumentoOrigen = "001", Fecha = "15-01-2019", DocumentoDestino = "XX1", TransOrigen = "1", Sit = "", TransDestino = "11", AlmacenDestino = "A" });
            Results.Add(new { Codigo = 2, DocumentoOrigen = "002", Fecha = "14-02-2019", DocumentoDestino = "XX2", TransOrigen = "2", Sit = "", TransDestino = "12", AlmacenDestino = "B" });
            Results.Add(new { Codigo = 3, DocumentoOrigen = "003", Fecha = "16-03-2019", DocumentoDestino = "XX3", TransOrigen = "3", Sit = "", TransDestino = "13", AlmacenDestino = "C" });

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
        public JsonResult GridTGDetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "01", CodigoProducto = "001", Descripcion = "Producto A", Lote = "1010", Und = "Und", PUnitario = "200.44", Cantidad = "50", Total = "550.00" });
            Results.Add(new { Codigo = "02", CodigoProducto = "002", Descripcion = "Producto B", Lote = "2010", Und = "Und", PUnitario = "220.44", Cantidad = "10", Total = "650.00" });
            Results.Add(new { Codigo = "03", CodigoProducto = "003", Descripcion = "Producto C", Lote = "1310", Und = "Und", PUnitario = "203.44", Cantidad = "20", Total = "570.00" });
            Results.Add(new { Codigo = "04", CodigoProducto = "004", Descripcion = "Producto D", Lote = "1040", Und = "Und", PUnitario = "400.44", Cantidad = "30", Total = "558.00" });
            Results.Add(new { Codigo = "05", CodigoProducto = "005", Descripcion = "Producto E", Lote = "1016", Und = "Und", PUnitario = "250.44", Cantidad = "40", Total = "950.00" });

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
        //CRUD DE Transferencia por Conversión de Unidades, Se Abrevia <TCU>
        // GET: Almacenes/AgregarTCU
        [HttpGet]
        public ActionResult AgregarTCU(string parametro1)
        {
            return PartialView("_AgregarTCU");
        }
        // GET: Almacenes/TCUIndex
        public ActionResult TCUIndex()
        {
            return View();
        }

        // GET: Almacenes/TCUCreate
        public ActionResult TCUCreate()
        {
            return View();
        }

        // POST: Almacenes/TCUCreate
        [HttpPost]
        public ActionResult TCUCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("TCUIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/TCUEdit/5
        public ActionResult TCUEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Almacenes/TCUEdit/5
        [HttpPost]
        public ActionResult TCUEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("TCUIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/TCUDelete/5
        [HttpGet]
        public ActionResult TCUDelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("TCUIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridTransferenciaConversionUnidades()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { Codigo = "01", NotaSalida = "001", NotaIngreso = "I-01", FechaEmision = "15-01-2019", ArticuloOrigen = "XX1", ArticuloDestino = "1", Sit = "", CantidadOrigen = 11, UnidadOrigen = "Und", CantidadDestino = 11, UnidadDestino = "Und" },
                new AlmacenesModel { Codigo = "02", NotaSalida = "002", NotaIngreso = "I-02", FechaEmision = "14-02-2019", ArticuloOrigen = "XX2", ArticuloDestino = "2", Sit = "", CantidadOrigen = 12, UnidadOrigen = "Und", CantidadDestino = 12, UnidadDestino = "Und" },
                new AlmacenesModel { Codigo = "03", NotaSalida = "003", NotaIngreso = "I-03", FechaEmision = "16-03-2019", ArticuloOrigen = "XX3", ArticuloDestino = "3", Sit = "", CantidadOrigen = 13, UnidadOrigen = "Und", CantidadDestino = 13, UnidadDestino = "Und" },
            };

            var Resultado = (from N in Listado
                             where N.NotaSalida.Contains(searchValue)
                             select new { N.Codigo, N.NotaSalida, N.NotaIngreso, N.FechaEmision, N.ArticuloOrigen, N.ArticuloDestino, N.Sit, N.CantidadOrigen, N.UnidadOrigen, N.CantidadDestino, N.UnidadDestino });
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
        //CRUD DE Transferencia por Armado de Kits, Se Abrevia <TAK>
        // GET: Almacenes/TAKIndex
        public ActionResult TAKIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridTAK()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { CodigoProducto = "001", DescripcionProducto = "Kit 1", Cantidad = 20, CantidadArmado = 5, CantidadDisponible = 1 },
                new AlmacenesModel { CodigoProducto = "002", DescripcionProducto = "Kit 2", Cantidad = 10, CantidadArmado = 1, CantidadDisponible = 0 },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProducto.Contains(searchValue)
                             select new { N.CodigoProducto, N.DescripcionProducto, N.Cantidad, N.CantidadArmado, N.CantidadDisponible });
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
        //CRUD DE Transferencia por Desarmado de Kits, Se Abrevia <TDK>
        // GET: Almacenes/TDKIndex
        public ActionResult TDKIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridTDK()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "001", Descripcion = "Kit 1", Cantidad = "20", CantArmado = "5", CantDisponible = 1 });
            Results.Add(new { Codigo = "002", Descripcion = "Kit 2", Cantidad = "10", CantArmado = "1", CantDisponible = 0 });

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
        //CRUD DE Notas de Ingreso por Compras Importadas, Se Abrevia <NICI>
        // GET: Almacenes/AgregarNICI
        [HttpGet]
        public ActionResult AgregarNICI(string parametro1)
        {
            return PartialView("_AgregarNICI");
        }
        // GET: Almacenes/NIIndex
        public ActionResult NICIIndex()
        {
            return View();
        }

        // GET: Almacenes/NICICreate
        public ActionResult NICICreate()
        {
            return View();
        }

        // POST: Almacenes/NICICreate
        [HttpPost]
        public ActionResult NICICreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("NICIIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/NICIEdit/5
        public ActionResult NICIEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Almacenes/NICIEdit/5
        [HttpPost]
        public ActionResult NICIEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("NICIIndex");
            }
            catch
            {
                return View();
            }
        }

        // POST: Almacenes/NICIDelete/5
        [HttpGet]
        public ActionResult NICIDelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("NICIIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridNICI()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Documento = "001", Fecha = "15-01-2019", Descripcion = "Nota Ingreso A", Codigo = "1", TM = "X", Sit = "", Orden = "XX1" });
            Results.Add(new { Documento = "002", Fecha = "15-02-2019", Descripcion = "Nota Ingreso B", Codigo = "2", TM = "Y", Sit = "", Orden = "XY2" });
            Results.Add(new { Documento = "003", Fecha = "15-03-2019", Descripcion = "Nota Ingreso C", Codigo = "3", TM = "Z", Sit = "", Orden = "ZX3" });

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
        public JsonResult GridNICIDetalle()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { Codigo = "01", CodigoProducto = "001", DescripcionProducto = "Producto A", Lote = "1010", Unidad = "Und", Precio = 200.44, Cantidad = 50, Total = 550.00, CantidadReq = 20, CantidadRec = 30, Saldo = 200.00 },
                new AlmacenesModel { Codigo = "02", CodigoProducto = "002", DescripcionProducto = "Producto B", Lote = "2010", Unidad = "Und", Precio = 220.44, Cantidad = 10, Total = 650.00, CantidadReq = 20, CantidadRec = 30, Saldo = 200.00 },
                new AlmacenesModel { Codigo = "03", CodigoProducto = "003", DescripcionProducto = "Producto C", Lote = "1310", Unidad = "Und", Precio = 203.44, Cantidad = 20, Total = 570.00, CantidadReq = 20, CantidadRec = 30, Saldo = 200.00 },
                new AlmacenesModel { Codigo = "04", CodigoProducto = "004", DescripcionProducto = "Producto D", Lote = "1040", Unidad = "Und", Precio = 400.44, Cantidad = 30, Total = 558.00, CantidadReq = 20, CantidadRec = 30, Saldo = 200.00 },
                new AlmacenesModel { Codigo = "05", CodigoProducto = "005", DescripcionProducto = "Producto E", Lote = "1016", Unidad = "Und", Precio = 250.44, Cantidad = 40, Total = 950.00, CantidadReq = 20, CantidadRec = 30, Saldo = 200.00 },
            };

            var Resultado = (from N in Listado
                             where N.DescripcionProducto.Contains(searchValue)
                             select new { N.Codigo, N.CodigoProducto, N.DescripcionProducto, N.Lote, N.Unidad, N.Precio, N.Cantidad, N.Total, N.CantidadReq, N.CantidadRec, N.Saldo });
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
        //Consulta / Consulta de Documentos, Se Abrevia <CCD>
        // GET: Almacenes/CCDIndex
        public ActionResult CCDIndex()
        {
            return View();
        }

        // GET: Almacenes/CCDDetalle/5
        public ActionResult CCDDetalle(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridCCD()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, Documento = "001", Fecha = "15-01-2019", Descripcion = "Guía A", Trans = "1", Sit = "", PrecioVta = "2000.00", Mon = "ME" });
            Results.Add(new { Codigo = 2, Documento = "002", Fecha = "14-02-2019", Descripcion = "Guía B", Trans = "2", Sit = "", PrecioVta = "3000.00", Mon = "ME" });
            Results.Add(new { Codigo = 3, Documento = "003", Fecha = "16-03-2019", Descripcion = "Guía C", Trans = "3", Sit = "", PrecioVta = "4050.00", Mon = "ME" });

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
        public JsonResult GridCCD2()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { Codigo = "01", NroTransferencia = "001", FechaEmision = "15-01-2019", DocumentoSalida = "Doc A", Almacen = "Almacen 1", Sit = "", DocumentoIngreso = "X1" },
                new AlmacenesModel { Codigo = "02", NroTransferencia = "002", FechaEmision = "14-02-2019", DocumentoSalida = "Doc B", Almacen = "Almacen B", Sit = "", DocumentoIngreso = "Y2" },
                new AlmacenesModel { Codigo = "03", NroTransferencia = "003", FechaEmision = "16-03-2019", DocumentoSalida = "Doc C", Almacen = "Almacen C", Sit = "", DocumentoIngreso = "Z3" },
            };

            var Resultado = (from N in Listado
                             where N.NroTransferencia.Contains(searchValue)
                             select new { N.Codigo, N.NroTransferencia, N.FechaEmision, N.DocumentoSalida, N.Almacen, N.Sit, N.DocumentoIngreso });
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
        public JsonResult GridCCDDetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "01", CodigoProducto = "001", Descripcion = "Producto A", Lote = "1010", Und = "Und", Cantidad = "20", VUnitario = "30", TotalVta = "200.00" });
            Results.Add(new { Codigo = "02", CodigoProducto = "002", Descripcion = "Producto B", Lote = "2010", Und = "Und", Cantidad = "20", VUnitario = "30", TotalVta = "300.00" });
            Results.Add(new { Codigo = "03", CodigoProducto = "003", Descripcion = "Producto C", Lote = "1310", Und = "Und", Cantidad = "20", VUnitario = "30", TotalVta = "400.00" });
            Results.Add(new { Codigo = "04", CodigoProducto = "004", Descripcion = "Producto D", Lote = "1040", Und = "Und", Cantidad = "20", VUnitario = "30", TotalVta = "250.00" });
            Results.Add(new { Codigo = "05", CodigoProducto = "005", Descripcion = "Producto E", Lote = "1016", Und = "Und", Cantidad = "20", VUnitario = "30", TotalVta = "206.00" });

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
        //Consulta / Stock de Artículos C/S Costos, Se Abrevia <CSAC>
        // GET: Almacenes/CSACLista
        [HttpGet]
        public ActionResult CSACLista(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CSACLista");
        }
        // GET: Almacenes/CSACIndex
        public ActionResult CSACIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridCSAC()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, Descripcion = "Producto A", Familia = "1", Und = "UNI", Stock = "200", Marca = "A", CodAlt = "" });
            Results.Add(new { Codigo = 2, Descripcion = "Producto B", Familia = "2", Und = "UNI", Stock = "300", Marca = "B", CodAlt = "" });
            Results.Add(new { Codigo = 3, Descripcion = "Producto C", Familia = "3", Und = "UNI", Stock = "405", Marca = "C", CodAlt = "" });

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
        //Stock de Artículos, Se abrevia <RASA>
        // GET: Almacenes/RASAIndex
        public ActionResult RASAIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Kardex de Artículos, Se abrevia <RAKA>
        // GET: Almacenes/RAKAIndex
        public ActionResult RAKAIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Stock de Artículos Lote/Serie, Se abrevia <RASAL>
        // GET: Almacenes/RASALIndex
        public ActionResult RASALIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Inventario Valorizado/Stock Valorizado , Se abrevia <RIVSV>
        // GET: Almacenes/RIVSVIndex
        public ActionResult RIVSVIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Inventario Valorizado / Kardex Valorizado, Se abrevia <RIVKV>
        // GET: Almacenes/RIVKVIndex
        public ActionResult RIVKVIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Inventario Valorizado / Inventario Valorizado General por Empresa, Se abrevia <RIVGE>
        // GET: Almacenes/RIVGEIndex
        public ActionResult RIVGEIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Rotación de Stock, Se abrevia <RRS>
        // GET: Almacenes/RRSIndex
        public ActionResult RRSIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Ordenes de Trabajo, Se abrevia <ROT>
        // GET: Almacenes/ROTIndex
        public ActionResult ROTIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Artículos en alerta logístico, Se abrevia <RAAIndex>
        // GET: Almacenes/RAAIndex
        public ActionResult RAAIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //PROCESO
        /**************************************************************************************************************/
        //Recálculo de Stock de Artículos, Se abrevia <PRSA>
        // GET: Almacenes/PRSAIndex
        public ActionResult PRSAIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Valorización de Artículos x Doc. \Artículos Pendientes de Valorizar, Se abrevia <PRSA>
        // GET: Almacenes/PAPVIndex
        public ActionResult PAPVIndex()
        {
            return View();
        }
        //GET: Almacenes/PAPVDetalle
        public ActionResult PAPVDetalle(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridPAPV()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { Codigo = "01", Descripcion = "Producto A", Sit = "NI", NroTransferencia = "000001", FechaEmision = "01-02-2019" },
                new AlmacenesModel { Codigo = "02", Descripcion = "Producto B", Sit = "NI", NroTransferencia = "000002", FechaEmision = "01-03-2019" },
                new AlmacenesModel { Codigo = "03", Descripcion = "Producto C", Sit = "NI", NroTransferencia = "000003", FechaEmision = "04-02-2019" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.FechaEmision, N.Sit, N.NroTransferencia });
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
        //Valorización de Artículos x Doc. \Corrección de Artículos Valorizados, Se abrevia <PCAV>
        // GET: Almacenes/PCAVIndex
        public ActionResult PCAVIndex()
        {
            return View();
        }
        //GET: Almacenes/PCAVDetalle
        public ActionResult PCAVDetalle(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridPCAV()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, Descripcion = "Producto A", TD = "NI", Numero = "000001", Fecha = "01-02-2019" });
            Results.Add(new { Codigo = 4, Descripcion = "Producto B", TD = "NI", Numero = "000002", Fecha = "01-03-2019" });
            Results.Add(new { Codigo = 3, Descripcion = "Producto C", TD = "NI", Numero = "000003", Fecha = "04-02-2019" });

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
        //Revalorización Total, Se abrevia <PRT>
        // GET: Almacenes/PRTIndex
        public ActionResult PRTIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Actualización de Saldos Mensuales, Se abrevia <PASM>
        // GET: Almacenes/PASMIndex
        public ActionResult PASMIndex()
        {
            return View();
        }
        /**************************************************************************************************************/
        //Selección de Artículos por Inventariar, Se abrevia <PSAI>
        // GET: Almacenes/PSAIIndex
        public ActionResult PSAIIndex()
        {
            return View();
        }

        // GET: Almacenes/PSAICreate
        public ActionResult PSAICreate()
        {
            return View();
        }

        // POST: Almacenes/PSAICreate
        [HttpPost]
        public ActionResult PSAICreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("PSAIIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/PSAIEdit/5
        public ActionResult PSAIEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Almacenes/PSAIEdit/5
        [HttpPost]
        public ActionResult PSAIEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("PSAIIndex");
            }
            catch
            {
                return View();
            }
        }

        // POST: Almacenes/PSAIDelete/5
        [HttpGet]
        public ActionResult PSAIDelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("PSAIIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridPSAI()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<AlmacenesModel> Listado = new List<AlmacenesModel>()
            {
                new AlmacenesModel { Codigo = "01", NroTransferencia = "001", FechaEmision = "15-01-2019", Descripcion = "Almacen Principal".ToUpper(), Almacen = "1", Cerrado = "NO", Grabado = "NO" },
                new AlmacenesModel { Codigo = "02", NroTransferencia = "002", FechaEmision = "15-02-2019", Descripcion = "Almacen Secundario".ToUpper(), Almacen = "1", Cerrado = "NO", Grabado = "NO" },
                new AlmacenesModel { Codigo = "03", NroTransferencia = "003", FechaEmision = "15-03-2019", Descripcion = "Almacen Principal".ToUpper(), Almacen = "1", Cerrado = "NO", Grabado = "NO" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.FechaEmision, N.Almacen, N.NroTransferencia, N.Cerrado, N.Grabado });
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
        //Registro de Conteo de Inventario Físico, Se abrevia <PRCIF>
        // GET: Almacenes/PRCIFIndex
        public ActionResult PRCIFIndex()
        {
            return View();
        }
        // GET: Almacenes/PRCIFCreate
        public ActionResult PRCIFCreate()
        {
            return View();
        }

        // POST: Almacenes/PRCIFCreate
        [HttpPost]
        public ActionResult PRCIFCreate(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("PRCIFIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Almacenes/PRCIFEdit/5
        public ActionResult PRCIFEdit(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        // POST: Almacenes/PRCIFEdit/5
        [HttpPost]
        public ActionResult PRCIFEdit(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("PRCIFIndex");
            }
            catch
            {
                return View();
            }
        }

        // POST: Almacenes/PRCIFDelete/5
        [HttpGet]
        public ActionResult PRCIFDelete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("PRCIFIndex");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult GridPRCIF()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, Numero = "001", Fecha = "15-01-2019", Descripcion = "Almacen Principal", Almacen = "1", Cerrado = "NO", Grabado = "NO" });
            Results.Add(new { Codigo = 2, Numero = "002", Fecha = "15-02-2019", Descripcion = "Almacen Principal", Almacen = "1", Cerrado = "NO", Grabado = "NO" });
            Results.Add(new { Codigo = 3, Numero = "003", Fecha = "15-03-2019", Descripcion = "Almacen Principal", Almacen = "1", Cerrado = "NO", Grabado = "NO" });

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
        //Reversión de Documentos Anulados, Se abrevia <PRDA>
        // GET: Almacenes/PRDAIndex
        public ActionResult PRDAIndex()
        {
            return View();
        }
        //GET: Almacenes/PRDADetalle
        public ActionResult PRDADetalle(string codigo)
        {
            Modelo.Codigo = codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridPRDA()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = 1, Descripcion = "Producto A", TD = "NI", Numero = "000001", Fecha = "01-02-2019" });
            Results.Add(new { Codigo = 4, Descripcion = "Producto B", TD = "NI", Numero = "000002", Fecha = "01-03-2019" });
            Results.Add(new { Codigo = 3, Descripcion = "Producto C", TD = "NI", Numero = "000003", Fecha = "04-02-2019" });

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
        public JsonResult GridPRDADetalle()
        {
            List<object> Results = new List<object>();

            Results.Add(new { Codigo = "01", CodigoProducto = "001", Descripcion = "Producto A", Lote = "1010", Und = "Und", Cantidad = "20", VUnitario = "30", TotalVta = "200.00" });
            Results.Add(new { Codigo = "02", CodigoProducto = "002", Descripcion = "Producto B", Lote = "2010", Und = "Und", Cantidad = "20", VUnitario = "30", TotalVta = "300.00" });
            Results.Add(new { Codigo = "03", CodigoProducto = "003", Descripcion = "Producto C", Lote = "1310", Und = "Und", Cantidad = "20", VUnitario = "30", TotalVta = "400.00" });
            Results.Add(new { Codigo = "04", CodigoProducto = "004", Descripcion = "Producto D", Lote = "1040", Und = "Und", Cantidad = "20", VUnitario = "30", TotalVta = "250.00" });
            Results.Add(new { Codigo = "05", CodigoProducto = "005", Descripcion = "Producto E", Lote = "1016", Und = "Und", Cantidad = "20", VUnitario = "30", TotalVta = "206.00" });

            int totalRecords = Results.Count();

            var jsonData = new
            {
                data = Results,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
