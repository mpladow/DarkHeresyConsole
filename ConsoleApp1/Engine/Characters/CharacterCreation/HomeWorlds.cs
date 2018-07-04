using Engine.Actions;
using Engine.Statistics;
using Engine.Utilities;
using Engine.Utilities.Constants;
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

        public HomeWorld RandomlySelectHomeWorld()//used for random generation.
        {
            HomeWorld homeworldRandom = null;
            Cryptorandom rn = new Cryptorandom();
            var result = Convert.ToInt32(DiceRolls.RollD100(rn));
            if (result >= 1 && result <= 15)
                homeworldRandom = ReadOnlyLists.GetHomeworldById(Constants.FeralWorld);
            if (result >= 16 && result <= 33)
                homeworldRandom = ReadOnlyLists.GetHomeworldById(Constants.ForgeWorld);
            if (result >= 34 && result <= 44)
                homeworldRandom = ReadOnlyLists.GetHomeworldById(Constants.HighBorn);
            if (result >= 45 && result <= 69)
                homeworldRandom = ReadOnlyLists.GetHomeworldById(Constants.HiveWorld);
            if (result >= 70 && result <= 85)
                homeworldRandom = ReadOnlyLists.GetHomeworldById(Constants.ShrineWorld);
            if (result >= 86 && result <= 100)
                homeworldRandom = ReadOnlyLists.GetHomeworldById(Constants.VoidBorn);
            return homeworldRandom;
        }
    }



}
