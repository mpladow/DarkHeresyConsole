using System.Collections.Generic;

namespace Engine
{
    internal class Human
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Mana { get; set; }
        public int Gold { get; set; }
        public int XP { get; set; }

        public List<Skills> Skills{ get; set; }

        public Human(string name, int hp, int mana, int gold, int xp)
        {
            Name = name;
            HP = hp;
            Mana = mana;
            Gold = gold;
            XP = xp;
        }
    }

}