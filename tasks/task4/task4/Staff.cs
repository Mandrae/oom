using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Staff : IPerson
    {

        public string Employment; 

        public Staff(string nameofperson, string serviceabo, int x, string condition = "Staff")
        {
            if (nameofperson.Any(c => char.IsDigit(c))) throw new ArgumentException("No digits, please!", nameof(nameofperson));
            if ((x < 0) || (x > 3)) throw new ArgumentException("Not a valid entry.", nameof(x));

            Nameofperson = nameofperson;
            Condition = condition;
            ServiceAbo = serviceabo;
            Employment = SubscribedService(x);

        }

        public string Nameofperson { get; }
        public string Condition { get; }
        public string ServiceAbo { get; }


        /* using a switch case instead of dictionary to define the status of the employees (variation of the same)*/
        public string SubscribedService(int a)
        {
            switch (a)
            {
                case 1: { return "Full time employee."; }
                case 2: { return "Part time employee.";  }
                case 3: { return "Trainee"; }
                default: return null;
            }
        }
    }
}
