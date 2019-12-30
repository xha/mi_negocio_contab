using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datos.Models
{
    public class CuentasPorCobrarModel
    {
        public CuentasPorCobrarModel()
        {
            Codigo = "";
        }

        public string Codigo { get; set; }
        public string Documento { get; set; }
        public string FechaEmision { get; set; }
        public string Moneda { get; set; }
        public string CodigoAlterno { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAlt { get; set; }
        public string CodigoMarca { get; set; }
        public string CodigoUnidadMedida { get; set; }
        public string CodigoTipoCompras { get; set; }
        public string CodigoColor { get; set; }
        public double Peso { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioUnitario { get; set; }
        public double ImporteIGV { get; set; }
        public double ValorVenta { get; set; }
        public string Origen { get; set; }
        public string FechaPago { get; set; }
        public string FechaVencimiento { get; set; }
        public string Foto { get; set; }
        public string CodigoLinea { get; set; }
        public string CodigoPrecio { get; set; }
        public string CodigoGrupo { get; set; }
        public string Arancel { get; set; }
        public string Comentario { get; set; }
        public string MesPeriodo { get; set; }
        public bool Habilitado { get; set; }
        public string TipoDocumento { get; set; }
        public string CodigoProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
        public double ImporteBruto { get; set; }
        public double ImporteNeto { get; set; }
        public double TotalCredito { get; set; }
        public double Monto { get; set; }
        public bool IncluyeIGV { get; set; }
        public string Glosa { get; set; }
        public string Documento2 { get; set; }
        public string Dias { get; set; }
        public bool EsMN { get; set; }
        public bool EsME { get; set; }
        public double Descuento { get; set; }
        public double TipoCambio { get; set; }
        public string Estatus { get; set; }
        public string Plazo { get; set; }
        public string CodigoVendedor { get; set; }
        public string CodigoBanco { get; set; }

        //DETALLE DE ITEMS
        public string Lote { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public double Precio { get; set; }
        public double Cantidad { get; set; }
        public double Total { get; set; }
        public double DescuentoUnitario { get; set; }
        public double IGV { get; set; }
        public double Stock { get; set; }
        public double PorcentajeDescuento { get; set; }
        public string CodigoAlmacen { get; set; }
        public string DescripcionProducto { get; set; }
        public string CodigoProducto { get; set; }

        //COMPARATIVOS
        public double SaldoMinimo { get; set; }
        public double SaldoMaximo { get; set; }
        public double SaldoActual { get; set; }
        public double MontoMN { get; set; }
        public double MontoME { get; set; }
        public double CanjeMN { get; set; }
        public double CanjeME { get; set; }
        public double ImporteCanjeMN { get; set; }
        public double ImporteCanjeME { get; set; }
    }
}
