using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using FirstAspDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstAspDotNetCore.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonModel model , IFormFile File)
        {

            //File --> Base64(string)
            if (File != null)
            {
                using (var ms = new MemoryStream())
                {
                    File.CopyTo(ms);
                    byte[] imageBytes = ms.ToArray();
                    var imageBase64 = Convert.ToBase64String(imageBytes);
                    model.Image = $"data:{File.ContentType};base64,{imageBase64}";
                }
            }
            ViewBag.Person = model;
            return View();

        }

        public IActionResult ByTagHelper()
        {
            var cities = GetCities();
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult ByTagHelper(PersonModel model , IFormFile File)
        {
            if (File != null)
            {
                using (var ms = new MemoryStream())
                {
                    File.CopyTo(ms);
                    var imagesArr = ms.ToArray();
                    var imageBase64 = Convert.ToBase64String(imagesArr);
                    model.Image = $"data:{File.ContentType};base64,{imageBase64}";
                }
          
            }

            var cities = GetCities();
            ViewBag.Cities = new SelectList(cities, "Id", "Name",model.CityId);
            return View(model);

        }

        private List<City> GetCities()
        {
            return new List<City>()
            {
                new City(){Id = 1 , Name = "Tehran"} ,
                new City(){Id = 2, Name = "Esfahan"}
            };
        }
    }
}