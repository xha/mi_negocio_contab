using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datos.Models
{
    public class UtilitariosModel
    {
        public UtilitariosModel()
        {
            Descripcion = "";
            Codigo = "";
        }

        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string RUCEmpresa { get; set; }
        public string Telefono { get; set; }
        public string DescripcionComercial { get; set; }
        public string DireccionEmpresa { get; set; }
        public string Representante { get; set; }
        public string Pantalla { get; set; }
        public string Documento { get; set; }
        public string Reporte { get; set; }
        public string Moneda { get; set; }

        //TIPO DE PRECIO
        public string DescripcionTipoPrecio { get; set; }
        public string CodigoTipoPrecio { get; set; }

        //COLOR
        public string CodigoColor { get; set; }
        public string DescripcionColor { get; set; }
    }
}
