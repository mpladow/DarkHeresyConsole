using Engine.Actions;
using Engine.Statistics;
using Engine.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Engine.Actions.DiceRolls;

namespace Engine.Skills
{
    public abstract class Skills_Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CharacterStat MainStat { get; set; }
        public List<SkillModifier> TotalSkillModifiers { get; set; }
        public bool IsOpposedCheck { get; set; }

        private int _value;
        public int ModifiedValue //this is the public value that is constantly displayed
        {
            get
            {
                _value = CalculateFinalValue();
                return _value;
            }
        }

        public double ActionCost { get; set; }


        private int CalculateFinalValue()
        {
            int finalValue = MainStat.BaseValue;

            for (int i = 0; i < TotalSkillModifiers.Count; i++)
            {
                finalValue += TotalSkillModifiers[i].Value;
            }
            return finalValue;
        }

        //contstructors
        //uses for asigning the main stat characteristic value
        public Skills_Base(string name, CharacterStat stat, string description, bool isopposedcheck = false, double actioncost = 1)
        {
            Name = name;
            Description = description;
            MainStat = stat;
            IsOpposedCheck = isopposedcheck;
            ActionCost = actioncost;
            TotalSkillModifiers = new List<SkillModifier>();
        }
        //used for populating lists of skills, blind to any characters

        public Skills_Base(string name, string description, bool isopposedcheck = false, double actioncost = 1)
        {
            Name = name;
            Description = description;
            IsOpposedCheck = isopposedcheck;
            ActionCost = actioncost;
            TotalSkillModifiers = new List<SkillModifier>();
        }


        public void AddModifier(SkillModifier mod)
        {
            this.TotalSkillModifiers.Add(mod);
        }
        public void RemoveModifier(SkillModifier mod)
        {
            this.TotalSkillModifiers.Remove(mod);
        }

       

        public D100Result ConductCheck()
        {
            return CharacteristicChecks.DoCharacteristicCheck(this.ModifiedValue);
        }

        public D100Result[] ConductOpposingCheck(int opponentValue)
        {
            var resultPlayer = CharacteristicChecks.DoCharacteristicCheck(this.ModifiedValue);
            var resultOpponent = CharacteristicChecks.DoCharacteristicCheck(opponentValue);

            D100Result[] results= { resultPlayer, resultOpponent };
            return results;
        }

    }
}
