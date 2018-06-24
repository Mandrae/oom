using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace task6
{
    class Cerealization
    {
        /* method needs to be static - otherwise calling it in Program would need an instance of the class */
        public static void DoJsonStuff(IPerson[] peoplesdata)
        {
            /* printing objects to screen */
            Console.WriteLine($"See the following list for public information of the objects in section \"Clients\", \"Deceased\" and \"Staff\":\n {JsonConvert.SerializeObject(peoplesdata, Formatting.Indented)} \n End of console writing.");


            /* quick & dirty serializing & deserializing from file ; copying settings from lesson 4 / Maierhofer */
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "graveyard.json"); // creating path to local Desktop & naming the file

            File.WriteAllText(path, JsonConvert.SerializeObject(peoplesdata, settings)); // serializing or writing to local file

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nThe following data is read from the json file.\n");
            Console.ResetColor();

            /* deserializing / reading from .json file */
            var takebackdata = JsonConvert.DeserializeObject<IPerson[]>(File.ReadAllText(path), settings);

            /* now sort alphabetically by status (client, deceased or staff) and print to console */
            Array.Sort(takebackdata, (x, y) => String.Compare(x.Condition, y.Condition));
            foreach (var t in takebackdata)
            {
                Console.WriteLine($"Status: {t.Condition}, {t.Nameofperson}, services responsible for/ subscribed to: {t.ServiceAbo}");
            }

            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nThat was all the data from the json file.\n");
            Console.ResetColor();


            
        }
    }
}
