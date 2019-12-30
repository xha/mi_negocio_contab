using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Datos.Models
{
    public class OrdenTrabajoModel : BaseModel
    {
        public OrdenTrabajoModel()
        {
            Codigo = "";
            Producto = "";
            NroOrden = "";

            OrdenTrabajoGrid = new DataTable();
        }

        public string Codigo { get; set; }
        public string NroOrden { get; set; }
        public string Producto { get; set; }
        public decimal Cantidad { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string CodigoUnidadMedida { get; set; }
        public string DescripcionUnidadMedida { get; set; }
        public string Observacion { get; set; }
        public bool Habilitado { get; set; }
        public DataTable OrdenTrabajoGrid { get; set; }

        //CLIENTE
        public string CodigoCliente { get; set; }
        public string DescripcionCliente { get; set; }
        
    }

}
