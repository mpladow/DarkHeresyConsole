using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Characters.HomeWorlds
{
    public class HomeWorld
    {
        public enum enumHomeWorlds
        {
            FeralWorld,
            HiveWorld,
            HighBorn,
            ForgeWorld,
            ShrineWorld,
            VoidBorn
        }
        public string Name { get; set; }
        public List<string> StatsAffectedPositive { get; set; }
        public List<string> StatsAffectedNegative { get; set; }
        public string Description { get; set; }

        public HomeWorld(string name, string description)
        {
            Name = name;
            Description = description;
            StatsAffectedPositive = new List<string>();
            StatsAffectedNegative = new List<string>();
        }


    }


}
