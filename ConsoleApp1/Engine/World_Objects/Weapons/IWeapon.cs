using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.World_Objects.Weapons
{
    interface IWeapon
    {
        int CalculateDamage(int dicetoroll);

        void EquipWeapon(Character_base character);


        void ReadyWeapon();


    }
}
