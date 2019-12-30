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
    public class ProveedorController : Controller
    {
        private AnexoModel Modelo = new AnexoModel();
        private ConexionModel cn = new ConexionModel();
        /**************************************************************************************************************/
        //LISTADO DINAMICO
        public dynamic Listado(string ruta)
        {
            string response = cn.ListadoGet(ruta);

            dynamic Listado = JsonConvert.DeserializeObject<List<AnexoModel>>(response);

            return Listado;
        }

        //LISTADO BANCO
        public dynamic ListadoBanco(string ruta)
        {
            string response = cn.ListadoGet(ruta);

            dynamic Listado = JsonConvert.DeserializeObject<List<BancoModel>>(response);

            return Listado;
        }
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_"+parametro1);
        }
        /**************************************************************************************************************/

        // GET: Proveedor/Proveedor
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult Proveedores(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Proveedor");
        }
        // GET: Proveedor/Embarcador
        //La view que se usara en todos lados del sistema donde sea llamado, recibe como parametro una funcion y devuelve el id
        [HttpGet]
        public ActionResult Embarcadores(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Embarcador");
        }

        // GET: Proveedor
        [NoDirectAccess]
        public ActionResult Index()
        {
            if (Session["GridListadoProveedores"] == null) Session["GridListadoProveedores"] = Listado("ListarProveedores?jsonB64=");
            return View();
        }

        // GET: Proveedor
        [NoDirectAccess]
        public ActionResult Create()
        {
            return View(Modelo);
        }

        // GET: Proveedor
        [NoDirectAccess]
        public ActionResult Edit(string Codigo)
        {
            var Listado = JsonConvert.SerializeObject(Session["GridListadoProveedores"]);
            dynamic Json = JsonConvert.DeserializeObject(Listado);
            foreach (var item in Json)
            {
                if (item.ANEX_CODIGO == Codigo)
                {
                    Modelo.ANEX_CODIGO = item.ANEX_CODIGO;
                    Modelo.TIPOANEX_CODIGO = item.TIPOANEX_CODIGO;
                    Modelo.ANEX_REFERENCIA = item.ANEX_REFERENCIA;
                    Modelo.ANEX_DESCRIPCION = item.ANEX_DESCRIPCION;
                    Modelo.ANEX_DIRECCION = item.ANEX_DIRECCION;
                    Modelo.ANEX_GIRO = item.ANEX_GIRO;
                    Modelo.ANEX_TELEFONO = item.ANEX_TELEFONO;
                    Modelo.ANEX_REPRESENTANTE = item.ANEX_REPRESENTANTE;
                    Modelo.ANEX_RUC = item.ANEX_RUC;
                    Modelo.ANEX_DOCIDENT = item.ANEX_DOCIDENT;
                    Modelo.ANEX_EMAIL = item.ANEX_EMAIL;
                    Modelo.ANEX_DSCTO = item.ANEX_DSCTO;
                    Modelo.ANEX_CREDITO = item.ANEX_CREDITO;
                    Modelo.ANEX_TELEFONO2 = item.ANEX_TELEFONO2;
                    Modelo.ANEX_TELEFONO3 = item.ANEX_TELEFONO3;
                    Modelo.ANEX_DIRECCION2 = item.ANEX_DIRECCION2;
                    Modelo.ANEX_NOTAS = item.ANEX_NOTAS;
                    Modelo.ANEX_BANCO = item.ANEX_BANCO;
                    Modelo.ANEX_NROCTA = item.ANEX_NROCTA;
                    Modelo.ANEX_ZONAVTA = item.ANEX_ZONAVTA;
                    Modelo.ANEX_VENDASIG = item.ANEX_VENDASIG;
                    Modelo.ANEX_FORMPAG = item.ANEX_FORMPAG;
                    Modelo.ANEX_DESCRIPCOMERC = item.ANEX_DESCRIPCOMERC;
                    Modelo.ANEXO_MODELOVEH = item.ANEXO_MODELOVEH;
                    Modelo.ANEXO_NROINSCRIP = item.ANEXO_NROINSCRIP;
                    Modelo.ANEXO_PLACA = item.ANEXO_PLACA;
                    Modelo.ANEXO_BREVE = item.ANEXO_BREVE;
                    Modelo.ANEX_VENDPROV = item.ANEX_VENDPROV;
                    Modelo.ANEX_MONCREDITO = item.ANEX_MONCREDITO;
                    Modelo.ANEX_NUMERO = item.ANEX_NUMERO;
                    Modelo.ANEX_ZONA = item.ANEX_ZONA;
                    Modelo.ANEX_DISTRITO = item.ANEX_DISTRITO;
                    Modelo.ANEX_PROVINCIA = item.ANEX_PROVINCIA;
                    Modelo.ANEX_DEPARTAMENTO = item.ANEX_DEPARTAMENTO;
                    Modelo.ANEX_INTERIOR = item.ANEX_INTERIOR;
                    Modelo.L_TIP_CLI = 0;
                    break;
                }
            }
            return View(Modelo);
        }

        [HttpPost]
        public JsonResult Actualizar(FormCollection formCollection)
        {
            //JArray data = JArray.Parse(formCollection["datos_enviar"]);
            string accion = "";
            string arr_banco = "";
            string arr_codigo = "";
            string data = "";
            string color = "";
            bool respuesta = false;
            bool bandera = true;

            try
            {
                JArray ArrayEncabezado = JArray.Parse(formCollection["datos_enviar"]);
                foreach (JObject item in ArrayEncabezado)
                {
                    arr_codigo = item.GetValue("ANEX_CODIGO").ToString();
                    arr_banco = item.GetValue("ANEX_BANCO").ToString();
                }

                switch (formCollection["accion"])
                {
                    case "0":
                        var Listado = JsonConvert.SerializeObject(Session["GridListadoProveedores"]);
                        dynamic Json = JsonConvert.DeserializeObject(Listado);
                        foreach (var item in Json)
                        {
                            if (item.ANEX_CODIGO == arr_codigo)
                            {
                                color = "Amarillo";
                                data = "Registro " + arr_codigo + " ya asociado a: " + item.ANEX_DESCRIPCION;
                                respuesta = false;
                                goto salto;
                            }
                        }
                        accion = "RegistrarProveedor";
                        break;
                    case "1":
                        accion = "ActualizarProveedor";
                        break;
                    case "2":
                        accion = "EliminarProveedor";
                        break;
                }

                if (arr_banco != "")
                {
                    bandera = false;
                    //BUSCANDO BANCO SI EXISTE
                    var Lista = JsonConvert.SerializeObject(ListadoBanco("ListarBancos?jsonB64="));
                    dynamic Json = JsonConvert.DeserializeObject(Lista);
                    foreach (var item in Json)
                    {
                        if (item.BAN_CODIGO == arr_banco)
                        {
                            bandera = true;
                            break;
                        }
                    }
                }


                if (bandera)
                {
                    respuesta = cn.Ejecutar(accion, formCollection["datos_enviar"]);
                    if (respuesta)
                    {
                        color = "Verde";
                        data = "Registro Actualizado";
                        Session["GridListadoProveedores"] = null;
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
                    data = "No existe el banco: " + arr_banco;
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

        [HttpPost]
        public JsonResult GridProveedores()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            if (Session["GridListadoProveedores"] == null) Session["GridListadoProveedores"] = Listado("ListarLinea?jsonB64=");

            var respuesta = (List<AnexoModel>)Session["GridListadoProveedores"];
            var Resultado = (from N in respuesta
                             where N.ANEX_DESCRIPCION.Contains(searchValue)
                             select new { N.ANEX_CODIGO, N.TIPOANEX_CODIGO,N.ANEX_REFERENCIA,N.ANEX_DESCRIPCION,N.ANEX_DIRECCION,N.ANEX_GIRO,N.ANEX_TELEFONO,
                                 N.ANEX_REPRESENTANTE,N.ANEX_RUC,N.ANEX_DOCIDENT,N.ANEX_EMAIL,N.ANEX_DSCTO,N.ANEX_CREDITO,N.ANEX_TELEFONO2,N.ANEX_TELEFONO3, N.ANEX_DIRECCION2,
                                 N.ANEX_NOTAS, N.ANEX_BANCO, N.ANEX_NROCTA, N.ANEX_ZONAVTA, N.ANEX_VENDASIG, N.ANEX_FORMPAG, N.ANEX_DESCRIPCOMERC, N.ANEXO_MODELOVEH, N.ANEXO_NROINSCRIP,
                                 N.ANEXO_PLACA, N.ANEXO_BREVE, N.ANEX_VENDPROV, N.ANEX_MONCREDITO, N.ANEX_NUMERO, N.ANEX_ZONA, N.ANEX_DISTRITO, N.ANEX_PROVINCIA, N.ANEX_DEPARTAMENTO,
                                 N.ANEX_INTERIOR, N.L_TIP_CLI
                             });
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
