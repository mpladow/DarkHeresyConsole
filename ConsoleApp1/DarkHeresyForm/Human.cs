namespace ConsoleApp1
{
    internal class Human
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Mana { get; set; }
        public int Gold { get; set; }
        public int XP { get; set; }

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