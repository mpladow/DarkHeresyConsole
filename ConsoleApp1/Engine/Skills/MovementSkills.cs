using Engine.Actions;
using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Skills
{
    public class MovementSkills
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public string Description { get; set; }
        public CharacterStat MainStat{ get; set; }
        public List<SkillModifier> TotalSkillModifiers { get; set; }

        private int _value;
        public int ModifiedValue //this is the public value that is constantly displayed
        {
            get
            {
                _value = CalculateFinalValue();
                return _value;
            }
        }


        private int CalculateFinalValue()
        {
            int finalValue = ModifiedValue;

            for (int i = 0; i < TotalSkillModifiers.Count; i++)
            {
                finalValue += TotalSkillModifiers[i].Value;
            }

            switch (Rank)
            {
                case 0:
                    finalValue = finalValue - 20;
                    break;
                case 1:
                    finalValue = finalValue - 0;
                    break;
                case 2:
                    finalValue = finalValue + 10;
                    break;
                case 3:
                    finalValue = finalValue + 20;
                    break;
                case 4:
                    finalValue = finalValue + 20;
                    break;

                default:
                    break;
            }
            return finalValue;
        }

        //contstructor 
        public MovementSkills(string name, int rank = 0, string description = "")
        {
            Name = name;
            Rank = rank;
            Description = description;
            TotalSkillModifiers = new List<SkillModifier>() {
            };
        }


        public void AddModifier(SkillModifier mod)
        {
            this.TotalSkillModifiers.Add(mod);
        }
        public void RemoveModifier(SkillModifier mod)
        {
            this.TotalSkillModifiers.Remove(mod);
        }
        public void ModifyRank(bool isLevelUp)
        {
            if (isLevelUp && Rank !=4)
            {
                Rank += 1;
            }
            if(!isLevelUp)
            {
                Rank -= 1;
            }
        }
    }




    public class Acrobatics : MovementSkills
    {
        public Acrobatics(int rank = 0, string description = "") : base(rank, description)
        {
            Rank = rank;
            Description = description;
        }

        public Tuple<string, bool, int> AcrobaticsCheck()
        {
            return CharacteristicChecks.DoCharacteristicCheck(this.ModifiedValue);
        }
    }
}
