using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace wsCanvas
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsCanvas : System.Web.Services.WebService
    {

   [WebMethod()]
   [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
    public static List<Nodo> obtenerObra()
    {
             List<Nodo> lista= new List<Nodo>();
         var conectionString=@"Data Source=192.168.2.8\SQLDEV12;Initial Catalog=STARDIM_DEV;User ID=sa;Password=SQLserver5670";
         using(SqlConnection con= new SqlConnection(conectionString))
         {
             var sql="SELECT idNodo, CAST(X AS INT) X, CAST(Y AS INT) Y, idObra, idObraTipo, A.idTipoNodo, A.descripcion, idSistema, idTipoDimensionamiento, idRecintos [idRecinto],esModificable , esDimensionable, esDeSeguridad [EsSeguridad], prorrataCaudal [Consumo],prorrataHabitantes [Poblacion], perdida , horasOperacion [HoraOperacion], idEmpresaElectrica ,hGeometrico , idPliegoElectrico, eficiencia [EficienciaMotobomba], idLocalidadesSistema [IdLocalidadSistema],prioridad , tamanoMaximo, fRecuperacion, IdSubModulo,factorPrecioEnergia,coefKwh_M3 FROM TB_DIM_NODOS A JOIN TB_DIM_MAE_TIPONODO B ON A.idTipoNodo = B.idTipoNodo WHERE idTipoDimensionamiento= 1 AND idSistema =1215";
             SqlCommand cmd= new SqlCommand(sql,con);
             SqlDataReader rd=cmd.ExecuteReader();
             if(rd.HasRows)
             {
                 while(rd.Read())
                 {
                     lista.Add(new Nodo() {IdNodo=int.Parse(rd["IdNodo"].ToString())});
                 }
             }
             return lista;

         }


    }
    }
    
}