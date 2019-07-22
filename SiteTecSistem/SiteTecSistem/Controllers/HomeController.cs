using System;
using System.Net.Mail;
using System.Web.Mvc;

namespace SiteTecSistem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String nome, String email, String empresa, String celular, String foneFixo, String assunto, String mensagem)
        {
            try
            {
                //tipo = ViewBag.TipoMensagem;
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("contato@tecsistemsistemas.com.br");
                correo.To.Add("contato@tecsistemsistemas.com.br");
                correo.Subject = assunto + " - " + nome;
                correo.Body = "Nome: " + nome + "<br />" + "E-mail: " + email + "<br />" +
                    "Empresa: " + empresa + "<br />" + "Celular: " + celular + "<br />" + "Fone: " + foneFixo + "<br />" +
                    "Assunto: " + assunto + "<br />" + "Comentário: " + mensagem;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                //Configuração SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.tecsistemsistemas.com.br";
                smtp.Port = 587;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = true;
                string conta = "contato@tecsistemsistemas.com.br";
                string senha = "tec2019";
                smtp.Credentials = new System.Net.NetworkCredential(conta, senha);

                smtp.Send(correo);

                TempData["EnviarMsg"] = "Enviado com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErroMsg"] = ex.Message + " - " + ex.StackTrace;
            }

            if (TempData["EnviarMsg"] != null)
            {
                TempData["mailMsg"] = TempData["EnviarMsg"];
            }
            else
            {
                TempData["mailMsg"] = TempData["ErroMsg"];
            }

            return View();
        }

        public PartialViewResult ShowError(String mailMsg)
        {
            return PartialView("_ModalEnviarEmail");
        }

        public ActionResult Default()
        {
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