using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Datos.Models
{
    public class AlmacenesModel
    {
        public AlmacenesModel()
        {
            ALM_CODIGO = "";
            ALM_DESCRI = "";
            ALM_DIRECC = "";
            ALM_DISTRI = "";
            ALM_TELEF = "";
            ALM_NUMENT = 0;
            ALM_NUMSAL = 0;
            ALM_NUMNE = 0;
            ALM_NUMNS = 0;
            ALM_NUMERO = "";
            ALM_ZONA = "";
            ALM_INTERIOR = "";
            ALM_PROVINCIA = "";
            ALM_DEPARTAMENTO = "";
            UBIGEO = "";
        }

        public string ALM_CODIGO { get; set; }
        public string ALM_DESCRI { get; set; }
        public string ALM_DIRECC { get; set; }
        public string ALM_DISTRI { get; set; }
        public string ALM_TELEF { get; set; }
        public double ALM_NUMENT { get; set; }
        public double ALM_NUMSAL { get; set; }
        public double ALM_NUMNE { get; set; }
        public double ALM_NUMNS { get; set; }
        public string ALM_NUMERO { get; set; }
        public string ALM_ZONA { get; set; }
        public string ALM_INTERIOR { get; set; }
        public string ALM_PROVINCIA { get; set; }
        public string ALM_DEPARTAMENTO { get; set; }
        public string UBIGEO { get; set; }

        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Documento { get; set; }
        public string FechaEmision { get; set; }
        public string FechaDocumento { get; set; }
        public string Moneda { get; set; }
        public string CodigoAlterno { get; set; }
        public string CodigoProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
        public string Sit { get; set; }
        public string Trans { get; set; }
        public string Orden { get; set; }
        public string OrdenTrabajo { get; set; }
        public string CAAnexo { get; set; }
        public string TipoDocumento { get; set; }
        public string TipoTransaccion { get; set; }
        public string CodigoCliente { get; set; }
        public double TipoCambio { get; set; }
        public string CodigoTransportista { get; set; }

        //DETALL DE PRODUCTOS
        public string CodigoProducto { get; set; }
        public string TipoPrecio { get; set; }
        public string DescripcionProducto { get; set; }
        public string Lote { get; set; }
        public string Unidad { get; set; }
        public double Precio { get; set; }
        public double Cantidad { get; set; }
        public double Total { get; set; }
        public double PrecioVenta { get; set; }
        public double Stock { get; set; }
        public double VentaTotal { get; set; }
        public string Origen { get; set; }
        public string Serie { get; set; }
        public string CodigoDireccion { get; set; }
        public string Comentario { get; set; }

        //TRANSFERENCIA AUTOMATICA
        public string DocumentoOrigen { get; set; }
        public string DocumentoDestino { get; set; }
        public string TransOrigen { get; set; }
        public string TransDestino { get; set; }
        public string AlmacenDestino { get; set; }

        //Transferencia por Conversion de Unidades
        public string NotaSalida { get; set; }
        public string NotaIngreso { get; set; }
        public string ArticuloOrigen { get; set; }
        public string ArticuloDestino { get; set; }
        public string UnidadOrigen { get; set; }
        public double CantidadDestino { get; set; }
        public double CantidadOrigen { get; set; }
        public string UnidadDestino { get; set; }

        //TRANSFERENCIA POR ARMADO Y DESARMADO DE KIT
        public double CantidadArmado { get; set; }
        public double CantidadDisponible { get; set; }

        //NOTAS DE INGRESO POR COMPRAS IMPORTADAS
        public double CantidadReq { get; set; }
        public double CantidadRec { get; set; }
        public double Saldo { get; set; }

        //CONSULTA DE TRANSFERENCIA ENTRE ALMACEN
        public string NroTransferencia { get; set; }
        public string DocumentoSalida { get; set; }
        public string Almacen { get; set; }
        public string DocumentoIngreso { get; set; }

        //Selección e Impresión de Artículos a Inventariar
        public string Cerrado { get; set; }
        public string Grabado { get; set; }
    }
}

