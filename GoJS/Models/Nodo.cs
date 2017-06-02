using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoJS.Models
{
    public class Nodo : Dimensionamiento
    {
        public int IdNodo { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}