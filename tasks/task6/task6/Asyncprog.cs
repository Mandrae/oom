using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Globalization;
using Newtonsoft.Json.Linq;
using System.IO;

namespace task6
{
    public static class Asyncprog
    {
        public class ANewClient // for API data
        {
            public string name { get; set; } // lower case, otherwise json mapping won't work
            public string email { get; set; }
            public string phone { get; set; }
        }

        public static void SyncingAsync()
        {
            /* start tasks with Task.Run */
            Task t = Task.Run(() => { // this will - at the very least - intertwine with Task tt
                Console.WriteLine($"This is running on thread {Thread.CurrentThread.ManagedThreadId}. Start processing data.");
                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId}. Typing... ");
                    Thread.Sleep(1000);
                }
                Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId}. Thanks for the input. 7 entries processed");
            });

            Task tt = Task.Run(() => {
                /*counting lines in json file*/
                int lines = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "graveyard.json")).Length;
                Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId}: Counted {lines} lines of the json file of task 4.");
            });
            Task.WaitAll(t, tt); // wait until those two are finished 


            /* using ContinueWith, async / await */
            
            Task ttt = new Task( async () => await GetMeInfo());
            ttt.ContinueWith((taskReference) => Console.WriteLine($"Thread: #{Thread.CurrentThread.ManagedThreadId} - just finished delivering some random user data.\n"));
            ttt.Start();           
        }

        public static async Task<string> GetMeInfo()
        {
            /* get me some random user data */
            var url = $"https://jsonplaceholder.typicode.com/users/1";
            var infourl = new WebClient().DownloadString(url);
            var somejsondata = JObject.Parse(infourl);

            /* simply print the info, nothing done to the json object yet */
            Console.WriteLine($"Excuse me, I'm thread: #{Thread.CurrentThread.ManagedThreadId} - and here's some information from an external source: {somejsondata}");

            /* now wait a bit: but not too long, otherwise main function is quicker with EOF & delay is not executed */
            await Task.Delay(2000);

            /* now we are converting the above json data & print to console - but as we will see: this is delayed & a new thread */
            ANewClient theClientFromJson = JsonConvert.DeserializeObject<ANewClient>(infourl);
            Console.WriteLine($"\nI'm a new thread: #{Thread.CurrentThread.ManagedThreadId} - and here's the data from the above json string. \nThe new client's name: {theClientFromJson.name}, mail: {theClientFromJson.email}, phone number: {theClientFromJson.phone}\n");

            return null; // if Task is not string => warnings for GetMeInfo
            
        } // end of GetMeInfo

    }

}
