using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Characters.HomeWorlds
{
    public class HomeWorlds_Base
    {
        public enum HomeWorlds
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
        public List<StatModifier> StatModifiers { get; set; }
        public string Description { get; set; }

        public HomeWorlds_Base(string name, string description)
        {
            Name = name;
            Description = description;
            StatModifiers = new List<StatModifier>();
            StatsAffectedPositive = new List<string>();
            StatsAffectedNegative = new List<string>();
        }


    }


}
