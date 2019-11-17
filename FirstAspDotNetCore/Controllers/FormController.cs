using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using FirstAspDotNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return View(model);

        }
    }
}