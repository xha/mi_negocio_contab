using Datos.Data;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inicio.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        [HttpGet]
        public ActionResult Index(int? id, string acc = "")
        {
            if (Convert.ToInt32(id) == 0)
            {
                Session["MenuId"] = 0;
            }
            else
            {
                Session["MenuId"] = Convert.ToInt32(id);
            }

            Session["menu_actual"] = acc;
            switch (Convert.ToInt32(id))
            {
                case 10:
                    return RedirectToAction("Index", "Compras");
                case 14:
                    return RedirectToAction("Index", "Importaciones");
                case 18:
                    return RedirectToAction("Index", "Almacenes");
                case 23:
                    return RedirectToAction("Index", "Facturacion");
                case 28:
                    return RedirectToAction("Index", "PuntoVenta");
                case 33:
                    return RedirectToAction("Index", "CuentasPorCobrar");
                case 38:
                    return RedirectToAction("Index", "CuentasPorPagar");
                case 43:
                    return RedirectToAction("Index", "Caja");
                case 47:
                    return RedirectToAction("Index", "Banco");
                case 52:
                    return RedirectToAction("Index", "Gerente");
                case 59:
                    return RedirectToAction("Index", "Utilitarios");
                case 226:
                    return RedirectToAction("Index", "Maestro");
                case 280:
                    return RedirectToAction("Index", "Planilla");
                case 446:
                    return RedirectToAction("Index", "Contabilidad");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Menus()
        {
            int id = Convert.ToInt32(Session["MenuId"]);
            var data = new MenuDatos();
            List<Menu> cadena;

            if (Convert.ToInt32(id) == 0)
            {
                cadena = data.MenuItems().ToList();
            }
            else
            {
                cadena = data.MenuItems().Where(c => c.parentId == Convert.ToInt32(id)).ToList();
            }

            switch (Convert.ToInt32(id))
            {
                case 10:
                    ViewBag.Titulo = "Compras";
                    break;
                case 14:
                    ViewBag.Titulo = "Importaciones";
                    break;
                case 18:
                    ViewBag.Titulo = "Almacenes";
                    break;
                case 23:
                    ViewBag.Titulo = "Facturacion";
                    break;
                case 28:
                    ViewBag.Titulo = "Punto de Venta";
                    break;
                case 33:
                    ViewBag.Titulo = "Cuentas Por Cobrar";
                    break;
                case 38:
                    ViewBag.Titulo = "Cuentas Por Pagar";
                    break;
                case 43:
                    ViewBag.Titulo = "Caja";
                    break;
                case 47:
                    ViewBag.Titulo = "Banco";
                    break;
                case 52:
                    ViewBag.Titulo = "Gerente";
                    break;
                case 59:
                    ViewBag.Titulo = "Utilidades";
                    break;
                case 226:
                    ViewBag.Titulo = "Maestro";
                    break;
                case 280:
                    ViewBag.Titulo = "Planilla";
                    break;
                case 446:
                    ViewBag.Titulo = "Contabilidad";
                    break;
                default:
                    ViewBag.Titulo = "Inicio";
                    break;
            }

            return PartialView("_Menu", cadena);
        }

        public ActionResult TopMenu()
        {
            return PartialView("_TopMenu");
        }

        //[HttpGet]
        public JsonResult GridMenu()
        {
            var Listado = new MenuDatos().MenuItems().ToList(); 
            //List<MenuDatos> Listado = new List<MenuDatos>();
            
            var Resultado = (from N in Listado
                             where N.action != "" && N.action != null && N.imageClass == "fa fa-check fa-fw"
                             select new { N.Id, Name = string.Format("{0} {1} {2}", N.controller," / " ,N.nameOption), N.nameOption, N.action, N.controller, N.parentId, N.parentId2, N.parentId3 });

            return Json(Resultado, JsonRequestBehavior.AllowGet);
        }
    }
}
