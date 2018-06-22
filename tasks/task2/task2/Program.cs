using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // T2.3 create instances
            var person = new[]
            {
                new Person("Schakal", "Gerda", 'w'),
                new Person("Heraldo", "Garfield", 'm'),
                new Person("Callan", "Ceilo"),
                new Person("Groh", "David", 'm'),
                new Person("Stevens", "Connie", 'w'),
                new Person("Carlyle","Eleonore",'w')
            };

            // T2.3 print properties (incl. effect of a method)
            foreach (var p in person)
            {
                Console.WriteLine(p.name);
            }


        }
    }
}