using System;
using System.Net.Mail;
using System.Web.Mvc;

namespace ApcWebSite.Controllers
{
    public class CotacaoController : Controller
    {
        // GET: Cotacao
        public ActionResult Cotacao()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Cotacao(String nome, String email, String empresa, String celular, String foneFixo, String assunto, String tipo, String mensagem)
        {
            try
            {
                //tipo = ViewBag.TipoMensagem;
                System.Net.Mail.MailMessage correo = new MailMessage();
                correo.From = new MailAddress("cotacao@allprotectioncorretora.com.br");
                correo.To.Add("cotacao@allprotectioncorretora.com.br");
                correo.Subject = assunto + " - " + nome;
                correo.Body = "Nome: " + nome + "<br />" + "E-mail: " + email + "<br />" +
                    "Empresa: " + empresa + "<br />" + "Celular: " + celular + "<br />" + "Fone: " + foneFixo + "<br />" + "Tipo de Mensagem: " + tipo + "<br />" +
                    "Assunto: " + assunto + "<br />" + "Comentário: " + mensagem;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                //Configuração SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.allprotectioncorretora.com.br";
                smtp.Port = 587;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = true;
                string conta = "cotacao@allprotectioncorretora.com.br";
                string senha = "allpc2019";
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