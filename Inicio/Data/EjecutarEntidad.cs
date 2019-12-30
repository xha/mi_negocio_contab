using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicio.Models
{
    public class EjecutarEntidad
    {
        public EjecutarEntidad()
        {
            stored = "";
            parametros = "";
            guarda = 0;
            debug = true;
        }

        public string stored { get; set; }
        public string parametros { get; set; }
        public int guarda { get; set; }
        public bool debug { get; set; }

        public int idUsuario { get; set; }
        public string idioma { get; set; }
    }

    public class Resultado
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public string Mensaje { get; set; }
    }
}
