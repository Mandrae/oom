using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace task4
{
    class Clients : IPerson
    {
        private string basestatus;
        private char _title; // storage for gender char if ever needed
        public string Title // way to address the client, based on gender
        {
            get
            {
                return Howtoaddress(_title);
            }
        }
        private string Name { get; } // full public name of client
        private string Service { get; } // what service package the client is currently subscribing to

        public Clients(string newLastname, string newFirstname, int newService, char x = Char.MinValue, string Conditions = "Client")
        {
            if (newLastname.Any(c => char.IsDigit(c))) throw new ArgumentException("No digits, please!", nameof(newLastname));
            if (newFirstname.Any(c => char.IsDigit(c))) throw new ArgumentException("Please enter name without digits.", nameof(newFirstname));
            if ((newService < 1) || (newService > 3)) throw new ArgumentException("Service not found.", nameof(newService));

            basestatus = Conditions;
            _title = x;
            Service = SubscribedService(newService); // map the number to the service
            Name = $"{Title}{newFirstname} {newLastname}"; 
        }

        [JsonConstructor]
        public Clients(string nameofperson, string condition, string serviceabo)
        {
            Name = nameofperson;
            basestatus = condition;
            Service = serviceabo;
        }

        public string Nameofperson => Name; // Interface
        public string Condition => basestatus; // Interface
        public string ServiceAbo => Service;


        public string SubscribedService(int a) {
            var map = new Dictionary<int, string>()
            {
                {1, "Basic Package: cemetery charges" },
                {2, "Premium Package: cemetery charges, care of grave" },
                {3, "Gold Package: cemetery charges, care of grave, weekly fresh flower arrangement" },
            };
            string helper;
            return map.TryGetValue(a, out helper) ? helper : "default";
        }

        public string Howtoaddress(char x)
        {
            switch (x)
            {
                case 'm':
                    {
                        return "Mr. ";
                    }
                case 'w':
                    {
                        return "Mrs. ";
                    }
                default:
                    {
                        return null;
                    }
            }
        }
        
    }
}
