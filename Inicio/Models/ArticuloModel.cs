using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Inicio.Models
{
    public class ArticuloModel : BaseModel
    {
        public ArticuloModel()
        {
            Id = 0;
            Descripcion = "";

        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string CodigoAlterno { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAlt { get; set; }
        public int IdMarca { get; set; }
        public int IdUnidadMedida { get; set; }
        public int IdTipoArticulo { get; set; }
        public int IdColor { get; set; }
        public double Peso { get; set; }
        public string Familia { get; set; }
        public string Foto { get; set; }
        public int IdLinea { get; set; }
        public int IdGrupo { get; set; }
        public string Arancel { get; set; }
        public string DescripcionMarca { get; set; }        
        public string Comentario { get; set; }
        public string Habilitado { get; set; }
        public bool AfectaRentabilidad { get; set; }
        public bool ControlSerie { get; set; }
        public string AfectaStock { get; set; }
        public bool StockLote { get; set; }
        public bool StockSerie { get; set; }
        public string Unidad { get; set; }
        public double Stock { get; set; }
        public double ValorVta { get; set; }
        public string Mon { get; set; }
        public string Lote { get; set; }
        public string TipoPrecio { get; set; }
        public double Porcentaje { get; set; }
        public string Fecha { get; set; }

        public DataTable ArticuloGrid { get; set; }

        //DATOS DE VENTA
        public int IdPrecio { get; set; }
        public double PrecioMinimo { get; set; }
        public double Ganancia { get; set; }
        public double PrecioConIGV { get; set; }
        public double PrecioSinIGV { get; set; }
        public double CantidadMinima { get; set; }
        public double Cantidad { get; set; }
        public double ValorVTA { get; set; }
        public double IGV { get; set; }
        public double PrecioVTA { get; set; }
        

        //DATOS DE COMPRA
        public string CodProv { get; set; }
        public string Documento { get; set; }
        public double PrecioUnitario { get; set; }
        public double ValorUnitario { get; set; }
        public int IdMonedaCompra { get; set; }
        public string FechaCotizacion { get; set; }

        //DATOS DE MANTENIMIENTO DE LOTE
        public int IdLote { get; set; }
        public string FechaFabricacion { get; set; }
        public string FechaVencimiento { get; set; }
        public string Observacion { get; set; }

    }
}