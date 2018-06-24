using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace task6
{
    class Deceased : IPerson
    {
        private string basestatus = "Deceased";
        private string lastname, firstname; // privately stored information on name
        private string _gender; // private info on gender, not really used
        private DateTime birthday, death; // day of birth & day of death
        private string Name; // full name for display
        public int Age
        {
            get
            {
                return Interestingnumber(birthday, death);
            }
        } // age set by function
        private string Service { get; } // what kind of services were provided for the deceased

        public Deceased(string newLastname, string newFirstname, string newBday, string newDeath, int newService, char x = Char.MinValue)
        {
            if (newLastname.Any(c => char.IsDigit(c))) throw new ArgumentException("No digits, please!", nameof(newLastname));
            if (newFirstname.Any(c => char.IsDigit(c))) throw new ArgumentException("No digits allowed.", nameof(newFirstname));
            if (Convert.ToDateTime(newBday) >= DateTime.Today) throw new ArgumentException("Date is invalid.", nameof(newBday));
            if (Convert.ToDateTime(newDeath) > DateTime.Today) throw new ArgumentException("Future deaths not included in database.", nameof(newDeath));
            if ((Convert.ToDateTime(newBday)) > (Convert.ToDateTime(newDeath))) throw new ArgumentException("Birth succeeded death?");
            if ((newService < 1) || (newService > 4)) throw new ArgumentException("Service not found.", nameof(newService));

            lastname = newLastname;
            firstname = newFirstname;
            _gender = Checkgender(x);
            Name = $"{firstname} {lastname}"; // accumulate name fields into one
            birthday = Convert.ToDateTime(newBday); // dates entered as strings, need to be converted
            death = Convert.ToDateTime(newDeath);
            Service = SubscribedService(newService);
        }

        [JsonConstructor]

        public Deceased(string nameofperson, string condition, string serviceabo, int age)
        {
            Name = nameofperson;
            basestatus = condition;
            Service = serviceabo;
        }

        public string Nameofperson => Name;
        public string Condition => basestatus;
        public string ServiceAbo => Service;

        private string Checkgender(char x) // for statistical usage only
        {
            if (x != 'm' && x != 'f') { return "no information"; }
            return (x == 'f') ? "female" : "male";
        }

        public int Interestingnumber(DateTime bday, DateTime dday)
        {
            int age = dday.Year - bday.Year;
            if (dday.Month < bday.Month || (dday.Month == bday.Month && dday.Day < bday.Day)) age--;
            return age;
        }

        public string SubscribedService(int a)
        {
            var map = new Dictionary<int, string>()
            {
                {1, "Basic Package: burial" },
                {2, "Premium Package: will, burial" },
                {3, "Silver Package: will, burial, administrative procedure incl obituary" },
                {4, "Gold Package: will, burial, administrative procedure incl obituary, grave fence" },
            };
            return map.TryGetValue(a, out string helper) ? helper : "default";  // computer says "declare inline"
        }
    }
}