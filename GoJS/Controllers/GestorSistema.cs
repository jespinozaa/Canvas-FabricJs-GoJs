using GoJS.Models;
using Intergrupo.Framework.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoJS.Controllers
{
    public class GestorSistema
    {
        public List<Sistema> Consultar(Sistema entidad, string procedimiento)
        {
            string xml = null;

            if (entidad != null)
            {
                var objSerializador = new Serializador<Sistema>();
                xml = objSerializador.Serializar(entidad);
            }

            BrokerGeneral.ProcedimientoAlmacenado = procedimiento;
            var listado = BrokerGeneral.ConsultarTuberia<Sistema>(xml);

            return listado;
        }
    }
}