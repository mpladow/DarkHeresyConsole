using Engine.Characters.HomeWorlds;
using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Engine.Characters.HomeWorlds.HomeWorld;
using static Engine.Statistics.CharacterStat;

namespace Engine.Utilities
{
    public static class ListGenerator
    {
        //this static class is used to generate the world objects and concepts.
        public static List<Characters.HomeWorlds.HomeWorld> GenerateHomeWorldList()
        {
            List<Characters.HomeWorlds.HomeWorld> list = new List<Characters.HomeWorlds.HomeWorld>();
            var FeralWorld = new Characters.HomeWorlds.HomeWorld(Characters.HomeWorlds.HomeWorld.enumHomeWorlds.FeralWorld.ToString(), "A feral world");
            FeralWorld.StatsAffectedPositive.Add(StatName.Str.ToString());
            FeralWorld.StatsAffectedPositive.Add(StatName.T.ToString());
            FeralWorld.StatsAffectedNegative.Add(StatName.Inte.ToString());
            list.Add(FeralWorld);

            var HiveWorld = new Characters.HomeWorlds.HomeWorld(Characters.HomeWorlds.HomeWorld.enumHomeWorlds.HiveWorld.ToString(), "A hive world");
            HiveWorld.StatsAffectedPositive.Add(StatName.Ag.ToString());
            HiveWorld.StatsAffectedPositive.Add(StatName.Per.ToString());
            HiveWorld.StatsAffectedNegative.Add(StatName.Wp.ToString());
            list.Add(HiveWorld);

            var HighBorn = new Characters.HomeWorlds.HomeWorld(Characters.HomeWorlds.HomeWorld.enumHomeWorlds.HighBorn.ToString(), "A High Born from an ecclessiarchal world.");
            HighBorn.StatsAffectedPositive.Add(StatName.Fel.ToString());
            HighBorn.StatsAffectedPositive.Add(StatName.Ifl.ToString());
            HighBorn.StatsAffectedNegative.Add(StatName.T.ToString());
            list.Add(HighBorn);


            var ForgeWorld = new Characters.HomeWorlds.HomeWorld(Characters.HomeWorlds.HomeWorld.enumHomeWorlds.ForgeWorld.ToString(), "An industrial forge world");
            ForgeWorld.StatsAffectedPositive.Add(StatName.Inte.ToString());
            ForgeWorld.StatsAffectedPositive.Add(StatName.T.ToString());
            ForgeWorld.StatsAffectedNegative.Add(StatName.Fel.ToString());
            list.Add(ForgeWorld);

            var ShrineWorld = new Characters.HomeWorlds.HomeWorld(Characters.HomeWorlds.HomeWorld.enumHomeWorlds.ShrineWorld.ToString(), "A shrine world");
            ShrineWorld.StatsAffectedPositive.Add(StatName.Fel.ToString());
            ShrineWorld.StatsAffectedPositive.Add(StatName.Wp.ToString());
            ShrineWorld.StatsAffectedNegative.Add(StatName.Per.ToString());
            list.Add(ShrineWorld);

            var VoidBorn = new Characters.HomeWorlds.HomeWorld(Characters.HomeWorlds.HomeWorld.enumHomeWorlds.VoidBorn.ToString(), "A void-born");
            VoidBorn.StatsAffectedPositive.Add(StatName.Inte.ToString());
            VoidBorn.StatsAffectedPositive.Add(StatName.Wp.ToString());
            VoidBorn.StatsAffectedNegative.Add(StatName.Str.ToString());
            list.Add(VoidBorn);
            return list;
        }
    }
}
