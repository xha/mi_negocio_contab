using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Inicio.Models
{
    public class OrdenTrabajoModel : BaseModel
    {
        public OrdenTrabajoModel()
        {
            Id = 0;
            Producto = "";

            OrdenTrabajoGrid = new DataTable();
        }

        public int Id { get; set; }
        public int NroOrden { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int IdUnidadMedida { get; set; }
        public string Observacion { get; set; }
        public bool Habilitado { get; set; }
        public DataTable OrdenTrabajoGrid { get; set; }

        //CLIENTE
        public int IdCliente { get; set; }
        public string DescripcionCliente { get; set; }

        public string ParametrosGuarda(int idUsuario, string idioma)
        {
            string parametros = "";

            parametros += string.Concat(
                Id, ",'",
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
            Habilitado = (bool)item["Habilitado"];
        }
    }

}