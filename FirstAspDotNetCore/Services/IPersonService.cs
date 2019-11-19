using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAspDotNetCore.Models;

namespace FirstAspDotNetCore.Services
{
    public  interface IPersonService
    {

        IEnumerable<PersonModel> Get();
    }

    public class PersonService: IPersonService
    {
        public IEnumerable<PersonModel> Get()
        {
            return new List<PersonModel>()
            {
                new PersonModel() {Name = "Fatemeh", Family = "Montazeri"},
                new PersonModel() {Name = "Zahra", Family = "Karimi"},
                new PersonModel() {Name = "Ali", Family = "Rezaei"},
                new PersonModel() {Name = "Hana", Family = "Akrami"},
                new PersonModel() {Name = "Zeinab", Family = "Sharifi"},
            };
            
        }
    }
}
