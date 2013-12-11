using System;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace ExpandoObjectClass
{
    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Contact contact1 = new Contact
            {
                FirstName = "Tony",
                LastName = "Stark",
                Email = "ironman@avengers.com"
            };
            Console.WriteLine(JsonConvert.SerializeObject(contact1, Formatting.Indented));

            var contact2 = new Dictionary<string, object>();
            contact2["FirstName"] = "Bruce";
            contact2["LastName"] = "Banner";
            contact2["Email"] = "hulk@avengers.com";
            Console.WriteLine(JsonConvert.SerializeObject(contact2, Formatting.Indented));

            dynamic contact3 = new ExpandoObject();
            contact3.FirstName = "Thor";
            contact3.LastName = "Odinson";
            contact3.Email = "thor@avengers.com";
            Console.WriteLine(JsonConvert.SerializeObject(contact3, Formatting.Indented));
        }
    }
}
