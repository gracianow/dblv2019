using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppDblv.Models;


namespace WebAppDblv.Controllers
{
    public class ContatoController : Controller
    {
        //
        // GET: /Contato/
        public ActionResult Index()
        {
            ViewBag.MostraSlide = false;
            return View();
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
                    msg.Subject = "Contato pelo site Doblevê";
                    sb.Append("Nome: " + c.Nome);
                    sb.Append(Environment.NewLine);
                    sb.Append("E-mail: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Telefone: " + c.Fone);
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
    }
}
