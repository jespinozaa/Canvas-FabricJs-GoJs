using GoJS.Models;
using Intergrupo.Framework.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoJS.Controllers
{
    public class GestorTuberias
    {
        public  List<Tuberia> Consultar(Tuberia entidad,string procedimiento)
        {
                string xml = null;

                if (entidad != null)
                {
                    var objSerializador = new Serializador<Tuberia>();
                    xml = objSerializador.Serializar(entidad);
                }

                BrokerGeneral.ProcedimientoAlmacenado = procedimiento;
                var listado = BrokerGeneral.ConsultarTuberia<Tuberia>(xml);

                return listado;
        }

    }
}