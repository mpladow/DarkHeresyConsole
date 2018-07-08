using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Characters
{
    public class BodyLocation
    {
        public string Name { get; set; }
        public int AP { get; set; }
        public int IsWounded { get; set; }

        public BodyLocation(string name, int aP, int isWounded)
        {
            Name = name;
            AP = aP;
            IsWounded = isWounded;
        }
    }
}
