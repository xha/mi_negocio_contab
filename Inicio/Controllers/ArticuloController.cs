using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using static Inicio.Controllers.GlobalController;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inicio.Controllers
{
    public class ArticuloController : Controller
    {
        private ArticuloModel Modelo = new ArticuloModel();
        private MaestroModel ModeloMaestro = new MaestroModel();
        private ConexionModel cn = new ConexionModel();
        /**************************************************************************************************************/
        //LISTADO DINAMICO
        public dynamic Listado(string ruta)
        {
            string response = cn.ListadoGet(ruta);

            dynamic Listado = JsonConvert.DeserializeObject<List<ArticuloModel>>(response);

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
        
        /********************************************************************************************************************************/
        // GET: Articulo/Tipos de Articulos
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult TipoArticulo(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_TipoArticulos");
        }

        [HttpPost]
        public JsonResult GridTipoArticulo()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            if (Session["GridListadoTipoArticulos"] == null) Session["GridListadoTipoArticulos"] = Listado("ListarTipoArticulo?jsonB64=");

            var respuesta = (List<MaestroModel>)Session["GridListadoTipoArticulos"];

            var Resultado = (from N in respuesta
                             where N.TART_DESCRIPCION.Contains(searchValue)
                             select new { N.TART_CODIGO, N.TART_DESCRIPCION });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /********************************************************************************************************************************/
        // GET: Articulo/Articulos
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult Articulos(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Articulos");
        }

        [HttpPost]
        public JsonResult GridArticulos()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            if (Session["GridListadoArticulos"] == null) Session["GridListadoArticulos"] = Listado("ListarArticulos?jsonB64=");
            var respuesta = (List<ArticuloModel>)Session["GridListadoArticulos"];

            var Resultado = (from N in respuesta
                             where N.ADESCRI.Contains(searchValue)
                             select new { N.ACODIGO, N.ADESCRI, N.AFSTOCK, N.UM_ABREV, N.ADESCRI2, N.APESO });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        
        /********************************************************************************************************************************/
        // GET: Articulo/PrecioArticulo
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult PrecioArticulo(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_PrecioArticulo");
        }

        [HttpPost]
        public JsonResult GridPrecioArticulo()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            if (Session["GridListadoArticulos"] == null) Session["GridListadoArticulos"] = Listado("ListarArticulos?jsonB64=");
            var respuesta = (List<ArticuloModel>)Session["GridListadoArticulos"];

            var Resultado = (from N in respuesta
                             where N.ADESCRI.Contains(searchValue)
                             select new { N.ACODIGO, N.ADESCRI });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /********************************************************************************************************************************/
        //CRUD
        // GET: Articulo
        [NoDirectAccess]
        public ActionResult Index()
        {
            if (Session["GridListadoArticulos"] == null) Session["GridListadoArticulos"] = Listado("ListarArticulos?jsonB64=");
            return View();
        }

        // GET: Articulo
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View(Modelo);
        }

        // GET: Articulo/Edit
        [NoDirectAccess]
        public ActionResult Edit(string Codigo)
        {
            var Listado = JsonConvert.SerializeObject(Session["GridListadoArticulos"]);
            dynamic Json = JsonConvert.DeserializeObject(Listado);
            foreach (var item in Json)
            {
                if (item.fam_codigo == Codigo)
                {
                    Modelo.ACODIGO = item.ACODIGO;
                    Modelo.ADESCRI = item.ADESCRI;
                    Modelo.UM_ABREV = item.UM_ABREV;
                    break;
                }
            }

            return View(Modelo);
        }

        // GET: Articulo
        [NoDirectAccess]
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult MantenimientoKitIndex()
        {
            return PartialView("_MantenimientoKitIndex");
        }
        /********************************************************************************************************************************/
        //EQUIVALENTES
        public ActionResult EquivalenteIndex(string Codigo)
        {
            var Listado = JsonConvert.SerializeObject(Session["GridListadoArticulos"]);
            dynamic Json = JsonConvert.DeserializeObject(Listado);
            foreach (var item in Json)
            {
                if (item.ACODIGO == Codigo)
                {
                    Modelo.ACODIGO = item.ACODIGO;
                    Modelo.ADESCRI = item.ADESCRI;
                    Modelo.UM_ABREV = item.UM_ABREV;
                    break;
                }
            }
            return PartialView("_EquivalenteIndex", Modelo );
            //return View();
        }

        [HttpPost]
        public JsonResult EquivalenteActualizar(FormCollection formCollection)
        {
            //JArray data = JArray.Parse(formCollection["datos_enviar"]);
            string accion = "";
            int arr_codigo = 0;
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
                            arr_codigo = Convert.ToInt32(item.GetValue("APC_COD"));
                        }
                        var Listado = JsonConvert.SerializeObject(Session["GridCajaApertura"]);
                        dynamic Json = JsonConvert.DeserializeObject(Listado);
                        foreach (var item in Json)
                        {
                            if (item.APC_COD == arr_codigo)
                            {
                                color = "Amarillo";
                                data = "Caja " + arr_codigo + " ya aperturada";
                                respuesta = false;
                                goto salto;
                            }
                        }
                        accion = "RegistrarCaja_Apertura";
                        break;
                    case "1":
                        accion = "ActualizarCaja_Apertura";
                        break;
                    case "2":
                        accion = "EliminarCaja_Apertura";
                        break;
                }

                respuesta = cn.Ejecutar(accion, formCollection["datos_enviar"]);
                if (respuesta)
                {
                    color = "Verde";
                    data = "Registro Actualizado";
                    Session["GridCajaApertura"] = null;
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
        /********************************************************************************************************************************/
        //MANTENIMIENTO DE ARTICULOS ALTERNATIVOS
        public ActionResult ProductoAlternativoIndex(string Codigo)
        {
            var Listado = JsonConvert.SerializeObject(Session["GridListadoArticulos"]);
            dynamic Json = JsonConvert.DeserializeObject(Listado);
            foreach (var item in Json)
            {
                if (item.ACODIGO == Codigo)
                {
                    Modelo.ACODIGO = item.ACODIGO;
                    Modelo.ADESCRI = item.ADESCRI;
                    Modelo.UM_ABREV = item.UM_ABREV;
                    break;
                }
            }
            return PartialView("_ProductoAlternativoIndex", Modelo);
        }

        [HttpPost]
        public JsonResult GridArtNoVinculados()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            if (Session["GridListadoArticulosAlternativos"] == null) Session["GridListadoArticulosAlternativos"] = Listado("ListarArticulos_Alter?jsonB64=");
            var respuesta = (List<ArticuloModel>)Session["GridListadoArticulos"];

            var Resultado = (from N in respuesta
                             where N.ARTCOD.Contains(searchValue)
                             select N);
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /********************************************************************************************************************************/
        //MANTENIMIENTOS POR LOTE
        public ActionResult MantenimientoLoteIndex()
        {
            return PartialView("_MantenimientoLoteIndex");
        }
        public ActionResult MantenimientoLoteCreate()
        {
            return PartialView("_MantenimientoLoteCreate");
        }

        [HttpPost]
        public JsonResult GridMantenimientoLote()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            if (Session["GridListadoArticulos"] == null) Session["GridListadoArticulos"] = Listado("ListarArticulos?jsonB64=");
            var respuesta = (List<ArticuloModel>)Session["GridListadoArticulos"];

            var Resultado = (from N in respuesta
                             where N.ADESCRI.Contains(searchValue)
                             select new { N.ACODIGO, N.ADESCRI });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /********************************************************************************************************************************/
        //GET: Datos de la Venta
        public ActionResult DatosVentaIndex()
        {
            return PartialView("_DatosVentaIndex");
        }
        public ActionResult DatosVentaCreate()
        {
            return PartialView("_DatosVentaCreate");
        }

        [HttpPost]
        public JsonResult GridDatosVenta()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            if (Session["GridListadoArticulos"] == null) Session["GridListadoArticulos"] = Listado("ListarArticulos?jsonB64=");
            var respuesta = (List<ArticuloModel>)Session["GridListadoArticulos"];

            var Resultado = (from N in respuesta
                             where N.ADESCRI.Contains(searchValue)
                             select new { N.ACODIGO, N.ADESCRI });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        /********************************************************************************************************************************/
        //GET: Datos de la Compra
        public ActionResult DatosCompraIndex()
        {
            return PartialView("_DatosCompraIndex");
        }
        public ActionResult DatosCompraCreate()
        {
            return PartialView("_DatosCompraCreate");
        }

        [HttpPost]
        public JsonResult GridDatosCompraProv()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            if (Session["GridListadoArticulos"] == null) Session["GridListadoArticulos"] = Listado("ListarArticulos?jsonB64=");
            var respuesta = (List<ArticuloModel>)Session["GridListadoArticulos"];

            var Resultado = (from N in respuesta
                             where N.ADESCRI.Contains(searchValue)
                             select new { N.ACODIGO, N.ADESCRI });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GridDatosCompra()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            if (Session["GridListadoArticulos"] == null) Session["GridListadoArticulos"] = Listado("ListarArticulos?jsonB64=");
            var respuesta = (List<ArticuloModel>)Session["GridListadoArticulos"];

            var Resultado = (from N in respuesta
                             where N.ADESCRI.Contains(searchValue)
                             select new { N.ACODIGO, N.ADESCRI });
            int totalRecords = Resultado.Count();

            var jsonData = new
            {
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
