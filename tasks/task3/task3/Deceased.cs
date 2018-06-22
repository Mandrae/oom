using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Deceased : IPerson
    {
        private string basestatus = "Deceased";
        private string lastname;
        private string firstname;
        private string _gender;
        private DateTime birthday;
        private DateTime death;
        public string Name;
        public int Age { get { return Interestingnumber(birthday, death); } }

        public Deceased(string newLastname, string newFirstname, string newBday, string newDeath, char x = Char.MinValue)
        {

            lastname = newLastname;
            firstname = newFirstname;
            _gender = Checkgender(x);
            Name = $"{firstname} {lastname}";
            birthday = Convert.ToDateTime(newBday);
            death = Convert.ToDateTime(newDeath);
        }

        public string Nameofperson => Name;
        public string condition => basestatus;

        private string Checkgender(char x)
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
    }
}
