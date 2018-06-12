using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Room:Location
    {
        public Room(string name, string size, string lightlevel)
        {
            Name = name;
            Size = size;
            LightLevel = lightlevel;
        }
    }
}
