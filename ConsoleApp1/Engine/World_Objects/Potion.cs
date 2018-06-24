using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Potion: Item_base
    {
        public int AmountToHeal { get; set; }

        public Potion(string name, string nameplural, int amounttoheal, double weight):base(name, nameplural, weight)
        {
            AmountToHeal = amounttoheal;
        }
    }
}
