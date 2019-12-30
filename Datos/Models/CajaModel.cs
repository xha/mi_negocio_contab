using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Datos.Models
{
    public class CajaModel
    {
        //APERTURA
        public int APC_COD { get; set; }
        public string APC_PV { get; set; }
        public string APC_TIPOANEX { get; set; }
        public string APC_ANEX { get; set; }
        public string APC_FECHA { get; set; }
        public string APC_HORA { get; set; }
        public string APC_ESTADO { get; set; }
        public string APC_USUARIO { get; set; }

        //OPERACIONES
        public double OPERC_MONTOMN { get; set; }

        //CIERRE
        public int CIERRE_COD { get; set; }
        public string CIERRE_FECHA { get; set; }
        public string CIERRE_HORA { get; set; }
        public double CIERRE_TOTALMN { get; set; }
        public double CIERRE_TOTALME { get; set; }
        public double CIERRE_EFECTIVOMN { get; set; }
        public double CIERRE_EFECTIVOME { get; set; }
        public double CIERRE_CHEQUEMN { get; set; }
        public double CIERRE_CHEQUEME { get; set; }
        public double CIERRE_TARJETAMN { get; set; }
        public double CIERRE_TARJETAME { get; set; }
        public double CIERRE_TIPVMN { get; set; }
        public double CIERRE_TIPVME { get; set; }
        public double CIERRE_TOIMN { get; set; }
        public double CIERRE_TOIME { get; set; }
        public double CIERRE_TSALMN { get; set; }
        public double CIERRE_TSALME { get; set; }
        public string CIERRE_USUARIO { get; set; }
        public string CIERRE_OBSERVACION { get; set; }
        public double CIERRE_PVEFECTIVOMN { get; set; }
        public double CIERRE_PVEFECTIVOME { get; set; }
        public double CIERRE_PVCHEQUEMN { get; set; }
        public double CIERRE_PVCHEQUEME { get; set; }
        public double CIERRE_PVTARJETAMN { get; set; }
        public double CIERRE_PVTARJETAME { get; set; }
        public double CIERRE_OIEFECTIVOMN { get; set; }
        public double CIERRE_OIEFECTIVOME { get; set; }
        public double CIERRE_OICHEQUEMN { get; set; }
        public double CIERRE_OICHEQUEME { get; set; }
        public double CIERRE_OITARJETAMN { get; set; }
        public double CIERRE_OITARJETAME { get; set; }
    }
}
