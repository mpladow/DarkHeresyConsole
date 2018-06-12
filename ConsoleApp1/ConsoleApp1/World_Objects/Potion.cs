using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Potion: Item_base
    {
        public int AmountToHeal { get; set; }

        public Potion(string name, int amounttoheal, double weight):base(id, name, nameplural, weight)
        {
            AmountToHeal = amounttoheal;
        }
    }
}
