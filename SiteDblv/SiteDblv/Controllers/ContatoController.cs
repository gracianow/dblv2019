using System.Net.Mail;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteDblv.Models;
using System.Net;
using System.Web.Helpers;

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

            var customerName = Request["customerName"];
            var customerEmail = Request["customerEmail"];
            var customerRequest = Request["customerRequest"];
            var errorMessage = "";
            var debuggingFlag = false;
            try
            {
                // Initialize WebMail helper
                WebMail.SmtpServer = "your-SMTP-host";
                WebMail.SmtpPort = 25;
                WebMail.UserName = "your-user-name-here";
                WebMail.Password = "your-account-password";
                WebMail.From = "your-email-address-here";

                // Send email
                WebMail.Send(to: customerEmail,
                    subject: "Help request from - " + customerName,
                    body: customerRequest
                );
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

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
                    msg.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient();

                    //Instância classe email
                    MailMessage mail = new MailMessage();
                    msg.To.Add("contato@dobleve.com.br");
                    msg.From = new MailAddress(c.Email);
                    msg.Subject = c.Assunto;
                    string Body = c.Mensagem;
                    msg.Body = Body;
                    mail.IsBodyHtml = true;

                    client.Credentials = new System.Net.NetworkCredential("contato@dobleve.com.br", "dblv2019#");
                    client.EnableSsl = true;
                    smtp.Host = "mail.dobleve.com.br";
                    smtp.UseDefaultCredentials = false;
                    smtp.Port = 465;

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
        public ViewResult Index(SiteDblv.Models.Contato _objModelMail)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
               //StringBuilder sb = new StringBuilder();

                //Instância classe email

                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                /*
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
                mail.Body = sb.ToString();
                
                smtp.Send(mail);
                mail.Dispose();
               

                //Instância smtp do servidor, neste caso o gmail.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.dobleve.com.br";
                smtp.Port = 465;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("contato@dobleve.com.br", "dblv2019#");// Login e senha do e-mail.
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index", _objModelMail);
            }
            else
            {
                return View();
            }
        }*/
    }
}
