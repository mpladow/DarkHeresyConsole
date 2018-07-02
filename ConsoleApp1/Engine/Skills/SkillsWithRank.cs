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
    public class SkillsWithRank:Skill_Base
    {
        public int Rank { get; set; }


        //contstructor 
        public SkillsWithRank(int id, string name, string description, CharacterStat stat, double actioncost = 1, int rank = 0, bool isopposedcheck = false) : base(id, name, stat, description, isopposedcheck, actioncost)
        {
            TotalSkillModifiers.Add(ReadOnlyLists.GetSkillLevelsById(rank));
        }
        //contstructor 
        public SkillsWithRank(int id, string name, string description, double actioncost = 1, int rank = 0, bool isopposedcheck = false) : base(id, name, description, isopposedcheck, actioncost)
        {
            TotalSkillModifiers.Add(ReadOnlyLists.GetSkillLevelsById(rank));
        }

        public bool ModifyRank(bool isLevelUp)
        {
            var result = true;
            if(isLevelUp && Rank != 4)
            {
                var currentSkillLevel = TotalSkillModifiers.Where(x => x.Id == Rank).FirstOrDefault();//finds the current aptidude
                TotalSkillModifiers.Remove(currentSkillLevel);//removes this
                TotalSkillModifiers.Add(ReadOnlyLists.GetSkillLevelsById(Rank + 1));//Replace with the next level up.
                TotalSkillModifiers.Add(ReadOnlyLists.SkillLevelsList.FirstOrDefault(x => x.Id == Rank + 1));
                Rank += 1;
                result = true;
            }
            else 
            {
                //return a warning? you cannot level up any further
                result = false;
            }
            if(!isLevelUp)
            {
                Rank -= 1;
            }
            return result;
        }


    }




    //public class Acrobatics : MovementSkills
    //{
    //    public MovementSkills(string name, CharacterStat stat, int rank = 0, string description = ""): base(name, stat, rank, description[p])
    //    {
    //        Name = name;
    //        Rank = rank;
    //        Description = description;
    //        MainStat = stat;
    //        TotalSkillModifiers = new List<SkillModifier>();
    //        TotalSkillModifiers.Add(SkillModifiersLists.GetAptitudesById(rank));
    //    }

    //}
}
