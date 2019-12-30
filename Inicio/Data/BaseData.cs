using Inicio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicio.Data
{
    public class BaseData
    {

        public static DataTable sc_ejecutar(EjecutarEntidad Modelo)
        {
            SqlCommand _comando = Configuracion.CrearComando("sc_ejecutar");
            _comando.Parameters.AddWithValue("@stored", Modelo.stored);
            _comando.Parameters.AddWithValue("@parametros", Modelo.parametros);
            _comando.Parameters.AddWithValue("@idUsuario", Modelo.idUsuario);
            _comando.Parameters.AddWithValue("@idioma", Modelo.idioma);
            _comando.Parameters.AddWithValue("@guarda", Modelo.guarda);
            _comando.Parameters.AddWithValue("@Debug", Modelo.debug);
            return Configuracion.EjecutarComando(_comando);
        }

        public static DataTable menu(int _idperfil, int idUsuario, string idioma)
        {
            SqlCommand _comando = Configuracion.CrearComando("sp_Menus_listar");
            _comando.Parameters.AddWithValue("@_idperfil", _idperfil);
            _comando.Parameters.AddWithValue("@_idioma", idioma);
            return Configuracion.EjecutarComando(_comando);
        }
    }
}
