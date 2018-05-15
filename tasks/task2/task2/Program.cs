using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{

    public class APC
    {
        // public properties:
        public string last_name, journal_full_title, publisher;
        public int institute;
        public bool doaj;
        public decimal approx_apc;

        // private fields:
        private decimal approx_apc_incl_vat;
        private bool is_hybrid;

        // contructor:
        public APC(string newLast_name, int newInstitute, string newJournal_full_title, string newPublisher, decimal newApprox_apc, bool doaj)
        {
            if (string.IsNullOrEmpty(newLast_name) || string.IsNullOrEmpty(newJournal_full_title) || string.IsNullOrEmpty(newPublisher)) throw new ArgumentOutOfRangeException("Data not valid");
            if (newInstitute < 100 || newInstitute > 399) throw new ArgumentOutOfRangeException("Institute does not exist.");

            last_name = newLast_name;
            institute = newInstitute;
            journal_full_title = newJournal_full_title;
            publisher = newPublisher;
            approx_apc = newApprox_apc;

            HybridStatus(doaj);
        }

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



    class Monitoring
    {
        static void Main(string[] args)
        {
            APC apc1 = new APC("Tschiedl", 260, "Tierschutz in Recht und Praxis", "Uni Salzburg", 120, true);
            APC apc2 = new APC("Hermann", 389, "ACS Sustainable Chemistry & Engineering", "ACS", 2900, false);
            APC apc3 = new APC("Wieso", 101, "Bärtierchen-Journal", "Mach", 350, true);

            Console.WriteLine("Article processing charges in euro, no VAT included: {0}", apc1.approx_apc);
            Console.WriteLine("Last name of author: {0}", apc2.last_name);
            Console.WriteLine("Corresponding author's institute: E{0}", apc3.institute);

            if (apc2.Brutto(apc2.approx_apc) > 2400)
            {
                Console.WriteLine("Funding too high - special approval needed: {0}", apc2.Brutto(apc2.approx_apc));
            }
            else
            {
                Console.WriteLine("Funding approved.");
            }

        }
    }
}
