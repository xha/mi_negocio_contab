using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Datos.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicio
{
    public class Configuracion
    {
        public static string CadenaConexion { get; } = ConfigurationManager.ConnectionStrings["MasterConnection"].ConnectionString;
        public static int CommandTimeout { get; } = Convert.ToInt32(ConfigurationManager.AppSettings["SQLSRVTIMEOUT"]);

        public static SqlCommand CrearComando(string proc)
        {
            string _cadenaConexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaConexion);
            SqlCommand _comando = new SqlCommand(proc, _conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.CommandTimeout = CommandTimeout;

            return _comando;
        }

        public static DataTable EjecutarComando(SqlCommand comando)
        {
            DataTable _tabla = new DataTable();
            try
            {
                comando.Connection.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(_tabla);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { comando.Connection.Close(); }
            return _tabla;
        }

        public static IList<Combo> GetList(SqlCommand command)
        {
            DataTable Table = new DataTable();

            Table = EjecutarComando(command);

            List<Combo> List = new List<Combo>();

            foreach (DataRow dr in Table.Rows)
            {
                List.Add(new Combo
                {
                    Id = Convert.ToInt32(dr[0]),
                    Descripcion = dr[1].ToString(),
                    Selected = dr.Table.Columns.Count == 3 ? dr[2].GetType() == typeof(bool) ? (bool)dr[2] : false : false
                });
            }
            return List;
        }
    }
}
