using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Datos.Models
{
    public class ArticuloModel
    {
        public string ACODIGO { get; set; }

        //MONEDA
        public string TIPOMONVTA_CODIGO { get; set; }

        //GRUPO
        public string GRU_CODIGO { get; set; }

        //LINEA
        public string LIN_CODIGO { get; set; }

        //FAMILIA
        public string FAM_CODIGO { get; set; }

        //TIPO ARTICULO
        public string TART_CODIGO { get; set; }

        public string UM_ABREV { get; set; }
        public string ACODIGO2 { get; set; }
        public string ADESCRI { get; set; }
        public string ADESCRI2 { get; set; }
        public decimal APRECIO { get; set; }
        public decimal APRECOM { get; set; }
        public string AFECHA { get; set; }
        public bool AESTADO { get; set; }
        public bool AFLAGIGV { get; set; }
        public bool AFLAGISC { get; set; }
        public bool AFSTOCK { get; set; }
        public string ACOMENTA { get; set; }
        public decimal AUNIART { get; set; }
        public decimal APESO { get; set; }
        public bool AFPRELIB { get; set; }
        public string AFOTO { get; set; }
        public bool ARTASOC { get; set; }
        public string TIPOMONCOM_CODIGO { get; set; }
        public string COD_COLOR { get; set; }
        public bool AFSERIE { get; set; }
        public decimal ADSCTO { get; set; }
        public string CODINVFIS { get; set; }
        public string AMARCA { get; set; }
        public decimal IGV { get; set; }
        public string UM_PESO { get; set; }
        public bool FlagCosto { get; set; }
        public string LoteSerie { get; set; }
        public string ARANCEL { get; set; }
        public bool ARENTABLE { get; set; }
        public bool AFSERIE_MUL { get; set; }

        //ART EQUIVALENTE
        public string ARTEQUI_COD { get; set; }
        public string ARTEQUI_ALT { get; set; }
        public string MULTI { get; set; }
        public decimal FACTORX { get; set; }

        //ART ALTERNATIVOS
        public string ARTCOD { get; set; }
        public string ARTALT { get; set; }        
    }
}
