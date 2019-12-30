using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;

namespace Inicio.Models
{
    public class LoginModel : BaseModel
    {
        public LoginModel()
        {
            Id = 0;
            usuario = "";

        }

        public int Id { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public bool recordar { get; set; }
    }
}