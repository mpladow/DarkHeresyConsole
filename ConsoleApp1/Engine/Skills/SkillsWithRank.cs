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
    public class SkillsWithRank:Skill_Base
    {
        public int Rank { get; set; }


        //contstructor 
        public SkillsWithRank(int id, string name, string description, CharacterStat stat, double actioncost = 1, int rank = 0, bool isopposedcheck = false) : base(id, name, stat, description, isopposedcheck, actioncost)
        {
            TotalSkillModifiers.Add(World.GetSkillLevelsById(rank));
        }
        //contstructor 
        public SkillsWithRank(int id, string name, string description, double actioncost = 1, int rank = 0, bool isopposedcheck = false) : base(id, name, description, isopposedcheck, actioncost)
        {
            TotalSkillModifiers.Add(World.GetSkillLevelsById(rank));
        }

        public bool ModifyRank(bool isLevelUp)
        {
            var result = true;
            if(isLevelUp && Rank != 4)
            {
                var currentSkillLevel = TotalSkillModifiers.Where(x => x.Id == Rank).FirstOrDefault();//finds the current aptidude
                TotalSkillModifiers.Remove(currentSkillLevel);//removes this
                Rank += 1;
                TotalSkillModifiers.Add(World.GetSkillLevelsById(Rank));//Replace with the next level up.
                //TotalSkillModifiers.Add(World.SkillLevelsList.FirstOrDefault(x => x.Id == Rank));
                result = true;
            }
            else 
            {
                //return a warning? you cannot level up any further
                result = false;
            }
            if(!isLevelUp && Rank != 0)
            {
                var currentSkillLevel = TotalSkillModifiers.Where(x => x.Id == Rank).FirstOrDefault();//finds the current aptidude
                TotalSkillModifiers.Remove(currentSkillLevel);//removes this
                Rank -= 1;
                TotalSkillModifiers.Add(World.GetSkillLevelsById(Rank));//Replace with the next level up.
                //TotalSkillModifiers.Add(World.SkillLevelsList.FirstOrDefault(x => x.Id == Rank));
                result = true;
            }
            return result;
        }
        public void SetRankToZero()
        {
            Rank = 0;
            foreach (var mod in TotalSkillModifiers.ToList())
            {
                if(mod.ModType == "Rank" && mod.Id!=0)
                {
                    TotalSkillModifiers.Remove(mod);
                }
            }
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
