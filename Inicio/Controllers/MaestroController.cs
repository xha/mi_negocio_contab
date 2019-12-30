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
using Newtonsoft.Json.Linq;
using System.Data;

namespace Inicio.Controllers
{
    public class MaestroController : Controller
    {
        private MaestroModel Modelo = new MaestroModel();
        private BancoModel ModeloBanco = new BancoModel();
        private ConexionModel cn = new ConexionModel();
        /**************************************************************************************************************/
        //LISTADO DINAMICO
        public dynamic Listado(string ruta)
        {
            string response = cn.ListadoGet(ruta);

            dynamic Listado = JsonConvert.DeserializeObject<List<MaestroModel>>(response);

            return Listado;
        }
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

        //Generico
        [HttpGet]
        public ActionResult Generico(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Generico");
        }

        //Series de Documentos
        [HttpGet]
        public ActionResult SeriesDoc(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_SeriesDoc");
        }

        [HttpPost]
        public JsonResult GridSeriesDoc()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "01", Descripcion = "Boleta de Venta".ToUpper(), Serie = "001", Visible = "NO" },
                new MaestroModel { Codigo = "02", Descripcion = "Cotización".ToUpper(), Serie = "001", Visible = "SI" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.Serie, N.Visible });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //Formas de Pago
        [HttpGet]
        public ActionResult FormaPago(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_FormaPago");
        }

        [HttpPost]
        public JsonResult GridFormaPago()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "01", Descripcion = "CONTADO".ToUpper() },
                new MaestroModel { Codigo = "02", Descripcion = "CREDITO 07 DIAS".ToUpper() },
                new MaestroModel { Codigo = "02", Descripcion = "CREDITO 15 DIAS".ToUpper() },
                new MaestroModel { Codigo = "02", Descripcion = "CREDITO 30 DIAS".ToUpper() },
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

        //Listado de Colores
        [HttpGet]
        public ActionResult ListaColores(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_ListaColores");
        }

        //Listado de Precios
        [HttpGet]
        public ActionResult ListaPrecios(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_ListaPrecios");
        }

        [HttpPost]
        public JsonResult GridListaPrecios()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "01", Descripcion = "Venta al público".ToUpper(), Serie = "001", Visible = "NO" },
                new MaestroModel { Codigo = "02", Descripcion = "por mayor".ToUpper(), Serie = "001", Visible = "SI" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.Serie, N.Visible });
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
        //CONFIGURACION
        /**************************************************************************************************************/
        // Configuración\ Administración de Punto de Venta, Se Abrevia <CAPV>
        public ActionResult CAPVIndex()
        {
            return View();
        }

        public ActionResult CAPVCreate()
        {
            return View();
        }

        public ActionResult CAPVEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridCAPV()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "1234", Descripcion = "Oficina Principal".ToUpper(), Ubicacion = "Este" },
                new MaestroModel { Codigo = "5678", Descripcion = "Oficina B".ToUpper(), Ubicacion = "Oeste" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.Codigo, N.Ubicacion });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Administración de Usuarios
        // Configuración \ Administración de Usuarios \ Usuarios, Se Abrevia <CAUU>
        public ActionResult CAUUIndex()
        {
            return View();
        }

        public ActionResult CAUUCreate()
        {
            return View();
        }

        public ActionResult CAUUEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridCAUU()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "Enter", Descripcion = "Enter".ToUpper(), Rol = "Enter" },
                new MaestroModel { Codigo = "Support", Descripcion = "Soporte Técnico".ToUpper(), Rol = "Soporte" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.Codigo, N.Rol });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Configuración \ Administración de Usuarios \ Roles, Se Abrevia <CAUR>
        public ActionResult CAURIndex()
        {
            return View();
        }

        public ActionResult CAURCreate()
        {
            return View();
        }

        public ActionResult CAUREdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridCAUR()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "R1", Descripcion = "Soporte".ToUpper() },
                new MaestroModel { Codigo = "R2", Descripcion = "Administrador".ToUpper() },
                new MaestroModel { Codigo = "R3", Descripcion = "Usuario".ToUpper() },
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

        // Configuración \ Administración de Usuarios \ Acciones, Se Abrevia <CAUA>
        public ActionResult CAUAIndex()
        {
            return View();
        }

        public ActionResult CAUACreate()
        {
            return View();
        }

        public ActionResult CAUAEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridCAUA()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "01", Rol = "Administrador", Alias = "Inicio", Descripcion = "Proveedor", Ruta = "Index", Controlador = "Proveedor" },
                new MaestroModel { Codigo = "02", Rol = "Administrador", Alias = "Acciones", Descripcion = "Configuración - Administración de Usuarios - Accion", Ruta = "CAUAIndex", Controlador = "Maestro" },
                new MaestroModel { Codigo = "03", Rol = "Administrador", Alias = "Roles", Descripcion = "Configuración - Administración de Usuarios - Rol", Ruta = "CAURIndex", Controlador = "Maestro" },
                new MaestroModel { Codigo = "04", Rol = "Administrador", Alias = "Usuarios", Descripcion = "Configuración - Administración de Usuarios - Usuario", Ruta = "CAUUIndex", Controlador = "Maestro" },
                new MaestroModel { Codigo = "05", Rol = "Soporte Técnico", Alias = "Roles - Acciones", Descripcion = "Configuración - Administración de Usuarios - Roles - Acciones", Ruta = "CAURAIndex", Controlador = "Maestro" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.Ruta, N.Alias, N.Controlador, N.Rol  });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Configuración \ Administración de Usuarios \ Roles - Acciones, Se Abrevia <CAUR>
        public ActionResult CAURAIndex()
        {
            return View();
        }

        public ActionResult CAURACreate()
        {
            return View();
        }

        /**************************************************************************************************************/
        // Configuración \ Administración de Almacenes, Se Abrevia <CAA>
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        public ActionResult CAAIndex()
        {
            if (Session["GridListadoAlmacenes"] == null) Session["GridListadoAlmacenes"] = Listado("ListarAlmacenes?jsonB64=");
            return View();
        }
        
        public ActionResult CAACreate()
        {
            return View();
        }

        public ActionResult CAAEdit(string Codigo)
        {
            var Listado = JsonConvert.SerializeObject(Session["GridListadoAlmacenes"]);
            dynamic Json = JsonConvert.DeserializeObject(Listado);
            foreach (var item in Json)
            {
                if (item.ALM_CODIGO == Codigo)
                {
                    Modelo.ALM_CODIGO = item.ALM_CODIGO;
                    Modelo.ALM_DESCRI = item.ALM_DESCRI;
                    Modelo.ALM_DIRECC = item.ALM_DIRECC;
                    Modelo.ALM_DISTRI = item.ALM_DISTRI;
                    Modelo.ALM_TELEF = item.ALM_TELEF;
                    Modelo.ALM_NUMENT = item.ALM_NUMENT;
                    Modelo.ALM_NUMSAL = item.ALM_NUMSAL;
                    Modelo.ALM_NUMNE = item.ALM_NUMNE;
                    Modelo.ALM_NUMNS = item.ALM_NUMNS;
                    Modelo.ALM_NUMERO = item.ALM_NUMERO;
                    Modelo.ALM_ZONA = item.ALM_ZONA;
                    Modelo.ALM_INTERIOR = item.ALM_INTERIOR;
                    Modelo.ALM_PROVINCIA = item.ALM_PROVINCIA;
                    Modelo.ALM_DEPARTAMENTO = item.ALM_DEPARTAMENTO;
                    break;
                }
            }

            return View(Modelo);
        }

        [HttpPost]
        public JsonResult CAAActualizar(FormCollection formCollection)
        {
            //JArray data = JArray.Parse(formCollection["datos_enviar"]);
            string accion = "";
            string arr_codigo = "";
            string data = "";
            string color = "";
            bool respuesta = false;

            try
            {
                switch (formCollection["accion"])
                {
                    case "0":
                        JArray ArrayEncabezado = JArray.Parse(formCollection["datos_enviar"]);
                        foreach (JObject item in ArrayEncabezado)
                        {
                            arr_codigo = item.GetValue("ALM_CODIGO").ToString();
                        }
                        var Listado = JsonConvert.SerializeObject(Session["GridListadoAlmacenes"]);
                        dynamic Json = JsonConvert.DeserializeObject(Listado);
                        foreach (var item in Json)
                        {
                            if (item.ALM_CODIGO == arr_codigo)
                            {
                                color = "Amarillo";
                                data = "Registro " + arr_codigo + " ya asociado a: " + item.ALM_DESCRI;
                                respuesta = false;
                                goto salto;
                            }
                        }
                        accion = "RegistrarAlmacen";
                        break;
                    case "1":
                        accion = "ActualizarAlmacen";
                        break;
                    case "2":
                        accion = "EliminarAlmacen";
                        break;
                }

                respuesta = cn.Ejecutar(accion, formCollection["datos_enviar"]);
                if (respuesta)
                {
                    color = "Verde";
                    data = "Registro Actualizado";
                    Session["GridListadoAlmacenes"] = null;
                }
                else
                {
                    color = "Rojo";
                    data = "Error al actualizar el registro";
                }


            }
            catch (Exception ex)
            {
                color = "Amarillo";
                if (ex.InnerException != null)
                {
                    data = ex.InnerException.Message.Replace(System.Environment.NewLine, "");
                }
                else
                {
                    data = ex.Message.Replace(System.Environment.NewLine, "");
                }
            }
        salto:
            var jsonData = new
            {
                data = data,
                color = color,
                respuesta = respuesta
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GridCAA()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            if (Session["GridListadoAlmacenes"] == null) Session["GridListadoAlmacenes"] = Listado("ListarAlmacenes?jsonB64=");

            var respuesta = (List<MaestroModel>)Session["GridListadoAlmacenes"];
            var Resultado = (from N in respuesta
                             where N.ALM_DESCRI.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            switch (order)
            {
                case 0:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.ALM_CODIGO) : Resultado.OrderBy(x => x.ALM_CODIGO);
                    break;
                case 1:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.ALM_DESCRI) : Resultado.OrderBy(x => x.ALM_DESCRI);
                    break;
                default:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.ALM_CODIGO) : Resultado.OrderBy(x => x.ALM_CODIGO);
                    break;
            }

            Resultado = Resultado.Skip(start).Take(length);

            var jsonData = new
            {
                draw = draw,
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************************************/

        // Configuración \ Modificación del IGV, Se Abrevia <CMI>
        public ActionResult CMIIndex()
        {
            return View();
        }

        // Configuración \ Configuración de  Documentos, Se Abrevia <CCD>
        public ActionResult CCDIndex()
        {
            return View();
        }

        public ActionResult CCDCreate()
        {
            return View();
        }

        public ActionResult CCDEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridCCD()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "Enter", Descripcion = "Almacén Principal".ToUpper(), Serie = "A", UltimoCorrelativo = 30 },
                new MaestroModel { Codigo = "Support", Descripcion = "Almacén Secundario".ToUpper(), Serie = "B", UltimoCorrelativo = 40  },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.Codigo, N.Serie, N.UltimoCorrelativo });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Configuración \ Configuración de Precios de Ventas, Se Abrevia <CPV>
        public ActionResult CPVIndex()
        {
            return View();
        }

        // Configuración \ Configuración de Precios de Ventas, Se Abrevia <CPV>
        public ActionResult CPVEIndex()
        {
            return View();
        }

        /**************************************************************************************************************/
        //TABLAS DE AYUDA
        /**************************************************************************************************************/
        // Tablas de Ayuda\ Tipo de Artículo, Se Abrevia <TATA>
        public ActionResult TATAIndex()
        {
            return View();
        }

        public ActionResult TATACreate()
        {
            return View();
        }

        public ActionResult TATAEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTATA()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "0001", Descripcion = "envases y embalajes".ToUpper() },
                new MaestroModel { Codigo = "0002", Descripcion = "materias primas".ToUpper() },
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

        // MODAL: GET: Maestro//TipoPrecio
        [HttpGet]
        public ActionResult TipoPrecio(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_TipoPrecio");
        }
        // Tablas de Ayuda\ Tipo de Precio, Se Abrevia <TATP>
        public ActionResult TATPIndex()
        {
            return View();
        }

        public ActionResult TATPCreate()
        {
            return View();
        }

        public ActionResult TATPEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTATP()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "0001", Descripcion = "tipo de precio a".ToUpper() },
                new MaestroModel { Codigo = "0002", Descripcion = "tipo de precio b".ToUpper() },
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

        // MODAL: GET: Maestro/UnidadMedida
        [HttpGet]
        public ActionResult UnidadMedida(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_UnidadMedida");
        }

        // Tablas de Ayuda\ Unidad de Medida, Se Abrevia <TAUM>
        public ActionResult TAUMIndex()
        {
            return View();
        }

        public ActionResult TAUMCreate()
        {
            return View();
        }

        public ActionResult TAUMEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTAUM()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "0001", Descripcion = "unidad de medida a".ToUpper() },
                new MaestroModel { Codigo = "0002", Descripcion = "unidad de medida b".ToUpper() },
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

        // Tablas de Ayuda\ Tipo de Cliente, Se Abrevia <TATCL>
        public ActionResult TATCLIndex()
        {
            return View();
        }

        public ActionResult TATCLCreate()
        {
            return View();
        }

        public ActionResult TATCLEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // Tablas de Ayuda\ Tabla de Colores, Se Abrevia <TATC>
        public ActionResult TATCIndex()
        {
            return View();
        }

        public ActionResult TATCCreate()
        {
            return View();
        }

        public ActionResult TATCEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTATC()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "0001", Descripcion = "REGISTRO A".ToUpper(), Tipo = "I" },
                new MaestroModel { Codigo = "0002", Descripcion = "REGISTRO B".ToUpper(), Tipo = "S" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.Codigo, N.Tipo });
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
        // Tablas de Ayuda\ Familia de Artículos, Se Abrevia <TAFA>
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult Familias(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Familias");
        }

        [HttpPost]
        public JsonResult GridFamilias()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            if (Session["GridListadoFamilias"] == null) Session["GridListadoFamilias"] = Listado("ListarFamilias?jsonB64=");

            var respuesta = (List<MaestroModel>)Session["GridListadoFamilias"];
            var Resultado = (from N in respuesta
                             where N.fam_nombre.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            switch (order)
            {
                case 0:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.fam_codigo) : Resultado.OrderBy(x => x.fam_codigo);
                    break;
                case 1:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.fam_nombre) : Resultado.OrderBy(x => x.fam_nombre);
                    break;
                default:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.fam_codigo) : Resultado.OrderBy(x => x.fam_codigo);
                    break;
            }

            Resultado = Resultado.Skip(start).Take(length);

            var jsonData = new
            {
                draw = draw,
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TAFAIndex()
        {
            if (Session["GridListadoFamilias"] == null) Session["GridListadoFamilias"] = Listado("ListarFamilias?jsonB64=");
            return View();
        }

        public ActionResult TAFACreate()
        {
            return View();
        }

        public ActionResult TAFAEdit(string Codigo)
        {
            var ListadoFamilia = JsonConvert.SerializeObject(Session["GridListadoFamilias"]);
            dynamic FamiliaJson = JsonConvert.DeserializeObject(ListadoFamilia);
            foreach (var item in FamiliaJson)
            {
                if (item.fam_codigo == Codigo)
                {
                    Modelo.fam_codigo = item.fam_codigo;
                    Modelo.fam_nombre = item.fam_nombre;
                    break;
                }
            }

            return View(Modelo);
        }

        [HttpPost]
        public JsonResult TAFAActualizar(FormCollection formCollection)
        {
            //JArray data = JArray.Parse(formCollection["datos_enviar"]);
            string accion = "";
            string arr_codigo = "";
            string data = "";
            string color = "";
            bool respuesta = false;

            try
            {
                switch (formCollection["accion"])
                {
                    case "0":
                        JArray ArrayEncabezado = JArray.Parse(formCollection["datos_enviar"]);
                        foreach (JObject item in ArrayEncabezado)
                        {
                            arr_codigo = item.GetValue("fam_codigo").ToString();
                        }
                        var ListadoFamilia = JsonConvert.SerializeObject(Session["GridListadoFamilias"]);
                        dynamic FamiliaJson = JsonConvert.DeserializeObject(ListadoFamilia);
                        foreach (var item in FamiliaJson)
                        {
                            if (item.fam_codigo == arr_codigo)
                            {
                                color = "Amarillo";
                                data = "Registro " + arr_codigo + " ya asociado a: " + item.fam_nombre;
                                respuesta = false;
                                goto salto;
                            }
                        }
                        accion = "RegistrarFamilia";
                        break;
                    case "1":
                        accion = "ActualizarFamilia";
                        break;
                    case "2":
                        accion = "EliminarFamilia";
                        break;
                }

                respuesta = cn.Ejecutar(accion, formCollection["datos_enviar"]);
                if (respuesta)
                {
                    color = "Verde";
                    data = "Registro Actualizado";
                    Session["GridListadoFamilias"] = null;
                }
                else
                {
                    color = "Rojo";
                    data = "Error al actualizar el registro";
                }


            }
            catch (Exception ex)
            {
                color = "Amarillo";
                if (ex.InnerException != null)
                {
                    data = ex.InnerException.Message.Replace(System.Environment.NewLine, "");
                }
                else
                {
                    data = ex.Message.Replace(System.Environment.NewLine, "");
                }
            }
        salto:
            var jsonData = new
            {
                data = data,
                color = color,
                respuesta = respuesta
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************************************/
        // Tablas de Ayuda\ Conceptos Generales, Se Abrevia <TCG>
        [HttpPost]
        public JsonResult GridConceptosGenerales()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            if (Session["GridConceptosGenerales"] == null) Session["GridConceptosGenerales"] = Listado("ListarConceptos_Generales?jsonB64=");

            var respuesta = (List<MaestroModel>)Session["GridConceptosGenerales"];
            var Resultado = (from N in respuesta
                             where N.CONCGRAL_DESCRIPCION.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            switch (order)
            {
                case 0:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.CONCGRAL_CODIGO) : Resultado.OrderBy(x => x.CONCGRAL_CODIGO);
                    break;
                case 1:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.CONCGRAL_DESCRIPCION) : Resultado.OrderBy(x => x.CONCGRAL_DESCRIPCION);
                    break;
                default:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.CONCGRAL_CODIGO) : Resultado.OrderBy(x => x.CONCGRAL_CODIGO);
                    break;
            }

            Resultado = Resultado.Skip(start).Take(length);

            var jsonData = new
            {
                draw = draw,
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TCGIndex()
        {
            if (Session["GridConceptosGenerales"] == null) Session["GridConceptosGenerales"] = Listado("ListarConceptos_Generales?jsonB64=");
            return View();
        }

        public ActionResult TCGCreate()
        {
            return View();
        }

        public ActionResult TCGEdit(string Codigo)
        {
            var Listado = JsonConvert.SerializeObject(Session["GridConceptosGenerales"]);
            dynamic Json = JsonConvert.DeserializeObject(Listado);
            foreach (var item in Json)
            {
                if (item.CONCGRAL_CODIGO == Codigo)
                {
                    Modelo.CONCGRAL_CODIGO = item.CONCGRAL_CODIGO;
                    Modelo.CONCGRAL_DESCRIPCION = item.CONCGRAL_DESCRIPCION;
                    Modelo.CONCGRAL_TIPO = item.CONCGRAL_TIPO;
                    Modelo.CONCGRAL_CONTEC = item.CONCGRAL_CONTEC;
                    Modelo.CONCGRAL_CONTEN = item.CONCGRAL_CONTEN;
                    Modelo.CONCGRAL_CONTED = item.CONCGRAL_CONTED;
                    Modelo.CONCGRAL_CONTEL = item.CONCGRAL_CONTEL;
                    Modelo.CONCGRAL_MONTOMIN = item.CONCGRAL_MONTOMIN;
                    break;
                }
            }

            return View(Modelo);
        }

        [HttpPost]
        public JsonResult TCGActualizar(FormCollection formCollection)
        {
            //JArray data = JArray.Parse(formCollection["datos_enviar"]);
            string accion = "";
            string arr_codigo = "";
            string data = "";
            string color = "";
            bool respuesta = false;

            try
            {
                switch (formCollection["accion"])
                {
                    case "0":
                        JArray ArrayEncabezado = JArray.Parse(formCollection["datos_enviar"]);
                        foreach (JObject item in ArrayEncabezado)
                        {
                            arr_codigo = item.GetValue("CONCGRAL_CODIGO").ToString();
                        }
                        var Listado = JsonConvert.SerializeObject(Session["GridConceptosGenerales"]);
                        dynamic Json = JsonConvert.DeserializeObject(Listado);
                        foreach (var item in Json)
                        {
                            if (item.Json == arr_codigo)
                            {
                                color = "Amarillo";
                                data = "Registro " + arr_codigo + " ya asociado a: " + item.CONCGRAL_DESCRIPCION;
                                respuesta = false;
                                goto salto;
                            }
                        }
                        accion = "RegistrarConcepto_General";
                        break;
                    case "1":
                        accion = "ActualizarConcepto_General";
                        break;
                    case "2":
                        accion = "EliminarConcepto_General";
                        break;
                }

                respuesta = cn.Ejecutar(accion, formCollection["datos_enviar"]);
                if (respuesta)
                {
                    color = "Verde";
                    data = "Registro Actualizado";
                    Session["GridConceptosGenerales"] = null;
                }
                else
                {
                    color = "Rojo";
                    data = "Error al actualizar el registro";
                }


            }
            catch (Exception ex)
            {
                color = "Amarillo";
                if (ex.InnerException != null)
                {
                    data = ex.InnerException.Message.Replace(System.Environment.NewLine, "");
                }
                else
                {
                    data = ex.Message.Replace(System.Environment.NewLine, "");
                }
            }
        salto:
            var jsonData = new
            {
                data = data,
                color = color,
                respuesta = respuesta
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************************************/
        // Tablas de Ayuda\ Conceptos Generales, Se Abrevia <TCG>
        [HttpPost]
        public JsonResult GridConversionMonetaria()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            if (Session["GridConversionMoneda"] == null) Session["GridConversionMoneda"] = Listado("ListarCONVERSION_MONEDA?jsonB64=");

            var respuesta = (List<MaestroModel>)Session["GridConversionMoneda"];
            var Resultado = (from N in respuesta
                             where N.COVMON_DESCRIPCION.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            switch (order)
            {
                case 0:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.COVMON_CODIGO) : Resultado.OrderBy(x => x.COVMON_CODIGO);
                    break;
                case 1:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.COVMON_DESCRIPCION) : Resultado.OrderBy(x => x.COVMON_DESCRIPCION);
                    break;
                default:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.COVMON_CODIGO) : Resultado.OrderBy(x => x.COVMON_CODIGO);
                    break;
            }

            Resultado = Resultado.Skip(start).Take(length);

            var jsonData = new
            {
                draw = draw,
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TCMIndex()
        {
            if (Session["GridConversionMoneda"] == null) Session["GridConversionMoneda"] = Listado("ListarCONVERSION_MONEDA?jsonB64=");
            return View();
        }

        public ActionResult TCMCreate()
        {
            return View();
        }

        public ActionResult TCMEdit(string Codigo)
        {
            var Listado = JsonConvert.SerializeObject(Session["GridConversionMoneda"]);
            dynamic Json = JsonConvert.DeserializeObject(Listado);
            foreach (var item in Json)
            {
                if (item.COVMON_CODIGO == Codigo)
                {
                    Modelo.COVMON_CODIGO = item.COVMON_CODIGO;
                    Modelo.COVMON_DESCRIPCION = item.COVMON_DESCRIPCION;
                    break;
                }
            }

            return View(Modelo);
        }

        [HttpPost]
        public JsonResult TCMActualizar(FormCollection formCollection)
        {
            //JArray data = JArray.Parse(formCollection["datos_enviar"]);
            string accion = "";
            string arr_codigo = "";
            string data = "";
            string color = "";
            bool respuesta = false;

            try
            {
                switch (formCollection["accion"])
                {
                    case "0":
                        JArray ArrayEncabezado = JArray.Parse(formCollection["datos_enviar"]);
                        foreach (JObject item in ArrayEncabezado)
                        {
                            arr_codigo = item.GetValue("COVMON_CODIGO").ToString();
                        }
                        var Listado = JsonConvert.SerializeObject(Session["GridConversionMoneda"]);
                        dynamic Json = JsonConvert.DeserializeObject(Listado);
                        foreach (var item in Json)
                        {
                            if (item.Json == arr_codigo)
                            {
                                color = "Amarillo";
                                data = "Registro " + arr_codigo + " ya asociado a: " + item.COVMON_DESCRIPCION;
                                respuesta = false;
                                goto salto;
                            }
                        }
                        accion = "RegistrarCONVERSION_MONEDA";
                        break;
                    case "1":
                        accion = "ActualizarCONVERSION_MONEDA";
                        break;
                    case "2":
                        accion = "EliminarCONVERSION_MONEDA";
                        break;
                }

                respuesta = cn.Ejecutar(accion, formCollection["datos_enviar"]);
                if (respuesta)
                {
                    color = "Verde";
                    data = "Registro Actualizado";
                    Session["GridConversionMoneda"] = null;
                }
                else
                {
                    color = "Rojo";
                    data = "Error al actualizar el registro";
                }


            }
            catch (Exception ex)
            {
                color = "Amarillo";
                if (ex.InnerException != null)
                {
                    data = ex.InnerException.Message.Replace(System.Environment.NewLine, "");
                }
                else
                {
                    data = ex.Message.Replace(System.Environment.NewLine, "");
                }
            }
        salto:
            var jsonData = new
            {
                data = data,
                color = color,
                respuesta = respuesta
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /************************************************************************************************************/
        // Tablas de Ayuda\ Linea de Artículos, Se Abrevia <TALA>
        public ActionResult TALAIndex()
        {
            if (Session["GridListadoLineas"] == null) Session["GridListadoLineas"] = Listado("ListarLinea?jsonB64=");
            return View();
        }

        public ActionResult TALACreate()
        {
            return View();
        }

        public ActionResult TALAEdit(string Codigo)
        {
            var ListadoLinea = JsonConvert.SerializeObject(Session["GridListadoLineas"]);
            dynamic LineasJson = JsonConvert.DeserializeObject(ListadoLinea);
            foreach (var item in LineasJson)
            {
                if (item.fam_codigo == Codigo)
                {
                    Modelo.lin_codigo = item.lin_codigo;
                    Modelo.lin_nombre = item.lin_nombre;
                    Modelo.fam_codigo = item.fam_codigo;
                    break;
                }
            }
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult TALAActualizar(FormCollection formCollection)
        {
            //JArray data = JArray.Parse(formCollection["datos_enviar"]);
            string accion = "";
            string arr_codigo = "";
            string arr_familia = "";
            string data = "";
            string color = "";
            bool respuesta = false;
            bool bandera = false;

            try
            {
                JArray ArrayEncabezado = JArray.Parse(formCollection["datos_enviar"]);
                foreach (JObject item in ArrayEncabezado)
                {
                    arr_codigo = item.GetValue("lin_codigo").ToString();
                    arr_familia = item.GetValue("fam_codigo").ToString();
                }

                switch (formCollection["accion"])
                {
                    case "0":
                        var ListadoLinea = JsonConvert.SerializeObject(Session["GridListadoLineas"]);
                        dynamic LineaJson = JsonConvert.DeserializeObject(ListadoLinea);
                        foreach (var item in LineaJson)
                        {
                            if (item.lin_codigo == arr_codigo)
                            {
                                color = "Amarillo";
                                data = "Registro " + arr_codigo + " ya asociado a: " + item.lin_nombre;
                                respuesta = false;
                                goto salto;
                            }
                        }
                        accion = "RegistrarLinea";
                        break;
                    case "1":
                        accion = "ActualizarLinea";
                        break;
                    case "2":
                        accion = "EliminarLinea";
                        break;
                }

                //BUSCANDO LA FAMILIA SI EXISTE
                if (Session["GridListadoFamilias"] == null) Session["GridListadoFamilias"] = Listado("ListarFamilias?jsonB64=");
                var ListadoFamilia = JsonConvert.SerializeObject(Session["GridListadoFamilias"]);
                dynamic FamiliaJson = JsonConvert.DeserializeObject(ListadoFamilia);
                foreach (var item in FamiliaJson)
                {
                    if (item.fam_codigo == arr_familia)
                    {
                        bandera = true;
                    }
                }

                if (bandera)
                {
                    respuesta = cn.Ejecutar(accion, formCollection["datos_enviar"]);
                    if (respuesta)
                    {
                        color = "Verde";
                        data = "Registro Actualizado";
                        Session["GridListadoLineas"] = null;
                    }
                    else
                    {
                        color = "Rojo";
                        data = "Error al actualizar el registro";
                    }
                }
                else
                {
                    color = "Amarillo";
                    data = "No existe la familia: " + arr_familia;
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                color = "Amarillo";
                if (ex.InnerException != null)
                {
                    data = ex.InnerException.Message.Replace(System.Environment.NewLine, "");
                }
                else
                {
                    data = ex.Message.Replace(System.Environment.NewLine, "");
                }
            }
        salto:
            var jsonData = new
            {
                data = data,
                color = color,
                respuesta = respuesta
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult Lineas(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Lineas");
        }

        [HttpPost]
        public JsonResult GridLineas()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            if (Session["GridListadoLineas"] == null) Session["GridListadoLineas"] = Listado("ListarLinea?jsonB64=");

            var respuesta = (List<MaestroModel>)Session["GridListadoLineas"];
            var Resultado = (from N in respuesta
                             where N.lin_nombre.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            switch (order)
            {
                case 0:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.lin_codigo) : Resultado.OrderBy(x => x.lin_codigo);
                    break;
                case 1:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.lin_nombre) : Resultado.OrderBy(x => x.lin_nombre);
                    break;
                default:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.lin_codigo) : Resultado.OrderBy(x => x.lin_codigo);
                    break;
            }

            Resultado = Resultado.Skip(start).Take(length);

            var jsonData = new
            {
                draw = draw,
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /********************************************************************************************************************************/
        // GET: Articulo/Grupos
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult Grupos(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Grupos");
        }        

        [HttpPost]
        public JsonResult GridGrupos()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            if (Session["GridListadoGrupos"] == null) Session["GridListadoGrupos"] = Listado("ListarGrupo?jsonB64=");

            var respuesta = (List<MaestroModel>)Session["GridListadoGrupos"];
            var Resultado = (from N in respuesta
                             where N.gru_nombre.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            switch (order)
            {
                case 0:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.gru_codigo) : Resultado.OrderBy(x => x.gru_codigo);
                    break;
                case 1:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.gru_nombre) : Resultado.OrderBy(x => x.gru_nombre);
                    break;
                default:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.gru_codigo) : Resultado.OrderBy(x => x.gru_codigo);
                    break;
            }

            Resultado = Resultado.Skip(start).Take(length);

            var jsonData = new
            {
                draw = draw,
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Tablas de Ayuda\ Grupo de Artículos, Se Abrevia <TALA>
        public ActionResult TAGAIndex()
        {
            if (Session["GridListadoGrupos"] == null) Session["GridListadoGrupos"] = Listado("ListarGrupo?jsonB64=");
            return View();
        }

        public ActionResult TAGACreate()
        {
            return View();
        }

        public ActionResult TAGAEdit(string Codigo)
        {
            var ListadoGrupo = JsonConvert.SerializeObject(Session["GridListadoGrupos"]);
            dynamic GruposJson = JsonConvert.DeserializeObject(ListadoGrupo);
            foreach (var item in GruposJson)
            {
                if (item.gru_codigo == Codigo)
                {
                    Modelo.gru_codigo = item.gru_codigo;
                    Modelo.gru_nombre = item.gru_nombre;
                    Modelo.fam_codigo = item.fam_codigo;
                    Modelo.lin_codigo = item.lin_codigo;
                    break;
                }
            }
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult TAGAActualizar(FormCollection formCollection)
        {
            //JArray data = JArray.Parse(formCollection["datos_enviar"]);
            string accion = "";
            string arr_codigo = "";
            string arr_linea = "";
            string arr_familia = "";
            string data = "";
            string color = "";
            bool respuesta = false;
            bool bandera = false;

            try
            {
                JArray ArrayEncabezado = JArray.Parse(formCollection["datos_enviar"]);
                foreach (JObject item in ArrayEncabezado)
                {
                    arr_codigo = item.GetValue("gru_codigo").ToString();
                    arr_linea = item.GetValue("lin_codigo").ToString();
                    arr_familia = item.GetValue("fam_codigo").ToString();
                }

                switch (formCollection["accion"])
                {
                    case "0":
                        var Listado = JsonConvert.SerializeObject(Session["GridListadoGrupos"]);
                        dynamic Json = JsonConvert.DeserializeObject(Listado);
                        foreach (var item in Json)
                        {
                            if (item.gru_codigo == arr_codigo)
                            {
                                color = "Amarillo";
                                data = "Registro " + arr_codigo + " ya asociado a: " + item.gru_nombre;
                                respuesta = false;
                                goto salto;
                            }
                        }
                        accion = "RegistrarLinea";
                        break;
                    case "1":
                        accion = "ActualizarLinea";
                        break;
                    case "2":
                        accion = "EliminarLinea";
                        break;
                }

                //BUSCANDO FAMILIA SI EXISTE
                if (Session["GridListadoFamilias"] == null) Session["GridListadoFamilias"] = Listado("ListarFamilias?jsonB64=");

                var ListadoFamilia = JsonConvert.SerializeObject(Session["GridListadoFamilias"]);
                dynamic FamiliaJson = JsonConvert.DeserializeObject(ListadoFamilia);
                foreach (var item in FamiliaJson)
                {
                    if (item.fam_codigo == arr_familia) bandera = true;
                }

                //BUSCANDO LINEA SI EXISTE
                if (bandera) {
                    if (Session["GridListadoLineas"] == null) Session["GridListadoLineas"] = Listado("ListarLinea?jsonB64=");
                    var ListadoLinea = JsonConvert.SerializeObject(Session["GridListadoLineas"]);
                    dynamic LineaJson = JsonConvert.DeserializeObject(ListadoLinea);
                    bandera = false;
                    foreach (var item in FamiliaJson)
                    {
                        if (item.lin_codigo == arr_linea) bandera = true;
                    }
                } else
                {
                    data = "No existe la familia: "+arr_familia;
                }

                if (bandera)
                {
                    respuesta = cn.Ejecutar(accion, formCollection["datos_enviar"]);
                    if (respuesta)
                    {
                        color = "Verde";
                        data = "Registro Actualizado";
                        Session["GridListadoGrupos"] = null;
                    }
                    else
                    {
                        color = "Rojo";
                        data = "Error al actualizar el registro";
                    }
                }
                else
                {
                    if (data == "")
                    {
                        data = "No existe la línea: " + arr_linea;
                    }
                    color = "Amarillo";
                    respuesta = false;
                }
            }
            catch (Exception ex)
            {
                color = "Amarillo";
                if (ex.InnerException != null)
                {
                    data = ex.InnerException.Message.Replace(System.Environment.NewLine, "");
                }
                else
                {
                    data = ex.Message.Replace(System.Environment.NewLine, "");
                }
            }
        salto:
            var jsonData = new
            {
                data = data,
                color = color,
                respuesta = respuesta
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /********************************************************************************************************************************/
        // Tablas de Ayuda\ Tabla de Aranceles, Se Abrevia <TATAR>
        public ActionResult TATARIndex()
        {
            return View();
        }

        public ActionResult TATARCreate()
        {
            return View();
        }

        public ActionResult TATAREdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // Tablas de Ayuda\ Tipo de Documentos, Se Abrevia <TATD>
        public ActionResult TATDIndex()
        {
            return View();
        }

        public ActionResult TATDCreate()
        {
            return View();
        }

        public ActionResult TATDEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTATD()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "0001", Descripcion = "NOTA DE ABONO".ToUpper(), BSunat = "03", BDocRef = "SI", BCompra = "SI", BAlmacen = "SI", BFacturacion = "SI" },
                new MaestroModel { Codigo = "0002", Descripcion = "BOLETA DE DEPOSITO".ToUpper(), BSunat = "03", BDocRef = "SI", BCompra = "SI", BAlmacen = "SI", BFacturacion = "SI" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.Codigo, N.BSunat, N.BDocRef, N.BCompra, N.BAlmacen, N.BFacturacion });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Tablas de Ayuda\ Tipo de Moneda, Se Abrevia <TATM>
        public ActionResult TATMIndex()
        {
            return View();
        }

        public ActionResult TATMCreate()
        {
            return View();
        }

        public ActionResult TATMEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTATM()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "ME", Descripcion = "MONEDA EXTRANJERA".ToUpper(), Simbolo = "$/.", MonedaNacional = "NO" },
                new MaestroModel { Codigo = "MN", Descripcion = "MONEDA NACIONAL".ToUpper(), Simbolo = "S/.", MonedaNacional = "SI" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.Codigo, N.Simbolo, N.MonedaNacional });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Tablas de Ayuda\ Formas de Pago, Se Abrevia <TAFP>
        public ActionResult TAFPIndex()
        {
            return View();
        }

        public ActionResult TAFPCreate()
        {
            return View();
        }

        public ActionResult TAFPEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // Tablas de Ayuda\ Tipo de Gastos, Se Abrevia <TATG>
        public ActionResult TATGIndex()
        {
            return View();
        }

        // Tablas de Ayuda\ Gastos de Importaciones, Se Abrevia <TAGI>
        public ActionResult TAGIIndex()
        {
            return View();
        }

        public ActionResult TAGICreate()
        {
            return View();
        }

        public ActionResult TAGIEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // Tablas de Ayuda\ Monedas de Importación, Se Abrevia <TAMI>
        public ActionResult TAMIIndex()
        {
            return View();
        }

        public ActionResult TAMICreate()
        {
            return View();
        }

        public ActionResult TAMIEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // Tablas de Ayuda\ Estados de Letras, Se Abrevia <TAEL>
        public ActionResult TAELIndex()
        {
            return View();
        }

        // Tablas de Ayuda\ Estados de Orden de Compra, Se Abrevia <TAEOC>
        public ActionResult TAEOCIndex()
        {
            return View();
        }

        public ActionResult TAEOCCreate()
        {
            return View();
        }

        public ActionResult TAEOCEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // Tablas de Ayuda\ Transacciones de Almacén, Se Abrevia <TATAL>
        public ActionResult TATALIndex()
        {
            return View();
        }

        public ActionResult TATALCreate()
        {
            return View();
        }

        public ActionResult TATALEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }
        
        [HttpPost]
        public JsonResult GridTATAL()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "AE", Descripcion = "ARTIculo ensamblado".ToUpper(), Tipo = "I", Proveedor = "NO", BDocRef = "SI", Cliente = "SI", Comentario = "NO", Descuento = "SI", Motivo = "0" },
                new MaestroModel { Codigo = "CC", Descripcion = "Ingreso por cambio de código".ToUpper(), Tipo = "I", Proveedor = "SI", BDocRef = "NO", Cliente = "SI", Comentario = "NO", Descuento = "SI", Motivo = "" },
                new MaestroModel { Codigo = "II", Descripcion = "inventario inicial".ToUpper(), Tipo = "I", Proveedor = "NO", BDocRef = "SI", Cliente = "SI", Comentario = "SI", Descuento = "NO", Motivo = "0" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Descripcion, N.Codigo, N.Tipo, N.Proveedor, N.BDocRef, N.Cliente, N.Comentario, N.Descuento, N.Motivo });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /************************************************************************************************************/
        // Tablas de Ayuda\ Transacciones de Caja, Se Abrevia <TATCA>
        public ActionResult TATCAIndex()
        {
            if (Session["GridListadoTransaccionesCaja"] == null) Session["GridListadoTransaccionesCaja"] = Listado("ListarCaja_Transacciones?jsonB64=");
            return View();
        }

        public ActionResult TATCACreate()
        {
            return View();
        }

        public ActionResult TATCAEdit(string Codigo)
        {
            var Listado = JsonConvert.SerializeObject(Session["GridListadoTransaccionesCaja"]);
            dynamic Json = JsonConvert.DeserializeObject(Listado);
            foreach (var item in Json)
            {
                if (item.TRANC_COD == Codigo)
                {
                    Modelo.TRANC_COD        = item.TRANC_COD;
                    Modelo.TRANC_INGSAL     = item.TRANC_INGSAL;
                    Modelo.TRANC_DESCRIPCION= item.TRANC_DESCRIPCION;
                    Modelo.TRANC_DOCREF     = item.TRANC_DOCREF;
                    break;
                }
            }

            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTATCA()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]); 
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            /*int pageSize = (length != null) ? length : 0;
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            int skip = (start != null) ? start : 0;*/
            int totalRecords = 0;

            if (Session["GridListadoTransaccionesCaja"] == null) Session["GridListadoTransaccionesCaja"] = Listado("ListarCaja_Transacciones?jsonB64=");

            var respuesta = (List<MaestroModel>)Session["GridListadoTransaccionesCaja"];
            var Resultado = (from N in respuesta
                             where N.TRANC_DESCRIPCION.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            switch (order)
            {
                case 0:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.TRANC_INGSAL) : Resultado.OrderBy(x => x.TRANC_INGSAL);
                    break;
                case 1:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.TRANC_COD) : Resultado.OrderBy(x => x.TRANC_COD);
                    break;
                case 2:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.TRANC_DESCRIPCION) : Resultado.OrderBy(x => x.TRANC_DESCRIPCION);
                    break;
                default:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.TRANC_COD) : Resultado.OrderBy(x => x.TRANC_COD);
                    break;
            }

            Resultado = Resultado.Skip(start).Take(length);

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
        public JsonResult TATCAActualizar(FormCollection formCollection)
        {
            //JArray data = JArray.Parse(formCollection["datos_enviar"]);
            string accion = "";
            string arr_codigo = "";
            string data = "";
            string color = "";
            bool respuesta = false;

            try
            {
                switch (formCollection["accion"])
                {
                    case "0":
                        JArray ArrayEncabezado = JArray.Parse(formCollection["datos_enviar"]);
                        foreach (JObject item in ArrayEncabezado)
                        {
                            arr_codigo = item.GetValue("TRANC_COD").ToString();
                        }
                        var Listado = JsonConvert.SerializeObject(Session["GridListadoTransaccionesCaja"]);
                        dynamic Json = JsonConvert.DeserializeObject(Listado);
                        foreach (var item in Json)
                        {
                            if (item.TRANC_COD == arr_codigo)
                            {
                                color = "Amarillo";
                                data = "Registro " + arr_codigo + " ya asociado a: " + item.TRANC_DESCRIPCION;
                                respuesta = false;
                                goto salto;
                            }
                        }
                        accion = "RegistrarCaja_Transacciones";
                        break;
                    case "1":
                        accion = "ActualizarCaja_Transacciones";
                        break;
                    case "2":
                        accion = "EliminarCaja_Transacciones";
                        break;
                }

                respuesta = cn.Ejecutar(accion, formCollection["datos_enviar"]);
                if (respuesta)
                {
                    color = "Verde";
                    data = "Registro Actualizado";
                    Session["GridListadoTransaccionesCaja"] = null;
                }
                else
                {
                    color = "Rojo";
                    data = "Error al actualizar el registro";
                }


            }
            catch (Exception ex)
            {
                color = "Amarillo";
                if (ex.InnerException != null)
                {
                    data = ex.InnerException.Message.Replace(System.Environment.NewLine, "");
                }
                else
                {
                    data = ex.Message.Replace(System.Environment.NewLine, "");
                }
            }
        salto:
            var jsonData = new
            {
                data = data,
                color = color,
                respuesta = respuesta
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /************************************************************************************************************/

        // Tablas de Ayuda\ Gastos Mensuales, Se Abrevia <TAGM>
        public ActionResult TAGMIndex()
        {
            return View();
        }

        public ActionResult TAGMCreate()
        {
            return View();
        }

        public ActionResult TAGMEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        /**************************************************************************************************************/
        //TABLAS DE BANCO
        /**************************************************************************************************************/
        //LISTA DE BANCOS
        public List<BancoModel> ListadoBancos(string ruta)
        {
            string response = cn.ListadoGet(ruta);

            ModeloBanco.ListadoBancos = JsonConvert.DeserializeObject<List<BancoModel>>(response);

            return ModeloBanco.ListadoBancos;
        }
        //LISTA DE BANCOS EN JSON
        public JsonResult ListadoBancosJson(List<BancoModel> listado)
        {
            var itemsSerialized = JsonConvert.SerializeObject(listado);

            var data = JsonConvert.DeserializeObject<List<BancoModel>>(itemsSerialized);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************************************/
        // Tablas de Banco \ Bancos, Se Abrevia <TBB>
        public ActionResult TBBIndex()
        {
            if (Session["GridListadoBancos"] == null)
            {
                List<BancoModel> grid_bancos = ListadoBancos("ListarBancos?jsonB64=");
                Session["GridListadoBancos"] = grid_bancos;
            }
            return View();
        }

        public ActionResult TBBCreate()
        {
            return View();
        }

        [HttpPost]
        public JsonResult TBBActualizar(FormCollection formCollection)
        {
            //JArray data = JArray.Parse(formCollection["datos_enviar"]);
            string accion = "";
            string arr_codigo = "";
            string data = "";
            string color = "";
            bool respuesta = false;

            try
            {
                switch (formCollection["accion"])
                {
                    case "0":
                        JArray ArrayEncabezado = JArray.Parse(formCollection["datos_enviar"]);
                        foreach (JObject item in ArrayEncabezado)
                        {
                            arr_codigo = item.GetValue("BAN_CODIGO").ToString();
                        }
                        var ListadoBanco = JsonConvert.SerializeObject(Session["GridListadoBancos"]);
                        dynamic BancoJson = JsonConvert.DeserializeObject(ListadoBanco);
                        foreach (var item in BancoJson)
                        {
                            if (item.BAN_CODIGO == arr_codigo)
                            {
                                color = "Amarillo";
                                data = "Registro "+ arr_codigo + " ya asociado a: "+ item.BAN_DESCRIPCION;
                                respuesta = false;
                                goto salto;
                            }
                        }
                        accion = "RegistrarBanco";
                        break;
                    case "1":
                        accion = "ActualizarBanco";
                        break;
                    case "2":
                        accion = "EliminarBanco";
                        break;
                }

                respuesta = cn.Ejecutar(accion, formCollection["datos_enviar"]);
                if (respuesta)
                {
                    color = "Verde";
                    data = "Registro Actualizado";
                    Session["GridListadoBancos"] = null;
                } else
                {
                    color = "Rojo";
                    data = "Error al actualizar el registro";
                }
                

            }
            catch (Exception ex)
            {
                color = "Amarillo";
                if (ex.InnerException != null)
                {
                    data = ex.InnerException.Message.Replace(System.Environment.NewLine, "");
                }
                else
                {
                    data = ex.Message.Replace(System.Environment.NewLine, "");
                }
            }
        salto:
            var jsonData = new
            {
                data = data,
                color = color,
                respuesta = respuesta
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TBBEdit(string Codigo)
        {
            var ListadoBanco = JsonConvert.SerializeObject(Session["GridListadoBancos"]);
            dynamic BancoJson = JsonConvert.DeserializeObject(ListadoBanco);
            foreach (var item in BancoJson)
            {
                if (item.BAN_CODIGO == Codigo)
                {
                    ModeloBanco.BAN_CODIGO = item.BAN_CODIGO;
                    ModeloBanco.BAN_DESCRIPCION = item.BAN_DESCRIPCION;
                    break;
                }
            }

            //ModeloBanco.BAN_CODIGO = Codigo;
            return View(ModeloBanco);
        }

        [HttpPost]
        public JsonResult GridListadoBancos()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            if (Session["GridListadoBancos"] == null)
            {
                List<BancoModel> grid_bancos = ListadoBancos("ListarBancos?jsonB64=");
                Session["GridListadoBancos"] = grid_bancos;
            }

            var respuesta = (List<BancoModel>)Session["GridListadoBancos"];
            var Resultado = (from N in respuesta
                             where N.BAN_DESCRIPCION.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            switch (order)
            {
                case 0:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.BAN_CODIGO) : Resultado.OrderBy(x => x.BAN_CODIGO);
                    break;
                case 1:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.BAN_DESCRIPCION) : Resultado.OrderBy(x => x.BAN_DESCRIPCION);
                    break;
                default:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.BAN_CODIGO) : Resultado.OrderBy(x => x.BAN_CODIGO);
                    break;
            }

            Resultado = Resultado.Skip(start).Take(length);

            var jsonData = new
            {
                draw = draw,
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /**************************************************************************************************************/

        // Tablas de Banco \ Cuentas Bancarias, Se Abrevia <TBCB>
        public ActionResult TBCBIndex()
        {
            return View();
        }

        public ActionResult TBCBCreate()
        {
            return View();
        }

        public ActionResult TBCBEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult GridTBCB()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "01", NroCuenta = "12345678", Descripcion = "Banco a".ToUpper(), Moneda = "MN", TipoCuenta = "Corriente" },
                new MaestroModel { Codigo = "02", NroCuenta = "01234587", Descripcion = "Banco B".ToUpper(), Moneda = "ME", TipoCuenta = "Ahorro" },
                new MaestroModel { Codigo = "03", NroCuenta = "81356544", Descripcion = "Banco c".ToUpper(), Moneda = "MN", TipoCuenta = "Corriente" },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.NroCuenta, N.Moneda, N.TipoCuenta });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Tablas de Banco \ Transacciones Bancarias, Se Abrevia <TBTB>
        public ActionResult TBTBIndex()
        {
            return View();
        }

        public ActionResult TBTBCreate()
        {
            return View();
        }

        public ActionResult TBTBEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        // Tablas de Banco \ Tarjetas de Crédito, Se Abrevia <TBTC>
        public ActionResult TBTCIndex()
        {
            return View();
        }

        public ActionResult TBTCCreate()
        {
            return View();
        }

        public ActionResult TBTCEdit(string Codigo)
        {
            Modelo.Codigo = Codigo;
            return View(Modelo);
        }

        /**************************************************************************************************************/
        //UTILIDADES ADICIONALES
        /**************************************************************************************************************/
        // Utilidades Adicionales \ Creación Masiva de Nuevos Artículos, Se Abrevia <UACMNA>
        public ActionResult UACMNAIndex()
        {
            return View();
        }

        // Utilidades Adicionales\Ingreso de Stock Inicial, Se Abrevia <UAISI>
        public ActionResult UAISIIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridUAISI()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>()
            {
                new MaestroModel { Codigo = "01", Unidad = "Unid", Descripcion = "unidad de cd".ToUpper(), CostoME = 1000.00, CostoMN = 3000.00, Marca = "Sony", Familia = "0001", Linea = "", Grupo = "", Stock = 100 },
                new MaestroModel { Codigo = "02", Unidad = "Unid", Descripcion = "impresora".ToUpper(), CostoME = 3000.00, CostoMN = 4000.00, Marca = "Sony", Familia = "0002", Linea = "", Grupo = "", Stock = 100 },
                new MaestroModel { Codigo = "03", Unidad = "Unid", Descripcion = "cornetas".ToUpper(), CostoME = 2000.00, CostoMN = 5000.00, Marca = "Sony", Familia = "0001", Linea = "", Grupo = "", Stock = 100 },
            };

            var Resultado = (from N in Listado
                             where N.Descripcion.Contains(searchValue)
                             select new { N.Codigo, N.Descripcion, N.Unidad, N.CostoME, N.CostoMN, N.Marca, N.Linea, N.Familia, N.Grupo, N.Stock });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Utilidades Adicionales\Copiar Base de Datos-Otra Empresa, Se Abrevia <UACBDOE>
        public ActionResult UACBDOEIndex()
        {
            return View();
        }

        // Utilidades Adicionales\Sincronizar Base de Datos (Exportar/Importar Movimiento), Se Abrevia <UASBD>
        public ActionResult UASBDIndex()
        {
            return View();
        }
    }
}
