using Engine.Characters.HomeWorlds;
using Engine.Skills;
using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Engine.Actions.DiceRolls;

namespace Engine
{
    public abstract class Human_Base
    {

        public string Name { get; set; }

        public List<CharacterStat> Stats { get; set; }
        public CharacterStat Ws { get; set; }
        public CharacterStat Bs{ get; set; }
        public CharacterStat Str { get; set; }
        public CharacterStat T { get; set; }
        public CharacterStat Ag { get; set; }
        public CharacterStat Inte { get; set; }
        public CharacterStat Per { get; set; }
        public CharacterStat Wp { get; set; }
        public CharacterStat Fel { get; set; }
        public CharacterStat Ifl { get; set; }

        public int A_Head { get; set; }
        public int A_Body { get; set; }
        public int A_LeftArm { get; set; }
        public int A_RightArm { get; set; }
        public int A_LeftLeg { get; set; }
        public int A_RightLeg { get; set; }

        public List<MovementSkills> MovementSkills { get; set; }
        public HomeWorld HomeWorld { get; set; }
        public int CurrentPosition { get; set; }


        public Human_Base()
        {
            MovementSkills = new List<MovementSkills>();
        }

        public D100Result ConductMovementCheck(string skill)
        {
            //the skill will always be in here, but just in case...
            var skillInList = MovementSkills.Where(x => x.Name == skill).FirstOrDefault();
            if (skillInList!= null)
            {
                return skillInList.ConductCheck();
            }
            else
            {
                throw new Exception();//
            }
        }

        
        //public Human_Base(string name, int ws, int bs, int str, int t, int ag, int inte, int per, int wp, int fel, int ifl)
        //{
        //    Name = name;
        //    Ws = ws;
        //    Bs = bs;
        //    Str = str;
        //    T = t;
        //    Ag = ag;
        //    Inte = inte;
        //    Per = per;
        //    Wp = wp;
        //    Fel = fel;
        //    Ifl = ifl;
        //}

    }
}
