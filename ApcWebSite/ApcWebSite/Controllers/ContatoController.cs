using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ApcWebSite.Models
{
    public class ContatoController : Controller
    {
        // GET: Contato
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

        // GET: EnviarCorreo
        public ActionResult EnviarEmail()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult EnviarCorreo(String nome, String para, String assunto, String Mensagem, HttpPostedFileBase arquivo)
        public ActionResult EnviarEmail(String nome, String email, String fone, String assunto, String tipo, String mensagem)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("cotacao@allprotectioncorretora.com.br");
                correo.To.Add("cotacao@allprotectioncorretora.com.br");
                correo.Subject = assunto + " - " + nome;
                correo.Body = "Nome: " + nome + "<br />" + "E-mail: " + email + "<br />" +
                    "Fone: " + fone + "<br />" + "Tipo de Mensagem: " + tipo + "<br />" + 
                    "Assunto: " + assunto + "<br />" + "Comentário: " + mensagem;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                //Configuração SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.allprotectioncorretora.com.br";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string conta = "cotacao@allprotectioncorretora.com.br";
                string senha = "allpc2019";
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
