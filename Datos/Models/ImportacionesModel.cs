using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datos.Models
{
    public class ImportacionesModel
    {
        public ImportacionesModel()
        {
            Documento = "";
        }

        public string Codigo { get; set; }
        public string Documento { get; set; }
        public string FechaEmision { get; set; }
        public string Moneda { get; set; }
        public string MonedaEx { get; set; }
        public string LugarEntrega { get; set; }
        public string CodigoAlterno { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAlt { get; set; }
        public string CodigoMarca { get; set; }
        public string CodigoUnidadMedida { get; set; }
        public string CodigoTipoCompras { get; set; }
        public string CodigoColor { get; set; }
        public double Peso { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioVentaMe { get; set; }
        public double PrecioUnitario { get; set; }
        public double Importe { get; set; }
        public double ImporteIGV { get; set; }
        public double ValorVenta { get; set; }
        public string Familia { get; set; }
        public string Origen { get; set; }
        public string FechaPago { get; set; }
        public string FechaVencimiento { get; set; }
        public string Foto { get; set; }
        public string CodigoLinea { get; set; }
        public string CodigoGrupo { get; set; }
        public string Arancel { get; set; }
        public string Comentario { get; set; }
        public string MesPeriodo { get; set; }
        public bool Habilitado { get; set; }
        public bool AfectaRentabilidad { get; set; }
        public bool ControlSerie { get; set; }
        public bool AfectaStock { get; set; }
        public bool StockLote { get; set; }
        public bool StockSerie { get; set; }
        public string TipoDocumento { get; set; }
        public string CodigoProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
        public double IGV { get; set; }
        public double ImporteBruto { get; set; }
        public double ImporteNeto { get; set; }
        public double TotalCredito { get; set; }
        public double Monto { get; set; }
        public bool IncluyeIGV { get; set; }
        public string Glosa { get; set; }
        public string Documento2 { get; set; }
        public string Dias { get; set; }
        public bool EnviarCXP { get; set; }
        public double Descuento { get; set; }
        public double Gastos { get; set; }
        public double DUA { get; set; }
        public double ValorAduana { get; set; }
        public double ValorEm { get; set; }
        public double IPM { get; set; }
        public string Estatus { get; set; }
        public string NroOrden { get; set; }
        public string TM { get; set; }
        public string Sit { get; set; }
        public string FechaEntrega { get; set; }
        public string Incoterms { get; set; }        

        //DETALLE
        public string CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string Lote { get; set; }
        public double Cantidad { get; set; }
        public string CodigoUnidad { get; set; }
        public string Serie { get; set; }
        public string CodigoEmbarcador { get; set; }
        public double Precio { get; set; }
        public double Bruto { get; set; }
        public double DescuentoProducto { get; set; }
        public double Total { get; set; }
        public double IGVProducto { get; set; }
        public double ValorVta { get; set; }
        public double DescuentoDetalle { get; set; }
        public double CantidadRequerida { get; set; }
        public double CantidadRecepcionada { get; set; }
        public double CantidadPend { get; set; }
        public double CantidadNacionalizar { get; set; }

        //HONORARIOS
        public string TipoHonorario { get; set; }
        public double IR { get; set; }
        public double IES { get; set; }
        public double Afecto { get; set; }
        public double Inafecto { get; set; }

        //GASTOS IMPORTACIONES
        public string CodigoGasto { get; set; }
        public string Parking { get; set; }
        public string Seguro { get; set; }
        public string TipoGasto { get; set; }
        public double TotalMoneda { get; set; }
        public double TotalMonedaEx { get; set; }
        public double Flete { get; set; }
        public double ValorAjuste { get; set; }
        public double FleteME { get; set; }
        public double FleteMN { get; set; }
        public double SeguroME { get; set; }
        public double SeguroMN { get; set; }

        //DETALLE GASTOS IMPORTACIONES
        public string ServicioDespacho { get; set; }
        public string NotaIngreso { get; set; }
        public double FOB { get; set; }
        public double Antidumping { get; set; }
        public double ISC { get; set; }
        public double TasaISC { get; set; }
        public double TasaIMP { get; set; }
    }
}
