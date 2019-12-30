using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Datos.Models
{
    public class MaestroModel
    {
        //TIPO DE ARTICULO
        public string TART_CODIGO { get; set; }
        public string TART_DESCRIPCION { get; set; }

        //LINEA
        public List<MaestroModel> ListadoGrupo;
        public string gru_codigo { get; set; }
        public string gru_nombre { get; set; }

        //LINEA
        public List<MaestroModel> ListadoLinea;
        public string lin_codigo { get; set; }
        public string lin_nombre { get; set; }

        //FAMILIA
        public List<MaestroModel> ListadoFamilia;
        public string fam_codigo { get; set; }
        public string fam_nombre { get; set; }
        public string fam_cta { get; set; }
        public string fam_debe { get; set; }
        public string fam_haber { get; set; }
        public string fam_compra { get; set; }
        public string fam_existencia { get; set; }
        public decimal porcentaje { get; set; }
        public bool giro_negocio { get; set; }
        public bool fam_descuento { get; set; }

        //CAJA
        public string TRANC_COD { get; set; }
        public string TRANC_INGSAL { get; set; }
        public string TRANC_DESCRIPCION { get; set; }
        public bool TRANC_DOCREF { get; set; }

        //ALMACENES
        public string ALM_CODIGO { get; set; }
        public string ALM_DESCRI { get; set; }
        public string ALM_DIRECC { get; set; }
        public string ALM_DISTRI { get; set; }
        public string ALM_TELEF { get; set; }
        public double ALM_NUMENT { get; set; }
        public double ALM_NUMSAL { get; set; }
        public double ALM_NUMNE { get; set; }
        public double ALM_NUMNS { get; set; }
        public string ALM_NUMERO { get; set; }
        public string ALM_ZONA { get; set; }
        public string ALM_INTERIOR { get; set; }
        public string ALM_PROVINCIA { get; set; }
        public string ALM_DEPARTAMENTO { get; set; }
        public string UBIGEO { get; set; }

        //CONCEPTOS GENERALES
        public string CONCGRAL_CODIGO { get; set; }
        public string CONCGRAL_DESCRIPCION { get; set; }
        public string CONCGRAL_TIPO { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CONCGRAL_CONTEC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double CONCGRAL_CONTEN { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CONCGRAL_CONTED { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool CONCGRAL_CONTEL { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public double CONCGRAL_MONTOMIN { get; set; }

        //CONVERSION MONETARIA
        public string COVMON_CODIGO { get; set; }
        public string COVMON_DESCRIPCION { get; set; }

        public string Descripcion { get; set; }
        public string Documento { get; set; }
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
        public string Comision { get; set; }
        public string CodigoSunat { get; set; }        
        public bool Activo { get; set; }
        public bool AplicaDescuento { get; set; }
        public bool AplicaSerie { get; set; }
        public bool AplicaDocumento { get; set; }
        public bool AplicaDocumentoReferencia { get; set; }
        public bool AplicaDtoCompra { get; set; }
        public bool AplicaDtoVenta { get; set; }
        public bool AplicaDtoAlmacen { get; set; }
        public bool AplicaDtoCxC { get; set; }
        public bool AplicaDtoCxP { get; set; }
        public bool AplicaDtoBanco { get; set; }
        public bool AplicaRegistroCompraSunat { get; set; }
        public bool AplicaRegistroVentaSunat { get; set; }
        public bool AplicaRegistroCompraComercial { get; set; }
        public bool AplicaRegistroVentaComercial { get; set; }
        public bool EsMN { get; set; }
        public bool AsignacionManual { get; set; }
        public double Advalorem { get; set; }
        public double ISC { get; set; }
        public double Antidumping { get; set; }
        public double EquivalenteME { get; set; }
        public string PaisOrigen { get; set; }        
        public int NroDias { get; set; }


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
        public string CodigoBanco { get; set; }

        //Ingreso de Stock Inicial
        public double Stock { get; set; }
        public double CostoMN { get; set; }
        public double CostoME { get; set; }
        public string Unidad { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public string Linea { get; set; }
        public string Grupo { get; set; }

        //Almacén
        public bool AplicaProveedor { get; set; }
        public bool AplicaCliente { get; set; }
        public bool AplicaOrdenProduccion { get; set; }
        public bool AplicaDtoStock { get; set; }
        public bool AplicaOrdenImportacion { get; set; }
        public bool AplicaComentario { get; set; }
        public bool AplicoCentroCosto { get; set; }
        public string Direccion { get; set; }
        public string Interior { get; set; }
        public string Telefono { get; set; }
        public string Zona { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string UltimoNumNI { get; set; }
        public string UltimoNumEmitirNI { get; set; }
        public string UltimoNumNS { get; set; }
        public string UltimoNumEmitirNS { get; set; }
    }
}
