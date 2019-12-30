using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Datos.Models
{
    public class VendedorModel : BaseModel
    {
        public VendedorModel()
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
            ZonaVenta = "";

            VendedorGrid = new DataTable();
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
        public string ZonaVenta { get; set; }
        public string TipoPersona { get; set; }

        public DataTable VendedorGrid { get; set; }

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
