using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Microsoft.AspNetCore.Mvc;
using FirstAspDotNetCore.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace FirstAspDotNetCore.ViewComponents
{
    [ViewComponent(Name = "PersonList")]
    //View created in shared folder
    public class PersonViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
          var persons = new List<PersonModel>()
          {
              new PersonModel(){ Name = "Fatemeh" , Family = "Montazeri"} , 
              new PersonModel(){ Name = "Zahra" , Family = "Ebrahimi"} , 
              new PersonModel(){ Name = "Ali" , Family = "Karimi"} 
          };

            return View(persons);
        }
    }
}
