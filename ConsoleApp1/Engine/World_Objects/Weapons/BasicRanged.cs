using Engine.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.World_Objects
{
    public class BasicRanged:Weapon_base
    {

        public int Range { get; set; }
        public int RateOfFire { get; set; }
        public int ClipCapacity { get; set; }
        public int ReloadRate { get; set; }
        public bool IsJammed { get; set; }

        public BasicRanged(int id, string name, int penetration, int availability, int craftsmanship, int weight, int baseDamage, bool isDamaged, SpecialAbilities special, int range, int rateOfFire, int clipCapacity, int reloadRate, bool isJammed)
            : base(id, name, penetration, availability, craftsmanship, weight, baseDamage, isDamaged, special)
        {
            Range = range;
            RateOfFire = rateOfFire;
            ClipCapacity = clipCapacity;
            ReloadRate = reloadRate;
            IsJammed = isJammed;
        }


        







    }
}
