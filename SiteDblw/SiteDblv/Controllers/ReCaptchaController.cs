using SiteDblv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SiteDblv.Controllers
{
    public class ReCaptchaController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View((new ReCaptcha()));
        }

        [HttpPost]
        public JsonResult AjaxMethod(string response)
        {
            ReCaptcha recaptcha = new ReCaptcha();
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + recaptcha.Secret + "&response=" + response;
            recaptcha.Response = (new WebClient()).DownloadString(url);
            return Json(recaptcha);
        }
    }
}