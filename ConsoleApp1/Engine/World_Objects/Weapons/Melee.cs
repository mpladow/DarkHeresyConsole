using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.World_Objects
{
    [Serializable]
    public class Melee : Weapon_base
    {
        public bool IsTwoHanded { get; set; }

        public Melee(int id, string name, string description, int penetration, int availability, int weight, int baseDamage, bool isDamaged = false, bool istwohanded=false, string craftsmanship = "") : base(id, name, description, penetration, availability, craftsmanship, weight, baseDamage, isDamaged)
        {
            IsTwoHanded = istwohanded;
        }
    }
}
