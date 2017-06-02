using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace GoJS.Controllers
{
    public class BrokerGeneral
    {

        #region Propiedades
        /// <summary>
        /// Obtiene o establece el nombre del procedimiento almacenado.
        /// </summary>
        public static string ProcedimientoAlmacenado { get; set; }
        #endregion
        
        /// <summary>
        /// Método para consultar todos los elementos de una entidad o algunos filtrados.
        /// </summary>
        /// <typeparam name="T">Parametro tipado dependiendo de la entidad instanciada.</typeparam>
        /// <param name="xmlEntidad">XML con la entidad a persistir o eliminar en la base de datos.</param>
        /// <param name="idVersion">Código de la versión para la cual se persiste o elimina la información.</param>
        /// <returns>Listado con la entidad consultada.</returns>
        public static List<T> Consultar<T>(string xmlEntidad,int idSistema) where T : class
        {
            using (IDbConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ToString() ))
            {
                var parametros = new
                {
                   
                    idSistema=idSistema,
                    idTipoDimensionamiento=1
                };

                try
                {
                    return conexion.Query<T>(ProcedimientoAlmacenado, parametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000).ToList();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }


        public static List<T> ConsultarTuberia<T>(string xmlEntidad) where T : class
        {
            using (IDbConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
            {
                var parametros = new
                {
                    entidadXML = xmlEntidad,
                     version=1134
                };

                try
                {
                    return conexion.Query<T>(ProcedimientoAlmacenado, parametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000).ToList();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }


        public static List<T> ConsultarNodoGraficador<T>(string xmlEntidad) where T : class
        {
            using (IDbConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ToString()))
            {
                var parametros = new
                {
                    entidadXML = xmlEntidad,
                    version = 1134
                };

                try
                {
                    return conexion.Query<T>(ProcedimientoAlmacenado, parametros, commandType: CommandType.StoredProcedure, commandTimeout: 2000).ToList();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

    }
}