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
    [Serializable]
    public abstract class Skill_Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CharacterStat MainStat { get; set; }
        public List<SkillModifier> TotalSkillModifiers { get; set; }
        public bool IsOpposedCheck { get; set; }

       
        public int ModifiedValue //this is the public value that is constantly displayed
        {
            get
            {
                var _value = CalculateFinalValue();
                _value = _value > 100? 100: _value;//sets limites between 100 and 1
                _value = _value < 0 ? 1 : _value;
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
        public Skill_Base(int id, string name, CharacterStat stat, string description, bool isopposedcheck = false, double actioncost = 1)
        {
            Id = id;
            Name = name;
            Description = description;
            MainStat = stat;
            IsOpposedCheck = isopposedcheck;
            ActionCost = actioncost;
            TotalSkillModifiers = new List<SkillModifier>();
        }
        //used for populating lists of skills, blind to any characters

        public Skill_Base(int id, string name, string description, bool isopposedcheck = false, double actioncost = 1)
        {
            Id = id;
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
