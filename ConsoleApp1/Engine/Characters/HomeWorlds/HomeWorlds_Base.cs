using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Characters.HomeWorlds
{
    class HomeWorlds_Base
    {
        private enum HomeWorlds
        {
            FeralWorld,
            HiveWorld,
            HighBorn,
            ForgeWorld,
            ShrineWorld,
            VoidBorn
        }
        public string Name { get; set; }
        public List<StatModifier> StatModifiers { get; set; }
        public string Description { get; set; }

        public HomeWorlds_Base(string name, string description)
        {
            Name = name;
            Description = description;
            StatModifiers = new List<StatModifier>();
        }

        public static void GenerateHomeWorldList()
        {
            var FeralWorld = new HomeWorlds_Base(HomeWorlds.FeralWorld.ToString(), "A feral world");
            var HiveWorld = new HomeWorlds_Base(HomeWorlds.HiveWorld.ToString(), "A feral world");

        }

    }


}
