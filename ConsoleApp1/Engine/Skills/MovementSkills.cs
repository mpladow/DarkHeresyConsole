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
        public int Rank { get; set; }
        public string Description { get; set; }
        public List<SkillModifier> SkillModifiers { get; set; }

        private int _value;
        public int ModValue //this is the public value that is constantly displayed
        {
            get
            {
                _value = CalculateFinalValue();
                return _value;
            }
        }

        private int CalculateFinalValue()
        {
            int finalValue = ModValue;

            for (int i = 0; i < SkillModifiers.Count; i++)
            {
                finalValue += SkillModifiers[i].Value;
            }

            return finalValue;
        }


        public MovementSkills(int rank = 0, string description = "")
        {
            Rank = rank;
            Description = description;
            SkillModifiers = new List<SkillModifier>();

        }
        public void AddModifier(SkillModifier mod)
        {
            this.SkillModifiers.Add(mod);
        }
        public void GainAptitude()
        {
            this.Rank += 1;
            //if rank is 1, then add the trained modifier,
            //if rank is 2, then add .....
            this.SkillModifiers.Add(mod);

        }
    }
    public class Acrobatics : MovementSkills
    {
    }
}
