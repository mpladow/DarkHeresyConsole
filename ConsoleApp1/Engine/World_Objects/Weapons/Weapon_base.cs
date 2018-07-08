using Engine.Actions;
using Engine.Utilities;
using Engine.World_Objects.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.World_Objects
{
    [Serializable]
    public class Weapon_base:IWeapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Penetration { get; set; }
        public int Availability { get; set; }
        public string Craftsmanship { get; set; }
        public double Weight { get; set; }
        public int BaseDamage { get; set; }
        public bool IsDamaged { get; set; }


        public Weapon_base(int id, string name, string description, int penetration, int availability, string craftsmanship, double weight, int baseDamage, bool isDamaged)
        {
            Id = id;
            Name = name;
            Description = description;
            Penetration = penetration;
            Availability = availability;
            Craftsmanship = craftsmanship;
            Weight = weight;
            BaseDamage = baseDamage;
            IsDamaged = isDamaged;
        }

        public int CalculateDamage(int dietoroll = 1)
        {
            Cryptorandom rn = new Cryptorandom();
            var roll = DiceRolls.RollD10(dietoroll, rn);
            var x = roll[0];

            var damage = x + BaseDamage;

            return x;
        }

        public void EquipWeapon(Character_base player)
        {
            player.Weapons.Add(this);
        }
        public void UnequipWeapon(Character_base player)
        {
            var weaponInInventory = player.Weapons.FirstOrDefault(x => x.Id == this.Id);
            if (weaponInInventory!=null)
                player.Weapons.Remove(weaponInInventory);
        }

        public void ReadyWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
