using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }

        public Item(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }


    }

}
