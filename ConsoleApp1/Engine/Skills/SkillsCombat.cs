using Engine.Statistics;
using Engine.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Skills
{
    [Serializable]
    public class SkillsCombat : Skill_Base
    {
        public int Rank { get; set; }


        //contstructor 
        public SkillsCombat(int id, string name, string description, CharacterStat stat, double actioncost = 1, int rank = 0, bool isopposedcheck = false) : base(id, name, stat, description, isopposedcheck, actioncost)
        {
            TotalSkillModifiers.Add(World.GetSkillLevelsById(rank));
        }
        //contstructor 
        public SkillsCombat(int id, string name, string description, double actioncost = 1, int rank = 0, bool isopposedcheck = false) : base(id, name, description, isopposedcheck, actioncost)
        {
            TotalSkillModifiers.Add(World.GetSkillLevelsById(rank));
        }

        public bool ModifyRank(bool isLevelUp)
        {
            var result = true;
            if (isLevelUp && Rank != 4)
            {
                var currentSkillLevel = TotalSkillModifiers.Where(x => x.Id == Rank).FirstOrDefault();//finds the current aptidude
                TotalSkillModifiers.Remove(currentSkillLevel);//removes this
                TotalSkillModifiers.Add(World.GetSkillLevelsById(Rank + 1));//Replace with the next level up.
                TotalSkillModifiers.Add(World.SkillLevelsList.FirstOrDefault(x => x.Id == Rank + 1));
                Rank += 1;
                result = true;
            }
            else
            {
                //return a warning? you cannot level up any further
                result = false;
            }
            if (!isLevelUp)
            {
                Rank -= 1;
            }
            return result;
        }


    }
}
