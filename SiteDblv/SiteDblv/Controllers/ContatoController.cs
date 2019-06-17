using System.Net.Mail;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteDblv.Models;
using System.Net;

namespace SiteDblv.Controllers
{
    public class ContatoController : Controller
    {
        //
        // GET: /Contato/
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

            /*
            ViewBag.TipoMensagem = new SelectList(
               new List<SelectListItem> {
                  new SelectListItem { Value = "0" , Text = "Contato"},
                  new SelectListItem { Value = "1" , Text = "Pedido"},
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
                                             */
            ViewData["TipoMensagem"] = ListaTipoMensagem();
            ViewData["Assunto"] = ListaAssunto();

            ViewBag.TipoMensagem = tipo;
            ViewBag.Assunto = assunto;

            return View(model);

        }

        public IEnumerable<SelectListItem> ListaTipoMensagem()
        {
            return new  List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Contato" },
                new SelectListItem { Value = "1", Text = "Pedido" }
            };
        }

        public List<SelectListItem> ListaAssunto()
        {
            return new List<SelectListItem>
            {
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
                                                new SelectListItem { Value = "10" , Text = "Reclamação"}
            };
        }

       [HttpPost]
        public ActionResult Index(String nome, String email, String empresa, String celular, String foneFixo, String assunto, String tipo, String mensagem)
        {
            try
            {
                //tipo = ViewBag.TipoMensagem;
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("contato@dobleve.com.br");
                correo.To.Add("contato@dobleve.com.br");
                correo.Subject = assunto + " - " + nome;
                correo.Body = "Nome: " + nome + "<br />" + "E-mail: " + email + "<br />" +
                    "Empresa: " + empresa + "<br />" + "Celular: " + celular + "<br />" + "Fone: " + foneFixo + "<br />" + "Tipo de Mensagem: " + tipo + "<br />" +
                    "Assunto: " + assunto + "<br />" + "Comentário: " + mensagem;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                //Configuração SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail5006.smarterasp.net";
                smtp.Port = 8889;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = true;
                string conta = "contato@dobleve.com.br";
                string senha = "Wcw1718v#";
                smtp.Credentials = new System.Net.NetworkCredential(conta, senha);

                smtp.Send(correo);
                ViewBag.Mensagem = "Enviado com sucesso!";

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message + " - " + ex.StackTrace;
            }

            return View();
        }

    }
}
