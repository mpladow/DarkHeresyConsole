using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.World_Objects
{
    public class Melee : Weapon_base
    {
        public bool IsTwoHanded { get; set; }

        public Melee(int id, string name, int penetration, int availability, int craftsmanship, int weight, int baseDamage, bool isDamaged, SpecialAbilities special, bool istwohanded) : base(id, name, penetration, availability, craftsmanship, weight, baseDamage, isDamaged, special)
        {
            IsTwoHanded = istwohanded;
        }
    }
}
