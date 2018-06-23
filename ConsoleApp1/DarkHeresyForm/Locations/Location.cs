using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class Location
    {
        public string Name { get; set; }
        public List<string> Options { get; set; }

        public List<Item_base> ItemsInRoom { get; set; }
        public List<Item_base> ItemsInLocation { get; set; }
        public Location LocationNorth{ get; set; }
        public Location LocationSouth { get; set; }
        public Location LocationEast { get; set; }
        public Location LocationWest { get; set; }

        public bool canEnter { get; set; }
    }

}