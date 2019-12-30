using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicio.Models
{
    public class CuentasPorPagarModel
    {
        public CuentasPorPagarModel()
        {
            Id = 0;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Documento { get; set; }
        public string FechaEmision { get; set; }
        public double SaldoMinimo { get; set; }
        public double SaldoMaximo { get; set; }
        public string Planilla { get; set; }
        public string Tipo { get; set; }
        public string FechaVence { get; set; }
        public string Moneda { get; set; }
        public double Importe { get; set; }
        public double Saldo { get; set; }

        //Cobranzas Realizadas
        public double MontoMN { get; set; }
        public double MontoME { get; set; }
        public double Cambio { get; set; }

        //Transacciones
        public string Estatus { get; set; }
        public string EL { get; set; }
        public int Dias { get; set; }
        public double VencimientoMonto { get; set; }

        //Letras
        public string NumeroLetra { get; set; }
        public string Plazo { get; set; }
        public double CanjeMN { get; set; }
        public double CanjeME { get; set; }
    }
}