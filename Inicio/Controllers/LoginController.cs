using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Datos.Models;

namespace Inicio.Controllers
{
    public class LoginController : Controller
    {
        private LoginModel Modelo = new LoginModel();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recuperar()
        {
            return View();
        }

        public ActionResult Crear()
        {
            return View();
        }
    }
}
