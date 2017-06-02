using GoJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoJS.Controllers
{
    public class SistemaController : Controller
    {
        //
        // GET: /Sistema/
        private readonly GestorSistema _gestorSistema = new GestorSistema();

        public ActionResult Index()
        {
            Sistema sistema = new Sistema();
            var list = _gestorSistema.Consultar(null, "procDimSistemasSelect");
            return View(list);
        }

    }
}
