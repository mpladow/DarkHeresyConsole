using Engine.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.World_Objects
{
    public class Weapon_base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Penetration { get; set; }
        public int Availability { get; set; }
        public int Craftsmanship { get; set; }
        public int Weight { get; set; }
        public int BaseDamage { get; set; }
        public bool IsDamaged { get; set; }
        public SpecialAbilities Special { get; set; }

        public Weapon_base(int id, string name, int penetration, int availability, int craftsmanship, int weight, int baseDamage, bool isDamaged, SpecialAbilities special)
        {
            Id = id;
            Name = name;
            Penetration = penetration;
            Availability = availability;
            Craftsmanship = craftsmanship;
            Weight = weight;
            BaseDamage = baseDamage;
            IsDamaged = isDamaged;
            Special = special;
        }


        private int CalculateDamage(int dietoroll = 1)
        {
            Random rn = new Random();
            var roll = DiceRolls.RollD10(dietoroll, rn);
            var x = roll[0];

            var damage = x + BaseDamage;

            return x;
        }
    }


    public abstract class SpecialAbilities
    {
        public int Name { get; set; }
        public int Description { get; set; }

        public void SpecialAbility()
        {

        }
    }
}
