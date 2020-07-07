using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SiteDblv.Models;
using System.Threading.Tasks;
using reCAPTCHA.MVC;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace SiteDblv.Controllers
{
    public class ContatoController : Controller
    {
        //
        // GET: /Contato/

        public ActionResult Index()
        {
            ViewBag.MostraSlide = false;
            var model = new ContatoViewModel();
            model.Nome = "";

            model.DataMensagem = DateTime.Now;
            int tipo = 0;
            string assunto = "";
            model.TipoMensagem = tipo;
            model.Assunto = assunto;

            ViewData["Assunto"] = ListaAssunto();

            ViewBag.TipoMensagem = tipo;
            ViewBag.Assunto = assunto;

                return View(model);
            
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

        public async Task<Boolean> ValidateRecaptcha(string encodedResponse)
        {
            var url = $"https://www.google.com/recaptcha/api/siteverify?secret=" + ConfigurationManager.AppSettings["6Le7q_cUAAAAAJKhDyrUOkjzyvZ0jraFNQIj70bo"] + "&response=" + encodedResponse;
            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync(url, null))
                {
                    var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                    if (!(bool)json["success"])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // POST: /Contato/
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CaptchaValidator(ErrorMessage = "Validación Captcha incorrecta.", RequiredMessage = "La validación Captcha es requerida.")]
        public ActionResult Index(String nome, String email, String empresa, String celular, String foneFixo, String assunto, String tipo, String mensagem, bool captchaValid)
            {
                try
                {
                if (ModelState.IsValid)
                {
                    MailMessage correo = new MailMessage();
                    correo.From = new MailAddress("info@dobleweb.com.br");
                    correo.To.Add("info@dobleweb.com.br");
                    correo.Subject = "Site Dobleweb: " + assunto + " - " + nome;
                    correo.Body = "Nome: " + nome + "<br />" + "E-mail: " + email + "<br />" +
                        "Empresa: " + empresa + "<br />" + "Celular: " + celular + "<br />" + "Fone: " + foneFixo + "<br />" + "Tipo de Mensagem: " + tipo + "<br />" +
                        "Assunto: " + assunto + "<br />" + "Comentário: " + mensagem;
                    correo.IsBodyHtml = true;
                    correo.Priority = MailPriority.Normal;

                    //Configuração SMTP
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.dobleweb.com.br";
                    smtp.Port = 587;
                    smtp.EnableSsl = false;
                    smtp.UseDefaultCredentials = true;
                    string conta = "info@dobleweb.com.br";
                    string senha = "Wcj#10565";
                    smtp.Credentials = new System.Net.NetworkCredential(conta, senha);

                    if (captchaValid)
                    {
                        smtp.Send(correo);
                        TempData["EnviarMsg"] = "Enviado com sucesso!";
                    }
                }

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
