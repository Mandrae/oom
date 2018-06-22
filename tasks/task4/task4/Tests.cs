using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task4

{
    [TestFixture]

    class Tests
    {
        [Test]

        /* Test #1: make sure that numbers are not accepted*/

        public void DigitsInNameDetected()
        {
            Assert.Catch(() =>
            {
                var a = new Clients("Tisch", "Eli7e", 2);
            });

        }

        [Test]
        /* Test #2: no wrong dates for birth or death are accepted */

        public void DatesAreValid()
        {
            Assert.Catch(() =>
            {
                var b = new[]
                {
                    new Deceased("Jäger", "Maxi", Convert.ToString(DateTime.Today), "22/02/2022", 2),
                    new Deceased("Jäger", "Maxi", "20/05/1923", "22/02/1922", 3)
                };
            });
        } 

        [Test]
        /*Test #3 if a client's address is correct*/

        public void NamesMatch()
        {
            var c = new Clients("Tisch", "Elise", 2, 'w');
            Assert.IsTrue(c.Title == "Mrs. ");
        }

        [Test]
        /* Test #4 if the age is correctly counted*/

        public void AgeCounting()
        {
            var d = new Deceased("Tisch", "Elise", "30/05/1980", "29/05/2010", 2, 'w');
            Assert.IsTrue(d.Age == 29);
        }

        [Test]
        /* Test #5: throw exception if wrong number for service for deceased person */

        public void ServiceWrong()
        {
            Assert.Catch(() =>
            {
                var e = new Deceased("Tisch", "Elise", "30/05/1980", "29/05/2010", 7, 'w');
            });
        }

        [Test]
        /* Test #6: checks if Subscribed Service Function is working properly for the Clients */

        public void CorrectService1()
        {
            var f = new Clients("Raab", "Helena", 2);
            Assert.IsTrue(f.ServiceAbo == "Premium Package: cemetery charges, care of grave");
        }

        [Test]
        /* Test #7: analog test 6, for Deceased*/

        public void CorrectService2()
        {
            var g = new Deceased("Raab", "Helena", "06/06/1950","07/07/1999", 4, 'w');
            Assert.IsTrue(g.ServiceAbo == "Gold Package: will, burial, administrative procedure incl obituary, grave fence");
        }

        [Test]

        /* Test #8 random test */

        public void RandomTest()
        {
            var h = new Clients("Carlisle", "Thomas", 1, 'm');
            Assert.IsFalse(h.Nameofperson == "Carlisle Thomas");
        }

    }
}
