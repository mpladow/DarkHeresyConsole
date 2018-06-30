using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Utilities.Constants;
using Engine.Characters.HomeWorlds;
using static Engine.Statistics.CharacterStat;
using Engine.Skills;

namespace Engine.Utilities.Constants
{
    public static class ReadOnlyLists
    {
        public static readonly List<SkillModifier> DifficultiesList = new List<SkillModifier>();
        public static readonly List<SkillModifier> SkillLevelsList = new List<SkillModifier>();
        public static readonly List<HomeWorld> HomeWorlds = new List<HomeWorld>();
        public static readonly List<Skills_Base> MovementSkillsList = new List<Skills_Base>();
        public static readonly List<Skills_Base> InteractionSkillsList = new List<Skills_Base>();
        public static readonly Dictionary<int, string> AptitudesDict = new Dictionary<int, string>();

        //Difficulties
        public static void PopulateDifficulties()
        {
            var trivial = new SkillModifier(Constants.Trivial, 60, "Trivial");
            var Ordinary = new SkillModifier(Constants.Ordinary, 10, "Ordinary");
            var Hard = new SkillModifier(Constants.Hard, -10, "Hard");
            var VeryHard = new SkillModifier(Constants.VeryHard, -30, "Very Hard");
            var Punishing = new SkillModifier(Constants.Punishing, -50, "Punishing");
            DifficultiesList.Add(trivial);
            DifficultiesList.Add(Ordinary);
            DifficultiesList.Add(Hard);
            DifficultiesList.Add(VeryHard);
            DifficultiesList.Add(Punishing);
        }

        public static SkillModifier GetDifficultyById(int id)
        {
            return DifficultiesList.Where(x => x.Id == id).FirstOrDefault();
        }

        //Homeworlds
        public static List<HomeWorld> PopulateHomeWorlds()
        {
            var FeralWorld = new Characters.HomeWorlds.HomeWorld(1, "FeralWorld", "A feral world", 9);
            FeralWorld.StatsAffectedPositive.Add(StatName.Str.ToString());
            FeralWorld.StatsAffectedPositive.Add(StatName.T.ToString());
            FeralWorld.StatsAffectedNegative.Add(StatName.Inte.ToString());
            HomeWorlds.Add(FeralWorld);

            var HiveWorld = new Characters.HomeWorlds.HomeWorld(2, "HiveWorld", "A hive world", 8);
            HiveWorld.StatsAffectedPositive.Add(StatName.Ag.ToString());
            HiveWorld.StatsAffectedPositive.Add(StatName.Per.ToString());
            HiveWorld.StatsAffectedNegative.Add(StatName.Wp.ToString());
            HomeWorlds.Add(HiveWorld);

            var HighBorn = new Characters.HomeWorlds.HomeWorld(3, "HighBorn", "A High Born from an ecclessiarchal world.", 9);
            HighBorn.StatsAffectedPositive.Add(StatName.Fel.ToString());
            HighBorn.StatsAffectedPositive.Add(StatName.Ifl.ToString());
            HighBorn.StatsAffectedNegative.Add(StatName.T.ToString());
            HomeWorlds.Add(HighBorn);


            var ForgeWorld = new Characters.HomeWorlds.HomeWorld(4, "ForgeWorld", "An industrial forge world", 8);
            ForgeWorld.StatsAffectedPositive.Add(StatName.Inte.ToString());
            ForgeWorld.StatsAffectedPositive.Add(StatName.T.ToString());
            ForgeWorld.StatsAffectedNegative.Add(StatName.Fel.ToString());
            HomeWorlds.Add(ForgeWorld);

            var ShrineWorld = new Characters.HomeWorlds.HomeWorld(5, "ShrineWorld", "A shrine world", 7);
            ShrineWorld.StatsAffectedPositive.Add(StatName.Fel.ToString());
            ShrineWorld.StatsAffectedPositive.Add(StatName.Wp.ToString());
            ShrineWorld.StatsAffectedNegative.Add(StatName.Per.ToString());
            HomeWorlds.Add(ShrineWorld);

            var VoidBorn = new Characters.HomeWorlds.HomeWorld(6, "VoidBorn", "A void-born", 7);
            VoidBorn.StatsAffectedPositive.Add(StatName.Inte.ToString());
            VoidBorn.StatsAffectedPositive.Add(StatName.Wp.ToString());
            VoidBorn.StatsAffectedNegative.Add(StatName.Str.ToString());
            HomeWorlds.Add(VoidBorn);
            return HomeWorlds;
        }


