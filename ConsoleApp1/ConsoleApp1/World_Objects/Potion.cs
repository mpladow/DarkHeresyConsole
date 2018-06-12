using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Potion:Item
    {
        public int AmountToHeal { get; set; }

        public Potion(int id, string name, string nameplural, int amounttoheal, double weight):base(id, name, nameplural, weight)
        {
            AmountToHeal = amounttoheal;
        }
    }
}
