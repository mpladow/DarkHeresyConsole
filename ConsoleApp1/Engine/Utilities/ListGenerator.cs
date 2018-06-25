using Engine.Characters.HomeWorlds;
using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Engine.Characters.HomeWorlds.HomeWorlds_Base;
using static Engine.Statistics.CharacterStat;

namespace Engine.Utilities
{
    public static class ListGenerator
    {
        public static List<HomeWorlds_Base> GenerateHomeWorldList()
        {
            List<HomeWorlds_Base> list = new List<HomeWorlds_Base>();
            var FeralWorld = new HomeWorlds_Base(HomeWorlds.FeralWorld.ToString(), "A feral world");
            FeralWorld.StatsAffectedPositive.Add(StatName.Str.ToString());
            FeralWorld.StatsAffectedPositive.Add(StatName.T.ToString());
            FeralWorld.StatsAffectedNegative.Add(StatName.Inte.ToString());
            list.Add(FeralWorld);

            var HiveWorld = new HomeWorlds_Base(HomeWorlds.HiveWorld.ToString(), "A hive world");
            var HighBorn = new HomeWorlds_Base(HomeWorlds.HighBorn.ToString(), "A High Born from an ecclessiarchal world.");
            var ForgeWorld = new HomeWorlds_Base(HomeWorlds.ForgeWorld.ToString(), "A forge world");
            var ShrineWorld = new HomeWorlds_Base(HomeWorlds.ShrineWorld.ToString(), "A shrine world");
            var VoidBorn = new HomeWorlds_Base(HomeWorlds.VoidBorn.ToString(), "A void-born");

            return list;
        }
    }
}
