using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Datos.Models
{
    public class AnexoModel 
    {
        public AnexoModel()
        {
            ANEX_CODIGO = "";
            TIPOANEX_CODIGO = "";
            ANEX_REFERENCIA = "";
            ANEX_DESCRIPCION = "";
            ANEX_DIRECCION = "";
            ANEX_DIRECCION2 = "";
            ANEX_GIRO = "";
            ANEX_TELEFONO = "";
            ANEX_TELEFONO2 = "";
            ANEX_TELEFONO3 = "";
            ANEX_REPRESENTANTE = "";
            ANEX_RUC = "";
            ANEX_DOCIDENT = "";
            ANEX_EMAIL = "";
            ANEX_DSCTO = 0;
            ANEX_CREDITO = 0;
            ANEX_NOTAS = "";
            ANEX_BANCO = "";
            ANEX_NROCTA = "";
            ANEX_ZONAVTA = "";
            ANEX_VENDASIG = "";
            ANEX_FORMPAG = "";
            ANEX_DESCRIPCOMERC = "";
        }

        public string ANEX_CODIGO { get; set; }
        public string TIPOANEX_CODIGO { get; set; }
        public string ANEX_REFERENCIA { get; set; }
        public string ANEX_DESCRIPCION { get; set; }
        public string ANEX_DIRECCION { get; set; }
        public string ANEX_DIRECCION2 { get; set; }
        public string ANEX_GIRO { get; set; }
        public string ANEX_TELEFONO { get; set; }
        public string ANEX_TELEFONO2 { get; set; }
        public string ANEX_TELEFONO3 { get; set; }
        public string ANEX_REPRESENTANTE { get; set; }
        public string ANEX_RUC { get; set; }
        public string ANEX_DOCIDENT { get; set; }
        public string ANEX_EMAIL { get; set; }
        public decimal ANEX_DSCTO { get; set; }
        public decimal ANEX_CREDITO { get; set; }
        public string ANEX_NOTAS { get; set; }

        //DATOS BANCARIOS
        public string ANEX_BANCO { get; set; }
        public string ANEX_NROCTA { get; set; }

        public string ANEX_ZONAVTA { get; set; }
        public string ANEX_VENDASIG { get; set; }
        public string ANEX_FORMPAG { get; set; }
        public string ANEX_DESCRIPCOMERC { get; set; }
        public string ANEXO_MODELOVEH { get; set; }
        public string ANEXO_NROINSCRIP { get; set; }
        public string ANEXO_PLACA { get; set; }
        public string ANEXO_BREVE { get; set; }
        public string ANEX_VENDPROV { get; set; }
        public string ANEX_MONCREDITO { get; set; }
        public string ANEX_NUMERO { get; set; }

        //DIRECCION DE ENTREGA (DE)
        public string ANEX_ZONA { get; set; }
        public string ANEX_DISTRITO { get; set; }
        public string ANEX_PROVINCIA { get; set; }
        public string ANEX_DEPARTAMENTO { get; set; }
        public string ANEX_INTERIOR { get; set; }
        public int L_TIP_CLI { get; set; }
        public string L_TIPO_PERSONA { get; set; }
        public string L_TIPO_DOC { get; set; }
        public string ANEX_APE_PAT { get; set; }
        public string ANEX_APE_MAT { get; set; }
        public string ANEX_NOMBRE { get; set; }
        public string ANEX_NOMBRE2 { get; set; }
        public string TRARAZEMP { get; set; }
        public string TRARUCEMP { get; set; }
        public string TRADIREMP { get; set; }
        public string TRATELEMP { get; set; }
        public string UBIGEO { get; set; }        
    }
}
