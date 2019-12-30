using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datos.Models
{
    public class TipoCambioModel
    {
        public TipoCambioModel()
        {
            Id = 0;
            Fecha = "";
            Compra = 0;
            Venta = 0;
        }

        public int Id { get; set; }
        public string Fecha { get; set; }
        public double Compra { get; set; }
        public double Venta { get; set; }
    }
}
