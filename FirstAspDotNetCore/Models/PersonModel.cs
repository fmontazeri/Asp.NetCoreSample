using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FirstAspDotNetCore.Models
{
    public class PersonModel
    {
        [Display]
        [Required]
        public string Name { get; set; }
        [Display]
        [Required]
        public string Family { get; set; }
        [Display]
        public string Image { get; set; }
        [Display(Name = "City")]
        [Required]
        public int CityId { get; set; }

        [Display(Name = "Accept")]
        [Range(typeof(bool),"true","true",ErrorMessage = "Accept the rules , please!")]
        public bool IAccept { get; set; }
        [Display]
        [Required]
        public IFormFile File { get; set; }
    }
}
