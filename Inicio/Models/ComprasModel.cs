using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicio.Models
{
    public class ComprasModel
    {
        public ComprasModel()
        {
            Id = 0;
            Descripcion = "";

        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Documento { get; set; }
        public string FechaEmision { get; set; }
        public string Moneda { get; set; }
        public string CodigoAlterno { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAlt { get; set; }
        public int IdMarca { get; set; }
        public int IdUnidadMedida { get; set; }
        public int IdTipoCompras { get; set; }
        public int IdColor { get; set; }
        public double Peso { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioUnitario { get; set; }        
        public double ImporteIGV { get; set; }
        public double ValorVenta { get; set; }
        public string Familia { get; set; }
        public string Origen { get; set; }
        public string FechaPago { get; set; }
        public string FechaVencimiento { get; set; }
        public string Foto { get; set; }
        public int IdLinea { get; set; }
        public int IdGrupo { get; set; }
        public string Arancel { get; set; }
        public string Comentario { get; set; }
        public bool Habilitado { get; set; }
        public bool AfectaRentabilidad { get; set; }
        public bool ControlSerie { get; set; }
        public bool AfectaStock { get; set; }
        public bool StockLote { get; set; }
        public bool StockSerie { get; set; }

        //COMPROBANTE DE COMPRA PARA STOCK (CC)
        public int CCId { get; set; }
        public string CodProv { get; set; }
        public string DescripcionProv { get; set; }
        public string CCDocumento { get; set; }
        public string CCFechaEmision { get; set; }
        public string CCFechaVencimiento { get; set; }
        public double CCIGV { get; set; }
        public double CCImporte { get; set; }
        public double CCMonto { get; set; }
        public bool CCHabilitado { get; set; }
        public bool CCIncluyeIGV { get; set; }
        public string CCGlosa { get; set; }
        public string CCEnviarCXP { get; set; }
        //DETALLE DE COMPRA PARA STOCK (CC)
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

    //COMPROBANTE DE LIQUIDACIONES DE COMPRA (CL)
    public int CLId { get; set; }
        public string CLDocumento { get; set; }
        public string CLFechaEmision { get; set; }
        public string CLFechaVencimiento { get; set; }
        public double CLIGV { get; set; }
        public double CLImporte { get; set; }
        public double CLMonto { get; set; }
        public bool CLHabilitado { get; set; }
        public bool CLIncluyeIGV { get; set; }
        public string CLGlosa { get; set; }
        public string CLEnviarCXP { get; set; }

        //COMPROBANTE DE LIQUIDACIONES DE COMPRA (CS)
        public int CSId { get; set; }
        public string CSDocumento { get; set; }
        public string CSFechaEmision { get; set; }
        public string CSFechaVencimiento { get; set; }
        public double CSIGV { get; set; }
        public double CSImporte { get; set; }
        public double CSMonto { get; set; }
        public bool CSHabilitado { get; set; }
        public double CSAfecto { get; set; }
        public double CSInafecto { get; set; }
        public string CSGlosa { get; set; }
        public string CSEnviarCXP { get; set; }
        //HONORARIO
        public double CSIR { get; set; }
        public double CSIES { get; set; }
        public double CSNeto { get; set; }
        public string CSTipoHonorario { get; set; }

        //ORDEN DE COMPRA (OC)
        public int OCId { get; set; }
        public int OCEmbarcador { get; set; }
        public string OCEstado { get; set; }
        public string OCFechaEmision { get; set; }
        public string OCFechaEntregada { get; set; }
        public string OCIGV { get; set; }
        public double OCTC { get; set; }
        public string OCGlosa { get; set; }
    }
}