        public static HomeWorld GetHomeworldById(int homeworldConst)
        {
            return HomeWorlds.Where(x => x.Id == homeworldConst).FirstOrDefault();
        }

        //Aptitudes
        public static void PopulateSkillLevels()
        {
            var unskilled = new SkillModifier(Constants.Unskilled, -20, "Unskilled");
            var known = new SkillModifier(Constants.Known, 0, "Known");
            var trained = new SkillModifier(Constants.Trained, 10, "Trained");
            var experienced = new SkillModifier(Constants.Experienced, 20, "Experienced");
            var veteran = new SkillModifier(Constants.Veteran, 30, "Veteran");

            SkillLevelsList.Add(unskilled);
            SkillLevelsList.Add(known);
            SkillLevelsList.Add(trained);
            SkillLevelsList.Add(experienced);
            SkillLevelsList.Add(veteran);
        }

        public static SkillModifier GetSkillLevelsById(int id)
        {
            var aptitude = SkillLevelsList.Where(x => x.Id == id).FirstOrDefault();
            return aptitude;
        }

        //Aptitudes
        public static void PopulateAptitudesDictionary()
        {
            string[] aptitudes =
            {
                "Offence",
                "Finesse",
                "Defence",
                "Knowledge", 
                "Fieldcraft",
                "Psyker",
                "Social",
                "Tech",
                "Leadership"
            };

            for (int i = 0; i < aptitudes.Length; i++)
            {
                for (int j = 0; j < aptitudes.Length; j++)
                {
                    if (i == j)
                        AptitudesDict[i] = aptitudes[j];
                    if(i < j)
                    break;
                }
            };          
        }

        //Skills

        public static void PopulateSkills()
        {
            var athletics = new SkillsWithRank("Athletics", "(Toughness) Control and direct vehicles and equipment.");
            MovementSkillsList.Add(athletics);

            var acrobatics = new SkillsWithRank("Acrobatics", "(Agility) Navigating through environments gracefully. Keeping balance. Jumping");
            MovementSkillsList.Add(acrobatics);

            var stealth = new SkillsWithRank("Stealth", "(Toughness) Control and direct vehicles and equipment.");
            MovementSkillsList.Add(stealth);

            var operate = new SkillsWithRank("Operate", "(Agility) Control and direct vehicles and equipment.",0.5);
            MovementSkillsList.Add(operate);

            var charm = new SkillsWithRank("Charm", "(Fellowship) Sway people towards a certain disposition. Gather information. Distract someone");
            InteractionSkillsList.Add(charm);

            var commerce = new SkillsWithRank("Commerce", "(Intelligence) Evaluating item worth. Attempting to track down a rare item in a market");
            InteractionSkillsList.Add(commerce);

            //var commonLore = new SkillsWithRank("Common Lore", "(Intelligence) Control and direct vehicles and equipment.", 0);
            //MovementSkillsList.Add(commonLore);requires more complicated information

            var deceive = new SkillsWithRank("Deceive", "(Fellowship) Attempt to lie and mislead. Attempt to disguise yourself", isopposedcheck: true);
            InteractionSkillsList.Add(deceive);

            var inquiry = new SkillsWithRank("Inquiry", "(Fellowship) Attempt to gain further information on locations, gossip, attitudes towards leaders, etc", actioncost: 60);
            InteractionSkillsList.Add(inquiry);

            var interrogation = new SkillsWithRank("Interrogation", "(Fellowship) Attempt to lie and mislead. Attempt to disguise yourself", isopposedcheck: true);
            InteractionSkillsList.Add(interrogation);

            var intimidate = new SkillsWithRank("Intimidate", "(Fellowship) Attempt to lie and mislead. Attempt to disguise yourself", isopposedcheck: true);
            InteractionSkillsList.Add(intimidate);

            var scrutiny = new SkillsWithRank("Scrutiny", "(Perception) Interpret other peoples words and actions. Judging their mood.", isopposedcheck: true);//opposed by deceive
            InteractionSkillsList.Add(scrutiny);

        }

    }
}
  