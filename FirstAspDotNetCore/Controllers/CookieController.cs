using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstAspDotNetCore.Controllers
{
    public class CookieController : Controller
    {
        // GET: /<controller>/
        public IActionResult Get()
        {
            if (HttpContext.Request.Cookies["Person"] != null)
                ViewBag.Person = JsonConvert.DeserializeObject<PersonModel>(Request.Cookies["Person"]);

            return View();
        }

        [HttpPost]
        public IActionResult Set()
        {
            var person = new PersonModel() { Name = "Fatemeh", Family = "Montazeri" };
            var perosnJson = JsonConvert.SerializeObject(person);
            Response.Cookies.Append("Person", perosnJson); 
            return RedirectToAction("Get");
        }

        public IActionResult Delete()
        {
            HttpContext.Response.Cookies.Delete("Person");
            return RedirectToAction("Get");
        }
    }
}
