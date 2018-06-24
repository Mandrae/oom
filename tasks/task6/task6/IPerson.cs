using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    interface IPerson
    {
        string Nameofperson { get; }
        string Condition { get; }
        string ServiceAbo { get; }
        string SubscribedService(int a);
    }
}
