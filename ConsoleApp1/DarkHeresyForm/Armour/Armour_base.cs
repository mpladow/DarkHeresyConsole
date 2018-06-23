using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Armour
{
    class Armour_base
    {   
        public int HeadBonus { get; set; }
        public int TorsoBonus { get; set; }
        public int LeftArmBonus { get; set; }
        public int RightArmBonus { get; set; }
        public int LeftLegBonus { get; set; }
        public int RightLegBonus { get; set; }

        public Armour_base(int headBonus, int torsoBonus, int leftArmBonus, int rightArmBonus, int leftLegBonus, int rightLegBonus)
        {
            HeadBonus = headBonus;
            TorsoBonus = torsoBonus;
            LeftArmBonus = leftArmBonus;
            RightArmBonus = rightArmBonus;
            LeftLegBonus = leftLegBonus;
            RightLegBonus = rightLegBonus;
        }
    }
}
