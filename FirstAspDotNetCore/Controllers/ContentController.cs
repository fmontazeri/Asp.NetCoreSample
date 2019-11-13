using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FirstAspDotNetCore.Controllers
{
    public class ContentController : Controller
    {
        public IActionResult GetName()
        {
            return Content("Fatemeh Montazeri");
        }

        public IActionResult GetPerson()
        {
            var person = new string[]{"Fatemeh" , "Zahra" , "Ali"};
            var personJson = JsonConvert.SerializeObject(person);
            return Json(personJson);
        }
    }
}