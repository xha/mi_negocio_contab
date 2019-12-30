using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Datos.PlanillaModels
{
    public class PMaestraModel
    {

        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public string CUENTA_CONTABLE { get; set; }
        public int NIVEL { get; set; }
        public double ESCALA_MINIMA { get; set; }
        public double ESCALA_MAXIMA { get; set; }
        public double APORTE { get; set; }
        public double SEGURO { get; set; }
        public string MONEDA { get; set; }

        public string MISION { get; set; }
        public string PERFIL { get; set; }
        public string REQUISITOS { get; set; }
        public string FUNCION { get; set; }
        public string SIMBOLO { get; set; }
        public string FECHA { get; set; }

        //LISTADO DE TRABAJADORES
        public string CODIGO_TRABAJADOR { get; set; }
        public string NOMBRE { get; set; }
        public string NOMBRE_AREA { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string CARGO { get; set; }
        public double BASICO { get; set; }
        public string DOCUMENTO { get; set; }
        public string FECHA_INGRESO { get; set; }
        public string CENTRO_COSTO { get; set; }
        public string CODIGO_CENTRO { get; set; }
        public string CODIGO_AREA { get; set; }
        public string NUMERO_FICHA { get; set; }
        public string CARNET_SEGURO { get; set; }
        public string FONDO_PENSION { get; set; }
        public int ASIGNACION_FAM { get; set; }
        public string FECHA_CESE { get; set; }
        public string CODIGO_TIPO { get; set; }
        public string CODIGO_ALTERNO { get; set; }
        public int SITUACION { get; set; }
        public string CODIGO_SCTR { get; set; }
        public string RUC_EPS { get; set; }
        public string AFP { get; set; }
        public string BANCO { get; set; }
        public string CUENTA_BANCO { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string NO_DECLARA { get; set; }
        public string NO_CALCULA { get; set; }
        public string DIRECCION { get; set; }
        public string SEXO { get; set; }

        //CONCEPTOS
        public string CODIGO_CONCEPTO { get; set; }
        public int TIPO { get; set; }
        public string DESCRIPCION_CONCEPTO { get; set; }
        public int FILA { get; set; }
        public string FORMULA { get; set; }
        public string COLUMNA_PLANILLA { get; set; }

        //MES
        public int MES { get; set; }
        public int ANIO { get; set; }
        public string ESTATUS { get; set; }
    }
}
