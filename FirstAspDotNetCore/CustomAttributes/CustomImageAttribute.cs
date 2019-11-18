using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FirstAspDotNetCore.CustomAttributes
{
    public class CustomImageAttribute : ValidationAttribute
    {
        /// <summary>
        /// Maximim of image size is 1MB.Enter in bytes.
        /// </summary>
        public int ImageSize { get; set; }

        public override bool IsValid(object value)
        {
            //1048576 bytes = 1MB
            var result = true;
            if (!(value is IFormFile image)) return false;
            if (image.Length > ImageSize )
            {
                ErrorMessage = $"Image size should be smaller than {ImageSize / 1048576}MB / {ImageSize} Bytes";
                result = false;
            }
            return  result;
        }

    }
}
