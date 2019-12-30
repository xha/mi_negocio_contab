using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicio.Models
{
    public class FacturacionModel
    {
        public FacturacionModel()
        {
            Id = 0;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Documento { get; set; }
        public string FechaEmision { get; set; }
        public string Moneda { get; set; }
        public string CodProv { get; set; }
        public string DescripcionProv { get; set; }
        public string Sit { get; set; }
        public string Unidad { get; set; }
        public double Stock { get; set; }
        public double Importe { get; set; }
        public string Ubicacion { get; set; }

        //DETALLE DE ITEMS
        public string Lote { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public double Precio { get; set; }
        public double Cantidad { get; set; }
        public double Total { get; set; }
        public double Descto { get; set; }
        public double IGV { get; set; }
        public double PrecioVenta { get; set; }

        //Ventas por Cliente
        public string RUC { get; set; }
        public string Telefono { get; set; }
        
        //PUNTO DE VENTA
    }
}
