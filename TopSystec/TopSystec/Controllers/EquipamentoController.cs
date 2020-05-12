using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopSystec.Controllers
{
    public class EquipamentoController : Controller
    {
        // GET: Equipamento
        public ActionResult Informatica()
        {
            return View();
        }

        public ActionResult Cameras()
        {
            return View();
        }

        public ActionResult Outros()
        {
            return View();
        }
    }
}