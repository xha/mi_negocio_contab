using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicio.Models
{
    public class Menu
    {

        public Menu()
        {
            parentId3 = 0;

        }

        public int Id { get; set; }
        public string nameOption { get; set; }
        public string controller { get; set; }
        public string action { get; set; }
        public string area { get; set; }
        public string imageClass { get; set; }
        public string activeli { get; set; }
        public bool status { get; set; }
        public int parentId { get; set; }
        public int parentId2 { get; set; }
        public int parentId3 { get; set; }
        public bool isParent { get; set; }
    }
}