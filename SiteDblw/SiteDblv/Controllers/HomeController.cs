﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteDblv.Controllers
{

    [Tls]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public class TlsAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var request = filterContext.HttpContext.Request;
                if (request.IsSecureConnection)
                {
                    filterContext.HttpContext.Response.AddHeader("Strict-Transport-Security", "max-age=15552000");
                }
                else if (!request.IsLocal && request.Headers["Upgrade-Insecure-Requests"] == "1")
                {
                    var url = new Uri("https://" + request.Url.GetComponents(UriComponents.Host | UriComponents.PathAndQuery, UriFormat.Unescaped), UriKind.Absolute);
                    filterContext.Result = new RedirectResult(url.AbsoluteUri);
                }
            }
        }

        public ActionResult Privacy()
        {
            
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Dobleweb";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}