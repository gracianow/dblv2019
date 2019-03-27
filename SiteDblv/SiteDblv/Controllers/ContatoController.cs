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
            
            model.DataMensagem = DateTime.Now;
            int tipo = 0;
            string assunto = "";
            model.TipoMensagem = tipo;
            model.Assunto = assunto;


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
            return View(model);

        }

        [HttpPost]
        public ActionResult Contact(Contato c)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    MailAddress from = new MailAddress(c.Email.ToString());
                    StringBuilder sb = new StringBuilder();
                    msg.IsBodyHtml = false;
                    SmtpClient client = new SmtpClient();
                    client.Credentials = new System.Net.NetworkCredential("contato@dobleve.com.br", "dblv2019#");
                    client.EnableSsl = true;
                    smtp.Host = "mail.dobleve.com.br";
                    smtp.UseDefaultCredentials = false;
                    smtp.Port = 587;

                    msg.From = from;
                    msg.Subject = "Assunto: " + c.Assunto;
                    sb.Append("Nome: " + c.Nome);
                    sb.Append(Environment.NewLine);
                    sb.Append("E-mail: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Fone: " + c.Fone);
                    sb.Append(Environment.NewLine);
                    sb.Append("Data: " + c.DataMensagem);
                    sb.Append(Environment.NewLine);
                    sb.Append("Tipo: " + c.TipoMensagem);
                    sb.Append(Environment.NewLine);
                    sb.Append("Mensagem: " + c.Mensagem);
                    msg.Body = sb.ToString();
                    smtp.Send(msg);
                    msg.Dispose();
                    return View("Index");
                }

                catch (Exception)
                {
                    return View("Index");
                }

            }
            return View();
        }
        /*
        [HttpPost]
        public ActionResult FaleComigo(FormCollection collection)
        {
            var fromNome = collection["name"].Trim();
            var fromEmail = collection["email"].Trim();
            var subject = " Mensagem do Site";
            var body = collection["body"].Trim();

            var to1 = "emailDestino1@hotmail.com";
            var to2 = "emailDestino2@live.com";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h2>Contato do Site XXXX</h2>");
            sb.AppendLine("<h3>Nome: <b>" + fromNome + "</b> - E-mail: <b>" + fromEmail + "</b></h3>");
            sb.AppendLine("<p>Mensagem:</p><br>");
            sb.AppendLine(body);
            try
            {
                using (MailMessage msg = new MailMessage())
                {
                    msg.From = new MailAddress("emailOrigem@gmail.com");
                    msg.To.Add(to1);
                    msg.Bcc.Add(to2);
                    msg.Subject = "[Contato] " + subject;
                    msg.Body = sb.ToString();
                    msg.Priority = MailPriority.High;
                    msg.IsBodyHtml = true;

                    using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtpClient.Credentials = new NetworkCredential("emailOrigem@gmail.com", "senhaEailOrigem");
                        smtpClient.EnableSsl = true;
                        smtpClient.Send(msg);
                    }
                }

                return RedirectToAction("EmailEnviado");
            }
            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("_FORM", ex.ToString());
            }

            return View();
        }

        public ActionResult EmailEnviado()
        {
            return View();
        }
        */
    }
}
