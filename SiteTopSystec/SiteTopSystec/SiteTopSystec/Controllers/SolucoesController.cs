﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteTopSystec.Controllers
{
    public class SolucoesController : Controller
    {
        // GET: Solucoes
        public ActionResult Bairro()
        {
            return View();
        }
        public ActionResult Condominio()
        {
            return View();
        }
        public ActionResult Empresa()
        {
            return View();
        }
    }
}