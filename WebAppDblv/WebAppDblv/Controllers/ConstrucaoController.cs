using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppDblv.Controllers
{
    public class ConstrucaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}