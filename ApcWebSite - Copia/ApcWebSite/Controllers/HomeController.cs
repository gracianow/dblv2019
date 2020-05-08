using ApcWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ApcWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.MostraSlide = false;
            var model = new Contato();
            model.Nome = "";

            model.DataMensagem = DateTime.Now;
            int tipo = 0;
            string assunto = "";
            model.TipoMensagem = tipo;
            model.Assunto = assunto;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}