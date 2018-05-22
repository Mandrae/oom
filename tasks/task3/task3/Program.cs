using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{

    public interface IApplication
    {
        string typeApplication();
        string Last_name { get; set; }
    }

    class APC : IApplication
    {

        public string typeApplication()
        {
            string application = "article processing charges";
            return application;
        }

        // private fields:
        private decimal approx_apc_incl_vat;
        private bool is_hybrid;

        // contructor:
        public APC(string newLast_name, int newInstitute, string newJournal_full_title, string newPublisher, decimal newApprox_apc, bool doaj)
        {
            if (string.IsNullOrEmpty(newLast_name) || string.IsNullOrEmpty(newJournal_full_title) || string.IsNullOrEmpty(newPublisher)) throw new ArgumentOutOfRangeException("Data not valid");
            if (newInstitute < 100 || newInstitute > 399) throw new ArgumentOutOfRangeException("Institute does not exist.");

            Last_name = newLast_name;
            Institute = newInstitute;
            Journal_full_title = newJournal_full_title;
            Publisher = newPublisher;
            Approx_apc = newApprox_apc;

            HybridStatus(doaj);
        }

        // properties ~ wip
        public string Last_name { get; set; }
        public int Institute { get; set; }
        public string Journal_full_title { get; set; }
        public string Publisher { get; set; }
        public decimal Approx_apc { get; private set; }


        // method:
        public void HybridStatus(bool doaj)
        {
            is_hybrid = doaj;
        }

        public decimal Brutto(decimal Approx_apc)
        {
            return approx_apc_incl_vat = (Approx_apc * (decimal)1.2);
        }
    }

    class BPC : IApplication
    {
        public string typeApplication()
        {
            string application = "book processing charges";
            return application;
        }

        public BPC(string newLast_name, int newPages)
        {

            Last_name = newLast_name;
            Pages = newPages;
        }
        //properties
        public string Last_name { get; set; }
        public int Pages { get; set; }
    }


    class Monitoring
    {
        static void Main(string[] args)
        {
            var mix = new IApplication[]
            {
                new APC("Tschiedl", 260, "Tierschutz in Recht und Praxis", "Uni Salzburg", 120, true),
                new APC("Hermann", 389, "ACS Sustainable Chemistry & Engineering", "ACS", 2900, false),
                new BPC("Wieso", 720),
            };

            //for (int i = 0; i < mix.Length; i++)
            foreach (var i in mix)
            {
                Console.WriteLine(i.Last_name); //prints Author's Last Name
            }

        }
    }
}