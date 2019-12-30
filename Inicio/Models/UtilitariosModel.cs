using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicio.Models
{
    public class UtilitariosModel
    {
        public UtilitariosModel()
        {
            Id = 0;
            Descripcion = "";
            Codigo = "";
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string RUCEmpresa { get; set; }
        public string Telefono { get; set; }
        public string DescripcionComercial { get; set; }
    }
}