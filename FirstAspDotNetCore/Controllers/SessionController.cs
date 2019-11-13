using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FirstAspDotNetCore.Controllers
{
    public class SessionController : Controller
    {
        public ActionResult Get()
        {
            if (Response.HttpContext.Session.GetString("Person") != null)
            {
                var personJson = Response.HttpContext.Session.GetString("Person");
                ViewBag.Person = JsonConvert.DeserializeObject<PersonModel>(personJson);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Post()
        {
            var person = new PersonModel(){Name = "Fatemeh"  , Family = "Montazeri"};
            var personJson = JsonConvert.SerializeObject(person);
            Request.HttpContext.Session.SetString("Person",personJson);
            return RedirectToAction("Get");
        }

       // [HttpDelete]
        public ActionResult Delete()
        {
            Request.HttpContext.Session.Clear();
            return RedirectToAction("Get");
        }
    }
}
