using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Inicio.Models
{
    public class CajaModel : BaseModel
    {
        public CajaModel()
        {
            Id = 0;
            Descripcion = "";

        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string PuntoVenta { get; set; }
        public string Vendedor { get; set; }
        public string FechaApertura { get; set; }
        public string Hora { get; set; }
        public double SaldoMN { get; set; }
        public double SaldoME { get; set; }
        public double Monto { get; set; }
        public string Moneda { get; set; }
        public string Glosa { get; set; }
        public string EntradaSalida { get; set; }
        public string Pago { get; set; }
        public string NroTransaccion { get; set; }
        public string Usuario { get; set; }
    }
}