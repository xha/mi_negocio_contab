using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Datos.Models
{
    public class ClienteModel : BaseModel
    {
        public ClienteModel()
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
            Descuento = 0;
            Credito = 0;
            Notas = "";
            CodigoBanco = "";
            Referencia = "";
            NumeroCuenta = "";
            ZonaVenta = "";
            VendedorAsignado = "";
            FormaPago = "";
            DescripcionComercial = "";

            ClienteGrid = new DataTable();
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
        public string NumeroInscripcion { get; set; }
        public string Referencia { get; set; }
        public string Ruc { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Email { get; set; }
        public decimal Descuento { get; set; }
        public decimal Credito { get; set; }
        public string Notas { get; set; }
        public string CodigoBanco { get; set; }
        public string NumeroCuenta { get; set; }
        public string ZonaVenta { get; set; }
        public string VendedorAsignado { get; set; }
        public string FormaPago { get; set; }
        public string DescripcionComercial { get; set; }
        public string MonedaCredito { get; set; }
        public string TipoPersona { get; set; }
        public string TipoDocumento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombrePaterno { get; set; }
        public string NombreMaterno { get; set; }
        public string Interior { get; set; }
        public string Zona { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }

        //DIRECCION DE ENTREGA (DE)
        public string DECodigo { get; set; }
        public string DEDireccion { get; set; }
        public string DENumero { get; set; }
        public string DEInterior { get; set; }
        public string DEZona { get; set; }
        public string DEDistrito { get; set; }
        public string DEProvincia { get; set; }
        public string DEDepartamento { get; set; }

        public DataTable ClienteGrid { get; set; }

        /*        public void AsignarById(DataTable Data)
                {
                    var item = Data.Rows[0];
                    Id = (int)item["Id"];
                    Descripcion = (string)item["Descripcion"];
                    DescripcionComercial = (string)item["DescripcionComercial"];
                    Habilitado = (bool)item["Habilitado"];
                }*/
    }
}
