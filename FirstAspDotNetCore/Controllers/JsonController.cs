using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FirstAspDotNetCore.Controllers
{
    public class JsonController
    {
        public JsonResult Get()
        {
            var persons = new List<PersonModel>()
            {
                new PersonModel(){ Name = "Fatemeh" , Family = "Montazeri"} ,
                new PersonModel(){Name = "Zahra" , Family = "Montazeri"} ,
                new PersonModel(){Name = "Ali" ,Family = "Montazeri"}
            };

            return new JsonResult(persons);
        }
    }
}