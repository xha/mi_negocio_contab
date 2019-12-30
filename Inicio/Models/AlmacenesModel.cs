using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicio.Models
{
    public class AlmacenesModel
    {
        public AlmacenesModel()
        {
            Id = 0;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Documento { get; set; }
        public string FechaEmision { get; set; }
        public string Moneda { get; set; }
        public string CodigoAlterno { get; set; }
        public string CodProv { get; set; }
        public string DescripcionProv { get; set; }
        public string Sit { get; set; }
        public string Trans { get; set; }
        public string Orden { get; set; }
        
        //DETALL DE PRODUCTOS
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string Lote { get; set; }
        public string Unidad { get; set; }
        public double Precio { get; set; }
        public double Cantidad { get; set; }
        public double Total { get; set; }
        public double PrecioVenta { get; set; }
        public string Origen { get; set; }

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
