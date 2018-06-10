using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Room
    {
        public string Name { get; set; }
        public List<string> Options { get; set; }
        public List<Item> ItemsInRoom { get; set; }
        public string Size { get; set; }
        public string LightLevel { get; set; }

        public Room(string name, string size, string lightlevel)
        {
            Name = name;
            Size = size;
            LightLevel = lightlevel;
        }

        public List<String> OptionsMenu()
        {
            var Options = new List<string>()
                {
                    "Wall",
                    "Floor",
                    "Ceiling",
                    "Window"
                };
            return Options;
        }
    }
}
