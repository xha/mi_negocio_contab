using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicio.Models
{
    public class Combo
    {
        public Combo()
        {
            Id = 0;
            Descripcion = "";
            Selected = false;
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Selected { get; set; }
    }
}
