using Engine.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.World_Objects
{
    [Serializable]
    public class BasicRanged:Weapon_base
    {

        public int Range { get; set; }
        public int RateOfFire { get; set; }
        public int ClipCapacity { get; set; }
        public double ReloadRate { get; set; }
        public bool IsJammed { get; set; }

        public BasicRanged(int id, string name, string description, int penetration, int availability, double weight, int baseDamage,  int range, int rateOfFire, int clipCapacity, double reloadRate, bool isDamaged = false, string craftsmanship = "", bool isJammed = false)
            : base( id, name, description, penetration, availability, craftsmanship, weight, baseDamage, isDamaged)
        {
            Range = range;
            RateOfFire = rateOfFire;
            ClipCapacity = clipCapacity;
            ReloadRate = reloadRate;
            IsJammed = isJammed;
        }


        







    }
}
