using System;
using System.Net.Mail;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace ApcWebSite.Controllers
{
    public class CotacaoController : Controller
    {
        // GET: Cotacao
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String nome, String email, String celular, String assunto)
        {
            try
            {
                System.Net.Mail.MailMessage correo = new MailMessage();
                correo.From = new MailAddress("cotacao@allprotection.com.br");
                correo.To.Add("cotacao@allprotection.com.br");
                correo.Subject = assunto + " - " + nome;
                correo.Body = "Nome: " + nome + "\n" + "E-mail: " + email + "\n" + "Celular: " + celular 
                    + "\n" + "Cotação." + "\n" + "Tipo de Seguro - " + assunto;
                correo.Priority = MailPriority.Normal;

                //Configuração SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.allprotection.com.br";
                smtp.Port = 587;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = true;
                string conta = "cotacao@allprotection.com.br";
                string senha = "Allpc#2020";
                smtp.Credentials = new System.Net.NetworkCredential(conta, senha);

                smtp.Send(correo);

                TempData["EnviarMsg"] = "Enviada com sucesso!";
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