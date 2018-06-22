using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace task4
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
                new Deceased("Andrae", "Magdalena", "14/07/1980","21/11/2000", 1, 'w')
            };
            
            /* printing objects to screen */
            Console.WriteLine($"See the following list for public information of the objects in section \"Clients\" and \"Deceased\":\n {JsonConvert.SerializeObject(person, Formatting.Indented)} \n End of console writing.");

            var employees = new IPerson[]
            {
                new Staff("Hannah Hold", "flowers", 1),
                new Staff("Karl Kobold", "allrounder", 3),
                new Staff("Kai Wildbau", "accounting", 2),
                new Staff("Sheila Watson", "legal representation", 2)
            };

            /* quick & dirty serializing & deserializing from file - using only Staff [otherwise would have to completely re-write clients/deceased]; copying settings from lesson 4 / Maierhofer */
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "graveyard.json"); // creating path to local Desktop & naming the file

            File.WriteAllText(path, JsonConvert.SerializeObject(employees, settings)); // serializing or writing to local file
            
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nThe following data is read from the json file.\n");
            Console.ResetColor();

            /* deserializing / reading from .json file - printing to console */

            //var helper = File.ReadAllText(path);
            var takebackdata = JsonConvert.DeserializeObject<IPerson[]>(File.ReadAllText(path), settings);

            foreach (var t in takebackdata)
            {
                Console.WriteLine($"Status: {t.Condition}, {t.Nameofperson}, responsible for: {t.ServiceAbo}");
            }

        }
    }
}
