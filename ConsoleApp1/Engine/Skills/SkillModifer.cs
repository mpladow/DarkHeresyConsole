using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Statistics
{
    [Serializable]
    public class SkillModifier
    {
        public int Id { get; set; }
        public int Value { get; set; } //this is the public value that is constantly displayed
        public string Description { get; set; }

        public SkillModifier(int id, int value = 0, string description = "")
        {
            Id = id;
            Value = value;
            Description = description;
        }

    }

}
