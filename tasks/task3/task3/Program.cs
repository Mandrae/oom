using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3 /* cemetery administration */
{
    class Program
    {
        static void Main(string[] args)
        {
            // T2.3 create instances
            var person = new IPerson[]
            {
                new Client("Schakal", "Gerda", 'w'),
                new Client("Heraldo", "Garfield", 'm'),
                new Client("Callan", "Ceilo"),
                new Deceased("Groh", "David", "20/08/1912", "12/12/1943", 'm'),
                new Deceased("Stevens", "Connie", "01/02/1956", "23/09/2015", 'w'),
                new Deceased("Carlyle","Eleonore", "28/11/1970", "03/04/1990", 'w'),
                new Deceased("Andrae", "Magdalena", "14/07/1980","21/11/2000", 'w')
            };

            foreach (var p in person)
            {
                Console.WriteLine($"Names in Database: {p.Nameofperson}, {p.condition}");
            }

        }
    }
}
