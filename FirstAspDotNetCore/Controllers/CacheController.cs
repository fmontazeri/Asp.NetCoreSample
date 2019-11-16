using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspDotNetCore.Controllers
{
    public class CacheController : Controller
    {
        public IActionResult Index()
        {
            var person = new PersonModel() {Name = "Fatemeh", Family = "Montazeri"};
            ViewBag.Person = person;
            return View();
        }

        public IActionResult Get()
        {
            return View("Index");
        }
    }
}