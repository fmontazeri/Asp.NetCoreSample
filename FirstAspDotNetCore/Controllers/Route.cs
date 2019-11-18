using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspDotNetCore.Controllers
{
    public class Route : Controller
    {

        public IActionResult Index(int id)
        {
            return View();
        }



        public IActionResult Route1(int? id)
        {
            return View();
        }

        public IActionResult Route2(int? id)
        {
            return View();
        }
        public IActionResult Index3(bool id)
        {
            return View();
        }
        public IActionResult Route4(int id , string title)
        {
            return View();
        }
        
    }
}
