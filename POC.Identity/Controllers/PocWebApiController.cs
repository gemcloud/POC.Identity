using Microsoft.AspNetCore.Mvc;
using POC.Identity.Models.Jsons;
using POC.Identity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Identity.Controllers
{
    public class PocWebApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
