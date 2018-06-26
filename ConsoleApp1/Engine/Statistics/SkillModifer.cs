using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Statistics
{
    public class SkillModifier
    {
        public int Value { get; set; } //this is the public value that is constantly displayed
        public string Description { get; set; }

        public SkillModifier(int value = 0,string description = "" )
        {
            Value = value;
        }

        public static List<SkillModifier> GenerateDifficulties()
        {

            var trivial = new SkillModifier(60, "Trivial");
            var Ordinary = new SkillModifier(10, "Ordinary");
            var Hard = new SkillModifier(-10, "Hard");
            var VeryHard = new SkillModifier(-30, "Very Hard");
            var Punishing = new SkillModifier(-50, "Punishing");

            var list = new List<SkillModifier>
            {
                trivial, Ordinary,
                Hard, VeryHard,Punishing
            };

            return list;
        }

    }

}
