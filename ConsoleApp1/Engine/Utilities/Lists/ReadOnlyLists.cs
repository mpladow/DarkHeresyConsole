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
using Engine.Characters.CharacterCreation;

namespace Engine.Utilities.Constants
{
    public static class ReadOnlyLists
    {
        public static readonly List<SkillModifier> DifficultiesList = new List<SkillModifier>();
        public static readonly List<SkillModifier> SkillLevelsList = new List<SkillModifier>();
        public static readonly List<HomeWorld> HomeWorlds = new List<HomeWorld>();
        public static readonly List<Background> Backgrounds = new List<Background>();
        public static readonly List<Role> Roles = new List<Role>();
        public static readonly List<SkillsWithRank> MovementSkillsList = new List<SkillsWithRank>();
        public static readonly List<SkillsWithRank> InteractionSkillsList = new List<SkillsWithRank>();
        public static readonly List<SkillsWithRank> GeneralSkillsList = new List<SkillsWithRank>();
        public static readonly List<Skills_Base> CombatSkillsList = new List<Skills_Base>();

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

        //Roles
        public static List<Role> PopulateRoles()
        {
            var 
        }
       //Backgrounds
        public static List<Background> PopulateBackgrounds()
        {
            var adeptusArbites = new Background(1, "Adeptus Arbites", "Lawbringers of the imperium.");
            adeptusArbites.StartingSkills.Add(GeneralSkillsList.FirstOrDefault(x => x.Id == 1));//adds awareness
            adeptusArbites.StartingSkills.Add(InteractionSkillsList.FirstOrDefault(x => x.Id == 4));//adds inquiry
            adeptusArbites.StartingSkills.Add(InteractionSkillsList.FirstOrDefault(x => x.Id == 5));//interrogate
            adeptusArbites.StartingSkills.Add(InteractionSkillsList.FirstOrDefault(x => x.Id == 6));//intimidate
            adeptusArbites.StartingSkills.Add(InteractionSkillsList.FirstOrDefault(x => x.Id == 7));//scrutiny
            adeptusArbites.StartingAptitudes.Add(Constants.Offence);
            adeptusArbites.StartingAptitudes.Add(Constants.Defence);
            Backgrounds.Add(adeptusArbites);

            var imperialGuard = new Background(2, "Imperial Guard", "Specialists in combat.");
            imperialGuard.StartingSkills.Add(GeneralSkillsList.FirstOrDefault(x => x.Id == 2));//adds command
            imperialGuard.StartingSkills.Add(MovementSkillsList.FirstOrDefault(x => x.Id == 1));//adds Athletics
            imperialGuard.StartingSkills.Add(GeneralSkillsList.FirstOrDefault(x => x.Id == 3));//adds medicae
            imperialGuard.StartingAptitudes.Add(Constants.Fieldcraft);
            imperialGuard.StartingAptitudes.Add(Constants.Leadership);
            Backgrounds.Add(imperialGuard);

            var outcast = new Background(2, "Outcast", "A rogue with ties to the underworld.");
            outcast.StartingSkills.Add(MovementSkillsList.FirstOrDefault(x => x.Id == 2));//adds acrobatics
            outcast.StartingSkills.Add(MovementSkillsList.FirstOrDefault(x => x.Id == 3));//adds stealth
            outcast.StartingSkills.Add(InteractionSkillsList.FirstOrDefault(x => x.Id == 3));//adds Deceive
            outcast.StartingSkills.Add(CombatSkillsList.FirstOrDefault(x => x.Id == 1));//adds Dodge
            outcast.StartingAptitudes.Add(Constants.Fieldcraft);
            outcast.StartingAptitudes.Add(Constants.Leadership);
            Backgrounds.Add(outcast);

            return Backgrounds;
        }
        //Homeworlds
        public static List<HomeWorld> PopulateHomeWorlds()
        {
            var FeralWorld = new HomeWorld(1, "FeralWorld", "A feral world", 9, Constants.T);
            FeralWorld.StatsAffectedPositive.Add(Constants.Str);
            FeralWorld.StatsAffectedPositive.Add(Constants.T);
            FeralWorld.StatsAffectedNegative.Add(Constants.Inte);
            HomeWorlds.Add(FeralWorld);

            var HiveWorld = new Characters.HomeWorlds.HomeWorld(2, "HiveWorld", "A hive world", 8, Constants.Per);
            HiveWorld.StatsAffectedPositive.Add(Constants.Ag);
            HiveWorld.StatsAffectedPositive.Add(Constants.Per);
            HiveWorld.StatsAffectedNegative.Add(Constants.Wp);
            HomeWorlds.Add(HiveWorld);

            var HighBorn = new Characters.HomeWorlds.HomeWorld(3, "HighBorn", "A High Born from an ecclessiarchal world.", 9, Constants.Fel);
            HighBorn.StatsAffectedPositive.Add(Constants.Fel);
            HighBorn.StatsAffectedPositive.Add(Constants.Ifl);
            HighBorn.StatsAffectedNegative.Add(Constants.T);
            HomeWorlds.Add(HighBorn);


            var ForgeWorld = new Characters.HomeWorlds.HomeWorld(4, "ForgeWorld", "An industrial forge world", 8, Constants.Inte );
            ForgeWorld.StatsAffectedPositive.Add(Constants.Inte);
            ForgeWorld.StatsAffectedPositive.Add(Constants.T);
            ForgeWorld.StatsAffectedNegative.Add(Constants.Fel);
            HomeWorlds.Add(ForgeWorld);

            var ShrineWorld = new Characters.HomeWorlds.HomeWorld(5, "ShrineWorld", "A shrine world", 7, Constants.Wp);
            ShrineWorld.StatsAffectedPositive.Add(Constants.Fel);
            ShrineWorld.StatsAffectedPositive.Add(Constants.Wp);
            ShrineWorld.StatsAffectedNegative.Add(Constants.Per);
            HomeWorlds.Add(ShrineWorld);

            var VoidBorn = new Characters.HomeWorlds.HomeWorld(6, "VoidBorn", "A void-born", 7, Constants.Inte);
            VoidBorn.StatsAffectedPositive.Add(Constants.Inte);
            VoidBorn.StatsAffectedPositive.Add(Constants.Wp);
            VoidBorn.StatsAffectedNegative.Add(Constants.Str);
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

        public static SkillModifier GetSkillLevelsById(int id, Player player = null)
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
                "Leadership",

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
            var athletics = new SkillsWithRank(1, "Athletics", "(Toughness) Using physically demanding tasks.");
            MovementSkillsList.Add(athletics);

            var acrobatics = new SkillsWithRank(2, "Acrobatics", "(Agility) Navigating through environments gracefully. Keeping balance. Jumping");
            MovementSkillsList.Add(acrobatics);

            var stealth = new SkillsWithRank(3, "Stealth", "(Agility) Attempt to hide from enemies and move unseen.");
            MovementSkillsList.Add(stealth);

            var operate = new SkillsWithRank(4, "Operate", "(Agility) Control and direct vehicles and equipment.",0.5);
            MovementSkillsList.Add(operate);


            //interaction skills
            var charm = new SkillsWithRank(1, "Charm", "(Fellowship) Sway people towards a certain disposition. Gather information. Distract someone");
            InteractionSkillsList.Add(charm);

            var commerce = new SkillsWithRank(2, "Commerce", "(Intelligence) Evaluating item worth. Attempting to track down a rare item in a market");
            InteractionSkillsList.Add(commerce);

            //var commonLore = new SkillsWithRank("Common Lore", "(Intelligence) Control and direct vehicles and equipment.", 0);
            //MovementSkillsList.Add(commonLore);requires more complicated information

            var deceive = new SkillsWithRank(3, "Deceive", "(Fellowship) Attempt to lie and mislead. Attempt to disguise yourself", isopposedcheck: true);
            InteractionSkillsList.Add(deceive);

            var inquiry = new SkillsWithRank(4, "Inquiry", "(Fellowship) Attempt to gain further information on locations, gossip, attitudes towards leaders, etc", actioncost: 60);
            InteractionSkillsList.Add(inquiry);

            var interrogation = new SkillsWithRank(5, "Interrogation", "(Willpower) Attempt to lie and mislead. Attempt to disguise yourself", isopposedcheck: true);//opposed by willpower - will require further methods to complete 
            InteractionSkillsList.Add(interrogation);

            var intimidate = new SkillsWithRank(6, "Intimidate", "(Strength) Attempt to lie and mislead. Attempt to disguise yourself", isopposedcheck: true);//opposed by willpower
            InteractionSkillsList.Add(intimidate);

            var scrutiny = new SkillsWithRank(7, "Scrutiny", "(Perception) Interpret other peoples words and actions. Judging their mood.", isopposedcheck: true);//opposed by deceive
            InteractionSkillsList.Add(scrutiny);

            //general skills
            var awareness = new SkillsWithRank(1, "Awareness", "(Perception) Attempting to spot items and individuals that are hidden.", isopposedcheck: true); //opposed by stealth against NPCS
            GeneralSkillsList.Add(awareness);

            var command = new SkillsWithRank(2, "Command", "(Fellowship) Attempt to boost morale of allies, or order an npc to do something for them.");
            GeneralSkillsList.Add(command);

            var medicae = new SkillsWithRank(3, "Medicae", "(Intelligence) Heal wounds and diagnosing afflictions.");
            GeneralSkillsList.Add(medicae);

            //combat skills
            var Dodge = new SkillsWithRank(1, "Dodge", "(Agility) Attempt to dodge a ranged or melee attack. Avoid hazards.");
            CombatSkillsList.Add(Dodge);
        }

        public static SkillsWithRank GetMovementSkillById(int id, Human_Base player = null)
        {
            if (player!= null)
            {
                return player.MovementSkills.FirstOrDefault(x => x.Id == id);
            }
            else return MovementSkillsList.FirstOrDefault(x => x.Id == id);
        }
        public static SkillsWithRank GetInteractionSkillById(int id, Human_Base player = null)
        {
            if (player != null)
            {
                return player.InteractionSkills.FirstOrDefault(x => x.Id == id);
            }
            else return InteractionSkillsList.FirstOrDefault(x => x.Id == id);
        }
        public static Skills_Base GetComabtSkillById(int id, Human_Base player = null)
        {
            if (player != null)
            {
                return player.CombatSkills.FirstOrDefault(x => x.Id == id);
            }
            else return CombatSkillsList.FirstOrDefault(x => x.Id == id);
        }

    }
}
  