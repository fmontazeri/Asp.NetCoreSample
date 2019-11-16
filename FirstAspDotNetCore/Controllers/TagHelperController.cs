using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspDotNetCore.Controllers
{
    public class TagHelperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index3(int id)
        {
            return View();
        }

        public  IActionResult Index4(PersonModel person)
        {
            return View(person);
        }
    }
}