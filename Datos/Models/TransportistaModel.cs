using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Datos.Models
{
    public class TransportistaModel : BaseModel
    {
        public TransportistaModel()
        {
            Codigo = "";
            TipoCodigo = "";
            Rererencia = "";
            Descripcion = "";
            Direccion = "";
            Direccion2 = "";
            Giro = "";
            Telefono = "";
            Telefono2 = "";
            Telefono3 = "";
            Representante = "";
            Ruc = "";
            DocumentoIdentidad = "";
            Email = "";
            Notas = "";
            ModeloVehiculo = "";
            NroInscripcion = "";
            Placa = "";

            TransportistaGrid = new DataTable();
        }

        public string Codigo { get; set; }
        public string TipoCodigo { get; set; }
        public string Rererencia { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Direccion2 { get; set; }
        public string Giro { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Representante { get; set; }
        public string Referencia { get; set; }
        public string Ruc { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Email { get; set; }
        public decimal Descuento { get; set; }
        public decimal Credito { get; set; }
        public string Notas { get; set; }
        public string TipoPersona { get; set; }
        public string ModeloVehiculo { get; set; }
        public string NroInscripcion { get; set; }
        public string Placa { get; set; }

        public DataTable TransportistaGrid { get; set; }

        //DatosEmpresa
        public string CodigoEmpresa { get; set; }
        public string RazonEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string RucEmpresa { get; set; }

    }

}
