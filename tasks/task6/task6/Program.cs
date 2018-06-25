using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new IPerson[]
            {
                new Clients("Schakal", "Gerda", 1, 'w'),
                new Clients("Heraldo", "Garfield", 2, 'm'),
                new Deceased("Stevens", "Connie", "01/02/1956", "23/09/2015", 3, 'w'),
                new Clients("Callan", "Ceilo", 3),
                new Deceased("Groh", "David", "20/08/1912", "12/12/1943", 4, 'm'),
                new Deceased("Carlyle","Eleonore", "28/11/1970", "03/04/1990", 2, 'w'),
                new Staff("Hannah Hold", "flowers", 1),
                new Staff("Karl Kobold", "allrounder", 3),
                new Staff("Kai Wildbau", "accounting", 2),
                new Staff("Sheila Watson", "legal representation", 2),
                new Deceased("Andrae", "Magdalena", "14/07/1980","21/11/2000", 1, 'w')
            };

            /* keeps on doing the task 4 serialization stuff - but moved it outside of main funcion*/
            Cerealization.DoJsonStuff(person);

            /* task 7 - asynchronous programming */
            Console.WriteLine($"Currently we are working on thread #{Thread.CurrentThread.ManagedThreadId}\n"); // show that we are on thread #1
            Console.WriteLine("Now let's start up another thread...");
            Asyncprog.SyncingAsync(); // works on method on different thread

            /* task 6 - subscribing to a subject */
            Subscription.Subscribing();
            
            Console.WriteLine("----------------EOF----------------");
        }
    }
}
