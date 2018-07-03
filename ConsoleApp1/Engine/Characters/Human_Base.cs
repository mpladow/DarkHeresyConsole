using Engine.Actions;
using Engine.Characters.CharacterCreation;
using Engine.Characters.HomeWorlds;
using Engine.Skills;
using Engine.Statistics;
using Engine.Utilities;
using Engine.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Engine.Actions.DiceRolls;
using static Engine.Statistics.CharacterStat;

namespace Engine
{
    [Serializable]
    public abstract class Human_Base
    {

        public string Name { get; set; }

        public List<CharacterStat> Stats { get; set; }

        public int Wounds { get; set; }

        public int A_Head { get; set; }
        public int A_Body { get; set; }
        public int A_LeftArm { get; set; }
        public int A_RightArm { get; set; }
        public int A_LeftLeg { get; set; }
        public int A_RightLeg { get; set; }

        public List<SkillsWithRank> MovementSkills { get; set; }
        public List<Skill_Base> CombatSkills { get; set; }
        public List<SkillsWithRank> InteractionSkills { get; set; }

        public List<string> Aptitudes { get; set; }

        public HomeWorld HomeWorld { get; set; }
        public Background Background { get; set; }
        public int CurrentPosition { get; set; }

        public int XP { get; set; }
        public Human_Base()
        {
            Stats = new List<CharacterStat>();
            Stats.Add(new CharacterStat(Constants.Ws));
            Stats.Add(new CharacterStat(Constants.Bs));
            Stats.Add(new CharacterStat(Constants.Str));
            Stats.Add(new CharacterStat(Constants.T));
            Stats.Add(new CharacterStat(Constants.Ag));
            Stats.Add(new CharacterStat(Constants.Inte));
            Stats.Add(new CharacterStat(Constants.Per));
            Stats.Add(new CharacterStat(Constants.Wp));
            Stats.Add(new CharacterStat(Constants.Fel));
            Stats.Add(new CharacterStat(Constants.Ifl));

            MovementSkills = ReadOnlyLists.MovementSkillsList;
            CombatSkills = new List<Skill_Base>();
            InteractionSkills = new List<SkillsWithRank>();
            Aptitudes = new List<string>();
        }

        public CharacterStat GetCharacterStatByName(string name)
        {
            return Stats.FirstOrDefault(x => x.Name == name);
        }
        public void AllocateValues()
        {
            Cryptorandom rn = new Cryptorandom();
            foreach (var stat in Stats)
            {
                var value = Constants.StartingValue;
                value += RollD10(2, rn).Sum();
                stat.BaseValue = value;
            }
            if(HomeWorld!= null)
            {
                Wounds = RollD5(1, rn)[0] + HomeWorld.BaseWounds;
            }
            XP = Constants.StartingExperience;
        }

        public void UpdateHomeWorldCharacteristicBonuses()
        {
            Cryptorandom rn = new Cryptorandom();
            var posStats = HomeWorld.StatsAffectedPositive;
            var negStats = HomeWorld.StatsAffectedNegative;
            foreach (var posStat in posStats)
            {
                foreach (var stat in Stats)
                {
                    if (stat.Name == posStat)
                    {
                        stat.BaseValue = Constants.StartingValue;//resets basevaluee to 25
                        int[] roll = RollD10(3, rn);
                        stat.BaseValue += TakeDice(2, roll, true).Sum();
                    }
                }
            }
            foreach (var negStat in negStats)
            {
                foreach (var stat in Stats)
                {
                    if (stat.Name == negStat)
                    {
                        stat.BaseValue = Constants.StartingValue;//resets basevaluee to 25
                        int[] roll = RollD10(3, rn);
                        stat.BaseValue += TakeDice(2, roll, false).Sum();
                    }
                }
            }
            this.Aptitudes.Add(HomeWorld.AptitudeBonus);

        }

        public void AllocateSkills()
        {
            foreach (var skill in MovementSkills)
            {
                //for each skill, map 
                while (skill.MainStat == null)
                {
                    skill.MainStat = skill.Description.Contains("(Toughness)") ? GetCharacterStatByName(Constants.T) : skill.MainStat;
                    skill.MainStat = skill.Description.Contains("(Agility)") ? GetCharacterStatByName(Constants.Ag) : skill.MainStat;
                    skill.MainStat = skill.Description.Contains("(Fellowship)") ? GetCharacterStatByName(Constants.Fel) : skill.MainStat;
                    skill.MainStat = skill.Description.Contains("(Agility)") ? GetCharacterStatByName(Constants.Ag) : skill.MainStat;
                    skill.MainStat = skill.Description.Contains("(Intelligence)") ? GetCharacterStatByName(Constants.Inte) : skill.MainStat;
                    skill.MainStat = skill.Description.Contains("(Willpower)") ? GetCharacterStatByName(Constants.Wp) : skill.MainStat;
                    skill.MainStat = skill.Description.Contains("(Perception)") ? GetCharacterStatByName(Constants.Per) : skill.MainStat;
                    skill.MainStat = skill.Description.Contains("(Strength)") ? GetCharacterStatByName(Constants.Str) : skill.MainStat;
                }

            }
        }

        public void AllocateStartingSkills(int[] ids)
        {
            foreach (var id in ids)
            {
                var skill = ReadOnlyLists.GetMovementSkillById(id, this);
                skill.ModifyRank(true);
            }
        }

        public void RandomlySelectHomeWorld()//used for random generation.
        {
            Cryptorandom rn = new Cryptorandom();
            var result = Convert.ToInt32(DiceRolls.RollD100(rn));
            if (result >= 1 && result <= 15)

                HomeWorld = ReadOnlyLists.GetHomeworldById(Constants.FeralWorld);
            if (result >= 16 && result <= 33)
                HomeWorld = ReadOnlyLists.GetHomeworldById(Constants.ForgeWorld);
            if (result >= 34 && result <= 44)
                HomeWorld = ReadOnlyLists.GetHomeworldById(Constants.HighBorn);
            if (result >= 45 && result <= 69)
                HomeWorld = ReadOnlyLists.GetHomeworldById(Constants.HiveWorld);
            if (result >= 70 && result <= 85)
                HomeWorld = ReadOnlyLists.GetHomeworldById(Constants.ShrineWorld);
            if (result >= 86 && result <= 100)
                HomeWorld = ReadOnlyLists.GetHomeworldById(Constants.VoidBorn);
        }
    }
}
