using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace Inicio.Controllers
{
    public class CajaController : Controller
    {
        private CajaModel Modelo = new CajaModel();
        private ConexionModel cn = new ConexionModel();
        /**************************************************************************************************************/
        //LISTADO DINAMICO
        public dynamic Listado(string ruta)
        {
            string response = cn.ListadoGet(ruta);

            dynamic Listado = JsonConvert.DeserializeObject<List<CajaModel>>(response);

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
        // GET: Caja
        public ActionResult Index()
        {
            Session["MenuColor"] = "goldenrod";
            ViewBag.menu_actual = Session["menu_actual"];
            Session["menu_actual"] = "";
            ViewBag.total_ingreso = "1.000.000,00";
            ViewBag.total_egreso = "350.000,00";
            ViewBag.total = "650.000,00";

            ViewData["ingreso_1"] = new double[] { 2000.00, 5000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 11000.00, 14000.00, 15000.00, 14000.00, 15000.00 };
            ViewData["ingreso_2"] = new double[] { 3000.00, 4000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 15000.00, 14000.00, 25000.00, 10000.00, 21000.00 };
            ViewData["ingreso_3"] = new double[] { 4000.00, 3000.00, 8000.00, 15000.00, 14000.00, 5000.00, 17000.00, 8000.00, 14000.00, 35000.00, 34000.00, 1000.00 };
            ViewData["egreso_1"] = new double[] { 5000.00, 2000.00, 7500.00, 12000.00, 12000.00, 35000.00, 27000.00, 1000.00, 14000.00, 5000.00, 24000.00, 15900.00 };
            ViewData["egreso_2"] = new double[] { 6000.00, 1000.00, 7900.00, 12000.00, 12000.00, 25000.00, 5000.00, 12000.00, 14000.00, 5500.00, 4000.00, 18000.00 };
            ViewData["egreso_3"] = new double[] { 2000.00, 5000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 11000.00, 14000.00, 15000.00, 14000.00, 15000.00 };
            ViewData["egreso_4"] = new double[] { 3000.00, 4000.00, 7000.00, 11000.00, 14000.00, 15000.00, 7000.00, 15000.00, 14000.00, 25000.00, 10000.00, 21000.00 };
            ViewData["ingresos"] = new double[] { 14000.00, 23000.00, 38000.00, 415000.00, 514000.00, 65000.00, 517000.00, 68000.00, 714000.00, 535000.00, 634000.00, 71000.00 };
            ViewData["egresos"] = new double[] { 32000.00, 45000.00, 47000.00, 311000.00, 214000.00, 215000.00, 37000.00, 411000.00, 514000.00, 615000.00, 714000.00, 81500.00 };

            ViewData["meses"] = new string[] { "ENE", "FEB", "MAR", "ABR", "MAY", "JUN", "JUL", "AGO", "SEP", "OCT", "NOV", "DIC" };

            return View();
        }

        //MODAL DE Transacciones DE CAJA
        // GET: Caja/Transacciones
        public ActionResult Transacciones(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Transacciones");
        }

        [HttpPost]
        public JsonResult GridTransacciones()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<MaestroModel> Listado = new List<MaestroModel>();

            var Resultado = (from N in Listado
                             where N.TRANC_COD.Contains(searchValue)
                             select new { N.TRANC_COD, N.TRANC_DESCRIPCION });
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
        //TRANSACCIONES
        /**************************************************************************************************************/
        // Transacciones / Apertura, Se Abrevia <TA>
        // GET: Caja/TAIndex
        public ActionResult TAIndex()
        {
            if (Session["GridCajaApertura"] == null) Session["GridCajaApertura"] = Listado("ListarCaja_Apertura?jsonB64=");
            return View();
        }

        [HttpPost]
        public JsonResult GridCajaAperturada()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            if (Session["GridCajaApertura"] == null) Session["GridCajaApertura"] = Listado("ListarCaja_Apertura?jsonB64=");

            var respuesta = (List<CajaModel>)Session["GridCajaApertura"];
            var Resultado = (from N in respuesta
                             where N.APC_USUARIO.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            switch (order)
            {
                case 0:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.APC_COD) : Resultado.OrderBy(x => x.APC_COD);
                    break;
                case 1:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.APC_USUARIO) : Resultado.OrderBy(x => x.APC_USUARIO);
                    break;
                default:
                    Resultado = (sortColumnDir == "desc") ? Resultado.OrderByDescending(x => x.APC_COD) : Resultado.OrderBy(x => x.APC_COD);
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
        public JsonResult TAActualizar(FormCollection formCollection)
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
        /**************************************************************************************************************/
        // Transacciones / Cierre <TC>
        // GET: Caja/TCIndex
        public ActionResult TCIndex()
        {
            return View();
        }

        // Transacciones / Reapertura <TR>
        // GET: Caja/TRIndex
        public ActionResult TRIndex()
        {
            return View();
        }

        //MODAL DE CIERRE DE CAJA
        // GET: Caja/Cierre
        public ActionResult Cierre(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Cierre");
        }

        // Transacciones / Movimientos de Entrada y salida, Se Abrevia <TMES>
        // GET: Caja/TMESIndex
        public ActionResult TMESIndex()
        {
            return View();
        }

        public ActionResult TMESCreate()
        {
            return View();
        }

        // GET: Caja/Edit
        public ActionResult TMESEdit(CajaModel Modelo)
        {
            return View(Modelo);
        }
        
        [HttpPost]
        public JsonResult GridTMES()
        {
            var draw = Request["draw"];
            var start = Request["start"];
            var length = Request["length"];
            var sortColumn = Request["columns[" + Request["order[0][column]"] + "][name]"];
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();

            List<CajaModel> Listado = new List<CajaModel>();

            var Resultado = (from N in Listado
                             where N.APC_USUARIO.Contains(searchValue)
                             select N );
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
        //CONSULTA
        /**************************************************************************************************************/
        // Consultas / Estado de Caja, Se Abrevia <CEC>
        // GET: Caja/CECIndex
        public ActionResult CECIndex()
        {
            return View();
        }

        // Consultas / Histórico de Cierres de Caja, Se Abrevia <CHCC>
        // GET: Caja/CHCCIndex
        public ActionResult CHCCIndex()
        {
            return View();
        }

        // GET: Caja/CHCCDetalle
        public ActionResult CHCCDetalle(int Codigo)
        {
            Modelo.APC_COD = Codigo;
            return View(Modelo);
        }
        /**************************************************************************************************************/
        //REPORTE
        /**************************************************************************************************************/
        // Reportes / Movimientos Mensuales, Se Abrevia <RMM>
        // GET: Caja/RMMIndex
        public ActionResult RMMIndex()
        {
            return View();
        }
    }
}
