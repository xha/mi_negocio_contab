using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicio.Models
{
    public class MaestroModel
    {
        public MaestroModel()
        {
            Id = 0;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Ubicacion { get; set; }
        public string Cargo { get; set; }
        public string Ruta { get; set; }
        public string Controlador { get; set; }
        public string Alias { get; set; }
        public string Rol { get; set; }
        public string Serie { get; set; }
        public int UltimoCorrelativo  { get; set; }
        public string Visible { get; set; }
        public string BSunat { get; set; }
        public string BDocRef { get; set; }
        public string BCompra { get; set; }
        public string BAlmacen { get; set; }
        public string BFacturacion { get; set; }
        public string Simbolo { get; set; }
        public string MonedaNacional { get; set; }


        //Transacciones de Almacén
        public string Proveedor { get; set; }
        public string Cliente { get; set; }
        public string Comentario { get; set; }
        public string Descuento { get; set; }
        public string Motivo { get; set; }
        public string Tipo { get; set; }

        //Banco
        public string NroCuenta { get; set; }
        public string Moneda { get; set; }
        public string TipoCuenta { get; set; }
        
        //Ingreso de Stock Inicial
        public double Stock { get; set; }
        public double CostoMN { get; set; }
        public double CostoME { get; set; }
        public string Unidad { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public string Linea { get; set; }
        public string Grupo { get; set; }
    }
}
