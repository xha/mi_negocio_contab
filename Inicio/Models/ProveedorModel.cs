using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Inicio.Models
{
    public class ProveedorModel : BaseModel
    {
        public ProveedorModel()
        {
            Id = 0;
            RUC = "";
            Descripcion = "";

            ProveedorGrid = new DataTable();
        }

        public int Id { get; set; }
        public string RUC { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionComercial { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Representante { get; set; }
        public int IdVendedor { get; set; }
        public int IdFormaPago { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string GiroNegocio { get; set; }
        public string Referencia { get; set; }
        public int IdBanco { get; set; }
        public string NroCuenta { get; set; }
        public string LimiteCredito { get; set; }
        public int IdMoneda { get; set; }
        public string Notas { get; set; }
        public bool Habilitado { get; set; }
        public DataTable ProveedorGrid { get; set; }

        public string ParametrosGuarda(int idUsuario, string idioma)
        {
            string parametros = "";

            parametros += string.Concat(
                Id, ",'",
                Descripcion, "','",
                DescripcionComercial, "',",
                idUsuario, ",",
                Habilitado, ",'",
                idioma, "'"
            );

            return parametros;
        }

        public string ParametrosDesactiva(int idUsuario, string idioma)
        {
            string parametros = "";

            parametros += string.Concat(
                Id, ",",
                idUsuario, ",'",
                idioma, "'"
            );

            return parametros;
        }


        public void AsignarById(DataTable Data)
        {
            var item = Data.Rows[0];
            Id = (int)item["Id"];
            Descripcion = (string)item["Descripcion"];
            DescripcionComercial = (string)item["DescripcionComercial"];
            Habilitado = (bool)item["Habilitado"];
        }
    }

}