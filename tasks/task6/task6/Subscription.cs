using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;

namespace task6
{

    /* task 6: subscribing to subject & experiment with query */

    public static class Subscription
    {
        public static void Subscribing()
        {
            Console.WriteLine($"\nHi, I am the main thread: #{Thread.CurrentThread.ManagedThreadId}! Let's start task 6.");

            var client_source = new Subject<Clients>();

            // now subscribing - but only to clients with the basic package
            client_source.Where(x => x.ServiceAbo == "Basic Package: cemetery charges").Subscribe(x => Console.WriteLine($"Thread: #{Thread.CurrentThread.ManagedThreadId} - new basic services: {x.Nameofperson}, {x.ServiceAbo}"));

            // print subscription to console - not all of them will make it
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                client_source.OnNext(new Clients("Silvia Sommer", "Client", "Basic Package: cemetery charges"));
                client_source.OnNext(new Clients("Theodor Calzone", "Client", "Premium Package: cemetery charges, care of grave"));
                client_source.OnNext(new Clients("Mohammad Rahman", "Client", "Basic Package: cemetery charges"));
            }
            
        }
    }
}
