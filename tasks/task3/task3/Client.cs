using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Client : IPerson
    {
        private string basestatus = "Client";
        private string lastname;
        private string firstname;
        private char _title;

        public string title
        {
            get
            {
                return Howtoaddress(_title);
            }
        }
        public string name { get; }

        public string Nameofperson => name;
        public string condition => basestatus;

        // T2.2 constructor
        public Client(string familienname, string vorn, char x = Char.MinValue)
        {
            if (familienname.All(char.IsDigit) || vorn.All(char.IsDigit)) throw new ArgumentOutOfRangeException("No digits!");

            lastname = familienname;
            firstname = vorn;
            _title = x;
            name = $"{title}{firstname} {lastname}"; // read-only property "name"
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
