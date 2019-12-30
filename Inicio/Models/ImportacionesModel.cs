using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicio.Models
{
    public class ImportacionesModel
    {
        public ImportacionesModel()
        {
            Id = 0;
        }

        public int Id { get; set; }
        public int IdSerie { get; set; }
        public string NroOrden { get; set; }
        public int Incoterm { get; set; }
        public string CodProv { get; set; }
        public string DescripcionProv { get; set; }        
        public string Embarcador { get; set; }
        public string FechaEmision { get; set; }
        public string FechaEntrega { get; set; }
        public double Total { get; set; }
        public string Glosa { get; set; }
        public int MonedaImportacion { get; set; }
        public int EquivalenteME { get; set; }
        public string LugarEntrega { get; set; }
        public string Descripcion { get; set; }
        public string TM { get; set; }
        public string Sit { get; set; }
        public double Importe { get; set; }

        //DETALLE DE COMPRA PARA STOCK (CC)
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string DescripcionProd { get; set; }
        public string Lote { get; set; }
        public double Cantidad { get; set; }
        public string Unidad { get; set; }
        public double Precio { get; set; }
        public double Bruto { get; set; }
        public double Descuento { get; set; }
        public double TotalVta { get; set; }
        public double IGV { get; set; }
        public double ValorVta { get; set; }
        public double Descuento2 { get; set; }

        //GASTOS DE IMPORTACION
        public string Documento { get; set; }
        public string TC { get; set; }
        public double Gastos { get; set; }
        public double DUA { get; set; }

        //NACIONALIZACION DE ARTICULOS
        public string Orden { get; set; }
        public string Incoterms { get; set; }
        public double ValorAduana { get; set; }
        public double ValorEm { get; set; }
        public double IPM { get; set; }
        public double CantidadRequerida { get; set; }
        public double CantidadPend { get; set; }
        public double CantidadRecepcionada { get; set; }
        public double CantidadNacionalizar { get; set; }
    }
}