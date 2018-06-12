using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Human_Base
    {
        public string Name { get; set; }
        public int Ws { get; set; }
        public int Bs { get; set; }
        public int Str { get; set; }
        public int T { get; set; }
        public int Ag { get; set; }
        public int Inte { get; set; }
        public int Per { get; set; }
        public int Wp { get; set; }
        public int Fel { get; set; }
        public int Ifl { get; set; }

        public List<Item> InventoryItems{ get; set; }

        public string HomeWorld { get; set; }
        public int CurrentPosition { get; set; }


        public Human_Base(string name, int ws, int bs, int str, int t, int ag, int inte, int per, int wp, int fel, int ifl)
        {
            Name = name;
            Ws = ws;
            Bs = bs;
            Str = str;
            T = t;
            Ag = ag;
            Inte = inte;
            Per = per;
            Wp = wp;
            Fel = fel;
            Ifl = ifl;
        }

        public Human_Base()
        {

        }
    }
}
