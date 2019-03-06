using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppDblv.Models;

namespace WebAppDblv.Controllers
{
    public class SendMailerController : Controller
    {
        //
        // GET: /SendMailer/  
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(Email _objModelMail)
        {
            if (ModelState.IsValid)
            {
                //Instância classe email
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                //Instância smtp do servidor, neste caso o gmail.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("username", "password");// Login e senha do e-mail.
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index", _objModelMail);
            }
            else
            {
                return View();
            }
        }
    }
}