using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspDotNetCore.Controllers
{
    public class CustomTagHelperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}