using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstAspDotNetCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspDotNetCore.Controllers
{
    public class FileController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public FileContentResult GetImage() // Or IActionResult , FileResult
        {
            var filePath = $"{_hostingEnvironment.ContentRootPath}\\images\\ada.jpg";
            //var ms = new FileStream(filePath,FileMode.Open,FileAccess.Read);
            //byte[] imageBytes= new byte[ms.Length];
            //ms.Read(imageBytes);
            //ms.Dispose();
            //OR
            var imageBytes = System.IO.File.ReadAllBytes(filePath);
            return new FileContentResult(imageBytes, "image/jpeg");
        }

        public IActionResult GetPdf() // Or IActionResult , FileResult
        {
            var filePath = $"{_hostingEnvironment.ContentRootPath}\\content\\ticket.pdf";
            var ms = new FileStream(filePath,FileMode.Open , FileAccess.Read);
            return  new FileStreamResult(ms,"application/pdf");
        }

        public IActionResult UploadImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadImage(ImageModel model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model != null)
            {
                using (var ms = new MemoryStream())
                {
                    model.Image.CopyTo(ms);
                    var bytes = ms.ToArray();
                    var imageBase64 = Convert.ToBase64String(bytes);
                    ViewBag.Image = $"data:{model.Image.ContentType};base64,{imageBase64}";
                }
            }
            return View();
        }

        
    }
}