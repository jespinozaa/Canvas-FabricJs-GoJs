using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using GoJS.Models;

namespace GoJS.Controllers
{
    public class HomeController : Controller
    {
        private readonly GestorSistema _gestorSistema = new GestorSistema();
        private readonly GestorNodos _gestorNodo = new GestorNodos();
        private readonly GestorTuberias _gestorTuberia = new GestorTuberias();
        private readonly GestorNodoGraficador _gestorNodoGraf = new GestorNodoGraficador();

        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View("dragdrop");

        }

        public ActionResult PartialNode(Nodo nodo)
        {
            var x = nodo.Descripcion;
            return PartialView(nodo);
        }



        [HttpPost]
        public JsonResult ObtenerNodos(int id)
        {
            var list = _gestorNodo.Consultar(new Nodo() { }, "procDimNodoSelect", id);
            foreach (var item in list)
            {
                switch (item.Descripcion)
                {
                    case "Arcos":
                        item.Imagen = "";
                        break;
                    case "Arranques":
                        item.Imagen = "";
                        break;
                    case "CargadorMasivo":
                        item.Imagen = "";
                        break;
                    case "Demanda":
                        item.Imagen = "/Images/SectorConsumo.png";
                        break;
                    case "Derechos de Agua":
                        item.Imagen = "";
                        break;
                    case "Estanques":
                        item.Imagen = "/Images/Estanque.png";
                        break;
                    case "Final":
                        item.Imagen = "/Images/NodoFinal.png";
                        break;
                    case "Fuentes":
                        item.Imagen = "/Images/Fuente.png";
                        break;
                    case "Otros":
                        item.Imagen = "/Images/Otros.png";
                        break;
                    case "Planta elevadora AP":
                        item.Imagen = "/Images/PlantaElevadora.png";
                        break;
                    case "Planta elevadora AS":
                        item.Imagen = "/Images/PlantaElevadora.png";
                        break;
                    case "Planta tratamiento AP":
                        item.Imagen = "/Images/PlantaTratamiento.png";
                        break;
                    case "RedAP":
                        item.Imagen = "";
                        break;
                    case "RedAS":
                        item.Imagen = "";
                        break;
                    case "Tratamiento AS":
                        item.Imagen = "/Images/PlantaTratamiento.png";
                        break;
                    case "UD":
                        item.Imagen = "";
                        break;
                    case "Virtual":
                        item.Imagen = "/Images/Nodo.png";
                        break;
                }



            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult ObtenerTuberias(int id)
        {
            var listTuberias = _gestorTuberia.Consultar(new Tuberia() { IdSubmodulo = 1, IdTipoDimensionamiento = 1, IdSistema = id }, "procDimTuberiasSelect");
            foreach (var item in listTuberias)
            {
                switch (item.IdTipoConduccion)
                {
                    case 1:
                        item.TipoConduccion = "Aduccion";
                        break;
                    case 2:
                        item.TipoConduccion = "Impulsion";
                        break;
                    case 3:
                        item.TipoConduccion = "Retraccion";
                        break;
                }

             
            }
            return Json(listTuberias, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult loadNode()
        {
            Nodo nodo = new Nodo();
            nodo.IdNodo = 1;
            nodo.Descripcion = "Prueba";
            return PartialView("PartialNode");
            //return View(nodo);
        }


        [HttpPost]
        public PartialViewResult CargarNodo(int idNodo, int idSistema)
        {
            var listNodo = _gestorNodoGraf.Consultar(new Nodo() { IdNodo = idNodo, IdSistema=idSistema, IdTipoDimensionamiento = 1, IdSubmodulo = 1 }, "procDimNodosGraficadorSelect", idSistema);
            Nodo nodo = new Nodo();
            foreach (var item in listNodo)
            {
                nodo.IdNodo= item.IdNodo ;
                nodo.Descripcion= item.Descripcion;
            }
            return PartialView("PartialNode",nodo);
        }
    }
    
}
