using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos.PlanillaModels;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace Inicio.Controllers
{
    public class PAsistenciaController : Controller
    {
        private PAsistenciaModel Modelo = new PAsistenciaModel();
        /**************************************************************************************************************/
        //AYUDA
        /**************************************************************************************************************/
        [HttpGet]
        public ActionResult Ayuda(string parametro1)
        {
            return PartialView("ayuda/_" + parametro1);
        }
        /**************************************************************************************************************/
        //Horario Fijo
        [HttpGet]
        public ActionResult HorarioFijo(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_HorarioFijo");
        }

        [HttpGet]
        public ActionResult DetalleHorarioFijo(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_DetalleHorarioFijo");
        }

        [HttpPost]
        public JsonResult GridHorarioFijo()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            List<PAsistenciaModel> Listado = new List<PAsistenciaModel>()
            {
                new PAsistenciaModel { CODIGO = "1", DIA = 10, ENTRADA = "08:00", SALIDA = "4:00", HORA_LABORADA = 6, MIN_TARDANZA = 0, HORA_INICIO = "08:00", HORA_TERMINO = "16:00", DIA_LIBRE = "Domingo" },
                new PAsistenciaModel { CODIGO = "2", DIA = 15, ENTRADA = "09:00", SALIDA = "4:30", HORA_LABORADA = 5, MIN_TARDANZA = 60, HORA_INICIO = "09:30", HORA_TERMINO = "14:30", DIA_LIBRE = "Lunes" },
            };

            var Resultado = (from N in Listado
                             where N.CODIGO.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            var jsonData = new
            {
                draw = draw,
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        //Incidencias
        [HttpGet]
        public ActionResult Incidencia(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Incidencia");
        }

        [HttpGet]
        public ActionResult DetalleIncidencia(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_DetalleIncidencia");
        }

        //Incidencias
        [HttpGet]
        public ActionResult IncidenciaHora(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_IncidenciaHora");
        }

        [HttpGet]
        public ActionResult DetalleIncidenciaHora(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_DetalleIncidenciaHora");
        }

        //Calendario de Feriados
        [HttpGet]
        public ActionResult CalendarioFeriado(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_CalendarioFeriado");
        }

        //InterfaceSistemaPlanilla
        [HttpGet]
        public ActionResult InterfaceSistemaPlanilla(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_InterfaceSistemaPlanilla");
        }

        //Registro de Horarios
        [HttpGet]
        public ActionResult RHorario(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RHorario");
        }

        //Registro de Marcaciones
        [HttpGet]
        public ActionResult RMarcaciones(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RMarcaciones");
        }

        //Registro de Horas Extras y Tardanzas
        [HttpGet]
        public ActionResult RHETardanzas(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RHETardanzas");
        }

        //Registro de Incidencias
        [HttpGet]
        public ActionResult RIncidencia(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RIncidencia");
        }

        //Calendario
        [HttpGet]
        public ActionResult Calendario(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_Calendario");
        }

        //Registro de Permisos
        [HttpGet]
        public ActionResult RPermiso(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RPermiso");
        }

        //Reporte Marcaciones por Fecha
        [HttpGet]
        public ActionResult RepMarcacionesFecha(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RepMarcacionesFecha");
        }

        //Reporte Asistencia MINTRA
        [HttpGet]
        public ActionResult RepAsistenciaMintra(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RepAsistenciaMintra");
        }

        //Reporte Horas Extras
        [HttpGet]
        public ActionResult RepHorasExtras(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RepHorasExtras");
        }

        //Reporte Horas Extras
        [HttpGet]
        public ActionResult RepIncidencias(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RepIncidencias");
        }

        //Reporte Permisos
        [HttpGet]
        public ActionResult RepPermisos(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RepPermisos");
        }

        //Reporte Tardanzas
        [HttpGet]
        public ActionResult RepTardanzas(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RepTardanzas");
        }
        
        //Reporte Ranking Horas Extras
        [HttpGet]
        public ActionResult RepRankingHE(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RepRankingHE");
        }

        //Archivo de Sincronizacion
        [HttpGet]
        public ActionResult ArchivoSincronizacion(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_ArchivoSincronizacion");
        }

        [HttpGet]
        public ActionResult DetalleArchivoSincronizacion(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_DetalleArchivoSincronizacion");
        }

        //Parametros de Reloj Marcador
        [HttpGet]
        public ActionResult RelojMarcador(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_RelojMarcador");
        }
        /**************************************************************************************************************/
        // Asistencia \ Control de Asistencia, Se Abrevia <PACA>
        public ActionResult PACAIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GridAsistencia()
        {
            var draw = Convert.ToInt32(Request["draw"]);
            var start = Convert.ToInt32(Request["start"]);
            var length = Convert.ToInt32(Request["length"]);
            var order = Convert.ToInt32(Request["order[0][column]"]);
            var sortColumnDir = Request["order[0][dir]"];
            var searchValue = Request["search[value]"].ToString().ToUpper();
            int totalRecords = 0;

            List<PAsistenciaModel> Listado = new List<PAsistenciaModel>()
            {
                new PAsistenciaModel { CODIGO_TRABAJADOR = "AAJ001", NOMBRE_TRABAJADOR = "AGUILAR ABANTO JUAN MAXIMILIANO", DIA = 10, ENTRADA = "08:00", SALIDA = "4:00", HORA_LABORADA = 6, MIN_TARDANZA = 0, HORA_INICIO = "00:00" },
                new PAsistenciaModel { CODIGO_TRABAJADOR = "BAJ001", NOMBRE_TRABAJADOR = "JOSE MOTA", DIA = 15, ENTRADA = "09:00", SALIDA = "4:30", HORA_LABORADA = 5, MIN_TARDANZA = 60, HORA_INICIO = "00:00"},
            };

            var Resultado = (from N in Listado
                             where N.NOMBRE_TRABAJADOR.Contains(searchValue)
                             select N);
            totalRecords = Resultado.Count();

            var jsonData = new
            {
                draw = draw,
                data = Resultado,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // Asistencia \ Registro de Asistencia, Se Abrevia <PARA>
        public ActionResult PARAIndex()
        {
            return View();
        }

        //Selector de Trabajadores
        [HttpGet]
        public ActionResult SelectorTrabajadores(string parametro1)
        {
            ViewBag.accion = parametro1;
            return PartialView("_SelectorTrabajadores");
        }

        // Asistencia \ Importación del tareaje, Se Abrevia <PAITT>
        public ActionResult PAITTIndex()
        {
            return View();
        }

        // Asistencia \ Importación del tareaje Excel, Se Abrevia <PAITE>
        public ActionResult PAITEIndex()
        {
            return View();
        }
    }
}