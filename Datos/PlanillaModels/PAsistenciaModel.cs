using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Datos.PlanillaModels
{
    public class PAsistenciaModel
    {
        public string CODIGO { get; set; }
        public string CODIGO_TRABAJADOR { get; set; }
        public string NOMBRE_TRABAJADOR { get; set; }
        public int DIA { get; set; }
        public string ENTRADA { get; set; }
        public string SALIDA { get; set; }
        public decimal HORA_LABORADA { get; set; }
        public decimal MIN_TARDANZA { get; set; }
        public string HORA_INICIO { get; set; }
        public string HORA_TERMINO { get; set; }
        public string DIA_LIBRE { get; set; }
    }
}
