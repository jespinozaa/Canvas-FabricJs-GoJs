using GoJS.Models;
using Intergrupo.Framework.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoJS.Controllers
{
    public class GestorNodoGraficador
    {
        public List<Nodo> Consultar(Nodo entidad, string procedimiento, int idSistema)
        {
            string xml = null;

            if (entidad != null)
            {
                var objSerializador = new Serializador<Nodo>();
                xml = objSerializador.Serializar(entidad);
            }

            BrokerGeneral.ProcedimientoAlmacenado = procedimiento;
            var listado = BrokerGeneral.ConsultarNodoGraficador<Nodo>(xml);

            return listado;
        }
    }
}