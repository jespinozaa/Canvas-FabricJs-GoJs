using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoJS.Models
{
    public class Tuberia
    {
        public int Id { get; set; }
        public int IdNodo1 { get; set; }
        public int IdNodo2 { get; set; }
        public int IdSubmodulo { get; set; }
        public int IdSistema { get; set; }
        public int IdTipoDimensionamiento { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoConduccion { get; set; }
        public string TipoConduccion { get; set; }
    }
}