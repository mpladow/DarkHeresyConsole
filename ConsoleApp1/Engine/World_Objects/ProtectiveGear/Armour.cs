using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.World_Objects.ProtectiveGear
{
    public class Armour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ArmourLocations { get; set; }
        public int AP { get; set; }
        public int MaxAg { get; set; }
        public double Weight { get; set; }
        public string Availabity { get; set; }

        public Armour(int id, string name, string description, List<string> armourlocations, int ap, int maxAg, double weight, string availabity)
        {
            Id = id;
            Name = name;
            Description = description;
            ArmourLocations = armourlocations;
            AP = ap;
            MaxAg = maxAg;
            Weight = weight;
            Availabity = availabity;
        }

        public void EquipArmour(Character_base character)
        {

        }
        public void RemoveArmour(Character_base character)
        {

        }
    }
}
