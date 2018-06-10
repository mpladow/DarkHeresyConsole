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

        public Potion(string name, int amounttoheal, double weight):base(name, weight)
        {
            AmountToHeal = amounttoheal;
        }
    }
}
