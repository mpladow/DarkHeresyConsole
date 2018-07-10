using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Characters
{
    [Serializable]
    public class BodyLocation
    {
        public string Name { get; set; }
        public int AP { get; set; }
        public bool IsWounded { get; set; }

        public BodyLocation(string name, int aP = 0, bool isWounded = false)
        {
            Name = name;
            AP = aP;
            IsWounded = isWounded;
        }
    }
}
