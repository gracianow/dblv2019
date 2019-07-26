using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SiteDblv.Controllers
{
    public class PerfumeController : Controller
    {
        // GET: Perfume
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String nome, String email, String empresa, String celular, String foneFixo, String assunto, String mensagem)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("cgraciano73@hotmail.com");
                correo.To.Add("cgraciano73@hotmail.com");
                correo.Subject = assunto + " - " + nome;
                correo.Body = "Nome: " + nome + "<br />" + "E-mail: " + email + "<br />" +
                    "Celular: " + celular + "<br />" + "Assunto: " + assunto + "<br />" + "Mensagem: " + mensagem;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                //Configuração SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.office365.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string conta = "cgraciano73@hotmail.com";
                string senha = "almanara2010";
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
    }
}