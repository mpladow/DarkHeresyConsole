using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Engine.Statistics.CharacterStat;

namespace Engine.Characters.HomeWorlds
{
    [Serializable]
    public class HomeWorld
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> StatsAffectedPositive { get; set; }
        public List<string> StatsAffectedNegative { get; set; }
        public string AptitudeBonus { get; set; }
        public int BaseWounds { get; set; }
        public string Description { get; set; }

        public HomeWorld(int id, string name, string description, int basewounds, string aptitude)
        {
            Id = id;
            Name = name;
            Description = description;
            BaseWounds = basewounds;
            StatsAffectedPositive = new List<string>();
            StatsAffectedNegative = new List<string>();
            AptitudeBonus = aptitude;
        }
    }


}
