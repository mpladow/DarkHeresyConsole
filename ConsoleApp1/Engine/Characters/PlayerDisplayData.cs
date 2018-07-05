using Engine.Characters.CharacterCreation;
using Engine.Characters.HomeWorlds;
using Engine.Interfaces;
using Engine.Skills;
using Engine.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Characters
{
    public class PlayerDisplayData : IObervable
    {
        public string Name { get; set; }
        public List<CharacterStat> Stats { get; set; }
        public int Wounds { get; set; }
        public int A_Head { get; set; }
        public int A_Body { get; set; }
        public int A_LeftArm { get; set; }
        public int A_RightArm { get; set; }
        public int A_LeftLeg { get; set; }
        public int A_RightLeg { get; set; }

        public List<string> Aptitudes { get; set; }

        public HomeWorld HomeWorld { get; set; }
        public Background Background { get; set; }
        public int CurrentPosition { get; set; }

        public int XP { get; set; }


        public void addObserver()
        {
            throw new NotImplementedException();
        }

        public void deleteObserver()
        {
            throw new NotImplementedException();
        }

        public void notifyObservers()
        {
            throw new NotImplementedException();
        }

        public void setChanged()
        {
            throw new NotImplementedException();
        }
        public List<CharacterStat> getCharacterStats()
        {
            return Stats;
        }
        public void setStats(Player player)
        {
            foreach (var item in player.Stats)
            {
                if(!Stats.Exists(x=> x.Name == item.Name))
            }
        }
    }
}
