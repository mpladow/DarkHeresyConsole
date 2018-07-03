using Engine.Skills;
using Engine.World_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Characters.CharacterCreation
{
    [Serializable]
    public class Background
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Skill_Base> StartingSkills { get; set; }
        public List<BasicRanged> StartingEquipment {get; set; }//change this to equipment
        //public List<Talents> StartingTalents { get; set; }
        public List<string> StartingAptitudes { get; set; }

        public Background(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            StartingSkills = new List<Skill_Base>();
            StartingAptitudes = new List<string>();
            StartingEquipment = new List<BasicRanged>();
        }
    }
}
