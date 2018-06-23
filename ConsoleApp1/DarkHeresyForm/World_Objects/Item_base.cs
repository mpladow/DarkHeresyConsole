using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Item_base
    {
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public double Weight { get; set; }
        public decimal Value { get; set; }

        public Item_base(string name, string nameplural, double weight)
        {
            Name = name;
            Weight = weight;
        }


    }

}
