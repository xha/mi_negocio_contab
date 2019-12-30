using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Inicio.Models
{
    public class BancoModel : BaseModel
    {
        public BancoModel()
        {
            Id = 0;
            Descripcion = "";

        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public string Moneda { get; set; }
        public string NroTransaccion { get; set; }
        public string Usuario { get; set; }
        public string NroCuenta { get; set; }
        public string TipoDeCuenta { get; set; }

        //TRANSACCIONES
        public string FechaOperacion { get; set; }
        public string FechaDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Glosa { get; set; }
        public double Ingreso { get; set; }
        public double Salida { get; set; }

        //CONSOLIDADO
        public double Saldo { get; set; }
        public double SaldoConsolidado { get; set; }
    }
}