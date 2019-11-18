using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FirstAspDotNetCore.CustomAttributes;
using Microsoft.AspNetCore.Http;

namespace FirstAspDotNetCore.Models
{
    public class ImageModel
    {
        [Required]
        [CustomImage(ImageSize=10161)]
        public IFormFile Image { get; set; }
    }
}
