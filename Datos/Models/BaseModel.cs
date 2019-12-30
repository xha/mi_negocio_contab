using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            PaisesList = new List<Combo>();
            EstadosList = new List<Combo>();
            CiudadesList = new List<Combo>();
        }

        public IList<Combo> PaisesList { get; set; }
        public IList<Combo> EstadosList { get; set; }
        public IList<Combo> CiudadesList { get; set; }

        
    }
}
