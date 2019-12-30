using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Datos.ContabilidadModels
{
    public class ContabilidadModel
    {
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public int NIVEL { get; set; }
        public string CLASE { get; set; }
        public string CENTRO_COSTO { get; set; }
        public string ESTANDAR { get; set; }
    }
}
