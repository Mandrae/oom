using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Person
    {

        // T2.2 private fields
        private string nachname;
        private string vorname;
        private char _anrede;

        // T2.2 public properties
        public string anrede
        {
            get
            {
                return wieanreden(_anrede);
            }
        }
        public string name { get; }


        // T2.2 constructor
        public Person(string familienname, string vorn, char x = Char.MinValue)
        {
            if (familienname.All(char.IsDigit) || vorn.All(char.IsDigit)) throw new ArgumentOutOfRangeException("No digits!");

            nachname = familienname;
            vorname = vorn;
            _anrede = x;
            //anrede = wieanreden(x);
            name = $"{anrede}{vorname} {nachname}"; // read-only property "name"
        }


        // T2.2 public method
        public string wieanreden(char x)
        {
            switch (x)
            {
                case 'm':
                    {
                        return "Herr ";
                    }
                case 'w':
                    {
                        return "Frau ";
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
