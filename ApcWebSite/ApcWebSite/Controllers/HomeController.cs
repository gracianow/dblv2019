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


            ViewBag.TipoMensagem = new SelectList(
               new List<SelectListItem> {
                  new SelectListItem { Value = "0" , Text = "Cotação"},
                  new SelectListItem { Value = "1" , Text = "Atendimento"},
                                             }, "Value", "Text", tipo);


            ViewBag.Assunto = new SelectList(
               new List<SelectListItem> {
                                                new SelectListItem { Value = "0" , Text = "Selecione"},
                                                new SelectListItem { Value = "1" , Text = "Site Moderno"},
                                                new SelectListItem { Value = "2" , Text = "Anúncio Google meu Negócio"},
                                                new SelectListItem { Value = "3" , Text = "Marketing Digital"},
                                                new SelectListItem { Value = "4" , Text = "Internet WI-FI"},
                                                new SelectListItem { Value = "5" , Text = "Mantutenção"},
                                                new SelectListItem { Value = "6" , Text = "IRPF"},
                                                new SelectListItem { Value = "7" , Text = "ERP"},
                                                new SelectListItem { Value = "8" , Text = "Sugestão"},
                                                new SelectListItem { Value = "9" , Text = "Pergunta"},
                                                new SelectListItem { Value = "10" , Text = "Reclamação"},
                                             }, "Value", "Text", assunto);


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